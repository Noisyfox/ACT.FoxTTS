using System.Collections.Generic;
using System.Net;

namespace ACT.FoxTTS.engine.baipiao
{
    /// <summary>
    /// 白嫖的！凑合用！
    /// </summary>
    class BaipiaoEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly BaipiaoSettingsControl _settingsControl = new BaipiaoSettingsControl();

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

        public string Name => "Baipiao";

        public void Stop()
        {
            _settingsControl.RemoveFromAct();
        }

        private static readonly HashSet<char> IllegalChars = new HashSet<char>(new []
        {
            '\\', '/', '*', '>', '<', '?', '|', '\"', ':'
        });

        public void Speak(string text, dynamic playDevice, bool isSync, float? volume)
        {
            var settings = _plugin.Settings.BaipiaoSettings;
            if (!settings.Accept)
            {
                return;
            }

            foreach (var illegalChar in IllegalChars)
            {
                text = text.Replace(illegalChar, ' ');
            }

            var wave = _plugin.Cache.GetOrCreateFile(
                this,
                text,
                "mp3",
                settings.ToString(),
                f =>
                {
                    var url =
                        $"https://fanyi.baidu.com/gettts?lan=zh&text={WebUtility.UrlEncode(text)}&spd={settings.Speed}&source=web";

                    Utils.Download(_plugin.Controller, url, f);
                });

            _plugin.SoundPlayer.Play(wave, playDevice, isSync, volume);
        }
    }
}
