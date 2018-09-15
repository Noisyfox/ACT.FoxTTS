using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.FoxTTS
{
    public class SoundPlayerWrapper : IPluginComponent
    {
        private FoxTTSPlugin _plugin;
        private bool _useYukkuri = false;

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
            _plugin.Controller.YukkuriPlaybackEnabledChanged += ControllerOnYukkuriPlaybackEnabledChanged;
        }

        private void ControllerOnYukkuriPlaybackEnabledChanged(bool fromView, bool enabled)
        {
            _useYukkuri = enabled;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        public void Stop()
        {

        }

        public void Play(string waveFile, dynamic playDevice, bool isSync)
        {
            if (_useYukkuri)
            {
                _plugin.TtsInjector.PlayTTSYukkuri(waveFile, playDevice, isSync);
            }
        }
    }
}
