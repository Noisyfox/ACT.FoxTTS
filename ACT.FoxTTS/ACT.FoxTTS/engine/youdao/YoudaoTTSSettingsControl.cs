using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;
using ACT.FoxTTS.localization;
using Advanced_Combat_Tracker;

namespace ACT.FoxTTS.engine.youdao
{
    public partial class YoudaoTTSSettingsControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public YoudaoTTSSettingsControl()
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
            var settings = plugin.Settings.YoudaoTtsSettings;
            textBoxAppId.Text = settings.AppId;
            textBoxAppSecret.Text = settings.AppSecret;
            trackBarSpeed.SetValue(settings.Speed, 10);
            trackBarVolume.SetValue(settings.Volume, 10);

            textBoxAppId.TextChanged += OnValueChanged;
            textBoxAppSecret.TextChanged += OnValueChanged;
            trackBarSpeed.ValueChanged += OnValueChanged;
            trackBarVolume.ValueChanged += OnValueChanged;

            OnValueChanged(null, EventArgs.Empty);

            checkBoxAppKey_CheckedChanged(null, EventArgs.Empty);

            if (string.IsNullOrWhiteSpace(settings.AppId) || string.IsNullOrWhiteSpace(settings.AppSecret))
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
            toolTip1.SetToolTip(checkBoxAppSecret, strings.checkBoxAppSecret_Tooltip);
        }

        private void OnValueChanged(object sender, EventArgs eventArgs)
        {
            var settings = _plugin.Settings.YoudaoTtsSettings;

            settings.AppId = textBoxAppId.Text;
            settings.AppSecret = textBoxAppSecret.Text;

            labelSpeedValue.Text = (trackBarSpeed.Value / 10.0).ToString();
            settings.Speed = trackBarSpeed.Value;

            labelVolumeValue.Text = (trackBarVolume.Value / 10.0).ToString();
            settings.Volume = trackBarVolume.Value;

            Validate(textBoxAppId);
            Validate(textBoxAppSecret);
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

        private void linkLabelOpenYoudaoReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://ai.youdao.com/product-tts.s");
        }

        private void checkBoxAppKey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAppId.PasswordChar = checkBoxAppId.Checked ? '\0' : '*';
            textBoxAppSecret.PasswordChar = checkBoxAppSecret.Checked ? '\0' : '*';

            timerHideKey.Stop();
            if (checkBoxAppId.Checked || checkBoxAppSecret.Checked)
            {
                timerHideKey.Start();
            }
        }

        private void timerHideKey_Tick(object sender, EventArgs e)
        {
            checkBoxAppId.Checked = false;
            checkBoxAppSecret.Checked = false;
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
                ts.ShowTraySlider(strings.msgYoudaoAppKeyEmpty, strings.actPanelTitle);
            }
        }
    }
}
