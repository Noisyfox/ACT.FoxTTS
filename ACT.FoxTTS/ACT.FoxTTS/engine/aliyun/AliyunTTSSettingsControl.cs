using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;
using ACT.FoxTTS.localization;
using Advanced_Combat_Tracker;

namespace ACT.FoxTTS.engine.aliyun
{
    public partial class AliyunTTSSettingsControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public AliyunTTSSettingsControl()
        {
            InitializeComponent();

            this.AdjustForDpiScaling();

            // Populate voices
            comboBoxPerson.ValueMember = nameof(AliyunVoice.Value);
            comboBoxPerson.DisplayMember = nameof(AliyunVoice.DisplayName);
            comboBoxPerson.DataSource = AliyunTTSEngine.Voices;

            // Populate effects
            comboBoxEffect.ValueMember = nameof(Voice.Value);
            comboBoxEffect.DisplayMember = nameof(Voice.DisplayName);
            comboBoxEffect.DataSource = AliyunTTSEngine.Effects;
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
            var settings = plugin.Settings.AliyunTtsSettings;
            textBoxAppId.Text = settings.AppId;
            textBoxAccessKeyId.Text = settings.AccessKeyId;
            textBoxAccessKeySecret.Text = settings.AccessKeySecret;
            trackBarSpeed.SetValue(settings.Speed, 0);
            trackBarPitch.SetValue(settings.Pitch, 0);
            trackBarVolume.SetValue(settings.Volume, 50);
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
            var selectedEffect = (comboBoxEffect.DataSource as Voice[]).FirstOrDefault(it => it.Value == settings.Effect);
            if (selectedEffect == null)
            {
                if (comboBoxEffect.Items.Count > 0)
                {
                    comboBoxEffect.SelectedIndex = 0;
                }
            }
            else
            {
                comboBoxEffect.SelectedValue = selectedEffect.Value;
            }
            trackBarEmotionIntensity.SetValue(settings.EmotionIntensity, 100);

            textBoxAccessKeyId.TextChanged += OnValueChanged;
            textBoxAccessKeySecret.TextChanged += OnValueChanged;
            textBoxAppId.TextChanged += OnValueChanged;
            trackBarSpeed.ValueChanged += OnValueChanged;
            trackBarPitch.ValueChanged += OnValueChanged;
            trackBarVolume.ValueChanged += OnValueChanged;
            comboBoxPerson.SelectedIndexChanged += OnPersonChanged;
            comboBoxEmotion.SelectedIndexChanged += OnValueChanged;
            trackBarEmotionIntensity.ValueChanged += OnValueChanged;
            comboBoxEffect.SelectedIndexChanged += OnValueChanged;

            OnPersonChanged(null, EventArgs.Empty);
            OnValueChanged(null, EventArgs.Empty);

            checkBoxAppId_CheckedChanged(null, EventArgs.Empty);

            if (string.IsNullOrWhiteSpace(settings.AccessKeyId) || string.IsNullOrWhiteSpace(settings.AccessKeySecret) || string.IsNullOrWhiteSpace(settings.AppId))
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
            toolTip1.SetToolTip(checkBoxAccessKeyId, strings.checkBoxAccessKeyId_Tooltip);
            toolTip1.SetToolTip(checkBoxAccessKeySecret, strings.checkBoxAccessKeySecret_Tooltip);
            toolTip1.SetToolTip(checkBoxAppId, strings.checkBoxAppId_Tooltip);
        }

        private void OnValueChanged(object sender, EventArgs eventArgs)
        {
            var settings = _plugin.Settings.AliyunTtsSettings;

            settings.AppId = textBoxAppId.Text;
            settings.AccessKeyId = textBoxAccessKeyId.Text;
            settings.AccessKeySecret = textBoxAccessKeySecret.Text;

            labelSpeedValue.Text = trackBarSpeed.Value.ToString();
            settings.Speed = trackBarSpeed.Value;

            labelPitchValue.Text = trackBarPitch.Value.ToString();
            settings.Pitch = trackBarPitch.Value;

            labelVolumeValue.Text = trackBarVolume.Value.ToString();
            settings.Volume = trackBarVolume.Value;

            labelEmotionIntensityValue.Text = (trackBarEmotionIntensity.Value / 100.0).ToString("F2");
            settings.EmotionIntensity = trackBarEmotionIntensity.Value;

            if (comboBoxEmotion.Items.Count > 0)
            {
                settings.EmotionCategory = comboBoxEmotion.SelectedValue as string;
            }
            else
            {
                settings.EmotionCategory = AliyunVoice.EmotionNone;
            }

            settings.Effect = comboBoxEffect.SelectedValue as string;

            Validate(textBoxAppId);
            Validate(textBoxAccessKeyId);
            Validate(textBoxAccessKeySecret);
        }

        private void OnPersonChanged(object sender, EventArgs eventArgs)
        {
            var settings = _plugin.Settings.AliyunTtsSettings;
            var voice = comboBoxPerson.SelectedItem as AliyunVoice;
            settings.Voice = voice.Value;

            comboBoxEmotion.SelectedIndexChanged -= OnValueChanged;

            if (voice.Emotions == null)
            {
                comboBoxEmotion.Enabled = false;
                comboBoxEmotion.DataSource = null;
                settings.EmotionCategory = AliyunVoice.EmotionNone;
            }
            else
            {
                comboBoxEmotion.Enabled = true;
                comboBoxEmotion.ValueMember = nameof(Voice.Value);
                comboBoxEmotion.DisplayMember = nameof(Voice.DisplayName);
                var emotions = new List<string> { AliyunVoice.EmotionNone };
                emotions.AddRange(voice.Emotions);
                var emotionsDS = emotions.Select(it =>
                    new Voice(it, LocalizationBase.GetString($"aliyunEmotion_{it}", it))
                ).ToList();
                comboBoxEmotion.DataSource = emotionsDS;

                var selectedEmotion = emotionsDS.FirstOrDefault(it => it.Value == settings.EmotionCategory);
                if (selectedEmotion == null)
                {
                    comboBoxEmotion.SelectedIndex = 0;
                    settings.EmotionCategory = AliyunVoice.EmotionNone;
                }
                else
                {
                    comboBoxEmotion.SelectedValue = selectedEmotion.Value;
                }
            }

            comboBoxEmotion.SelectedIndexChanged += OnValueChanged;
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
            Process.Start(@"https://ai.aliyun.com/nls/tts");
        }

        private void timerHideKey_Tick(object sender, EventArgs e)
        {
            checkBoxAccessKeyId.Checked = false;
            checkBoxAccessKeySecret.Checked = false;
            checkBoxAppId.Checked = false;
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
                ts.ShowTraySlider(strings.msgAliyunApiKeyEmpty, strings.actPanelTitle);
            }
        }

        private void checkBoxAppId_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAccessKeyId.PasswordChar = checkBoxAccessKeyId.Checked ? '\0' : '*';
            textBoxAccessKeySecret.PasswordChar = checkBoxAccessKeySecret.Checked ? '\0' : '*';
            textBoxAppId.PasswordChar = checkBoxAppId.Checked ? '\0' : '*';

            timerHideKey.Stop();
            if (checkBoxAccessKeyId.Checked || checkBoxAccessKeySecret.Checked || checkBoxAppId.Checked)
            {
                timerHideKey.Start();
            }
        }
    }
}
