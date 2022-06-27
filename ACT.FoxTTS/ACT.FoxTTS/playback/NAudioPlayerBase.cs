using System;
using System.Collections.Generic;
using System.IO;
using ACT.FoxCommon.logging;
using NAudio.Wave;

namespace ACT.FoxTTS.playback
{
    public abstract class NAudioPlayerBase : IPlayer
    {
        protected FoxTTSPlugin _plugin;

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        public abstract string Name { get; }

        public bool SupportVolumeControl => true;

        public bool SupportVolumeBoost => true;

        public bool SupportSessionControl => true;

        private List<PlayerSession> _sessions = new List<PlayerSession>();

        private void CloseSession(PlayerSession session)
        {
            var didDispose = false;
            lock (session)
            {
                if (!session.Disposed)
                {
                    session.Disposed = true;
                    didDispose = true;
                }
            }

            if (didDispose)
            {
                session.Dispose();
                lock (_sessions)
                {
                    _sessions.Remove(session);
                }
            }
        }

        public void Stop()
        {
            StopAllSessions();
        }

        private void StopAllSessions()
        {
            lock (_sessions)
            {
                var s = new List<PlayerSession>(_sessions);
                _sessions.Clear();

                foreach (var session in s)
                {
                    CloseSession(session);
                }
            }
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

                if (Logger.IsDebugLevelEnabled)
                {
                    // find the max peak
                    float max = 0;
                    float[] buffer = new float[audio.WaveFormat.SampleRate];
                    int read;
                    do
                    {
                        read = audio.Read(buffer, 0, buffer.Length);
                        for (int n = 0; n < read; n++)
                        {
                            var abs = Math.Abs(buffer[n]);
                            if (abs > max) max = abs;
                        }
                    } while (read > 0);

                    Logger.Debug($"Max sample value: {max}");

                    audio.Position = 0;
                }

                player = CreateWavePlayer(deviceId);
                var session = new PlayerSession
                {
                    Reader = audio,
                    Player = player,
                };
                player.Init(audio);
                player.PlaybackStopped += delegate
                {
                    CloseSession(session);
                };
                lock (_sessions)
                {
                    if (_plugin.Settings.PlaybackSettings.StopPrevious)
                    {
                        StopAllSessions();
                        _sessions.Add(session);
                    }
                }

                player.Play();
            }
            catch (Exception)
            {
                player?.Dispose();
                audio?.Dispose();
                throw;
            }
        }

        protected abstract IWavePlayer CreateWavePlayer(string deviceId);

        public abstract List<Device> ListDevices();

        private class PlayerSession: IDisposable
        {
            public bool Disposed = false;
            public AudioFileReader Reader;
            public IWavePlayer Player;

            public void Dispose()
            {
                Player.Dispose();
                Reader.Dispose();
            }
        }
    }
}
