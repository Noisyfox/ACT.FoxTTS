using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Combat_Tracker;

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

        public void Play(string waveFile, dynamic playDevice, bool isSync, float? volume)
        {
            PlaybackSettings settings = _plugin.Settings.PlaybackSettings;
            switch (settings.Method)
            {
                case PlaybackMethod.Yukkuri:
                    _plugin.TtsInjector.PlayTTSYukkuri(waveFile, playDevice, isSync, volume);
                    break;
                case PlaybackMethod.Act:
                    // Play sound with ACT's sound API
                    ActGlobals.oFormActMain.PlaySoundWmpApi(waveFile, settings.MasterVolume);
                    break;
            }
        }
    }
}
