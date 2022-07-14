using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using ACT.FoxCommon.logging;
using ACT.FoxTTS.localization;
using Newtonsoft.Json.Linq;

namespace ACT.FoxTTS.engine.aliyun
{
    internal class AliyunTTSEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly AliyunTTSSettingsControl _settingsControl = new AliyunTTSSettingsControl();

        public static readonly AliyunVoice[] Voices = new[]
        {
            new AliyunVoice("zhimi_emo", "多种情感女声 知米",
                new[] { "angry", "fear", "happy", "hate", "neutral", "sad", "surprise" }),
            new AliyunVoice("zhiyan_emo", "多种情感女声 知燕",
                new[] { "neutral", "happy", "angry", "sad", "fear", "hate", "surprise", "arousal" }),
            new AliyunVoice("zhibei_emo", "多种情感童声 知贝",
                new[] { "neutral", "happy", "angry", "sad", "fear", "hate", "surprise" }),
            new AliyunVoice("zhitian_emo", "多种情感女声 知甜",
                new[] { "neutral", "happy", "angry", "sad", "fear", "hate", "surprise" }),
            new AliyunVoice("xiaoyun", "标准女声 小云"),
            new AliyunVoice("xiaogang", "标准男声 小刚"),
            new AliyunVoice("ruoxi", "温柔女声 若兮"),
            new AliyunVoice("siqi", "温柔女声 思琪"),
            new AliyunVoice("sijia", "标准女声 思佳"),
            new AliyunVoice("sicheng", "标准男声 思诚"),
            new AliyunVoice("aiqi", "温柔女声 艾琪"),
            new AliyunVoice("aijia", "标准女声 艾佳"),
            new AliyunVoice("aicheng", "标准男声 艾诚"),
            new AliyunVoice("aida", "标准男声 艾达"),
            new AliyunVoice("ninger", "标准女声 宁儿"),
            new AliyunVoice("ruilin", "标准女声 瑞琳"),
            new AliyunVoice("siyue", "温柔女声 思悦"),
            new AliyunVoice("aiya", "严厉女声 艾雅"),
            new AliyunVoice("aixia", "亲和女声 艾夏"),
            new AliyunVoice("aimei", "甜美女声 艾美"),
            new AliyunVoice("aiyu", "自然女声 艾雨"),
            new AliyunVoice("aiyue", "温柔女声 艾悦"),
            new AliyunVoice("aijing", "严厉女声 艾婧"),
            new AliyunVoice("xiaomei", "甜美女声 小美"),
            new AliyunVoice("aina", "浙普女声 艾娜"),
            new AliyunVoice("yina", "浙普女声 伊娜"),
            new AliyunVoice("sijing", "严厉女声 思婧"),
            new AliyunVoice("sitong", "儿童音 思彤"),
            new AliyunVoice("xiaobei", "萝莉女声 小北"),
            new AliyunVoice("aitong", "儿童音 艾彤"),
            new AliyunVoice("aiwei", "萝莉女声 艾薇"),
            new AliyunVoice("aibao", "萝莉女声 艾宝"),
            new AliyunVoice("harry", "英音男声 Harry"),
            new AliyunVoice("abby", "美音女声 Abby"),
            new AliyunVoice("andy", "美音男声 Andy"),
            new AliyunVoice("eric", "英音男声 Eric"),
            new AliyunVoice("emily", "英音女声 Emily"),
            new AliyunVoice("luna", "英音女声 Luna"),
            new AliyunVoice("luca", "英音男声 Luca"),
            new AliyunVoice("wendy", "英音女声 Wendy"),
            new AliyunVoice("william", "英音男声 William"),
            new AliyunVoice("olivia", "英音女声 Olivia"),
            new AliyunVoice("shanshan", "粤语女声 姗姗"),
            new AliyunVoice("chuangirl", "四川话女声 小玥"),
            new AliyunVoice("lydia", "英中双语女声 Lydia"),
            new AliyunVoice("aishuo", "自然男声 艾硕"),
            new AliyunVoice("qingqing", "中国台湾话女声 青青"),
            new AliyunVoice("cuijie", "东北话女声 翠姐"),
            new AliyunVoice("xiaoze", "湖南重口音男声 小泽"),
            new AliyunVoice("tomoka", "日语女声 智香"),
            new AliyunVoice("tomoya", "日语男声 智也"),
            new AliyunVoice("annie", "美语女声 Annie"),
            new AliyunVoice("jiajia", "粤语女声 佳佳"),
            new AliyunVoice("indah", "印尼语女声 Indah"),
            new AliyunVoice("taozi", "粤语女声 桃子"),
            new AliyunVoice("guijie", "亲切女声 柜姐"),
            new AliyunVoice("stella", "知性女声 Stella"),
            new AliyunVoice("stanley", "沉稳男声 Stanley"),
            new AliyunVoice("kenny", "沉稳男声 Kenny"),
            new AliyunVoice("rosa", "自然女声 Rosa"),
            new AliyunVoice("farah", "马来语女声 Farah"),
            new AliyunVoice("mashu", "儿童剧男声 马树"),
            new AliyunVoice("xiaoxian", "亲切女声 小仙"),
            new AliyunVoice("yuer", "儿童剧女声 悦儿"),
            new AliyunVoice("maoxiaomei", "活力女声 猫小美"),
            new AliyunVoice("zhifei", "激昂解说 知飞"),
            new AliyunVoice("zhilun", "悬疑解说 知伦"),
            new AliyunVoice("aifei", "激昂解说 艾飞"),
            new AliyunVoice("yaqun", "卖场广播 亚群"),
            new AliyunVoice("qiaowei", "卖场广播 巧薇"),
            new AliyunVoice("dahu", "东北话男声 大虎"),
            new AliyunVoice("ava", "美语女声 ava"),
            new AliyunVoice("ailun", "悬疑解说 艾伦"),
            new AliyunVoice("jielidou", "治愈童声 杰力豆"),
            new AliyunVoice("laotie", "东北老铁 老铁"),
            new AliyunVoice("laomei", "吆喝女声 老妹"),
            new AliyunVoice("aikan", "天津话男声 艾侃"),
            new AliyunVoice("tala", "菲律宾语女声 Tala"),
            new AliyunVoice("tien", "越南语女声 Tien"),
            new AliyunVoice("becca", "美语客服女声 Becca"),
        };

