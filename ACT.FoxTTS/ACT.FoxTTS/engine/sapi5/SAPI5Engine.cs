using System;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Xml;
using ACT.FoxCommon.logging;

namespace ACT.FoxTTS.engine.sapi5
{
    class SAPI5Engine : ITTSEngine
    {
        private FoxTTSPlugin _plugin;
        private readonly SAPI5SettingsControl _settingsControl = new SAPI5SettingsControl();

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
            _settingsControl.AttachToAct(plugin);
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
            _settingsControl.PostAttachToAct(plugin);

            _settingsControl.DoLocalization();
        }

        public string Name => "SAPI5";

        public void Stop()
        {
            _settingsControl.RemoveFromAct();
        }

        private static string ToMarkupValue(Pitches pitch)
        {
            switch (pitch)
            {
                case Pitches.Default:
                    return "default";
                case Pitches.XLow:
                    return "x-low";
                case Pitches.Low:
                    return "low";
                case Pitches.Medium:
                    return "medium";
                case Pitches.High:
                    return "high";
                case Pitches.XHigh:
                    return "x-high";
                default:
                    throw new ArgumentOutOfRangeException(nameof(pitch), pitch, null);
            }
        }

        public void Speak(string text, dynamic playDevice, bool isSync, float? volume)
        {
            var settings = _plugin.Settings.SApi5Settings;

            // Calculate hash
            var wave = _plugin.Cache.GetOrCreateFile(
                this,
                text,
                "wav",
                settings.ToString(),
                f =>
                {
                    using (var fileStream = new FileStream(
                        f,
                        FileMode.OpenOrCreate,
                        FileAccess.Write,
                        FileShare.ReadWrite
                    ))
                    {
                        using (var speechSynthesizer = new SpeechSynthesizer())
                        {
                            // Get the selected voice
                            var voice = speechSynthesizer.GetInstalledVoices()
                                .FirstOrDefault(it => it.VoiceInfo.Id.ToLower() == settings.Voice);
                            if (voice == null)
                            {
                                Logger.Error($"Unable to find voice {settings.Voice}");
                                return;
                            }

                            speechSynthesizer.SelectVoice(voice.VoiceInfo.Name);
                            speechSynthesizer.Rate = settings.Rate;
                            speechSynthesizer.Volume = settings.Volume;

                            // Generate markup like "<prosody pitch="default">some text</prosody>"
                            var writer = new StringWriter();
                            using (var xmlTextWriter = new XmlTextWriter(writer))
                            {
                                xmlTextWriter.WriteStartElement("prosody");
                                xmlTextWriter.WriteAttributeString("pitch", ToMarkupValue(settings.Pitch));
                                xmlTextWriter.WriteString(text);
                                xmlTextWriter.WriteEndElement();
                                xmlTextWriter.Flush();
                            }

                            var content = writer.ToString();

                            var pb = new PromptBuilder(voice.VoiceInfo.Culture);
                            pb.StartVoice(voice.VoiceInfo);
                            pb.AppendSsmlMarkup(content);
                            pb.EndVoice();

                            fileStream.SetLength(0L);
                            speechSynthesizer.SetOutputToWaveStream(fileStream);
                            speechSynthesizer.Speak(pb);
                            fileStream.Flush();
                        }
                    }
                });

            _plugin.SoundPlayer.Play(wave, playDevice, isSync, volume);
        }
    }
}
