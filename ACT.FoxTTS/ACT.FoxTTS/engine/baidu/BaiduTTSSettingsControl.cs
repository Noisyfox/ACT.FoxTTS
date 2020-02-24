using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.localization;

namespace ACT.FoxTTS.engine.baidu
{
    public partial class BaiduTTSSettingsControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public BaiduTTSSettingsControl()
        {
            InitializeComponent();
        }

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;

            var parentPanel = plugin.EngineSettingsPanel;
            parentPanel.Controls.Add(this);
            parentPanel.Resize += ParentPanelOnResize;
            ParentPanelOnResize(parentPanel, null);
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

            textBoxApiKey.TextChanged += OnValueChanged;
            textBoxSecretKey.TextChanged += OnValueChanged;
            trackBarSpeed.ValueChanged += OnValueChanged;
            trackBarPitch.ValueChanged += OnValueChanged;
            trackBarVolume.ValueChanged += OnValueChanged;
            comboBoxPerson.SelectedIndexChanged += OnValueChanged;

            OnValueChanged(null, EventArgs.Empty);
        }

        public void RemoveFromAct()
        {
            Parent.Controls.Remove(this);
        }

        public void DoLocalization()
        {
            LocalizationBase.TranslateControls(this);
        }

        private void ParentPanelOnResize(object sender, EventArgs eventArgs)
        {
            Location = new Point(0, 0);
            Size = ((Control)sender).Size;
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
        }

        private void linkLabelOpenBaiduReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://ai.baidu.com/tech/speech/tts");
        }

        private void linkLabelSetRecommend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxApiKey.Text = "ALLgqCqouZ9GmIiFgafuyCsG";
            textBoxSecretKey.Text = "079d11c1b742b0031adc5872661fab81";
            trackBarSpeed.SetValue(5, 5);
            trackBarPitch.SetValue(5, 5);
            trackBarVolume.SetValue(5, 5);
            comboBoxPerson.SelectedIndex = 3;
        }
    }
}
