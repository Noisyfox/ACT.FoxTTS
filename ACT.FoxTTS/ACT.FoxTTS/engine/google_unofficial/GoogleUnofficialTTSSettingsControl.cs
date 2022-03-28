using System.Windows.Forms;
using ACT.FoxCommon.dpi;
using ACT.FoxCommon.localization;
using ACT.FoxTTS.localization;

namespace ACT.FoxTTS.engine.google_unofficial
{
    public partial class GoogleUnofficialTTSSettingsControl : UserControl, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public GoogleUnofficialTTSSettingsControl()
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
            
        }

        public void RemoveFromAct()
        {
            Parent.Controls.Remove(this);
        }

        public void DoLocalization()
        {
            LocalizationBase.TranslateControls(this);

            var settings = _plugin.Settings.GoogleUnofficialTtsSettings;
            if (!settings.Accept)
            {
                MessageBox.Show(strings.labelGoogleDisclaimer,
                    strings.actPanelTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                settings.Accept = true;
            }
        }
    }
}
