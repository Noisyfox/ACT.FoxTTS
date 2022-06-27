using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security;
using System.Text;
using System.Threading;
using ACT.FoxCommon;
using ACT.FoxCommon.core;
using ACT.FoxCommon.logging;

namespace ACT.FoxTTS.engine.edge
{
    class EdgeTTSEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly EdgeTTSSettingsControl _settingsControl = new EdgeTTSSettingsControl();
        private readonly EdgeWSKeepAliveWorker _keepAlive = new EdgeWSKeepAliveWorker();

        private const string URL =
            "wss://speech.platform.bing.com/consumer/speech/synthesize/readaloud/edge/v1?TrustedClientToken=6A5AA1D4EAFF4E9FB37E23D68491D6F4";

        public static readonly Voice[] Voices = new[]
        {
            new Voice("zh-CN-XiaoxiaoNeural", "中文-普通话-女 晓晓"),
            new Voice("zh-CN-XiaoyouNeural", "中文-普通话-儿童-女 晓悠"),
            new Voice("zh-CN-XiaomoNeural", "中文-普通话-女 晓墨"),
            new Voice("zh-CN-XiaoxuanNeural", "中文-普通话-女 晓萱"),
            new Voice("zh-CN-XiaohanNeural", "中文-普通话-女 晓涵"),
            new Voice("zh-CN-XiaoruiNeural", "中文-普通话-女 晓睿"),
            new Voice("zh-CN-XiaochenNeural", "中文-普通话-女 晓辰"),
            new Voice("zh-CN-XiaoqiuNeural", "中文-普通话-女 晓秋"),
            new Voice("zh-CN-XiaoshuangNeural", "中文-普通话-儿童-女 晓双"),
            new Voice("zh-CN-XiaoyanNeural", "中文-普通话-女 晓颜"),
            new Voice("zh-CN-YunyangNeural", "中文-普通话-新闻-男 云扬"),
            new Voice("zh-CN-YunyeNeural", "中文-普通话-故事-男 云野"),
            new Voice("zh-CN-YunxiNeural", "中文-普通话-男 云希"),
            new Voice("zh-HK-HiuGaaiNeural", "中文-粤语-女 曉曼"),
            new Voice("zh-HK-HiuMaanNeural", "中文-粤语-女 曉佳"),
            new Voice("zh-HK-WanLungNeural", "中文-粤语-男 雲龍"),
            new Voice("zh-TW-HsiaoChenNeural", "中文-台普-女 曉臻"),
            new Voice("zh-TW-HsiaoYuNeural", "中文-台普-女 曉雨"),
            new Voice("zh-TW-YunJheNeural", "中文-台普-男 雲哲"),
            new Voice("ja-JP-NanamiNeural", "日语-女 七海"),
            new Voice("ja-JP-KeitaNeural", "日语-男 圭太"),
            new Voice("en-US-AriaNeural", "英语-美国-女 阿莉雅"),
            new Voice("en-US-JennyNeural", "英语-美国-女 珍妮"),
            new Voice("en-US-GuyNeural", "英语-美国-男 盖"),
            new Voice("en-US-AmberNeural", "英语-美国-女 安柏"),
            new Voice("en-US-AshleyNeura", "英语-美国-女 艾什莉"),
            new Voice("en-US-CoraNeural", "英语-美国-女 科拉"),
            new Voice("en-US-ElizabethNeural", "英语-美国-女 伊丽莎白"),
            new Voice("en-US-MichelleNeural", "英语-美国-女 米歇尔"),
            new Voice("en-US-MonicaNeural", "英语-美国-女 莫妮卡"),
            new Voice("en-US-AnaNeural", "英语-美国-儿童-女 安娜"),
            new Voice("en-US-BrandonNeural", "英语-美国-男 布兰登"),
            new Voice("en-US-ChristopherNeural", "英语-美国-男 克里斯多弗"),
            new Voice("en-US-JacobNeural", "英语-美国-男 雅各布"),
            new Voice("en-US-EricNeural", "英语-美国-男 埃里克"),
            new Voice("en-GB-LibbyNeural", "英语-英国-女 利比"),
            new Voice("en-GB-MiaNeural", "英语-英国-女 米亚"),
            new Voice("en-GB-RyanNeural", "英语-英国-男 瑞恩"),
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

            lock (ws)
            {
                // Send request
                var requestId = Guid.NewGuid().ToString().Replace("-", "");
                var timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffK");
                try
                {
                    ws.SendText(
                        "Path:speech.config\r\n" +
                        $"X-RequestId:{requestId}\r\n" +
                        $"X-Timestamp:{timestamp}\r\n" +
                        "Content-Type:application/json\r\n" +
                        "\r\n" +
                        "{\"context\":{\"synthesis\":{\"audio\":{\"metadataoptions\":{\"sentenceBoundaryEnabled\":\"false\",\"wordBoundaryEnabled\":\"false\"},\"outputFormat\":\"audio-16khz-32kbitrate-mono-mp3\"}}}}\r\n",
                        _wsCancellationSource
                    );
                    ws.SendText(
                        "Path:ssml\r\n" +
                        $"X-RequestId:{requestId}\r\n" +
                        $"X-Timestamp:{timestamp}\r\n" +
                        "Content-Type:application/ssml+xml\r\n" +
                        "\r\n" +
                        "<speak xmlns=\"http://www.w3.org/2001/10/synthesis\" xmlns:mstts=\"http://www.w3.org/2001/mstts\" xmlns:emo=\"http://www.w3.org/2009/10/emotionml\" version=\"1.0\" xml:lang=\"en-US\">" +
                        $"<voice name=\"{settings.Voice}\">" +
                        $"<prosody rate=\"{settings.Speed - 100}%\" pitch=\"{(settings.Pitch - 100) / 2}%\" volume=\"{settings.Volume.Clamp(1, 100)}\">" +
                        text +
                        "</prosody></voice></speak>\r\n",
                        _wsCancellationSource
                    );
                }
                catch (Exception)
                {
                    ws.Abort();
                    ws.Dispose();
                    throw;
                }

                // Start receiving
                var buffer = new MemoryStream();
                var session = new WebSocketHelper.Session(ws);
                var state = ProtocolState.NotStarted;
                while (true)
                {
                    var message = WebSocketHelper.ReceiveNextMessage(session, _wsCancellationSource);
                    Logger.Debug($"Received WS message\n{message}");
                    if (message.Type == WebSocketMessageType.Text)
                    {
                        if (message.MessageStr.Contains(requestId))
                        {
                            switch (state)
                            {
                                case ProtocolState.NotStarted:
                                    if (message.MessageStr.Contains("Path:turn.start"))
                                    {
                                        state = ProtocolState.TurnStarted;
                                    }
                                    break;
                                case ProtocolState.TurnStarted:
                                    if (message.MessageStr.Contains("Path:turn.end"))
                                    {
                                        throw new IOException("Unexpected turn.end");
                                    }
                                    else if (message.MessageStr.Contains("Path:turn.start"))
                                    {
                                        throw new IOException("Turn already started");
                                    }
                                    break;
                                case ProtocolState.Streaming:
                                    if (message.MessageStr.Contains("Path:turn.end"))
                                    {
                                        // All done
                                        return buffer.ToArray();
                                    }
                                    else
                                    {
                                        throw new IOException($"Unexpected message during streaming: {message.MessageStr}");
                                    }
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                        else
                        {
                            if (state != ProtocolState.NotStarted)
                            {
                                throw new IOException("Unexpected request id during streaming");
                            }
                            else
                            {
                                // Ignore
                            }
                        }
                    }
                    else if (message.Type == WebSocketMessageType.Binary)
                    {
                        switch (state)
                        {
                            case ProtocolState.NotStarted:
                                // Do nothing
                                break;
                            case ProtocolState.TurnStarted:
                            case ProtocolState.Streaming:
                                // Parsing message
                                // The first 2 bytes are the header length
                                if (message.MessageBinary.Length < 2)
                                {
                                    throw new IOException("Message too short");
                                }
                                var headerLen = (message.MessageBinary[0] << 8) + message.MessageBinary[1];
                                if (message.MessageBinary.Length < 2 + headerLen)
                                {
                                    throw new IOException("Message too short");
                                }
                                var header = Encoding.UTF8.GetString(message.MessageBinary, 2, headerLen);
                                if (header.EndsWith("Path:audio\r\n"))
                                {
                                    if (!header.Contains(requestId))
                                    {
                                        throw new IOException("Unexpected request id during streaming");
                                    }
                                    state = ProtocolState.Streaming;

                                    buffer.Write(message.MessageBinary, 2 + headerLen, message.MessageBinary.Length - 2 - headerLen);
                                }
                                else
                                {
                                    Logger.Warn($"Unexpected message with header {header}");
                                }
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    else if (message.Type == WebSocketMessageType.Close)
                    {
                        throw new IOException("Unexpected closing of connection");
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }
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
