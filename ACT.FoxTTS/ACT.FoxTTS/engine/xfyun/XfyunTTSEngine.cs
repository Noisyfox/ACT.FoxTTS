using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using ACT.FoxCommon.logging;
using ACT.FoxTTS.localization;
using Newtonsoft.Json;

namespace ACT.FoxTTS.engine.xfyun
{
    class XfyunTTSEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly XfyunTTSSettingsControl _settingsControl = new XfyunTTSSettingsControl();

        public static readonly Voice[] Voices = new[]
        {
            new Voice("xiaoyan", "中文-普通话-甜美女声 小燕"),
            new Voice("aisjiuxu", "中文-普通话-亲切男声 许久"),
            new Voice("aisxping", "中文-普通话-知性女声 小萍"),
            new Voice("aisjinger", "中文-普通话-亲切女声 小婧"),
            new Voice("aisbabyxu", "中文-普通话-可爱童声 许小宝"),
            // TODO：特色发音人
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
        }

        public string Name => "XfyunTTS";

        public void Stop()
        {
            lock (this)
            {
                _authContext?.Dispose();
                _authContext = null;
            }
            _settingsControl.RemoveFromAct();
        }

        public void Speak(string text, dynamic playDevice, bool isSync, float? volume)
        {
            var settings = _plugin.Settings.XfyunTtsSettings;

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

        private byte[] Synthesis(XfyunTTSSettings settings, string text)
        {
            CurrentAuthContext ctx;
            lock (this)
            {
                var apiSecret = settings.ApiSecret;
                var apiKey = settings.ApiKey;
                if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret) || string.IsNullOrEmpty(settings.AppId))
                {
                    _authContext?.Dispose();
                    _authContext = null;
                    Logger.Error(strings.msgErrorEmptyApiSecretKey);
                    _settingsControl.NotifyEmptyApiKey();
                    return null;
                }

                if (_authContext == null)
                {
                    _authContext = new CurrentAuthContext(apiKey, apiSecret);
                }
                else if (_authContext.ApiKey != apiKey || _authContext.ApiSecret != apiSecret)
                {
                    _authContext.Dispose();
                    _authContext = new CurrentAuthContext(apiKey, apiSecret);
                }

                ctx = _authContext;
            }

