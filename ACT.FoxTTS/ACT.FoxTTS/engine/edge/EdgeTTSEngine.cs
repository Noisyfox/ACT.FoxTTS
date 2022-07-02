using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security;
using System.Threading;
using ACT.FoxCommon.core;
using ACT.FoxCommon.logging;
using ACT.FoxTTS.engine.azure;

namespace ACT.FoxTTS.engine.edge
{
    class EdgeTTSEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly EdgeTTSSettingsControl _settingsControl = new EdgeTTSSettingsControl();
        private readonly EdgeWSKeepAliveWorker _keepAlive = new EdgeWSKeepAliveWorker();

        private const string URL =
            "wss://speech.platform.bing.com/consumer/speech/synthesize/readaloud/edge/v1?TrustedClientToken=6A5AA1D4EAFF4E9FB37E23D68491D6F4";

        /// <summary>
        /// Obtained from:
        /// https://speech.platform.bing.com/consumer/speech/synthesize/readaloud/voices/list?trustedclienttoken=6A5AA1D4EAFF4E9FB37E23D68491D6F4
        /// </summary>
        public static readonly Voice[] Voices = new[]
        {
            new Voice("zh-CN-XiaoxiaoNeural", "中文-普通话-女 晓晓"),
            new Voice("zh-CN-XiaoyiNeural", "中文-普通话-女 晓依"),
            new Voice("zh-CN-YunjianNeural", "中文-普通话-男 云健"),
            new Voice("zh-CN-YunyangNeural", "中文-普通话-新闻-男 云扬"),
            new Voice("zh-CN-YunxiaNeural", "中文-普通话-儿童-男 云霞"),
            new Voice("zh-CN-YunxiNeural", "中文-普通话-男 云希"),
            
            new Voice("zh-HK-HiuMaanNeural", "中文-粤语-女 曉佳"),

            new Voice("zh-TW-HsiaoChenNeural", "中文-台普-女 曉臻"),

            new Voice("ja-JP-NanamiNeural", "日语-女 七海"),

            new Voice("en-US-AriaNeural", "英语-美国-女 阿莉雅"),
            new Voice("en-US-JennyNeural", "英语-美国-女 珍妮"),
            new Voice("en-US-GuyNeural", "英语-美国-男 盖"),

            new Voice("en-GB-SoniaNeural", "英语-英国-女 索尼娅"),
        };

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
            _settingsControl.AttachToAct(plugin);
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
            _settingsControl.PostAttachToAct(plugin);

            _settingsControl.DoLocalization();

            _keepAlive.StartWorkingThread(this);
        }

        public string Name => "EdgeTTS";

        public void Stop()
        {
            _wsCancellationSource.Cancel();
            _keepAlive.StopWorkingThread();
            lock (this)
            {
                _webSocket?.Abort();
                _webSocket?.Dispose();
                _webSocket = null;
            }
            _settingsControl.RemoveFromAct();
        }

        public void Speak(string text)
        {
            var settings = _plugin.Settings.EdgeTtsSettings;
            if (!settings.Accept)
            {
                return;
            }

            // Xml escape
            text = SecurityElement.Escape(text);

            var wave = _plugin.Cache.GetOrCreateFile(
                this,
                text,
                "mp3",
                settings.ToString(),
                f =>
                {
                    byte[] result = null;
                    var retry = 0;
                    while(true)
                    {
                        try
                        {
                            result = Synthesis(settings, text);
                            break;
                        }
                        catch (Exception e)
                        {
                            Exception se = e;
                            while (se != null)
                            {
                                if (se is SocketException)
                                {
                                    break;
                                }

                                se = se.InnerException;
                            }

                            if (se != null && ((SocketException)se).SocketErrorCode == SocketError.ConnectionReset)
                            {
                                Logger.Error("连接被服务器中止");
                            }
                            else
                            {
                                Logger.Error("服务器连接失败", e);
                            }

                            retry++;
                            if (retry > 3)
                            {
                                Logger.Error("失败太多次，放弃重试", e);
                                break;
                            }
                            else
                            {
                                Logger.Error($"语音合成失败，开始第 {retry} 次重试");
                            }
                        }
                    }

                    if (result != null)
                    {
                        File.WriteAllBytes(f, result);
                    }
                });

            _plugin.SoundPlayer.Play(wave);
        }
        

        private byte[] Synthesis(EdgeTTSSettings settings, string text)
        {
            var ws = ObtainConnection();

            if (ws == null)
            {
                // Cancelled
                return null;
            }

            return AzureWSSynthesiser.Synthesis(ws, _wsCancellationSource,
                text, settings.Speed, settings.Pitch, settings.Volume, settings.Voice);
        }

        private enum ProtocolState
        {
            NotStarted,
            TurnStarted, // turn.start received
            Streaming, // audio binary started
        }

        private readonly CancellationTokenSource _wsCancellationSource = new CancellationTokenSource();
        private WebSocket _webSocket;

        private WebSocket ObtainConnection()
        {
            lock (this)
            {
                if (_wsCancellationSource.IsCancellationRequested)
                {
                    return null;
                }

                if (_webSocket == null)
                {
                    _webSocket = SystemClientWebSocket.CreateClientWebSocket();
                }

                switch (_webSocket.State)
                {
                    case WebSocketState.None:
                        break;
                    case WebSocketState.Connecting:
                    case WebSocketState.Open:
                        // All good
                        return _webSocket;
                    case WebSocketState.CloseSent:
                    case WebSocketState.CloseReceived:
                    case WebSocketState.Closed:
                        _webSocket.Abort();
                        _webSocket.Dispose();
                        _webSocket = SystemClientWebSocket.CreateClientWebSocket();
                        break;
                    case WebSocketState.Aborted:
                        _webSocket.Dispose();
                        _webSocket = SystemClientWebSocket.CreateClientWebSocket();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Debug.Assert(_webSocket.State == WebSocketState.None);
                // Connect
                Logger.Debug("（重新）连接 EdgeTTS 服务器中...");
                if (_webSocket is ClientWebSocket ws)
                {
                    var options = ws.Options;
                    options.SetRequestHeader("Accept-Encoding", "gzip, deflate, br");
                    options.SetRequestHeader("Cache-Control", "no-cache");
                    options.SetRequestHeader("Pragma", "no-cache");
                }
                else
                {
                    var options = ((System.Net.WebSockets.Managed.ClientWebSocket)_webSocket).Options;
                    options.SetRequestHeader("Accept-Encoding", "gzip, deflate, br");
                    options.SetRequestHeader("Cache-Control", "no-cache");
                    options.SetRequestHeader("Pragma", "no-cache");
                }
                _webSocket.ConnectAsync(new Uri(URL), _wsCancellationSource.Token).Wait();
                return _webSocket;
            }
        }

        private class EdgeWSKeepAliveWorker : BaseThreading<EdgeTTSEngine>
        {
            protected override void DoWork(EdgeTTSEngine context)
            {
                while (!WorkingThreadStopping)
                {
                    try
                    {
                        context.ObtainConnection();
                    }
                    catch (Exception e)
                    {
                        Logger.Error("Unable to establish connection", e);
                    }
                    SafeSleep(5000);
                }
            }
        }
    }
}
