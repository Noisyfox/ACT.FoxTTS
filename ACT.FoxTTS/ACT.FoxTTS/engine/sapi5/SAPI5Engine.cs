using System;
using System.IO;
using System.Speech.Synthesis;

namespace ACT.FoxTTS.engine.sapi5
{
    class SAPI5Engine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        public string Name => "SAPI5";

        public void Stop()
        {
        }

        public void Speak(string text, dynamic playDevice, bool isSync, float? volume)
        {
            // Calculate hash
            var wave = this.GetCacheFileName(text.Replace(Environment.NewLine, "+"), "wav", "");

            lock (this)
            {
                if (!File.Exists(wave))
                {
                    using (var fileStream = new FileStream(
                        wave,
                        FileMode.OpenOrCreate,
                        FileAccess.Write,
                        FileShare.ReadWrite
                    ))
                    {
                        using (var speechSynthesizer = new SpeechSynthesizer())
                        {
                            fileStream.SetLength(0L);
                            speechSynthesizer.SetOutputToWaveStream(fileStream);
                            speechSynthesizer.Speak(text);
                            fileStream.Flush();
                        }
                    }
                }
            }

            _plugin.SoundPlayer.Play(wave, playDevice, isSync, volume);
        }
    }
}
