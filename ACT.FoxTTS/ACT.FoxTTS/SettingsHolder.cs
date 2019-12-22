using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using ACT.FoxTTS.engine.baidu;
using Advanced_Combat_Tracker;

namespace ACT.FoxTTS
{
    /// <summary>
    /// https://github.com/anoyetta/act_timeline/blob/origin/src/PluginSettings.cs
    /// </summary>
    internal class PluginSettings : SettingsSerializer
    {
        private readonly string _settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName,
            "Config\\ACT.FoxTTS.config.xml");

        public PluginSettings(object ParentSettingsClass) : base(ParentSettingsClass)
        {
        }

        public PlaybackSettings Playback = new PlaybackSettings();
        public BaiduTTSSettings BaiduTtsSettings = new BaiduTTSSettings();

        public void Load()
        {
            if (File.Exists(_settingsFile))
            {
                FileStream fs = new FileStream(_settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                XmlTextReader reader = new XmlTextReader(fs);
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    switch (reader.LocalName)
                    {
                        case "SettingsSerializer":
                            ImportFromXml(reader);
                            break;
                        case nameof(PlaybackSettings):
                            Playback = Deserialize<PlaybackSettings>(reader);
                            break;
                        case nameof(BaiduTTSSettings):
                            BaiduTtsSettings = Deserialize<BaiduTTSSettings>(reader);
                            break;
                    }
                }

                reader.Close();
            }
        }

        public void Save()
        {
            FileStream stream = new FileStream(_settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 1;
            writer.IndentChar = '\t';
            writer.WriteStartDocument(true);
            writer.WriteStartElement("Config");
            writer.WriteStartElement("SettingsSerializer");
            ExportToXml(writer);
            writer.WriteEndElement();

            Serialize(writer, Playback);
            Serialize(writer, BaiduTtsSettings);

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
        }

        private static void Serialize<T>(XmlTextWriter writer, T obj) where T : class
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, obj, ns);
        }

        private static T Deserialize<T>(XmlTextReader reader) where T : class
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return serializer.Deserialize(reader) as T;
        }
    }

    public enum PluginIntegration: int
    {
        Auto = 0,
        Act,
        Yukkuri
    }

    public enum PlaybackMethod
    {
        Yukkuri,
        Act
    }

    public class PlaybackSettings
    {
        [XmlElement]
        public PlaybackMethod Method = PlaybackMethod.Act;

        [XmlElement]
        public int MasterVolume = 100;
    }

    public class SettingsHolder : IPluginComponent
    {
        #region Proxy methods

        private PluginSettings Settings { get; }

        public SettingsHolder()
        {
            Settings = new PluginSettings(this);
        }

        public void AddControlSetting(Control controlToSerialize)
        {
            Settings.AddControlSetting(controlToSerialize.Name, controlToSerialize);
        }

        public void Load()
        {
            Settings.Load();
        }

        public void Save()
        {
            Settings.Save();
        }

        #endregion

        #region Settings

        public string Language { get; set; }

        public string VersionIgnored { get; set; }

        public PluginIntegration PluginIntegration { get; set; } = PluginIntegration.Auto;

        public PlaybackSettings PlaybackSettings => Settings.Playback;

        public BaiduTTSSettings BaiduTtsSettings => Settings.BaiduTtsSettings;

        public string TTSEngine { get; set; }
        
        #endregion

        #region Controller notify

        private MainController _controller;

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            Settings.AddStringSetting(nameof(Language));
            Settings.AddStringSetting(nameof(VersionIgnored));
            Settings.AddStringSetting(nameof(TTSEngine));
            Settings.AddIntSetting(nameof(PluginIntegration));

            _controller = plugin.Controller;

            _controller.LanguageChanged += ControllerOnLanguageChanged;
            _controller.NewVersionIgnored += ControllerOnNewVersionIgnored;
            _controller.TTSEngineChanged += ControllerOnTtsEngineChanged;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {

        }

        public void NotifySettingsLoaded()
        {
            _controller.NotifySettingsLoaded();
        }

        private void ControllerOnLanguageChanged(bool fromView, string lang)
        {
            if (!fromView)
            {
                return;
            }

            Language = lang;
        }

        private void ControllerOnNewVersionIgnored(bool fromView, string ignoredVersion)
        {
            VersionIgnored = ignoredVersion;
        }

        private void ControllerOnTtsEngineChanged(bool fromView, string engine)
        {
            if (!fromView)
            {
                return;
            }

            TTSEngine = engine;
        }

        #endregion
    }
}
