using System.Net;
using System.Reflection;
using System.Security;
using System.Text;
using ACT.FoxCommon.logging;
using ACT.FoxTTS.engine.azure;

namespace ACT.FoxTTS.engine.cafepro
{
    internal class CafeProTTSEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly CafeProTTSSettingsControl _settingsControl = new CafeProTTSSettingsControl();

        public static readonly AzureVoice[] Voices = new[]
        {
            new AzureVoice("zh-CN-XiaoxiaoNeural", "中文-普通话-女 晓晓",
                new [] { "affectionate", "angry", "assistant", "calm", "chat", "cheerful", "customerservice", "disgruntled", "fearful", "gentle", "lyrical", "newscast", "poetry-reading", "sad", "serious" },
                true),
            new AzureVoice("zh-CN-XiaoyouNeural", "中文-普通话-儿童-女 晓悠"),
            new AzureVoice("zh-CN-XiaomoNeural", "中文-普通话-女 晓墨",
                new [] { "affectionate", "angry", "calm", "cheerful", "depressed", "disgruntled", "embarrassed", "envious", "fearful", "gentle", "sad", "serious" },
                true),
            new AzureVoice("zh-CN-XiaoxuanNeural", "中文-普通话-女 晓萱",
                new [] { "angry", "calm", "cheerful", "depressed", "disgruntled", "fearful", "gentle", "serious" },
                true),
            new AzureVoice("zh-CN-XiaohanNeural", "中文-普通话-女 晓涵",
                new [] { "affectionate", "angry", "calm", "cheerful", "disgruntled", "embarrassed", "fearful", "gentle", "sad", "serious" },
                true),
            new AzureVoice("zh-CN-XiaoruiNeural", "中文-普通话-女 晓睿",
                new [] { "angry", "calm", "fearful", "sad" },
                true),
            new AzureVoice("zh-CN-YunyangNeural", "中文-普通话-新闻-男 云扬",
                new [] { "customerservice", "narration-professional", "newscast-casual" },
                true),
            new AzureVoice("zh-CN-YunyeNeural", "中文-普通话-故事-男 云野",
                new [] { "angry", "calm", "cheerful", "disgruntled", "embarrassed", "fearful", "sad", "serious" },
                true),
            new AzureVoice("zh-CN-YunxiNeural", "中文-普通话-男 云希",
                new [] { "angry", "assistant", "cheerful", "depressed", "disgruntled", "embarrassed", "fearful", "narration-relaxed", "sad", "serious" },
                true),
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

        public string Name => "CafeTTSPro";

        public void Stop()
        {
            _settingsControl.RemoveFromAct();
        }

        public void Speak(string text)
        {
            var settings = _plugin.Settings.CafeProTtsSettings;

            // Xml escape
            text = SecurityElement.Escape(text);

            var wave = _plugin.Cache.GetOrCreateFile(
                this,
                text,
                "mp3",
                settings.ToString(),
                f =>
                {
                    var ssml = AzureWSSynthesiser.CreateSSML(
                        text,
                        settings.Speed, settings.Pitch, settings.Volume,
                        settings.Voice,
                        settings.Style, settings.StyleDegree, settings.Role
                    );

                    // Send request
                    var req = (HttpWebRequest)WebRequest.Create("https://ttspro.xivcdn.com/tts/v1");
                    req.Method = "POST";
                    req.ContentType = "application/ssml+xml";
                    req.Headers["FFCafe-Access-Token"] = "9cua5sn8cb385bza27gjgca5sjx8rwfn";
                    req.Headers["Output-Format"] = "audio-24khz-48kbitrate-mono-mp3";
                    req.Headers["Voice-Variant"] = settings.Voice.ToLower();
                    req.UserAgent = $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.74 Safari/537.36 Edg/99.0.1150.55 FoxTTS/{Assembly.GetCallingAssembly().GetName().Version}";

                    var data = Encoding.UTF8.GetBytes(ssml);
                    req.ContentLength = data.Length;
                    using (var reqStream = req.GetRequestStream())
                    {
                        reqStream.Write(data, 0, data.Length);
                        reqStream.Close();
                    }

                    // Parse response
                    using var resp = (HttpWebResponse)req.GetResponse();
                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        // OK, save file
                        resp.SaveToBinaryFile(f);
                    }
                    else
                    {
                        Logger.Error($"Unable to complete the request: {resp}");
                    }
                });

            _plugin.SoundPlayer.Play(wave);
        }
    }
}
