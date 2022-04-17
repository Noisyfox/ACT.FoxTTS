using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;
using ACT.FoxTTS.localization;

namespace ACT.FoxTTS.engine.cafe
{
    public partial class CafeTTSSettingsControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public CafeTTSSettingsControl()
        {
            InitializeComponent();

            this.AdjustForDpiScaling();

            // Populate voices
            comboBoxPerson.ValueMember = nameof(Voice.Value);
            comboBoxPerson.DisplayMember = nameof(Voice.DisplayName);
            comboBoxPerson.DataSource = CafeTTSEngine.Voices;
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
            var settings = plugin.Settings.CafeTtsSettings;
            trackBarSpeed.SetValue(settings.Rate, 0);
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

            trackBarSpeed.ValueChanged += OnValueChanged;
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

        private void OnValueChanged(object sender, EventArgs eventArgs)
        {
            var settings = _plugin.Settings.CafeTtsSettings;

            labelSpeedValue.Text = trackBarSpeed.Value.ToString();
            settings.Rate = trackBarSpeed.Value;

            settings.Voice = comboBoxPerson.SelectedValue as string;
        }
        
    }
}
