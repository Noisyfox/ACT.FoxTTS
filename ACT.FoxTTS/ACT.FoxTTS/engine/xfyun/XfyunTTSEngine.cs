using System;
using System.IO;
using System.Linq;
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
        private readonly CancellationTokenSource _wsCancellationSource = new CancellationTokenSource();

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
            _wsCancellationSource.Cancel();
            _settingsControl.RemoveFromAct();
        }

        public void Speak(string text)
        {
            var settings = _plugin.Settings.XfyunTtsSettings;

            var wave = _plugin.Cache.GetOrCreateFile(
                this,
                text,
                "mp3",
                settings.ToString(),
                f =>
                {
                    byte[] result = null;
                    
                    result = Synthesis(settings, text);

                    if (result != null)
                    {
                        File.WriteAllBytes(f, result);
                    }
                });

            _plugin.SoundPlayer.Play(wave);
        }

        private byte[] Synthesis(XfyunTTSSettings settings, string text)
        {
            var apiSecret = settings.ApiSecret;
            var apiKey = settings.ApiKey;
            var appId = settings.AppId;
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret) || string.IsNullOrEmpty(appId))
            {
                Logger.Error(strings.msgErrorEmptyApiSecretKey);
                _settingsControl.NotifyEmptyApiKey();
                return null;
            }

            var base64Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            if (base64Text.Length > 8000)
            {
                Logger.Error("Convert string too long. No more than 2000 chinese characters.");
                return null;
            }

            using (var ws = SystemClientWebSocket.CreateClientWebSocket())
            {
                // Connect
                var date = DateTime.UtcNow.ToString("R");
                var sign = $"host: tts-api.xfyun.cn\ndate: {date}\nGET /v2/tts HTTP/1.1";
                string sha;
                using (var hash = new HMACSHA256(Encoding.UTF8.GetBytes(apiSecret)))
                {
                    sha = Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(sign)));
                    hash.Clear();
                }
                var authorization =
                    $"api_key=\"{apiKey}\"," +
                    $" algorithm=\"hmac-sha256\"," +
                    $" headers=\"host date request-line\"," +
                    $" signature=\"{sha}\"";
                var url =
                    $"wss://tts-api.xfyun.cn/v2/tts?host=tts-api.xfyun.cn" +
                    $"&date={WebUtility.UrlEncode(date).Replace("+", "%20")}" +
                    $"&authorization={Convert.ToBase64String(Encoding.UTF8.GetBytes(authorization))}";
                try
                {
                    ws.ConnectAsync(new Uri(url), _wsCancellationSource.Token).Wait();
                }
                catch (AggregateException e)
                {
                    var inner = e.InnerExceptions.First().GetBaseException();
                    if (inner is WebException webException)
                    {
                        var resp = (HttpWebResponse)webException.Response;
                        string body = null;
                        using (var stream = resp.GetResponseStream())
                        {
                            if (stream != null)
                            {
                                var reader = new StreamReader(stream, string.IsNullOrEmpty(resp.CharacterSet) ? Encoding.UTF8 : Encoding.GetEncoding(resp.CharacterSet));
                                body = reader.ReadToEnd();
                            }
                        }
                        Logger.Error($"Unable to connect to server: {body}");
                        switch (resp.StatusCode)
                        {
                            case HttpStatusCode.Unauthorized:
                            case HttpStatusCode.Forbidden:
                                Logger.Error(strings.msgErrorXfyunAuthFail);
                                return null;
                        }
                    }

                    throw;
                }

                // Send request
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
                ws.SendText(JsonConvert.SerializeObject(request), _wsCancellationSource);

                // Start receiving
                var buffer = new MemoryStream();
                var session = new WebSocketHelper.Session(ws);
                while (true)
                {
                    var message = WebSocketHelper.ReceiveNextMessage(session, _wsCancellationSource);
                    Logger.Debug($"Received WS message\n{message}");
                    if (message.Type == WebSocketMessageType.Text)
                    {
                        var resp = JsonConvert.DeserializeObject<TTSResponse>(message.MessageStr);
                        if (resp.Code == 0)
                        {
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
                        }
                        else
                        {
                            Logger.Error($"Unexpected response code received: {resp.Code}: {resp.Message}");
                            switch (resp.Code)
                            {
                                case 10005:
                                case 10313:
                                    Logger.Error(strings.msgErrorXfyunWrongAppId);
                                    break;
                                case 11200:
                                case 11201:
                                    Logger.Error(strings.msgErrorXfyunInsufficientApiQuota);
                                    break;
                            }
                            return null;
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
    }
}