            return ctx.Synthesis(settings, text);
        }

        private CurrentAuthContext _authContext;

        private class CurrentAuthContext: IDisposable
        {
            public readonly CancellationTokenSource CancellationSource = new CancellationTokenSource();
            public WebSocket WebSocket;
            public readonly string ApiKey;
            public readonly string ApiSecret;

            public CurrentAuthContext(string apiKey, string apiSecret)
            {
                ApiKey = apiKey;
                ApiSecret = apiSecret;
            }

            class TTSRequest
            {

                public class CommonParam
                {
                    [JsonProperty("app_id")] public string AppId { get; set; }
                }

                public class BusinessParam
                {
                    [JsonProperty("aue")] public string AudioEncoding { get; set; } = "lame";
                    [JsonProperty("sfl")] public int Streaming { get; set; } = 1;
                    [JsonProperty("vcn")] public string Voice { get; set; }
                    [JsonProperty("pitch")] public int Pitch { get; set; } = 50;
                    [JsonProperty("speed")] public int Speed { get; set; } = 50;
                    [JsonProperty("volume")] public int Volume { get; set; } = 50;
                    [JsonProperty("tte")] public string TextEncoding { get; set; } = "UTF8";
                    [JsonProperty("reg")] public string EnglishPronounce { get; set; } = "2";
                    [JsonProperty("rdn")] public string NumberPronounce { get; set; } = "0";
                }

                public class DataParam
                {
                    [JsonProperty("status")] public int Status { get; set; } = 2;
                    [JsonProperty("text")] public string Text { get; set; }
                }

                [JsonProperty("common")] public CommonParam Common { get; set; }
                [JsonProperty("business")] public BusinessParam Business { get; set; }
                [JsonProperty("data")] public DataParam Data { get; set; }
            }

            class TTSResponse
            {
                public class DataParam
                {
                    [JsonProperty("audio")] public string Audio { get; set; }
                    [JsonProperty("ced")] public string Progress { get; set; }
                    [JsonProperty("status")] public int Status { get; set; }
                }

                [JsonProperty("code")] public int Code { get; set; }
                [JsonProperty("message")] public string Message { get; set; }
                [JsonProperty("sid")] public string SessionId { get; set; }
                [JsonProperty("data")] public DataParam Data { get; set; }
            }

            public byte[] Synthesis(XfyunTTSSettings settings, string text)
            {
                var base64Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
                if (base64Text.Length > 8000)
                {
                    Logger.Error("Convert string too long. No more than 2000 chinese characters.");
                    return null;
                }

                var ws = ObtainConnection();

                if (ws == null)
                {
                    // Cancelled
                    return null;
                }

                lock (ws)
                {
                    // Send request
                    try
                    {
                        var request = new TTSRequest
                        {
                            Common = new TTSRequest.CommonParam
                            {
                                AppId = settings.AppId,
                            },
                            Business = new TTSRequest.BusinessParam
                            {
                                Voice = settings.Voice,
                                Pitch = settings.Pitch * 10,
                                Speed = settings.Speed * 10,
                                Volume = settings.Volume * 10,
                            },
                            Data = new TTSRequest.DataParam
                            {
                                Status = 2,
                                Text = base64Text,
                            }
                        };
                        ws.SendText(
                            JsonConvert.SerializeObject(request),
                            CancellationSource
                        );

                        // Start receiving
                        var buffer = new MemoryStream();
                        var session = new WebSocketHelper.Session(ws);
                        while (true)
                        {
                            var message = WebSocketHelper.ReceiveNextMessage(session, CancellationSource);
                            Logger.Debug($"Received WS message\n{message}");
                            if (message.Type == WebSocketMessageType.Text)
                            {
                                var resp = JsonConvert.DeserializeObject<TTSResponse>(message.MessageStr);
                                switch (resp.Code)
                                {
                                    case 0:
                                        // Success!
                                        if (resp.Data != null)
                                        {
                                            var data = Convert.FromBase64String(resp.Data.Audio);
                                            buffer.Write(data, 0, data.Length);

                                            if (resp.Data.Status == 2)
                                            {
                                                // Complete!
                                                return buffer.ToArray();
                                            }
                                        }
                                        break;
                                    default:
                                        Logger.Error($"Unexpected response code received: {resp.Code}: {resp.Message}");
                                        break;
                                }
                            }
                            else if (message.Type == WebSocketMessageType.Binary)
                            {
                                throw new IOException("Unexpected binary message received");
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
                    catch (Exception)
                    {
                        ws.Abort();
                        ws.Dispose();
                        throw;
                    }
                }
            }

            public void Dispose()
            {
                CancellationSource.Cancel();
                lock (this)
                {
                    WebSocket?.Abort();
                    WebSocket?.Dispose();
                    WebSocket = null;
                }
            }

            private WebSocket ObtainConnection()
            {
                lock (this)
                {
                    if (CancellationSource.IsCancellationRequested)
                    {
                        return null;
                    }

                    if (WebSocket == null)
                    {
                        WebSocket = SystemClientWebSocket.CreateClientWebSocket();
                    }

                    switch (WebSocket.State)
                    {
                        case WebSocketState.None:
                            break;
                        case WebSocketState.Connecting:
                        case WebSocketState.Open:
                            // All good
                            return WebSocket;
                        case WebSocketState.CloseSent:
                        case WebSocketState.CloseReceived:
                        case WebSocketState.Closed:
                            WebSocket.Abort();
                            WebSocket.Dispose();
                            WebSocket = SystemClientWebSocket.CreateClientWebSocket();
                            break;
                        case WebSocketState.Aborted:
                            WebSocket.Dispose();
                            WebSocket = SystemClientWebSocket.CreateClientWebSocket();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    Debug.Assert(WebSocket.State == WebSocketState.None);
                    // Connect
                    Logger.Debug("（重新）连接讯飞语音服务器中...");
                    // if (_webSocket is ClientWebSocket ws)
                    // {
                    //     var options = ws.Options;
                    //     options.SetRequestHeader("Accept-Encoding", "gzip, deflate, br");
                    //     options.SetRequestHeader("Cache-Control", "no-cache");
                    //     options.SetRequestHeader("Pragma", "no-cache");
                    // }
                    // else
                    // {
                    //     var options = ((System.Net.WebSockets.Managed.ClientWebSocket)_webSocket).Options;
                    //     options.SetRequestHeader("Accept-Encoding", "gzip, deflate, br");
                    //     options.SetRequestHeader("Cache-Control", "no-cache");
                    //     options.SetRequestHeader("Pragma", "no-cache");
                    // }
                    var date = DateTime.UtcNow.ToString("R");
                    var sign = $"host: tts-api.xfyun.cn\ndate: {date}\nGET /v2/tts HTTP/1.1";
                    string sha;
                    using (var hash = new HMACSHA256(Encoding.UTF8.GetBytes(ApiSecret)))
                    {
                        sha = Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(sign)));
                        hash.Clear();
                    }

                    var authorization =
                        $"api_key=\"{ApiKey}\"," +
                        $" algorithm=\"hmac-sha256\"," +
                        $" headers=\"host date request-line\"," +
                        $" signature=\"{sha}\"";

                    var url =
                        $"wss://tts-api.xfyun.cn/v2/tts?host=tts-api.xfyun.cn" +
                        $"&date={WebUtility.UrlEncode(date).Replace("+", "%20")}" +
                        $"&authorization={Convert.ToBase64String(Encoding.UTF8.GetBytes(authorization))}";

                    WebSocket.ConnectAsync(new Uri(url), CancellationSource.Token).Wait();
                    return WebSocket;
                }
            }
        }

    }
}
