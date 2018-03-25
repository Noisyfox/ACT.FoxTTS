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

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        public void Stop()
        {

        }

        public void Play(string waveFile, dynamic playDevice)
        {
            _plugin.TtsInjector.PlayTTSYukkuri(waveFile, playDevice);
        }
    }
}
