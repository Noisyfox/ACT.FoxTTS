using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;
using ACT.FoxCommon.update;
using ACT.FoxTTS.engine;
using ACT.FoxTTS.localization;

namespace ACT.FoxTTS
{
    public partial class FoxTTSTabControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;
        private MainController _controller;

        public FoxTTSTabControl()
        {
            InitializeComponent();

            comboBoxLanguage.DisplayMember = nameof(LanguageDef.DisplayName);
            comboBoxLanguage.ValueMember = nameof(LanguageDef.LangCode);
            comboBoxLanguage.DataSource = Localization.SupportedLanguages;
            comboBoxTTSEngine.DisplayMember = nameof(TTSEngineDef.DisplayName);
            comboBoxTTSEngine.ValueMember = nameof(TTSEngineDef.Name);

            labelCurrentVersionValue.Text = Assembly.GetCallingAssembly().GetName().Version.ToString();

            this.AdjustForDpiScaling();
        }

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
            var parentTabPage = plugin.ParentTabPage;

            parentTabPage.Controls.Add(this);
            parentTabPage.Resize += ParentTabPageOnResize;
            ParentTabPageOnResize(parentTabPage, null);

            var settings = plugin.Settings;
            // add settings
            settings.AddControlSetting(checkBoxCheckUpdate);
            settings.AddControlSetting(checkBoxNotifyStableOnly);

            _controller = plugin.Controller;

            comboBoxLanguage.SelectedIndexChanged += ComboBoxLanguageSelectedIndexChanged;

