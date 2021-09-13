using System;
using System.Linq;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;
using ACT.FoxTTS.localization;

namespace ACT.FoxTTS.engine.edge
{
    public partial class EdgeTTSSettingsControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public EdgeTTSSettingsControl()
        {
            InitializeComponent();

            this.AdjustForDpiScaling();

            // Populate voices
            comboBoxPerson.ValueMember = nameof(Voice.Value);
            comboBoxPerson.DisplayMember = nameof(Voice.DisplayName);
            comboBoxPerson.DataSource = EdgeTTSEngine.Voices;
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
            var settings = plugin.Settings.EdgeTtsSettings;
            trackBarSpeed.SetValue(settings.Speed, 100);
            trackBarPitch.SetValue(settings.Pitch, 100);
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

            var settings = _plugin.Settings.EdgeTtsSettings;
            if (!settings.Accept)
            {
                MessageBox.Show(strings.labelEdgeDisclaimer,
                    strings.actPanelTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                settings.Accept = true;
            }
        }

        private void OnValueChanged(object sender, EventArgs eventArgs)
        {
            var settings = _plugin.Settings.EdgeTtsSettings;

            labelSpeedValue.Text = (trackBarSpeed.Value / 100.0).ToString("F2") + "X";
            settings.Speed = trackBarSpeed.Value;

            labelPitchValue.Text = (trackBarPitch.Value / 100.0).ToString("F2");
            settings.Pitch = trackBarPitch.Value;

            labelVolumeValue.Text = trackBarVolume.Value.ToString();
            settings.Volume = trackBarVolume.Value;

            settings.Voice = comboBoxPerson.SelectedValue as string;
        }
    }
}
