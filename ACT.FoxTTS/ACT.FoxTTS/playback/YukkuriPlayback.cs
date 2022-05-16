using System.Collections.Generic;

namespace ACT.FoxTTS.playback
{
    public class YukkuriPlayback : IPlayer
    {
        private FoxTTSPlugin _plugin;

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        public string Name => SoundPlayerWrapper.PlayerYukurri;

        public bool SupportVolumeControl => false;

        public bool SupportSessionControl => false;

        public void Stop()
        {
        }

        public void Play(string file, int volume, string deviceId)
        {
            _plugin.TtsInjector.PlayTTSYukkuri(file, null, false, null);
        }

        public List<Device> ListDevices() => null;
    }
}