        public const string EffectNone = "none";

        public static readonly Voice[] Effects = new[]
        {
            new Voice(EffectNone, "无"),
            new Voice("robot", "机器人"),
            new Voice("lolita", "萝莉"),
            new Voice("lowpass", "低通"),
            new Voice("echo", "回声"),
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

        public string Name => "AliyunTTS";

        public void Stop()
        {
            _settingsControl.RemoveFromAct();
        }

        public void Speak(string text)
        {
            var settings = _plugin.Settings.AliyunTtsSettings;

            // Xml escape
            text = SecurityElement.Escape(text);

            var wave = _plugin.Cache.GetOrCreateFile(
                this,
                text,
                "mp3",
                settings.ToString(),
                f =>
                {
                    var accessKeyId = settings.AccessKeyId;
                    var accessKeySecret = settings.AccessKeySecret;
                    var appId = settings.AppId;
                    if (string.IsNullOrEmpty(appId)
                        || string.IsNullOrWhiteSpace(accessKeyId)
                        || string.IsNullOrWhiteSpace(accessKeySecret))
                    {
                        Logger.Error(strings.msgErrorEmptyApiSecretKey);
                        _settingsControl.NotifyEmptyApiKey();
                        return;
                    }

                    // Auth
                    if (_currentAccessToken == null || !_currentAccessToken.IsValid(accessKeyId, accessKeySecret))
                    {
                        Logger.Info("刷新Token中...");
                        _currentAccessToken = ObtainNewToken(accessKeyId, accessKeySecret) ?? throw new Exception("身份认证失败");
                    }

                    // Build SSML
                    var effectSSML = "";
                    if (!string.IsNullOrWhiteSpace(settings.Effect) && settings.Effect != EffectNone)
                    {
                        effectSSML = $"effect=\"{settings.Effect}\"";
                    }
                    var textSSML = text;
                    if (!string.IsNullOrWhiteSpace(settings.EmotionCategory) &&
                        settings.EmotionCategory != AliyunVoice.EmotionNone)
                    {
                        var intensity = settings.EmotionIntensity;
                        if (intensity == 0)
                        {
                            intensity = 1;
                        }
                        textSSML = $"<emotion category=\"{settings.EmotionCategory}\" intensity=\"{intensity / 100f}\">{text}</emotion>";
                    }
                    var ssml =
                        $"<speak {effectSSML}>" +
                        textSSML +
                        "</speak>";

                    // Build request body
                    var reqObj = new JObject();
                    reqObj["appkey"] = appId;
                    reqObj["token"] = _currentAccessToken.Token;
                    reqObj["format"] = "mp3";
                    reqObj["text"] = ssml;
                    reqObj["voice"] = settings.Voice;
                    reqObj["speech_rate"] = settings.Speed;
                    reqObj["pitch_rate"] = settings.Pitch;
                    reqObj["volume"] = settings.Volume;
                    var requestBody = reqObj.ToString();

                    // Send request
                    var req = (HttpWebRequest)WebRequest.Create("https://nls-gateway.aliyuncs.com/stream/v1/tts");
                    req.Method = "POST";
                    req.ContentType = "application/json";
                    var data = Encoding.UTF8.GetBytes(requestBody);
                    req.ContentLength = data.Length;
                    using (var reqStream = req.GetRequestStream())
                    {
                        reqStream.Write(data, 0, data.Length);
                        reqStream.Close();
                    }

                    // Parse response
                    using var resp = req.GetHttpResponse();
                    if (resp.ContentType.ToLower() == "audio/mpeg")
                    {
                        // OK, save file
                        resp.SaveToBinaryFile(f);
                    }
                    else
                    {
                        // Error
                        using var stream = resp.GetResponseStream();
                        string result;
                        using (var reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }

                        Logger.Error($"Unable to complete the request: {result}");
                        // TODO: Better error message
                    }

                });

            _plugin.SoundPlayer.Play(wave);
        }

        private class AccessToken
        {
            private readonly string AccessKeyId;
            private readonly string AccessKeySecret;
            public readonly string Token;
            private readonly DateTime ExpireTime;

            public AccessToken(string accessKeyId, string accessKeySecret, string token, DateTime expireTime)
            {
                AccessKeyId = accessKeyId;
                AccessKeySecret = accessKeySecret;
                Token = token;
                ExpireTime = expireTime;
            }

            public bool IsValid(string keyId, string keySecret)
            {
                if (AccessKeyId != keyId || AccessKeySecret != keySecret)
                {
                    return false;
                }

                var now = DateTime.UtcNow;

                return (ExpireTime - now).TotalSeconds > 10;
            }
        }

        private AccessToken _currentAccessToken = null;

        private static AccessToken ObtainNewToken(
            string accessKeyId,
            string accessKeySecret
            )
        {
            // 所有请求参数
            var queryParamsDict = new Dictionary<string, string>
            {
                ["AccessKeyId"] = accessKeyId,
                ["Action"] = "CreateToken",
                ["Version"] = "2019-02-28",
                ["Timestamp"] = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture),
                ["Format"] = "JSON",
                ["RegionId"] = "cn-shanghai",
                ["SignatureMethod"] = "HMAC-SHA1",
                ["SignatureVersion"] = "1.0",
                ["SignatureNonce"] = Guid.NewGuid().ToString(),
            };

            // 1.构造规范化的请求字符串
            var queryString = string.Join("&",
                queryParamsDict
                    .OrderBy(it => it.Key)
                    .Select(it => $"{WebUtility.UrlEncode(it.Key)}={WebUtility.UrlEncode(it.Value)}")
            );

            // 2.构造签名字符串
            var stringToSign = $"GET&{WebUtility.UrlEncode("/")}&{WebUtility.UrlEncode(queryString)}";
            Logger.Debug($"stringToSign: {stringToSign}");

            // 3.计算签名
            string signBase64;
            using (var hash = new HMACSHA1(Encoding.UTF8.GetBytes(accessKeySecret + '&')))
            {
                signBase64 = Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
                hash.Clear();
            }
            var signature = WebUtility.UrlEncode(signBase64);

            // 4.将签名加入到第1步获取的请求字符串
            var queryStringWithSign = $"Signature={signature}&{queryString}";

            // 5.发送HTTP GET请求，获取token。
            var request = (HttpWebRequest)WebRequest.Create($"https://nls-meta.cn-shanghai.aliyuncs.com/?{queryStringWithSign}");
            request.Method = "GET";
            request.Accept = "application/json";

            using var response = request.GetHttpResponse();
            var result = new StreamReader(response.GetResponseStream()).ReadToEnd();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Logger.Error($"Unexpected error: {result}");
                // TODO: Better error message
                return null;
            }

            Logger.Debug($"Token response: {result}");
            var tokenObj = JObject.Parse(result)["Token"] as JObject;
            var token = tokenObj["Id"].ToObject<string>();
            var expireTime = DateTimeOffset.FromUnixTimeSeconds(tokenObj["ExpireTime"].ToObject<long>()).UtcDateTime;

            return new AccessToken(accessKeyId, accessKeySecret, token, expireTime);
        }
    }
}
