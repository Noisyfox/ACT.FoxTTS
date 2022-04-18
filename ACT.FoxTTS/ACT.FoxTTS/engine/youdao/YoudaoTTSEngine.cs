using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using ACT.FoxCommon.logging;
using ACT.FoxTTS.localization;
using Newtonsoft.Json.Linq;

namespace ACT.FoxTTS.engine.youdao
{
    class YoudaoTTSEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly YoudaoTTSSettingsControl _settingsControl = new YoudaoTTSSettingsControl();

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

        public string Name => "YoudaoTTS";

        public void Stop()
        {
            _settingsControl.RemoveFromAct();
        }

        public void Speak(string text, dynamic playDevice, bool isSync, float? volume)
        {
            var settings = _plugin.Settings.YoudaoTtsSettings;

            var option = new Dictionary<string, string>()
            {
                {"q", WebUtility.UrlEncode(text)},
                {"langType", "zh-CHS"},
                {"voice", "2"}, // 语言设为"zh-CHS"，voice设为"2"，女声音色，支持中英混合语音合成
                {"speed", (settings.Speed / 10.0).ToString()},
                {"volume", (settings.Volume / 10.0).ToString()},
            };


            var wave = _plugin.Cache.GetOrCreateFile(
                this,
                text,
                "mp3",
                option.GetString(),
                f =>
                {
                    var appId = settings.AppId;
                    var appSecret = settings.AppSecret;
                    if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(appSecret))
                    {
                        Logger.Error(strings.msgErrorEmptyApiSecretKey);
                        _settingsControl.NotifyEmptyApiKey();
                        return;
                    }

                    // Auth
                    var salt = DateTime.Now.Millisecond.ToString();
                    var signStr = appId + text + salt + appSecret;
                    var sign = ComputeHash(signStr, new MD5CryptoServiceProvider());
                    option.Add("appKey", appId);
                    option.Add("salt", salt);
                    option.Add("sign", sign);

                    // Send request
                    var req = (HttpWebRequest)WebRequest.Create("https://openapi.youdao.com/ttsapi");
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    var data = Encoding.UTF8.GetBytes(string.Join("&", option.Select(it => $"{it.Key}={it.Value}")));
                    req.ContentLength = data.Length;
                    using (var reqStream = req.GetRequestStream())
                    {
                        reqStream.Write(data, 0, data.Length);
                        reqStream.Close();
                    }
                    
                    // Parse response
                    var resp = (HttpWebResponse)req.GetResponse();
                    if (resp.ContentType.ToLower() == "audio/mp3")
                    {
                        // OK, save file
                        SaveBinaryFile(resp, f);
                    }
                    else
                    {
                        // Error
                        var stream = resp.GetResponseStream();
                        string result;
                        using (var reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }

                        Logger.Error($"Unable to complete the request: {result}");
                        var o = JObject.Parse(result);
                        var errorCode = o["errorCode"].ToObject<int>();
                        switch (errorCode)
                        {
                            case 108:
                            case 110:
                            case 111:
                                Logger.Error(strings.msgErrorYoudaoAuthFail);
                                break;
                            case 401:
                                Logger.Error(strings.msgErrorYoudaoInsufficientApiQuota);
                                break;
                            case 411:
                            case 412:
                            case 1411:
                            case 2411:
                            case 3411:
                            case 4411:
                            case 9411:
                            case 10411:
                                Logger.Error(strings.msgErrorYoudaoTooFrequent);
                                break;
                            case 2004:
                            case 1412:
                            case 2412:
                            case 3412:
                            case 9412:
                            case 10412:
                                Logger.Error(strings.msgErrorYoudaoTooLong);
                                break;
                            default:
                                Logger.Error(string.Format(strings.msgErrorYoudaoUnexpected, errorCode));
                                break;
                        }
                    }
                });

            _plugin.SoundPlayer.Play(wave, playDevice, isSync, volume);
        }

        private static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        private static bool SaveBinaryFile(WebResponse response, string filePath)
        {
            bool Value = true;
            byte[] buffer = new byte[1024];

            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
                Stream outStream = System.IO.File.Create(filePath);
                Stream inStream = response.GetResponseStream();

                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        outStream.Write(buffer, 0, l);
                }
                while (l > 0);

                outStream.Close();
                inStream.Close();
            }
            catch
            {
                Value = false;
            }
            return Value;
        }
    }
}
