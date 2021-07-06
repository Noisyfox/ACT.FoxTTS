using System;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;
using ACT.FoxTTS.localization;

namespace ACT.FoxTTS.engine.baipiao
{
    public partial class BaipiaoSettingsControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public BaipiaoSettingsControl()
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
            var settings = plugin.Settings.BaipiaoSettings;
            trackBarSpeed.SetValue(settings.Speed, 5);

            trackBarSpeed.ValueChanged += OnValueChanged;

            OnValueChanged(null, EventArgs.Empty);
        }

        public void RemoveFromAct()
        {
            Parent.Controls.Remove(this);
        }

        public void DoLocalization()
        {
            LocalizationBase.TranslateControls(this);

            var settings = _plugin.Settings.BaipiaoSettings;
            if (!settings.Accept)
            {
                MessageBox.Show(strings.labelBaipiaoDisclaimer,
                    strings.actPanelTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                settings.Accept = true;
            }
        }

        private void OnValueChanged(object sender, EventArgs eventArgs)
        {
            var settings = _plugin.Settings.BaipiaoSettings;

            labelSpeedValue.Text = trackBarSpeed.Value.ToString();
            settings.Speed = trackBarSpeed.Value;
        }
    }
}
