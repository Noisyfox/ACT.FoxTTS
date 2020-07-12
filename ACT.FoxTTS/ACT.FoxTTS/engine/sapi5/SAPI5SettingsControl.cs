using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;

namespace ACT.FoxTTS.engine.sapi5
{
    public partial class SAPI5SettingsControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public class VoiceVM
        {
            public VoiceVM(InstalledVoice voice)
            {
                Id = voice.VoiceInfo.Id.ToLower();
                Name = $"{voice.VoiceInfo.Name} {voice.VoiceInfo.Culture.DisplayName}";
            }

            public string Id { get; }

            public string Name { get; }
        }

        public SAPI5SettingsControl()
        {
            InitializeComponent();

            this.AdjustForDpiScaling();

            // Populate installed voices
            var installedVoices = new SpeechSynthesizer().GetInstalledVoices().Select(it=>new VoiceVM(it)).ToList();
            comboBoxPerson.ValueMember = nameof(VoiceVM.Id);
            comboBoxPerson.DisplayMember = nameof(VoiceVM.Name);
            comboBoxPerson.DataSource = installedVoices;
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
            var settings = plugin.Settings.SApi5Settings;
            trackBarSpeed.SetValue(settings.Rate, 0);
            comboBoxPitch.SelectedIndex = ((int)settings.Pitch).Clamp(0, comboBoxPitch.Items.Count - 1);
            trackBarVolume.SetValue(settings.Volume, 100);
            var selectedVoice = (comboBoxPerson.DataSource as List<VoiceVM>).FirstOrDefault(it => it.Id == settings.Voice);
            if (selectedVoice == null)
            {
                if (comboBoxPerson.Items.Count > 0)
                {
                    comboBoxPerson.SelectedIndex = 0;
                }
            }
            else
            {
                comboBoxPerson.SelectedValue = selectedVoice.Id;
            }

            trackBarSpeed.ValueChanged += OnValueChanged;
            comboBoxPitch.SelectedIndexChanged += OnValueChanged;
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
            var settings = _plugin.Settings.SApi5Settings;

            labelSpeedValue.Text = trackBarSpeed.Value.ToString();
            settings.Rate = trackBarSpeed.Value;

            settings.Pitch = (Pitches)comboBoxPitch.SelectedIndex;

            labelVolumeValue.Text = trackBarVolume.Value.ToString();
            settings.Volume = trackBarVolume.Value;

            settings.Voice = comboBoxPerson.SelectedValue.ToString();
        }
    }
}
