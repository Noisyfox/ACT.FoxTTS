using System;
using System.Windows.Forms;
using ACT.FoxCommon.core;
using ACT.FoxTTS.localization;

namespace ACT.FoxTTS
{
    public class FoxTTSPlugin : PluginBase<MainController>
    {
        private bool _settingsLoaded = false;

        public SettingsHolder Settings { get; private set; }
        public TabPage ParentTabPage { get; private set; }
        public Label StatusLabel { get; private set; }
        public FoxTTSTabControl SettingsTab { get; private set; }
        private TTSInjector _ttsInjector = new TTSInjector();

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
                
                UpdateChecker.AttachToAct(this);
                _ttsInjector.AttachToAct(this);

                Settings.PostAttachToAct(this);
                SettingsTab.PostAttachToAct(this);
                UpdateChecker.PostAttachToAct(this);
                _ttsInjector.PostAttachToAct(this);

                Settings.Load();
                _settingsLoaded = true;

                DoLocalization();

                Settings.NotifySettingsLoaded();

                _ttsInjector.StartWorkingThread(this);

                StatusLabel.Text = "Init Success. >w<";
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
            _ttsInjector.Stop();
            UpdateChecker.Stop();

            if (_settingsLoaded)
            {
                Settings?.Save();
            }

            StatusLabel.Text = "Exited. Bye~";
        }
    }

    public interface IPluginComponent : IPluginComponentBase<MainController, FoxTTSPlugin>
    {
    }
}
