using System;
using ACT.FoxCommon;
using ACT.FoxTTS.playback;
using Advanced_Combat_Tracker;

namespace ACT.FoxTTS
{
    public class SoundPlayerWrapper : IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        private WMMPlayback _wmm = new WMMPlayback();

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
            _wmm.AttachToAct(plugin);
        }


        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
            _wmm.PostAttachToAct(plugin);
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
                case PlaybackMethod.BuiltIn:
                    // Use built-in api to play sounds
                    // atm we support WMM only
                    // And WMM needs to be called in main thread
                    ActGlobals.oFormActMain.SafeInvoke(new Action(() => _wmm.PlaySound(waveFile, settings.MasterVolume)));
                    break;
            }
        }
    }
}
