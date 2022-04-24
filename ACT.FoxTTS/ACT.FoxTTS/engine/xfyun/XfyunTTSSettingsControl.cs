using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;
using ACT.FoxTTS.localization;
using Advanced_Combat_Tracker;

namespace ACT.FoxTTS.engine.xfyun
{
    public partial class XfyunTTSSettingsControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public XfyunTTSSettingsControl()
        {
            InitializeComponent();

            this.AdjustForDpiScaling();

            // Populate voices
            comboBoxPerson.ValueMember = nameof(Voice.Value);
            comboBoxPerson.DisplayMember = nameof(Voice.DisplayName);
            comboBoxPerson.DataSource = XfyunTTSEngine.Voices;
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
            var settings = plugin.Settings.XfyunTtsSettings;
            textBoxAppId.Text = settings.AppId;
            textBoxApiKey.Text = settings.ApiKey;
            textBoxApiSecret.Text = settings.ApiSecret;
            trackBarSpeed.SetValue(settings.Speed, 5);
            trackBarPitch.SetValue(settings.Pitch, 5);
            trackBarVolume.SetValue(settings.Volume, 5);
            var selectedVoice = (comboBoxPerson.DataSource as Voice[]).FirstOrDefault(it => it.Value == settings.Voice);
            if (selectedVoice == null)
            {
                if (comboBoxPerson.Items.Count > 0)
                {
                    comboBoxPerson.SelectedIndex = 0;
                }
            }
            else
            {
                comboBoxPerson.SelectedValue = selectedVoice.Value;
            }

            textBoxAppId.TextChanged += OnValueChanged;
            textBoxApiKey.TextChanged += OnValueChanged;
            textBoxApiSecret.TextChanged += OnValueChanged;
            trackBarSpeed.ValueChanged += OnValueChanged;
            trackBarPitch.ValueChanged += OnValueChanged;
            trackBarVolume.ValueChanged += OnValueChanged;
            comboBoxPerson.SelectedIndexChanged += OnValueChanged;

            OnValueChanged(null, EventArgs.Empty);

            checkBoxApiKey_CheckedChanged(null, EventArgs.Empty);

            if (string.IsNullOrWhiteSpace(settings.AppId) || string.IsNullOrWhiteSpace(settings.ApiKey) || string.IsNullOrWhiteSpace(settings.ApiSecret))
            {
                NotifyEmptyApiKey();
            }
        }

        public void RemoveFromAct()
        {
            Parent.Controls.Remove(this);
        }

        public void DoLocalization()
        {
            LocalizationBase.TranslateControls(this);
            toolTip1.SetToolTip(checkBoxAppId, strings.checkBoxAppId_Tooltip);
            toolTip1.SetToolTip(checkBoxApiKey, strings.checkBoxApiKey_Tooltip);
            toolTip1.SetToolTip(checkBoxApiSecret, strings.checkBoxApiSecret_Tooltip);
        }

        private void OnValueChanged(object sender, EventArgs eventArgs)
        {
            var settings = _plugin.Settings.XfyunTtsSettings;

            settings.AppId = textBoxAppId.Text;
            settings.ApiKey = textBoxApiKey.Text;
            settings.ApiSecret = textBoxApiSecret.Text;

            labelSpeedValue.Text = trackBarSpeed.Value.ToString();
            settings.Speed = trackBarSpeed.Value;

            labelPitchValue.Text = trackBarPitch.Value.ToString();
            settings.Pitch = trackBarPitch.Value;

            labelVolumeValue.Text = trackBarVolume.Value.ToString();
            settings.Volume = trackBarVolume.Value;

            settings.Voice = comboBoxPerson.SelectedValue as string;

            Validate(textBoxAppId);
            Validate(textBoxApiKey);
            Validate(textBoxApiSecret);
        }

        private static void Validate(TextBox tb)
        {
            if (tb.TextLength > 0)
            {
                tb.ResetBackColor();
            }
            else
            {
                tb.BackColor = Color.Red;
            }
        }

        private void linkLabelOpenXfyunReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://www.xfyun.cn/services/online_tts");
        }

        private void checkBoxApiKey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAppId.PasswordChar = checkBoxAppId.Checked ? '\0' : '*';
            textBoxApiKey.PasswordChar = checkBoxApiKey.Checked ? '\0' : '*';
            textBoxApiSecret.PasswordChar = checkBoxApiSecret.Checked ? '\0' : '*';

            timerHideKey.Stop();
            if (checkBoxAppId.Checked || checkBoxApiKey.Checked || checkBoxApiSecret.Checked)
            {
                timerHideKey.Start();
            }
        }

        private void timerHideKey_Tick(object sender, EventArgs e)
        {
            checkBoxAppId.Checked = false;
            checkBoxApiKey.Checked = false;
            checkBoxApiSecret.Checked = false;
            timerHideKey.Stop();
        }

        internal void NotifyEmptyApiKey()
        {
            if (InvokeRequired)
            {
                this.SafeInvoke(new Action(NotifyEmptyApiKey));
            }
            else
            {
                var ts = new TraySlider
                {
                    ButtonLayout = TraySlider.ButtonLayoutEnum.OneButton,
                };
                ts.ShowTraySlider(strings.msgBaiduApiKeyEmpty, strings.actPanelTitle);
            }
        }
    }
}
