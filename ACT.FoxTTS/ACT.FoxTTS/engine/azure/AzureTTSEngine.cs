using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security;
using System.Threading;
using ACT.FoxCommon.core;
using ACT.FoxCommon.logging;
using ACT.FoxTTS.localization;

namespace ACT.FoxTTS.engine.azure
{
    class AzureTTSEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly AzureTTSSettingsControl _settingsControl = new AzureTTSSettingsControl();
        private readonly AzureWSKeepAliveWorker _keepAlive = new AzureWSKeepAliveWorker();

        public static readonly AzureVoice[] Voices = new[]
        {
            new AzureVoice("zh-CN-XiaoxiaoNeural", "中文-普通话-女 晓晓",
                new [] { "affectionate", "angry", "assistant", "calm", "chat", "cheerful", "customerservice", "disgruntled", "fearful", "gentle", "lyrical", "newscast", "poetry-reading", "sad", "serious" },
                true),
            new AzureVoice("zh-CN-XiaoyouNeural", "中文-普通话-儿童-女 晓悠"),
            new AzureVoice("zh-CN-XiaomoNeural", "中文-普通话-女 晓墨",
                new [] { "affectionate", "angry", "calm", "cheerful", "depressed", "disgruntled", "embarrassed", "envious", "fearful", "gentle", "sad", "serious" },
                true,
                new [] { "YoungAdultFemale", "YoungAdultMale", "OlderAdultFemale", "OlderAdultMale", "SeniorFemale", "SeniorMale", "Girl", "Boy" }),
            new AzureVoice("zh-CN-XiaoxuanNeural", "中文-普通话-女 晓萱",
                new [] { "angry", "calm", "cheerful", "depressed", "disgruntled", "fearful", "gentle", "serious" },
                true,
                new [] { "YoungAdultFemale", "YoungAdultMale", "OlderAdultFemale", "OlderAdultMale", "SeniorFemale", "SeniorMale", "Girl", "Boy" }),
            new AzureVoice("zh-CN-XiaohanNeural", "中文-普通话-女 晓涵",
                new [] { "affectionate", "angry", "calm", "cheerful", "disgruntled", "embarrassed", "fearful", "gentle", "sad", "serious" },
                true),
            new AzureVoice("zh-CN-XiaoruiNeural", "中文-普通话-女 晓睿",
                new [] { "angry", "calm", "fearful", "sad" },
                true),
            new AzureVoice("zh-CN-XiaochenNeural", "中文-普通话-女 晓辰"),
            new AzureVoice("zh-CN-XiaoqiuNeural", "中文-普通话-女 晓秋"),
            new AzureVoice("zh-CN-XiaoshuangNeural", "中文-普通话-儿童-女 晓双",
                new [] { "chat" },
                true),
            new AzureVoice("zh-CN-XiaoyanNeural", "中文-普通话-女 晓颜"),
            new AzureVoice("zh-CN-YunyangNeural", "中文-普通话-新闻-男 云扬",
                new [] { "customerservice", "narration-professional", "newscast-casual" },
                true),
            new AzureVoice("zh-CN-YunyeNeural", "中文-普通话-故事-男 云野",
                new [] { "angry", "calm", "cheerful", "disgruntled", "embarrassed", "fearful", "sad", "serious" },
                true,
                new [] { "YoungAdultFemale", "YoungAdultMale", "OlderAdultFemale", "OlderAdultMale", "SeniorFemale", "SeniorMale", "Girl", "Boy" }),
            new AzureVoice("zh-CN-YunxiNeural", "中文-普通话-男 云希",
                new [] { "angry", "assistant", "cheerful", "depressed", "disgruntled", "embarrassed", "fearful", "narration-relaxed", "sad", "serious" },
                true,
                new [] { "Narrator", "YoungAdultMale", "Boy" }),
            new AzureVoice("zh-CN-YunfengNeural", "中文-普通话-男 云枫",
                new [] { "calm", "angry", "disgruntled", "cheerful", "fearful", "sad", "serious", "depressed" },
                true),
            new AzureVoice("zh-CN-YunhaoNeural", "中文-普通话-广告-男 云皓",
                new [] { "advertisement-upbeat" },
                true),
            new AzureVoice("zh-CN-YunjianNeural", "中文-普通话-体育-男 云健",
                new [] { "narration-relaxed", "sports-commentary", "sports-commentary-excited" },
                true),
            new AzureVoice("zh-CN-LN-XiaobeiNeural", "中文-普通话-辽宁-女 晓北"),
            new AzureVoice("zh-CN-SC-YunxiSichuanNeural", "中文-普通话-四川-男 云希"),
            new AzureVoice("zh-HK-HiuGaaiNeural", "中文-粤语-女 曉曼"),
            new AzureVoice("zh-HK-HiuMaanNeural", "中文-粤语-女 曉佳"),
            new AzureVoice("zh-HK-WanLungNeural", "中文-粤语-男 雲龍"),
            new AzureVoice("zh-TW-HsiaoChenNeural", "中文-台普-女 曉臻"),
            new AzureVoice("zh-TW-HsiaoYuNeural", "中文-台普-女 曉雨"),
            new AzureVoice("zh-TW-YunJheNeural", "中文-台普-男 雲哲"),
            new AzureVoice("ja-JP-NanamiNeural", "日语-女 七海",
                new [] { "chat", "cheerful", "customerservice" }),
            new AzureVoice("ja-JP-KeitaNeural", "日语-男 圭太"),
            new AzureVoice("en-US-AriaNeural", "英语-美国-女 阿莉雅",
                new [] { "angry", "chat", "cheerful", "customerservice", "empathetic", "excited", "friendly", "hopeful", "narration-professional", "newscast-casual", "newscast-formal", "sad", "shouting", "terrified", "unfriendly", "whispering" }),
            new AzureVoice("en-US-JennyNeural", "英语-美国-女 珍妮",
                new [] { "angry", "assistant", "chat", "cheerful", "customerservice", "excited", "friendly", "hopeful", "newscast", "sad", "shouting", "terrified", "unfriendly", "whispering" }),
            new AzureVoice("en-US-GuyNeural", "英语-美国-男 盖",
                new [] { "angry", "cheerful", "excited", "friendly", "hopeful", "newscast", "sad", "shouting", "terrified", "unfriendly", "whispering" }),
            new AzureVoice("en-US-AmberNeural", "英语-美国-女 安柏"),
            new AzureVoice("en-US-AshleyNeura", "英语-美国-女 艾什莉"),
            new AzureVoice("en-US-CoraNeural", "英语-美国-女 科拉"),
            new AzureVoice("en-US-ElizabethNeural", "英语-美国-女 伊丽莎白"),
            new AzureVoice("en-US-MichelleNeural", "英语-美国-女 米歇尔"),
            new AzureVoice("en-US-MonicaNeural", "英语-美国-女 莫妮卡"),
            new AzureVoice("en-US-AnaNeural", "英语-美国-儿童-女 安娜"),
            new AzureVoice("en-US-BrandonNeural", "英语-美国-男 布兰登"),
            new AzureVoice("en-US-ChristopherNeural", "英语-美国-男 克里斯多弗"),
            new AzureVoice("en-US-JacobNeural", "英语-美国-男 雅各布"),
            new AzureVoice("en-US-EricNeural", "英语-美国-男 埃里克"),
            new AzureVoice("en-GB-LibbyNeural", "英语-英国-女 利比"),
            new AzureVoice("en-GB-MiaNeural", "英语-英国-女 米亚"),
            new AzureVoice("en-GB-RyanNeural", "英语-英国-男 瑞恩"),
        };

