using ACT.FoxCommon.logging;

namespace ACT.FoxTTS.playback
{
    public class SoundPlayerWrapper : IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public IPlayer CurrentPlayer { get; private set; }

        public const string PlayerACT = "ACT";
        public const string PlayerYukurri = "Yukurri";
        public const string PlayerWASAPI = "WASAPI";
        public const string PlayerDirectSound = "DirectSound";
        public const string PlayerWaveOut = "WaveOut";
        public const string PlayerWinMM = "WinMM";

        public static readonly string[] Apis =
        {
            PlayerWASAPI,
            PlayerDirectSound,
            PlayerWaveOut,
            PlayerWinMM,
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
                        case PlayerACT:
                            CurrentPlayer = new ACTPlayback();
                            break;
                        case PlayerYukurri:
                            CurrentPlayer = new YukkuriPlayback();
                            break;
                        case PlayerDirectSound:
                            CurrentPlayer = new DirectSoundPlayback();
                            break;
                        case PlayerWaveOut:
                            CurrentPlayer = new WaveOutPlayback();
                            break;
                        case PlayerWinMM:
                            CurrentPlayer = new WMMPlayback();
                            break;
                        case PlayerWASAPI:
                        default:
                            CurrentPlayer = new WASAPIPlayback();
                            break;
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
