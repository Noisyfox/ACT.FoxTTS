using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            //new Voice("zh-CN-XiaochenNeural", "中文-普通话-女 晓辰"),
            //new Voice("zh-CN-XiaoqiuNeural", "中文-普通话-女 晓秋"),
            //new Voice("zh-CN-XiaoshuangNeural", "中文-普通话-儿童-女 晓双"),
            //new Voice("zh-CN-XiaoyanNeural", "中文-普通话-女 晓颜"),
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
            lock (this)
            {
                _webSocket?.Abort();
                _webSocket?.Dispose();
                _webSocket = null;
            }
            _keepAlive.StopWorkingThread();
            _settingsControl.RemoveFromAct();
        }

        public void Speak(string text, dynamic playDevice, bool isSync, float? volume)
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
                    var result = Synthesis(settings, text);
                    if (result != null)
                    {
                        File.WriteAllBytes(f, result);
                    }
                });

            _plugin.SoundPlayer.Play(wave, playDevice, isSync, volume);
        }

        private void SendText(WebSocket ws, string msg)
        {
            Logger.Debug($"Sending request\n{msg}");
            ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg)),
                WebSocketMessageType.Text, true,
                _wsCancellationSource.Token).Wait();
        }

        private byte[] Synthesis(EdgeTTSSettings settings, string text)
        {
            var ws = ObtainConnection();

            if (ws == null)
            {
                return null;
            }

            lock (ws)
            {
                // Send request
                var requestId = Guid.NewGuid().ToString().Replace("-", "");
                var timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffK");
                SendText(ws,
                    "Path:speech.config\r\n" +
                    $"X-RequestId:{requestId}\r\n" +
                    $"X-Timestamp:{timestamp}\r\n" +
                    "Content-Type:application/json\r\n" +
                    "\r\n" +
                    "{\"context\":{\"synthesis\":{\"audio\":{\"metadataoptions\":{\"sentenceBoundaryEnabled\":\"false\",\"wordBoundaryEnabled\":\"false\"},\"outputFormat\":\"audio-24khz-48kbitrate-mono-mp3\"}}}}\r\n"
                );
                SendText(ws,
                    "Path:ssml\r\n" +
                    $"X-RequestId:{requestId}\r\n" +
                    $"X-Timestamp:{timestamp}\r\n" +
                    "Content-Type:application/ssml+xml\r\n" +
                    "\r\n" +
                    "<speak xmlns=\"http://www.w3.org/2001/10/synthesis\" xmlns:mstts=\"http://www.w3.org/2001/mstts\" xmlns:emo=\"http://www.w3.org/2009/10/emotionml\" version=\"1.0\" xml:lang=\"en-US\">" +
                    $"<voice name=\"{settings.Voice}\">" +
                    $"<prosody rate=\"{settings.Speed - 100}%\" pitch=\"{(settings.Pitch - 100) / 2}%\" volume=\"{settings.Volume.Clamp(1, 100)}\">" +
                    text +
                    "</prosody></voice></speak>\r\n"
                );

                // Start receiving
                var buffer = new MemoryStream();
                var session = new WSSession(ws);
                var state = ProtocolState.NotStarted;
                while (true)
                {
                    var message = ReceiveNextMessage(session);
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
                        Logger.Error("Unexpected closing of connection");
                        return null;
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

        private class WSMessage
        {

            public static readonly WSMessage Close = new WSMessage();

            public readonly WebSocketMessageType Type;

            public readonly string MessageStr;

            public readonly byte[] MessageBinary;

            public WSMessage(string message)
            {
                Type = WebSocketMessageType.Text;
                MessageStr = message;
                MessageBinary = null;
            }

            public WSMessage(byte[] message)
            {
                Type = WebSocketMessageType.Binary;
                MessageStr = null;
                MessageBinary = message;
            }

            private WSMessage()
            {
                Type = WebSocketMessageType.Close;
                MessageStr = null;
                MessageBinary = null;
            }

            public override string ToString()
            {
                return $"{nameof(Type)}: {Type}, {nameof(MessageStr)}: {MessageStr}, {nameof(MessageBinary)}: byte[{MessageBinary?.Length ?? -1}]";
            }
        }

        private class WSSession
        {
            public readonly WebSocket ws;
            public readonly StringBuilder sb = new StringBuilder();
            public readonly MemoryStream buffer = new MemoryStream();
            public readonly byte[] array = new byte[5 * 1024];

            public WSSession(WebSocket ws)
            {
                this.ws = ws;
            }
        }

        private WSMessage ReceiveNextMessage(WSSession session)
        {
            var ws = session.ws;
            var sb = session.sb;
            var buffer = session.buffer;
            var array = session.array;

            sb.Clear();
            buffer.Position = 0;
            buffer.SetLength(0);

            WebSocketMessageType? previousMessageType = null;

            while (true)
            {
                var result = ws.ReceiveAsync(new ArraySegment<byte>(array), _wsCancellationSource.Token).Result;
                switch (result.MessageType)
                {
                    case WebSocketMessageType.Text:
                        if (previousMessageType != null && previousMessageType != WebSocketMessageType.Text)
                        {
                            throw new IOException("Unexpected WebSocketMessageType");
                        }

                        if (result.Count > 0)
                        {
                            sb.Append(Encoding.UTF8.GetString(array, 0, result.Count));
                        }
                        break;
                    case WebSocketMessageType.Binary:
                        if (previousMessageType != null && previousMessageType != WebSocketMessageType.Binary)
                        {
                            throw new IOException("Unexpected WebSocketMessageType");
                        }

                        if (result.Count > 0)
                        {
                            buffer.Write(array, 0, result.Count);
                        }
                        break;
                    case WebSocketMessageType.Close:
                        Debug.Assert(sb.Length == 0);
                        Debug.Assert(buffer.Length == 0);
                        return WSMessage.Close;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                previousMessageType = result.MessageType;

                if (result.EndOfMessage)
                {
                    if (previousMessageType == WebSocketMessageType.Text)
                    {
                        return new WSMessage(sb.ToString());
                    }
                    else
                    {
                        return new WSMessage(buffer.ToArray());
                    }
                }
            }
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
