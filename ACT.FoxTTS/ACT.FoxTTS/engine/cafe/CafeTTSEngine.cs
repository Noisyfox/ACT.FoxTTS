using System.Net;

namespace ACT.FoxTTS.engine.cafe
{
    class CafeTTSEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly CafeTTSSettingsControl _settingsControl = new CafeTTSSettingsControl();

        public static readonly Voice[] Voices = new[]
        {
            new Voice("huihui", "Microsoft Huihui 中文女声"),
            new Voice("yaoyao", "Microsoft Yaoyao 中文女声"),
            new Voice("kangkang", "Microsoft Kangkang 中文男声"),
            new Voice("tracy", "Microsoft Tracy 粤语女声"),
            new Voice("danny", "Microsoft Danny 粤语男声"),
            new Voice("yating", "Microsoft Yating 中文女声"),
            new Voice("hanhan", "Microsoft Hanhan 中文女声"),
            new Voice("zhiwei", "Microsoft Zhiwei 中文男声"),
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

        public string Name => "CafeTTS";

        public void Stop()
        {
            _settingsControl.RemoveFromAct();
        }

        public void Speak(string text)
        {
            var settings = _plugin.Settings.CafeTtsSettings;

            var wave = _plugin.Cache.GetOrCreateFile(
                this,
                text,
                "mp3",
                settings.ToString(),
                f =>
                {
                    var url = $"https://tts.xivcdn.com/api/say?voice={settings.Voice}&text={WebUtility.UrlEncode(text)}&rate={settings.Rate}";

                    Utils.Download(url, f);
                });

            _plugin.SoundPlayer.Play(wave);
        }
    }
}
