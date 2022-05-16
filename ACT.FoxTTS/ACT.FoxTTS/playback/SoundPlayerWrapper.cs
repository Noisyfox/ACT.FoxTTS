using ACT.FoxCommon.logging;

namespace ACT.FoxTTS.playback
{
    public class SoundPlayerWrapper : IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public IPlayer CurrentPlayer { get; private set; }

        public const string ApiWinMM = "WinMM";

        public static readonly string[] Apis =
        {
            "WinMM",
            "DirectSound",
            "WaveOut",
            "WASAPI",
        };

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
        }

        public void SelectPlayer(string player)
        {
            lock (this)
            {
                if (CurrentPlayer == null || CurrentPlayer.Name != player)
                {
                    CurrentPlayer?.Stop();

                    switch (player)
                    {
                        case "ACT": CurrentPlayer = new ACTPlayback(); break;
                        case "Yukurri": CurrentPlayer = new YukkuriPlayback(); break;
                        case "DirectSound": CurrentPlayer = new DirectSoundPlayback(); break;
                        case "WaveOut": CurrentPlayer = new WaveOutPlayback(); break;
                        case "WASAPI": CurrentPlayer = new WASAPIPlayback(); break;
                        case "WinMM": default: CurrentPlayer = new WMMPlayback(); break;
                    }
                    CurrentPlayer.AttachToAct(_plugin);
                    CurrentPlayer.PostAttachToAct(_plugin);
                    _plugin.Controller.NotifyPlayerChanged(false, player);
                }
            }
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        public void Stop()
        {
            CurrentPlayer?.Stop();
        }

        public void Play(string waveFile)
        {
            PlaybackSettings settings = _plugin.Settings.PlaybackSettings;
            CurrentPlayer?.Play(waveFile, settings.MasterVolume, settings.Device);
        }
    }
}
