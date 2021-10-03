using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;
using ACT.FoxCommon.logging;
using ACT.FoxCommon.update;
using ACT.FoxTTS.engine;
using ACT.FoxTTS.localization;
using ACT.FoxTTS.preprocess;
using Advanced_Combat_Tracker;

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
            settings.AddControlSetting(checkBoxDebugLogging);

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
        private void checkBoxDebugLogging_CheckedChanged(object sender, EventArgs e)
        {
            Logger.IsDebugLevelEnabled = checkBoxDebugLogging.Checked;
        }

        private void ControllerOnSettingsLoaded()
        {
            Logger.IsDebugLevelEnabled = checkBoxDebugLogging.Checked;
            if (checkBoxCheckUpdate.Checked)
            {
                _plugin.UpdateChecker.CheckUpdate(false);
            }

            comboBoxTTSEngine.SelectedItem =
                TTSEngineFactory.Engines.FirstOrDefault(it => it.Name.Equals(_plugin.Settings.TTSEngine)) ??
                TTSEngineFactory.Engines.First();

            if (_plugin.Settings.BaiduTtsSettings.WasUsingFreeKey &&
                comboBoxTTSEngine.SelectedItem == TTSEngineFactory.EngineBaidu)
            {
                // Automatically switch to CafeTTS if user is currently using baidu tts free key
                comboBoxTTSEngine.SelectedItem = TTSEngineFactory.EngineCafe;

                var ts = new TraySlider
                {
                    ButtonLayout = TraySlider.ButtonLayoutEnum.OneButton,
                };
                ts.ShowTraySlider(strings.msgBaiduFreeApiKeyExpired, strings.actPanelTitle);
            }

            comboBoxTTSEngine.SelectedIndexChanged += comboBoxTTSEngine_SelectedIndexChanged;

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

            // Load text processor settings
            dataGridViewRules.AutoGenerateColumns = false;
            dataGridViewRules.Columns["ColumnOrder"].DataPropertyName = nameof(PreProcessorRuleViewModel.Order);
            dataGridViewRules.Columns["ColumnEnabled"].DataPropertyName = nameof(PreProcessorRuleViewModel.Enabled);
            dataGridViewRules.Columns["ColumnFindPattern"].DataPropertyName = nameof(PreProcessorRuleViewModel.SourcePattern);
            dataGridViewRules.Columns["ColumnReplacement"].DataPropertyName = nameof(PreProcessorRuleViewModel.Replacement);
            dataGridViewRules.Columns["ColumnUseRegex"].DataPropertyName = nameof(PreProcessorRuleViewModel.UseRegex);
            foreach (var vm in _plugin.Settings.PreProcessorSettings.Rules.Select(
                (v, index) => new PreProcessorRuleViewModel(index + 1, v)
            ))
            {
                _rules.Add(vm);
            }
            dataGridViewRules.DataSource = _rules;
            dataGridViewRules.SelectionChanged += DataGridViewRules_SelectionChanged;
            _rules.ListChanged += Rules_ListChanged;

            comboBoxTTSEngine_SelectedIndexChanged(null, EventArgs.Empty);
            OnPluginIntegrationValueChanged(null, EventArgs.Empty);
            OnPlaybackValueChanged(null, EventArgs.Empty);
            DataGridViewRules_SelectionChanged(null, EventArgs.Empty);
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
                    var ts = new TraySlider
                    {
                        ButtonLayout = TraySlider.ButtonLayoutEnum.OneButton,
                    };
                    ts.ShowTraySlider(strings.messageLatest, strings.actPanelTitle);
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

                    var ts = new TraySlider
                    {
                        ButtonLayout = TraySlider.ButtonLayoutEnum.FourButton,
                        ButtonSW = { Text = strings.buttonUpdateNow },
                        ButtonSE = { Text = strings.buttonUpdateLater },
                        ButtonNE = { Text = strings.buttonIgnoreVersion },
                    };
                    ts.ButtonNW.Hide();
                    ts.ButtonSW.Click += (sender, args) => Process.Start(newVersion.PublishPage);
                    ts.ButtonNE.Click += (sender, args) => _controller.NotifyNewVersionIgnored(true, newVersion.ParsedVersion.ToString());
                    ts.ShowTraySlider(message, strings.actPanelTitle);
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
            if (Directory.Exists(FileCache.CacheDirectory))
            {
                Process.Start(FileCache.CacheDirectory);
            }
        }

        private void linkLabelClearCache_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(FileCache.CacheDirectory))
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
                        FileCache.CacheDirectory,
                        "*",
                        SearchOption.TopDirectoryOnly))
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            Logger.Error($"Failed to delete file {file}", ex);
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

            radioButtonIntegrationAct.Visible =
                radioButtonIntegrationYukkuri.Visible =
                    settings.PluginIntegration != PluginIntegration.Auto;
        }

        internal void SwitchToWinMMPlayback()
        {
            radioButtonPlaybackBuiltIn.Checked = true;
            comboBoxPlaybackApi.SelectedIndex = (int)PlaybackApi.WinMM;
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

        #region Preprocess rules

        private readonly BindingList<PreProcessorRuleViewModel> _rules = new BindingList<PreProcessorRuleViewModel>();

        private int GetCurrentSelectedRuleIndex()
        {
            var rs = dataGridViewRules.SelectedRows;
            if (rs.Count == 0)
            {
                return -1;
            }

            return rs[0].Index;
        }

        private PreProcessorRuleViewModel GetCurrentSelectedRule()
        {
            var index = GetCurrentSelectedRuleIndex();
            if (index < 0)
            {
                return null;
            }

            return _rules[index];
        }

        private void SelectRule(int index)
        {
            dataGridViewRules.CurrentCell = dataGridViewRules.Rows[index].Cells[0];
            dataGridViewRules.ClearSelection();
            dataGridViewRules.Rows[index].Selected = true;
        }

        private void UpdateRuleOrder()
        {
            for (var i = 0; i < _rules.Count; i++)
            {
                _rules[i].Order = i + 1;
            }
        }

        private void DataGridViewRules_SelectionChanged(object sender, EventArgs e)
        {
            var selectedIndex = GetCurrentSelectedRuleIndex();
            if (selectedIndex < 0)
            {
                buttonDupRule.Enabled = false;
                buttonDelRule.Enabled = false;
                buttonMoveUp.Enabled = false;
                buttonMoveDown.Enabled = false;
                tableEditRule.Enabled = false;

                checkBoxRuleEnabled.Checked = false;
                checkBoxUseRegex.Checked = false;
                textBoxFindPattern.Text = "";
                textBoxReplacement.Text = "";
            }
            else
            {
                buttonDupRule.Enabled = true;
                buttonDelRule.Enabled = true;
                buttonMoveUp.Enabled = selectedIndex > 0;
                buttonMoveDown.Enabled = selectedIndex < _rules.Count - 1;
                tableEditRule.Enabled = true;

                var vm = _rules[selectedIndex];
                checkBoxRuleEnabled.Checked = vm.Enabled;
                checkBoxUseRegex.Checked = vm.UseRegex;
                textBoxFindPattern.Text = vm.SourcePattern;
                textBoxReplacement.Text = vm.Replacement;

                if (vm.UseRegex)
                {
                    labelFindPattern.Text = strings.labelRegex;
                }
                else
                {
                    labelFindPattern.Text = strings.labelFindPattern;
                }
            }
        }

        private void buttonAddRule_Click(object sender, EventArgs e)
        {
            _rules.Add(new PreProcessorRuleViewModel(_rules.Count + 1));
            DataGridViewRules_SelectionChanged(null, EventArgs.Empty);
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            var selectedIndex = GetCurrentSelectedRuleIndex();
            if (selectedIndex > 0)
            {
                var r = _rules[selectedIndex];
                _rules.RemoveAt(selectedIndex);
                _rules.Insert(selectedIndex - 1, r);
                UpdateRuleOrder();
                SelectRule(selectedIndex - 1);
                DataGridViewRules_SelectionChanged(null, EventArgs.Empty);
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            var selectedIndex = GetCurrentSelectedRuleIndex();
            if (selectedIndex < _rules.Count - 1)
            {
                var r = _rules[selectedIndex];
                _rules.RemoveAt(selectedIndex);
                _rules.Insert(selectedIndex + 1, r);
                UpdateRuleOrder();
                SelectRule(selectedIndex + 1);
                DataGridViewRules_SelectionChanged(null, EventArgs.Empty);
            }
        }

        private void buttonDupRule_Click(object sender, EventArgs e)
        {
            var r = GetCurrentSelectedRule();
            if (r != null)
            {
                _rules.Add(r.Dup(_rules.Count + 1));
            }
        }

        private void buttonDelRule_Click(object sender, EventArgs e)
        {
            var selectedIndex = GetCurrentSelectedRuleIndex();
            if (selectedIndex >= 0)
            {
                _rules.RemoveAt(selectedIndex);
                UpdateRuleOrder();
                if (GetCurrentSelectedRuleIndex() < 0 && _rules.Count > 0)
                {
                    SelectRule(_rules.Count - 1);
                }
                DataGridViewRules_SelectionChanged(null, EventArgs.Empty);
            }
        }

        private void Rules_ListChanged(object sender, ListChangedEventArgs e)
        {
            _plugin.Settings.PreProcessorSettings.Rules = _rules.Select(it => it.ToRule()).ToList();
            DataGridViewRules_SelectionChanged(null, EventArgs.Empty);
            _plugin.Controller.NotifyPreProcessorSettingsChanged(true, _plugin.Settings.PreProcessorSettings);
        }

        private void checkBoxRuleEnabled_CheckedChanged(object sender, EventArgs e)
        {
            var r = GetCurrentSelectedRule();
            if (r != null)
            {
                r.Enabled = checkBoxRuleEnabled.Checked;
            }
        }

        private void checkBoxUseRegex_CheckedChanged(object sender, EventArgs e)
        {
            var r = GetCurrentSelectedRule();
            if (r != null)
            {
                r.UseRegex = checkBoxUseRegex.Checked;
            }
        }

        private void textBoxFindPattern_TextChanged(object sender, EventArgs e)
        {
            var r = GetCurrentSelectedRule();
            if (r != null)
            {
                r.SourcePattern = textBoxFindPattern.Text;
            }
        }

        private void textBoxReplacement_TextChanged(object sender, EventArgs e)
        {
            var r = GetCurrentSelectedRule();
            if (r != null)
            {
                r.Replacement = textBoxReplacement.Text;
            }
        }

        sealed class PreProcessorRuleViewModel : INotifyPropertyChanged
        {
            private int _order;
            private bool _enabled = false;
            private string _sourcePattern = "";
            private string _replacement = "";
            private bool _useRegex = false;

            public int Order
            {
                get => _order;
                set
                {
                    if (value != _order)
                    {
                        _order = value;
                        OnPropertyChanged(nameof(Order));
                    }
                }
            }

            public bool Enabled
            {
                get => _enabled;
                set
                {
                    if (value != _enabled)
                    {
                        _enabled = value;
                        OnPropertyChanged(nameof(Enabled));
                    }
                }
            }

            public string SourcePattern
            {
                get => _sourcePattern;
                set
                {
                    if (value != _sourcePattern)
                    {
                        _sourcePattern = value;
                        OnPropertyChanged(nameof(SourcePattern));
                    }
                }
            }

            public string Replacement
            {
                get => _replacement;
                set
                {
                    if (value != _replacement)
                    {
                        _replacement = value;
                        OnPropertyChanged(nameof(Replacement));
                    }
                }
            }

            public bool UseRegex
            {
                get => _useRegex;
                set
                {
                    if (value != _useRegex)
                    {
                        _useRegex = value;
                        OnPropertyChanged(nameof(UseRegex));
                    }
                }
            }

            public PreProcessorRuleViewModel(int order)
            {
                Order = order;
            }

            public PreProcessorRuleViewModel(int order, Rule r)
            {
                Order = order;
                Enabled = r.Enabled;
                SourcePattern = r.SourcePattern;
                Replacement = r.Replacement;
                UseRegex = r.UseRegex;
            }

            public Rule ToRule()
            {
                return new Rule
                {
                    Enabled = Enabled,
                    SourcePattern = SourcePattern,
                    Replacement = Replacement,
                    UseRegex = UseRegex,
                };
            }

            public PreProcessorRuleViewModel Dup(int index)
            {
                return new PreProcessorRuleViewModel(index)
                {
                    Enabled = Enabled,
                    SourcePattern = SourcePattern,
                    Replacement = Replacement,
                    UseRegex = UseRegex,
                };
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