            _controller.SettingsLoaded += ControllerOnSettingsLoaded;
            _controller.LanguageChanged += ControllerOnLanguageChanged;
            _controller.LogMessageAppend += ControllerOnLogMessageAppend;
            _controller.UpdateCheckingStarted += ControllerOnUpdateCheckingStarted;
            _controller.VersionChecked += ControllerOnVersionChecked;
            _controller.TTSEngineChanged += ControllerOnTtsEngineChanged;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
            if (!UpdateChecker.IsEnabled)
            {
                // Hide update checker panel
                groupBoxUpdate.Visible = false;
            }
        }

        public void DoLocalization()
        {
            LocalizationBase.TranslateControls(this);

            comboBoxTTSEngine.DataSource = TTSEngineFactory.Engines;
            labelLatestStableVersionValue.Text = strings.versionUnknown;
            labelLatestVersionValue.Text = strings.versionUnknown;
        }

        private void ParentTabPageOnResize(object sender, EventArgs eventArgs)
        {
            Location = new Point(0, 0);
            Size = ((TabPage)sender).Size;
        }
        private void ComboBoxLanguageSelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.NotifyLanguageChanged(true, (string)comboBoxLanguage.SelectedValue);
        }

        private void buttonCheckUpdate_Click(object sender, EventArgs e)
        {
            _plugin.UpdateChecker.CheckUpdate(true);
        }

        private void buttonDownloadUpdate_Click(object sender, EventArgs e)
        {
            Process.Start(UpdateChecker.ReleasePage);
        }

        private void ControllerOnSettingsLoaded()
        {
            if (checkBoxCheckUpdate.Checked)
            {
                _plugin.UpdateChecker.CheckUpdate(false);
            }

            switch (_plugin.Settings.PluginIntegration)
            {
                case PluginIntegration.Act:
                    radioButtonIntegrationAct.Checked = true;
                    break;
                case PluginIntegration.Yukkuri:
                    radioButtonIntegrationYukkuri.Checked = true;
                    break;
                default:
                case PluginIntegration.Auto:
                    radioButtonIntegrationAuto.Checked = true;
                    break;
            }
            radioButtonIntegrationAuto.CheckedChanged += OnPluginIntegrationValueChanged;
            radioButtonIntegrationAct.CheckedChanged += OnPluginIntegrationValueChanged;
            radioButtonIntegrationYukkuri.CheckedChanged += OnPluginIntegrationValueChanged;

            var playbackSettings = _plugin.Settings.PlaybackSettings;
            trackBarMasterVolume.SetValue(playbackSettings.MasterVolume, 100);
            switch (playbackSettings.Method)
            {
                case PlaybackMethod.Act:
                    radioButtonPlaybackACT.Checked = true;
                    break;
                case PlaybackMethod.Yukkuri:
                    radioButtonPlaybackYukkuri.Checked = true;
                    break;
                default:
                case PlaybackMethod.BuiltIn:
                    radioButtonPlaybackBuiltIn.Checked = true;
                    break;
            }
            comboBoxPlaybackApi.SelectedIndex = (int) playbackSettings.Api;
            radioButtonPlaybackACT.CheckedChanged += OnPlaybackValueChanged;
            radioButtonPlaybackYukkuri.CheckedChanged += OnPlaybackValueChanged;
            radioButtonPlaybackBuiltIn.CheckedChanged += OnPlaybackValueChanged;
            trackBarMasterVolume.ValueChanged += OnPlaybackValueChanged;
            comboBoxPlaybackApi.SelectedIndexChanged += OnPlaybackValueChanged;

            OnPluginIntegrationValueChanged(null, EventArgs.Empty);
            OnPlaybackValueChanged(null, EventArgs.Empty);
        }

        private void ControllerOnLanguageChanged(bool fromView, string lang)
        {
            if (fromView)
            {
                return;
            }
            var ld = LocalizationBase.GetLanguage(lang);
            _controller.NotifyLanguageChanged(true, ld.LangCode);
            comboBoxLanguage.SelectedValue = ld.LangCode;
        }

        private void ControllerOnLogMessageAppend(bool fromView, string log)
        {
            richTextBoxLog.AppendDateTimeLine(log);
        }
        private void ControllerOnUpdateCheckingStarted(bool fromView)
        {
            if (InvokeRequired)
            {
                this.SafeInvoke(new Action(delegate
                {
                    ControllerOnUpdateCheckingStarted(fromView);
                }));
            }
            else
            {
                labelLatestStableVersionValue.Text = strings.updateChecking;
                labelLatestVersionValue.Text = strings.updateChecking;
            }
        }

        private void ControllerOnVersionChecked(bool fromView, VersionInfo versionInfo, bool forceNotify)
        {
            if (InvokeRequired)
            {
                this.SafeInvoke(new Action(delegate
                {
                    ControllerOnVersionChecked(fromView, versionInfo, forceNotify);
                }));
            }
            else
            {
                var stable = versionInfo?.LatestStableVersion?.ParsedVersion;
                var latest = versionInfo?.LatestVersion?.ParsedVersion;

                labelLatestStableVersionValue.Text = stable != null ? stable.ToString() : strings.versionUnknown;
                labelLatestVersionValue.Text = latest != null ? latest.ToString() : strings.versionUnknown;

                var stableOnly = checkBoxNotifyStableOnly.Checked;
                if (stableOnly)
                {
                    ShowUpdateResult(IsNewVersion(versionInfo?.LatestStableVersion), forceNotify);
                }
                else
                {
                    ShowUpdateResult(IsNewVersion(versionInfo?.LatestVersion), forceNotify);
                }
            }
        }

        private void ControllerOnTtsEngineChanged(bool fromView, string engine)
        {
            if (fromView)
            {
                return;
            }

            comboBoxPlaybackApi.SelectedValue = engine;
        }

        private PublishVersion IsNewVersion(PublishVersion newVersion)
        {
            if (newVersion == null)
            {
                return null;
            }
            var currentVersion = Assembly.GetCallingAssembly().GetName().Version;

            var v = newVersion.ParsedVersion;
            if (currentVersion.Revision == 0)
            {
                // Local build, no revision
                v = new Version(v.Major, v.Minor, v.Build);
            }

            return v > currentVersion ? newVersion : null;
        }

        private void ShowUpdateResult(PublishVersion newVersion, bool forceNotify)
        {
            if (newVersion == null)
            {
                if (forceNotify)
                {
                    MessageBox.Show(strings.messageLatest, strings.actPanelTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                // Check if ignored
                if (forceNotify ||
                    !Version.TryParse(_plugin.Settings.VersionIgnored, out var v) ||
                    v < newVersion.ParsedVersion)
                {
                    // Show notify
                    var message = string.Format(newVersion.IsPreRelease
                            ? strings.messageNewPrerelease
                            : strings.messageNewStable,
                        newVersion.ParsedVersion);

                    MessageBoxManager.Yes = strings.buttonUpdateNow;
                    MessageBoxManager.No = strings.buttonIgnoreVersion;
                    MessageBoxManager.Cancel = strings.buttonUpdateLater;
                    MessageBoxManager.Register();
                    var res = MessageBox.Show(message, strings.actPanelTitle, MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    MessageBoxManager.Unregister();

                    if (res == DialogResult.No)
                    {
                        _controller.NotifyNewVersionIgnored(true, newVersion.ParsedVersion.ToString());
                    }
                    else if (res == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(newVersion.PublishPage);
                    }
                }
            }
        }

        private void comboBoxTTSEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.NotifyTTSEngineChanged(true, (string)comboBoxTTSEngine.SelectedValue);
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            Task.Run(() => _plugin.Speak(textBoxPreview.Text, 0));
        }

        private void linkLabelOpenCacheDir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(Utils.CacheDirectory))
            {
                Process.Start(Utils.CacheDirectory);
            }
        }

        private void linkLabelClearCache_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(Utils.CacheDirectory))
            {
                var result = MessageBox.Show(
                    strings.messageAskClearCache,
                    strings.actPanelTitle,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (result != DialogResult.OK)
                {
                    return;
                }

                Task.Run(() =>
                {
                    foreach (var file in Directory.GetFiles(
                        Utils.CacheDirectory,
                        "*",
                        SearchOption.TopDirectoryOnly))
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            _controller.NotifyLogMessageAppend(true, ex.ToString());
                        }
                    }
                }).Wait();

                MessageBox.Show(
                    strings.messageCacheCleared,
                    strings.actPanelTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void OnPluginIntegrationValueChanged(object sender, EventArgs e)
        {
            var settings = _plugin.Settings;
            if (radioButtonIntegrationAct.Checked)
            {
                settings.PluginIntegration = PluginIntegration.Act;
            }
            else if (radioButtonIntegrationYukkuri.Checked)
            {
                settings.PluginIntegration = PluginIntegration.Yukkuri;
            }
            else
            {
                settings.PluginIntegration = PluginIntegration.Auto;
            }
        }

        private void OnPlaybackValueChanged(object sender, EventArgs e)
        {
            var settings = _plugin.Settings.PlaybackSettings;
            settings.MasterVolume = trackBarMasterVolume.Value;
            labelCurrentVolume.Text = settings.MasterVolume.ToString();

            if (radioButtonPlaybackACT.Checked)
            {
                settings.Method = PlaybackMethod.Act;

                trackBarMasterVolume.Enabled = true;
                comboBoxPlaybackApi.Enabled = false;
                comboBoxPlaybackDevice.Enabled = false;
            }
            else if (radioButtonPlaybackYukkuri.Checked)
            {
                settings.Method = PlaybackMethod.Yukkuri;

                trackBarMasterVolume.Enabled = false;
                comboBoxPlaybackApi.Enabled = false;
                comboBoxPlaybackDevice.Enabled = false;
            }
            else
            {
                settings.Method = PlaybackMethod.BuiltIn;

                trackBarMasterVolume.Enabled = false;
                comboBoxPlaybackApi.Enabled = true;
                comboBoxPlaybackDevice.Enabled = false;
            }

            settings.Api = (PlaybackApi) comboBoxPlaybackApi.SelectedIndex;
        }
    }
}
