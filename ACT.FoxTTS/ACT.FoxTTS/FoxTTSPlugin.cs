using System;
using System.Windows.Forms;
using ACT.FoxCommon.core;
using ACT.FoxTTS.engine;
using ACT.FoxTTS.localization;
using ACT.FoxTTS.preprocess;

namespace ACT.FoxTTS
{
    public class FoxTTSPlugin : PluginBase<MainController>
    {
        private bool _settingsLoaded = false;

        public SettingsHolder Settings { get; private set; }
        public TabPage ParentTabPage { get; private set; }
        public Panel EngineSettingsPanel => SettingsTab.panelTTSEngineSettings;
        public Label StatusLabel { get; private set; }
        public FoxTTSTabControl SettingsTab { get; private set; }
        public PreProcessor PreProcessor { get; } = new PreProcessor();
        public TTSInjector TtsInjector { get; } = new TTSInjector();
        public SoundPlayerWrapper SoundPlayer { get; } = new SoundPlayerWrapper();

        private ITTSEngine TtsEngine
        {
            get
            {
                lock (this)
                {
                    return _ttsEngine;
                }
            }
        }
        private ITTSEngine _ttsEngine;

        internal UpdateChecker UpdateChecker { get; } = new UpdateChecker();

        public override void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            _settingsLoaded = false;
            ParentTabPage = pluginScreenSpace;
            StatusLabel = pluginStatusText;
            ParentTabPage.Text = "Fox TTS";

            try
            {
                Controller = new MainController();
                Settings = new SettingsHolder();

                Settings.AttachToAct(this);

                SettingsTab = new FoxTTSTabControl();
                SettingsTab.AttachToAct(this);

                PreProcessor.AttachToAct(this);
                UpdateChecker.AttachToAct(this);
                SoundPlayer.AttachToAct(this);
                TtsInjector.AttachToAct(this);

                Controller.TTSEngineChanged += ControllerOnTtsEngineChanged;

                Settings.PostAttachToAct(this);
                SettingsTab.PostAttachToAct(this);
                PreProcessor.PostAttachToAct(this);
                UpdateChecker.PostAttachToAct(this);
                SoundPlayer.PostAttachToAct(this);
                TtsInjector.PostAttachToAct(this);

                Settings.Load();
                _settingsLoaded = true;

                DoLocalization();

                Settings.NotifySettingsLoaded();

                TtsInjector.StartWorkingThread(this);

                StatusLabel.Text = "Init Success. >w<";
            }
            catch (SettingsNotLoadException ex)
            {
                StatusLabel.Text = "Init Failed: " + ex;
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Init Failed: " + ex;
                if (_settingsLoaded)
                {
                    MessageBox.Show($"Init failed!\nCaused by:\n{ex}");
                }
                else
                {
                    MessageBox.Show($"Init failed before settings are loaded. Settings won't be saved until next successfully initialization to prevent settings lost!\nCaused by:\n{ex}");
                }
            }
        }

        private void DoLocalization()
        {
            Controller.NotifyLanguageChanged(false, Settings.Language);

            Localization.ConfigLocalization(Settings.Language);

            ParentTabPage.Text = strings.actPanelTitle;
            SettingsTab.DoLocalization();
        }

        public override void DeInitPlugin()
        {
            Controller.TTSEngineChanged -= ControllerOnTtsEngineChanged;
            TtsInjector.Stop();
            SoundPlayer.Stop();
            UpdateChecker.Stop();

            lock (this)
            {
                _ttsEngine?.Stop();
                _ttsEngine = null;
            }

            if (_settingsLoaded)
            {
                Settings?.Save();
            }

            StatusLabel.Text = "Exited. Bye~";
        }

        private void ControllerOnTtsEngineChanged(bool fromView, string engine)
        {
            Controller.NotifyLogMessageAppend(fromView, $"TTSEngine Changed: fromView = {fromView}, engine = {engine}");
            lock (this)
            {
                _ttsEngine?.Stop();
                _ttsEngine = null;
                _ttsEngine = TTSEngineFactory.CreateEngine(engine);
                _ttsEngine.AttachToAct(this);
                _ttsEngine.PostAttachToAct(this);
            }
        }

        public void Speak(string text, dynamic playDevice, bool isSync = false, float? volume = null)
        {
            try
            {
                var processed = PreProcessor.Process(text);
                TtsEngine?.Speak(processed, playDevice, isSync, volume);
            }
            catch (Exception ex)
            {
                Controller.NotifyLogMessageAppend(false, ex.ToString());
            }
        }
    }

    public interface IPluginComponent : IPluginComponentBase<MainController, FoxTTSPlugin>
    {
    }
}
