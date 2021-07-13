using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ACT.FoxTTS.engine.cafe
{
    class CafeTTSEngine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly CafeTTSSettingsControl _settingsControl = new CafeTTSSettingsControl();

        public class Voice
        {
            public string Value { get; }

            public string DisplayName { get; }

            public Voice(string value, string displayName)
            {
                Value = value;
                DisplayName = displayName;
            }
        }

        public static readonly Voice[] Voices = new[]
        {
            new Voice("xiaoyun", "小云 (标准女声 通用 中英文 16K)"),
            new Voice("xiaoda", "小达 (标准男声 通用 中英文 16K)"),
            new Voice("xiaogang", "小刚 (温暖男声 通用 中英文 16K)"),
            new Voice("xiaoqi", "小琪 (温柔女声 通用 中英文 16K)"),
            new Voice("xiaoxia", "小夏 (自然女声 客服 中英文 16K)"),
            new Voice("aijia", "艾佳 (标准女声 通用 中英文)"),
            new Voice("aicheng", "艾诚 (温暖男声 通用 中英文)"),
            new Voice("aiqi", "艾琪 (温柔女声 通用 中文)"),
            new Voice("aida", "艾达 (标准男声 通用 中文)"),
            new Voice("aihao", "艾浩 (资讯男声 文学 中文)"),
            new Voice("aishuo", "艾硕 (自然男声 客服 中文)"),
            new Voice("aiying", "艾颖 (软萌童声 文学 中英文)"),
            new Voice("aitong", "艾彤 (儿童音 童声 中文)"),
            new Voice("abby", "Abby (美语女声 英文)"),
            new Voice("andy", "Andy (美语男声 英文)"),
            new Voice("annie", "Annie (美语女声 英文)"),
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

        public void Speak(string text, dynamic playDevice, bool isSync, float? volume)
        {
            var settings = _plugin.Settings.CafeTtsSettings;

            var wave = _plugin.Cache.GetOrCreateFile(
                this,
                text,
                "mp3",
                settings.ToString(),
                f =>
                {
                    var url = $"http://tts.wakingsands.com:3002/tts.mp3?voice_font={settings.Voice}&text={WebUtility.UrlEncode(text)}";

                    Utils.Download(_plugin.Controller, url, f);
                });

            _plugin.SoundPlayer.Play(wave, playDevice, isSync, volume);
        }
    }
}
