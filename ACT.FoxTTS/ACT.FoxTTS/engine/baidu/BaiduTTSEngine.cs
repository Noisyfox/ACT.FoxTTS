using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Stop()
        {
            _settingsControl.RemoveFromAct();
        }

        public void Speak(string text, dynamic playDevice)
        {
            var settings = _plugin.Settings.BaiduTtsSettings;

            _plugin.SoundPlayer.Play("", playDevice);
        }
    }
}
