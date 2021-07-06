using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;
using ACT.FoxTTS.localization;

namespace ACT.FoxTTS.engine.baidu
{
    public partial class BaiduTTSSettingsControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public BaiduTTSSettingsControl()
        {
            InitializeComponent();

            this.AdjustForDpiScaling();
        }

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;

            var parentPanel = plugin.EngineSettingsPanel;
            parentPanel.Controls.Add(this);
            Dock = DockStyle.Top;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
            var settings = plugin.Settings.BaiduTtsSettings;
            textBoxApiKey.Text = settings.ApiKey;
            textBoxSecretKey.Text = settings.SecretKey;
            trackBarSpeed.SetValue(settings.Speed, 5);
            trackBarPitch.SetValue(settings.Pitch, 5);
            trackBarVolume.SetValue(settings.Volume, 5);
            comboBoxPerson.SelectedIndex = settings.Person.Clamp(0, comboBoxPerson.Items.Count - 1);
            checkBoxUseHttps.Checked = settings.UseHttps;

            textBoxApiKey.TextChanged += OnValueChanged;
            textBoxSecretKey.TextChanged += OnValueChanged;
            trackBarSpeed.ValueChanged += OnValueChanged;
            trackBarPitch.ValueChanged += OnValueChanged;
            trackBarVolume.ValueChanged += OnValueChanged;
            comboBoxPerson.SelectedIndexChanged += OnValueChanged;
            checkBoxUseHttps.CheckedChanged += OnValueChanged;

            OnValueChanged(null, EventArgs.Empty);

            checkBoxApiKey_CheckedChanged(null, EventArgs.Empty);
        }

        public void RemoveFromAct()
        {
            Parent.Controls.Remove(this);
        }

        public void DoLocalization()
        {
            LocalizationBase.TranslateControls(this);
            toolTip1.SetToolTip(checkBoxApiKey, strings.checkBoxApiKey_Tooltip);
            toolTip1.SetToolTip(checkBoxSecretKey, strings.checkBoxSecretKey_Tooltip);
        }

        private void OnValueChanged(object sender, EventArgs eventArgs)
        {
            var settings = _plugin.Settings.BaiduTtsSettings;

            settings.ApiKey = textBoxApiKey.Text;
            settings.SecretKey = textBoxSecretKey.Text;

            labelSpeedValue.Text = trackBarSpeed.Value.ToString();
            settings.Speed = trackBarSpeed.Value;

            labelPitchValue.Text = trackBarPitch.Value.ToString();
            settings.Pitch = trackBarPitch.Value;

            labelVolumeValue.Text = trackBarVolume.Value.ToString();
            settings.Volume = trackBarVolume.Value;

            settings.Person = comboBoxPerson.SelectedIndex;

            settings.UseHttps = checkBoxUseHttps.Checked;
        }

        private void linkLabelOpenBaiduReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://ai.baidu.com/tech/speech/tts");
        }

        private void checkBoxApiKey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxApiKey.PasswordChar = checkBoxApiKey.Checked ? '\0' : '*';
            textBoxSecretKey.PasswordChar = checkBoxSecretKey.Checked ? '\0' : '*';
        }
    }
}
