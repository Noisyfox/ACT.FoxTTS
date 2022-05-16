using System.Net;

namespace ACT.FoxTTS.engine.google_unofficial
{
    class GoogleUnofficialTTSEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly GoogleUnofficialTTSSettingsControl _settingsControl = new GoogleUnofficialTTSSettingsControl();

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

        public string Name => "GoogleUnofficialTTS";

        public void Stop()
        {
            _settingsControl.RemoveFromAct();
        }

        public void Speak(string text)
        {
            var settings = _plugin.Settings.GoogleUnofficialTtsSettings;
            if (!settings.Accept)
            {
                return;
            }

            var wave = _plugin.Cache.GetOrCreateFile(
                this,
                text,
                "mp3",
                "",
                f =>
                {
                    var url = $"https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q={WebUtility.UrlEncode(text)}&tl=zh";

                    Utils.Download(url, f);
                });

            _plugin.SoundPlayer.Play(wave);
        }
    }
}
