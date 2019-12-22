using System;
using System.Collections.Generic;
using System.IO;

namespace ACT.FoxTTS.engine.baidu
{
    class BaiduTTSEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly BaiduTTSSettingsControl _settingsControl = new BaiduTTSSettingsControl();

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

        public string Name => "BaiduTTS";

        public void Stop()
        {
            _settingsControl.RemoveFromAct();
        }

        // https://ai.baidu.com/ai-doc/SPEECH/Qk38y8lrl
        private static readonly int[] PERSON_CODES =
        {
            0, // 度小美
            1, // 度小宇
            3, // 度逍遥
            4, // 度丫丫
            106, // 度博文
            110, // 度小童
            111, // 度小萌
            103, // 度米朵
            5 // 度小娇
        };

        public void Speak(string text, dynamic playDevice, bool isSync, float? volume)
        {
            var settings = _plugin.Settings.BaiduTtsSettings;

            var person = PERSON_CODES[settings.Person];

            var option = new Dictionary<string, object>()
            {
                {"spd", settings.Speed}, // 语速
                {"pit", settings.Pitch}, // 语调
                {"vol", settings.Volume}, // 音量
                {"per", person} // 发音人
            };

            // Calculate hash
            var wave = this.GetCacheFileName(text.Replace(Environment.NewLine, "+"), "mp3", option.GetString());

            lock (this)
            {
                if (!File.Exists(wave))
                {
                    var apiKey = settings.ApiKey;
                    var secretKey = settings.SecretKey;
                    if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(secretKey))
                    {
                        return;
                    }

                    var client = new Baidu.Aip.Speech.Tts(apiKey, secretKey);
                    var result = client.Synthesis(text, option);
                    if (result.Success)
                    {
                        File.WriteAllBytes(wave, result.Data);
                    }
                }
            }

            _plugin.SoundPlayer.Play(wave, playDevice, isSync, volume);
        }
    }
}
