using System;
using System.Collections.Generic;
using System.IO;
using NAudio.Wave;

namespace ACT.FoxTTS.playback
{
    public abstract class NAudioPlayerBase : IPlayer
    {
        public void AttachToAct(FoxTTSPlugin plugin)
        {
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        public abstract string Name { get; }

        public bool SupportVolumeControl => true;

        public void Stop()
        {
        }

        public void Play(string file, int volume, string deviceId)
        {
            if (!File.Exists(file))
            {
                return;
            }


            AudioFileReader audio = null;
            IWavePlayer player = null;
            try
            {
                audio = new AudioFileReader(file) {Volume = volume / 100f};
                player = CreateWavePlayer(deviceId);
                var session = new PlayerSession
                {
                    Reader = audio,
                    Player = player,
                };
                player.Init(audio);
                player.PlaybackStopped += delegate { session.Dispose(); };
                player.Play();
            }
            catch (Exception)
            {
                audio?.Dispose();
                player?.Dispose();
                throw;
            }
        }

        protected abstract IWavePlayer CreateWavePlayer(string deviceId);

        public abstract List<Device> ListDevices();

        private class PlayerSession: IDisposable
        {
            public AudioFileReader Reader;
            public IWavePlayer Player;

            public void Dispose()
            {
                Reader?.Dispose();
                Player?.Dispose();
            }
        }
    }
}