        public static readonly string StyleGeneral = "general";
        public static readonly string RoleDefault = "Default";


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

        public string Name => "AzureTTS";

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
            var settings = _plugin.Settings.AzureTtsSettings;

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

                    while (true)
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


        private byte[] Synthesis(AzureTTSSettings settings, string text)
        {
            var apiKey = settings.Key;
            var region = settings.Region;
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(region))
            {
                Logger.Error(strings.msgErrorEmptyKeyRegion);
                _settingsControl.NotifyEmptyApiKey();
                return null;
            }

            var ws = ObtainConnection(apiKey, region);

            if (ws == null)
            {
                // Cancelled
                return null;
            }

            return AzureWSSynthesiser.Synthesis(ws, _wsCancellationSource,
                text, settings.Speed, settings.Pitch, settings.Volume, settings.Voice,
                settings.Style, settings.StyleDegree, settings.Role);
        }

        private readonly CancellationTokenSource _wsCancellationSource = new CancellationTokenSource();
        private string _currentCredentials = null;
        private string _currentAuthToken = null;
        private WebSocket _webSocket;

        private WebSocket ObtainConnection(string apiKey, string region)
        {
            lock (this)
            {
                if (_wsCancellationSource.IsCancellationRequested)
                {
                    return null;
                }

                // Check if user updated api key
                var cred = $"{region}:{apiKey}";
                if (_currentCredentials != cred)
                {
                    _currentAuthToken = null;
                    _currentCredentials = cred;

                    _webSocket?.Abort();
                    _webSocket?.Dispose();
                    _webSocket = null;
                }

                if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(region))
                {
                    _currentAuthToken = null;
                    _webSocket?.Abort();
                    _webSocket?.Dispose();
                    _webSocket = null;

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
                if (_currentAuthToken == null)
                {
                    Logger.Info("身份认证中...");
                    _currentAuthToken = ObtainNewToken(apiKey, region);
                    if (_currentAuthToken == null)
                    {
                        _webSocket.Abort();
                        _webSocket.Dispose();
                        _webSocket = null;
                        return null;
                    }
                    Logger.Debug($"Token: {_currentAuthToken}");
                }
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
                var connectionId = Guid.NewGuid().ToString().Replace("-", "");
                try
                {
                    _webSocket
                        .ConnectAsync(
                            new Uri(
                                $"wss://{region}.tts.speech.microsoft.com/cognitiveservices/websocket/v1?Authorization=bearer {_currentAuthToken}&X-ConnectionId={connectionId}"),
                            _wsCancellationSource.Token)
                        .Wait();
                }
                catch (Exception e)
                {
                    if (IsUnauthorizedException(e))
                    {
                        Logger.Warn("Token expired");
                    }

                    _currentAuthToken = null;
                    _webSocket.Abort();
                    _webSocket.Dispose();
                    _webSocket = null;

                    throw;
                }

                return _webSocket;
            }
        }

        private static bool IsUnauthorizedException(Exception e)
        {
            Exception we = e;
            while (we != null)
            {
                if (we is WebException)
                {
                    break;
                }

                we = we.InnerException;
            }

            if (we == null)
            {
                return false;
            }

            return ((HttpWebResponse)((WebException) we).Response).StatusCode == HttpStatusCode.Unauthorized;
        }

        private string ObtainNewToken(string apiKey, string region)
        {
            var request = (HttpWebRequest)WebRequest.Create($"https://{region}.api.cognitive.microsoft.com/sts/v1.0/issuetoken");
            request.Method = "POST";
            request.Headers["Ocp-Apim-Subscription-Key"] = apiKey;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = 0;
            using (var reqStream = request.GetRequestStream()){
                reqStream.Close();
            }

            var response = (HttpWebResponse)request.GetResponse();
            var result = new StreamReader(response.GetResponseStream()).ReadToEnd();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return result;
                case HttpStatusCode.Unauthorized:
                    Logger.Error(strings.msgErrorAzureAuthFail);
                    Logger.Error(result);
                    return null;
                default:
                    Logger.Error($"Unexpected error: {result}");
                    return null;
            }
        }

        private class AzureWSKeepAliveWorker : BaseThreading<AzureTTSEngine>
        {
            protected override void DoWork(AzureTTSEngine context)
            {
                while (!WorkingThreadStopping)
                {
                    try
                    {
                        var settings = context._plugin.Settings.AzureTtsSettings;
                        context.ObtainConnection(settings.Key, settings.Region);
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
