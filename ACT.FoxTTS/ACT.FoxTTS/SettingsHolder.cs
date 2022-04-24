using System.Windows.Forms;
using System.Xml.Serialization;
using ACT.FoxCommon.core;
using ACT.FoxTTS.engine.baidu;
using ACT.FoxTTS.engine.baipiao;
using ACT.FoxTTS.engine.cafe;
using ACT.FoxTTS.engine.edge;
using ACT.FoxTTS.engine.google_unofficial;
using ACT.FoxTTS.engine.sapi5;
using ACT.FoxTTS.engine.xfyun;
using ACT.FoxTTS.engine.youdao;
using ACT.FoxTTS.preprocess;
using Advanced_Combat_Tracker;

namespace ACT.FoxTTS
{
    /// <summary>
    /// https://github.com/anoyetta/act_timeline/blob/origin/src/PluginSettings.cs
    /// </summary>
    internal class PluginSettings : SettingsSerializer
    {
        private readonly SettingsIO _settingsIo = new SettingsIO("ACT.FoxTTS");
        
        public PlaybackSettings Playback = new PlaybackSettings();
        public PreProcessorSettings PreProcessorSettings = new PreProcessorSettings();
        public CafeTTSSettings CafeTtsSettings = new CafeTTSSettings();
        public BaiduTTSSettings BaiduTtsSettings = new BaiduTTSSettings();
        public SAPI5Settings SApi5Settings = new SAPI5Settings();
        public BaipiaoSettings BaipiaoSettings = new BaipiaoSettings();
        public EdgeTTSSettings EdgeTtsSettings = new EdgeTTSSettings();
        public GoogleUnofficialTTSSettings GoogleUnofficialTtsSettings = new GoogleUnofficialTTSSettings();
        public YoudaoTTSSettings YoudaoTtsSettings = new YoudaoTTSSettings();
        public XfyunTTSSettings XfyunTtsSettings = new XfyunTTSSettings();

        public PluginSettings(object ParentSettingsClass) : base(ParentSettingsClass)
        {
            _settingsIo.WriteSettings = writer =>
            {
                writer.WriteStartElement("SettingsSerializer");
                ExportToXml(writer);
                writer.WriteEndElement();

                writer.Serialize(Playback);
                writer.Serialize(PreProcessorSettings);
                writer.Serialize(CafeTtsSettings);
                writer.Serialize(BaiduTtsSettings);
                writer.Serialize(SApi5Settings);
                writer.Serialize(BaipiaoSettings);
                writer.Serialize(EdgeTtsSettings);
                writer.Serialize(GoogleUnofficialTtsSettings);
                writer.Serialize(YoudaoTtsSettings);
                writer.Serialize(XfyunTtsSettings);
            };

            _settingsIo.ReadSettings = reader =>
            {
                switch (reader.LocalName)
                {
                    case "SettingsSerializer":
                        ImportFromXml(reader);
                        break;
                    case nameof(PlaybackSettings):
                        Playback = reader.Deserialize<PlaybackSettings>();
                        break;
                    case nameof(preprocess.PreProcessorSettings):
                        PreProcessorSettings = reader.Deserialize<PreProcessorSettings>();
                        break;
                    case nameof(CafeTTSSettings):
                        CafeTtsSettings = reader.Deserialize<CafeTTSSettings>();
                        break;
                    case nameof(BaiduTTSSettings):
                        BaiduTtsSettings = reader.Deserialize<BaiduTTSSettings>();
                        BaiduTtsSettings.RemoveFreeKey();
                        break;
                    case nameof(SAPI5Settings):
                        SApi5Settings = reader.Deserialize<SAPI5Settings>();
                        break;
                    case nameof(engine.baipiao.BaipiaoSettings):
                        BaipiaoSettings = reader.Deserialize<BaipiaoSettings>();
                        break;
                    case nameof(EdgeTTSSettings):
                        EdgeTtsSettings = reader.Deserialize<EdgeTTSSettings>();
                        break;
                    case nameof(GoogleUnofficialTTSSettings):
                        GoogleUnofficialTtsSettings = reader.Deserialize<GoogleUnofficialTTSSettings>();
                        break;
                    case nameof(YoudaoTTSSettings):
                        YoudaoTtsSettings = reader.Deserialize<YoudaoTTSSettings>();
                        break;
                    case nameof(XfyunTTSSettings):
                        XfyunTtsSettings = reader.Deserialize<XfyunTTSSettings>();
                        break;
                }
            };
        }

        public void Load()
        {
            _settingsIo.Load();
        }

        public void Save()
        {
            _settingsIo.Save();
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
        Act,
        BuiltIn, // Use built in playback apis
    }

    public enum PlaybackApi : int
    {
        WinMM = 0,
    }

    public class PlaybackSettings
    {
        [XmlElement]
        public PlaybackMethod Method = PlaybackMethod.Act;

        [XmlElement]
        public int MasterVolume = 100;

        [XmlElement]
        public PlaybackApi Api = PlaybackApi.WinMM;
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

        public PreProcessorSettings PreProcessorSettings => Settings.PreProcessorSettings;

        public CafeTTSSettings CafeTtsSettings => Settings.CafeTtsSettings;

        public BaiduTTSSettings BaiduTtsSettings => Settings.BaiduTtsSettings;

        public SAPI5Settings SApi5Settings => Settings.SApi5Settings;

        public BaipiaoSettings BaipiaoSettings => Settings.BaipiaoSettings;

        public EdgeTTSSettings EdgeTtsSettings => Settings.EdgeTtsSettings;

        public GoogleUnofficialTTSSettings GoogleUnofficialTtsSettings => Settings.GoogleUnofficialTtsSettings;

        public YoudaoTTSSettings YoudaoTtsSettings => Settings.YoudaoTtsSettings;

        public XfyunTTSSettings XfyunTtsSettings => Settings.XfyunTtsSettings;

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
