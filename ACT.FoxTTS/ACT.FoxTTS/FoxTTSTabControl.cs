using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.localization;
using ACT.FoxCommon.update;
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

            labelCurrentVersionValue.Text = Assembly.GetCallingAssembly().GetName().Version.ToString();
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
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        public void DoLocalization()
        {
            LocalizationBase.TranslateControls(this);

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
            System.Diagnostics.Process.Start(UpdateChecker.ReleasePage);
        }

        private void ControllerOnSettingsLoaded()
        {
            if (checkBoxCheckUpdate.Checked)
            {
                _plugin.UpdateChecker.CheckUpdate(false);
            }

            var settings = _plugin.Settings;
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

        private void checkBoxPlaybackYukkuri_CheckedChanged(object sender, EventArgs e)
        {
            bool yukkuriPlaybackEnable = checkBoxPlaybackYukkuri.Enabled && checkBoxPlaybackYukkuri.Checked;
            tableLayoutPanelPlayback.Enabled = !yukkuriPlaybackEnable;

            _controller.NotifyYukkuriPlaybackEnabledChanged(true, yukkuriPlaybackEnable);
        }

        private void checkBoxPlaybackYukkuri_EnabledChanged(object sender, EventArgs e)
        {
            bool yukkuriPlaybackEnable = checkBoxPlaybackYukkuri.Enabled && checkBoxPlaybackYukkuri.Checked;
            tableLayoutPanelPlayback.Enabled = !yukkuriPlaybackEnable;

            _controller.NotifyYukkuriPlaybackEnabledChanged(true, yukkuriPlaybackEnable);
        }
    }
}
