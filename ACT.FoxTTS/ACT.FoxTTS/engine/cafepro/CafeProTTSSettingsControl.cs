using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;
using ACT.FoxTTS.engine.azure;

namespace ACT.FoxTTS.engine.cafepro
{
    public partial class CafeProTTSSettingsControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public CafeProTTSSettingsControl()
        {
            InitializeComponent();

            this.AdjustForDpiScaling();

            // Populate voices
            comboBoxPerson.ValueMember = nameof(AzureVoice.Value);
            comboBoxPerson.DisplayMember = nameof(AzureVoice.DisplayName);
            comboBoxPerson.DataSource = CafeProTTSEngine.Voices;
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
            var settings = plugin.Settings.CafeProTtsSettings;
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
            trackBarStyleDegree.SetValue(settings.StyleDegree, 100);

            trackBarSpeed.ValueChanged += OnValueChanged;
            trackBarPitch.ValueChanged += OnValueChanged;
            trackBarVolume.ValueChanged += OnValueChanged;
            comboBoxPerson.SelectedIndexChanged += OnPersonChanged;
            comboBoxStyle.SelectedIndexChanged += OnValueChanged;
            trackBarStyleDegree.ValueChanged += OnValueChanged;
            comboBoxRole.SelectedIndexChanged += OnValueChanged;

            OnPersonChanged(null, EventArgs.Empty);
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
            var settings = _plugin.Settings.CafeProTtsSettings;

            labelSpeedValue.Text = (trackBarSpeed.Value / 100.0).ToString("F2") + "X";
            settings.Speed = trackBarSpeed.Value;

            labelPitchValue.Text = (trackBarPitch.Value / 100.0).ToString("F2");
            settings.Pitch = trackBarPitch.Value;

            labelVolumeValue.Text = trackBarVolume.Value.ToString();
            settings.Volume = trackBarVolume.Value;

            labelStyleDegreeValue.Text = (trackBarStyleDegree.Value / 100.0).ToString("F2");
            settings.StyleDegree = trackBarStyleDegree.Value;

            if (comboBoxStyle.Items.Count > 0)
            {
                settings.Style = comboBoxStyle.SelectedValue as string;
            }
            else
            {
                settings.Style = AzureVoice.StyleGeneral;
            }

            if (comboBoxRole.Items.Count > 0)
            {
                settings.Role = comboBoxRole.SelectedValue as string;
            }
            else
            {
                settings.Role = AzureVoice.RoleDefault;
            }

            UpdateStyleDescription();
        }

        private void OnPersonChanged(object sender, EventArgs eventArgs)
        {
            var settings = _plugin.Settings.CafeProTtsSettings;
            var voice = comboBoxPerson.SelectedItem as AzureVoice;
            settings.Voice = voice.Value;

            comboBoxStyle.SelectedIndexChanged -= OnValueChanged;
            comboBoxRole.SelectedIndexChanged -= OnValueChanged;
            trackBarStyleDegree.Enabled = voice.SupportStyleDegree;

            if (voice.Styles == null)
            {
                trackBarStyleDegree.Enabled = false;
                comboBoxStyle.Enabled = false;
                comboBoxStyle.DataSource = null;
                settings.Style = AzureVoice.StyleGeneral;
            }
            else
            {
                trackBarStyleDegree.Enabled = true;
                comboBoxStyle.Enabled = true;
                comboBoxStyle.ValueMember = nameof(Voice.Value);
                comboBoxStyle.DisplayMember = nameof(Voice.DisplayName);
                var styles = new List<string> { AzureVoice.StyleGeneral };
                styles.AddRange(voice.Styles);
                var styleDS = styles.Select(it =>
                    new Voice(it, LocalizationBase.GetString($"azureStyle_{it}", it))
                ).ToList();
                comboBoxStyle.DataSource = styleDS;

                var selectedStyle = styleDS.FirstOrDefault(it => it.Value == settings.Style);
                if (selectedStyle == null)
                {
                    comboBoxStyle.SelectedIndex = 0;
                    settings.Style = AzureVoice.StyleGeneral;
                }
                else
                {
                    comboBoxStyle.SelectedValue = selectedStyle.Value;
                }
            }

            if (voice.Roles == null)
            {
                comboBoxRole.Enabled = false;
                comboBoxRole.DataSource = null;
                settings.Role = AzureVoice.RoleDefault;
            }
            else
            {
                comboBoxRole.Enabled = true;
                comboBoxRole.ValueMember = nameof(Voice.Value);
                comboBoxRole.DisplayMember = nameof(Voice.DisplayName);
                var roles = new List<string> { AzureVoice.RoleDefault };
                roles.AddRange(voice.Roles);
                var roleDS = roles.Select(it =>
                    new Voice(it, LocalizationBase.GetString($"azureRole_{it}", it))
                ).ToList();
                comboBoxRole.DataSource = roleDS;

                var selectedRole = roleDS.FirstOrDefault(it => it.Value == settings.Role);
                if (selectedRole == null)
                {
                    comboBoxRole.SelectedIndex = 0;
                    settings.Role = AzureVoice.RoleDefault;
                }
                else
                {
                    comboBoxRole.SelectedValue = selectedRole.Value;
                }
            }

            comboBoxStyle.SelectedIndexChanged += OnValueChanged;
            comboBoxRole.SelectedIndexChanged += OnValueChanged;

            UpdateStyleDescription();
        }

        private void UpdateStyleDescription()
        {
            if (comboBoxStyle.Items.Count > 0)
            {
                var style = comboBoxStyle.SelectedValue as string;
                labelStyleDescription.Text = LocalizationBase.GetString($"azureStyle_{style}.Desc", " ");
            }
            else
            {
                labelStyleDescription.Text = " ";
            }
        }
    }
}
