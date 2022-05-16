namespace ACT.FoxTTS.playback
{
    public class SoundPlayerWrapper : IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        private WMMPlayback _wmm = new WMMPlayback();
        private ACTPlayback _act = new ACTPlayback();
        private YukkuriPlayback _yukkuri = new YukkuriPlayback();

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
            _wmm.AttachToAct(plugin);
            _act.AttachToAct(plugin);
            _yukkuri.AttachToAct(plugin);
        }


        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
            _wmm.PostAttachToAct(plugin);
            _act.PostAttachToAct(plugin);
            _yukkuri.PostAttachToAct(plugin);
        }

        public void Stop()
        {
            _wmm.Stop();
            _act.Stop();
            _yukkuri.Stop();
        }

        public void Play(string waveFile)
        {
            PlaybackSettings settings = _plugin.Settings.PlaybackSettings;
            switch (settings.Method)
            {
                case PlaybackMethod.Yukkuri:
                    _yukkuri.Play(waveFile, settings.MasterVolume, null);
                    break;
                case PlaybackMethod.Act:
                    // Play sound with ACT's sound API
                    _act.Play(waveFile, settings.MasterVolume, null);
                    break;
                case PlaybackMethod.BuiltIn:
                    // Use built-in api to play sounds
                    // atm we support WMM only
                    _wmm.Play(waveFile, settings.MasterVolume, null);
                    break;
            }
        }
    }
}
