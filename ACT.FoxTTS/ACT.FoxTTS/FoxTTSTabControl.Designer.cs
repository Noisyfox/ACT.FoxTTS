namespace ACT.FoxTTS
{
    partial class FoxTTSTabControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGeneralSettings = new System.Windows.Forms.TabPage();
            this.groupBoxIntegration = new System.Windows.Forms.GroupBox();
            this.radioButtonIntegrationYukkuri = new System.Windows.Forms.RadioButton();
            this.radioButtonIntegrationAct = new System.Windows.Forms.RadioButton();
            this.radioButtonIntegrationAuto = new System.Windows.Forms.RadioButton();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxPreview = new System.Windows.Forms.TextBox();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.groupBoxTTSEngine = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTTSEngine = new System.Windows.Forms.Label();
            this.comboBoxTTSEngine = new System.Windows.Forms.ComboBox();
            this.checkBoxClearCacheExit = new System.Windows.Forms.CheckBox();
            this.linkLabelClearCache = new System.Windows.Forms.LinkLabel();
            this.linkLabelOpenCacheDir = new System.Windows.Forms.LinkLabel();
            this.panelTTSEngineSettings = new System.Windows.Forms.Panel();
            this.groupBoxPlayback = new System.Windows.Forms.GroupBox();
            this.radioButtonPlaybackBuiltIn = new System.Windows.Forms.RadioButton();
            this.radioButtonPlaybackACT = new System.Windows.Forms.RadioButton();
            this.radioButtonPlaybackYukkuri = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanelPlayback = new System.Windows.Forms.TableLayoutPanel();
            this.labelPlaybackApi = new System.Windows.Forms.Label();
            this.comboBoxPlaybackApi = new System.Windows.Forms.ComboBox();
            this.labelPlaybackDevice = new System.Windows.Forms.Label();
            this.trackBarMasterVolume = new System.Windows.Forms.TrackBar();
            this.comboBoxPlaybackDevice = new System.Windows.Forms.ComboBox();
            this.labelCurrentVolume = new System.Windows.Forms.Label();
            this.labelMasterVolume = new System.Windows.Forms.Label();
            this.groupBoxUpdate = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCurrentVersion = new System.Windows.Forms.Label();
            this.labelCurrentVersionValue = new System.Windows.Forms.Label();
            this.labelLatestStableVersion = new System.Windows.Forms.Label();
            this.labelLatestVersion = new System.Windows.Forms.Label();
            this.labelLatestStableVersionValue = new System.Windows.Forms.Label();
            this.labelLatestVersionValue = new System.Windows.Forms.Label();
            this.checkBoxCheckUpdate = new System.Windows.Forms.CheckBox();
            this.checkBoxNotifyStableOnly = new System.Windows.Forms.CheckBox();
            this.buttonCheckUpdate = new System.Windows.Forms.Button();
            this.buttonDownloadUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanelMainLanguage = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelMainLanguage = new System.Windows.Forms.Label();
            this.labelNeedToRestart = new System.Windows.Forms.Label();
            this.tabPageTextProcessor = new System.Windows.Forms.TabPage();
            this.groupBoxPreprocessRules = new System.Windows.Forms.GroupBox();
            this.tableEditRule = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxUseRegex = new System.Windows.Forms.CheckBox();
            this.labelFindPattern = new System.Windows.Forms.Label();
            this.labelReplacement = new System.Windows.Forms.Label();
            this.textBoxFindPattern = new System.Windows.Forms.TextBox();
            this.textBoxReplacement = new System.Windows.Forms.TextBox();
            this.checkBoxRuleEnabled = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddRule = new System.Windows.Forms.Button();
            this.buttonDupRule = new System.Windows.Forms.Button();
            this.buttonDelRule = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.dataGridViewRules = new System.Windows.Forms.DataGridView();
            this.ColumnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnFindPattern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReplacement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUseRegex = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.checkBoxDebugLogging = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPageGeneralSettings.SuspendLayout();
            this.groupBoxIntegration.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxTTSEngine.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxPlayback.SuspendLayout();
            this.tableLayoutPanelPlayback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterVolume)).BeginInit();
            this.groupBoxUpdate.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanelMainLanguage.SuspendLayout();
            this.tabPageTextProcessor.SuspendLayout();
            this.groupBoxPreprocessRules.SuspendLayout();
            this.tableEditRule.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRules)).BeginInit();
            this.tabPageLog.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGeneralSettings);
            this.tabControl1.Controls.Add(this.tabPageTextProcessor);
            this.tabControl1.Controls.Add(this.tabPageLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1009, 860);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPageGeneralSettings
            // 
            this.tabPageGeneralSettings.AutoScroll = true;
            this.tabPageGeneralSettings.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageGeneralSettings.Controls.Add(this.groupBoxIntegration);
            this.tabPageGeneralSettings.Controls.Add(this.groupBoxPreview);
            this.tabPageGeneralSettings.Controls.Add(this.groupBoxTTSEngine);
            this.tabPageGeneralSettings.Controls.Add(this.panelTTSEngineSettings);
            this.tabPageGeneralSettings.Controls.Add(this.groupBoxPlayback);
            this.tabPageGeneralSettings.Controls.Add(this.groupBoxUpdate);
            this.tabPageGeneralSettings.Controls.Add(this.tableLayoutPanelMainLanguage);
            this.tabPageGeneralSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneralSettings.Name = "tabPageGeneralSettings";
            this.tabPageGeneralSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneralSettings.Size = new System.Drawing.Size(1001, 834);
            this.tabPageGeneralSettings.TabIndex = 0;
            this.tabPageGeneralSettings.Text = "General Settings";
            // 
            // groupBoxIntegration
            // 
            this.groupBoxIntegration.Controls.Add(this.radioButtonIntegrationYukkuri);
            this.groupBoxIntegration.Controls.Add(this.radioButtonIntegrationAct);
            this.groupBoxIntegration.Controls.Add(this.radioButtonIntegrationAuto);
            this.groupBoxIntegration.Location = new System.Drawing.Point(5, 43);
            this.groupBoxIntegration.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxIntegration.Name = "groupBoxIntegration";
            this.groupBoxIntegration.Size = new System.Drawing.Size(262, 93);
            this.groupBoxIntegration.TabIndex = 15;
            this.groupBoxIntegration.TabStop = false;
            this.groupBoxIntegration.Text = "Plugin Integration";
            // 
            // radioButtonIntegrationYukkuri
            // 
            this.radioButtonIntegrationYukkuri.AutoSize = true;
            this.radioButtonIntegrationYukkuri.Enabled = false;
            this.radioButtonIntegrationYukkuri.Location = new System.Drawing.Point(9, 67);
            this.radioButtonIntegrationYukkuri.Name = "radioButtonIntegrationYukkuri";
            this.radioButtonIntegrationYukkuri.Size = new System.Drawing.Size(65, 16);
            this.radioButtonIntegrationYukkuri.TabIndex = 2;
            this.radioButtonIntegrationYukkuri.Text = "Yukkuri";
            this.radioButtonIntegrationYukkuri.UseVisualStyleBackColor = true;
            this.radioButtonIntegrationYukkuri.Visible = false;
            // 
            // radioButtonIntegrationAct
            // 
            this.radioButtonIntegrationAct.AutoSize = true;
            this.radioButtonIntegrationAct.Enabled = false;
            this.radioButtonIntegrationAct.Location = new System.Drawing.Point(9, 44);
            this.radioButtonIntegrationAct.Name = "radioButtonIntegrationAct";
            this.radioButtonIntegrationAct.Size = new System.Drawing.Size(41, 16);
            this.radioButtonIntegrationAct.TabIndex = 1;
            this.radioButtonIntegrationAct.Text = "ACT";
            this.radioButtonIntegrationAct.UseVisualStyleBackColor = true;
            this.radioButtonIntegrationAct.Visible = false;
            // 
            // radioButtonIntegrationAuto
            // 
            this.radioButtonIntegrationAuto.AutoSize = true;
            this.radioButtonIntegrationAuto.Checked = true;
            this.radioButtonIntegrationAuto.Location = new System.Drawing.Point(9, 21);
            this.radioButtonIntegrationAuto.Name = "radioButtonIntegrationAuto";
            this.radioButtonIntegrationAuto.Size = new System.Drawing.Size(107, 16);
            this.radioButtonIntegrationAuto.TabIndex = 0;
            this.radioButtonIntegrationAuto.TabStop = true;
            this.radioButtonIntegrationAuto.Text = "Auto Detection";
            this.radioButtonIntegrationAuto.UseVisualStyleBackColor = true;
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxPreview.Location = new System.Drawing.Point(5, 478);
            this.groupBoxPreview.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPreview.Size = new System.Drawing.Size(262, 51);
            this.groupBoxPreview.TabIndex = 8;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "Preview";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.textBoxPreview, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonPreview, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(258, 33);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textBoxPreview
            // 
            this.textBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPreview.Location = new System.Drawing.Point(2, 4);
            this.textBoxPreview.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPreview.Name = "textBoxPreview";
            this.textBoxPreview.Size = new System.Drawing.Size(194, 21);
            this.textBoxPreview.TabIndex = 8;
            // 
            // buttonPreview
            // 
            this.buttonPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreview.AutoSize = true;
            this.buttonPreview.Location = new System.Drawing.Point(200, 2);
            this.buttonPreview.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(56, 25);
            this.buttonPreview.TabIndex = 9;
            this.buttonPreview.Text = "Say!";
            this.buttonPreview.UseVisualStyleBackColor = true;
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            // 
            // groupBoxTTSEngine
            // 
            this.groupBoxTTSEngine.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxTTSEngine.Location = new System.Drawing.Point(5, 341);
            this.groupBoxTTSEngine.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxTTSEngine.Name = "groupBoxTTSEngine";
            this.groupBoxTTSEngine.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxTTSEngine.Size = new System.Drawing.Size(262, 133);
            this.groupBoxTTSEngine.TabIndex = 7;
            this.groupBoxTTSEngine.TabStop = false;
            this.groupBoxTTSEngine.Text = "TTS Engine";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelTTSEngine, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTTSEngine, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxClearCacheExit, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.linkLabelClearCache, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.linkLabelOpenCacheDir, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(258, 115);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelTTSEngine
            // 
            this.labelTTSEngine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTTSEngine.AutoSize = true;
            this.labelTTSEngine.Location = new System.Drawing.Point(2, 6);
            this.labelTTSEngine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTTSEngine.Name = "labelTTSEngine";
            this.labelTTSEngine.Size = new System.Drawing.Size(47, 12);
            this.labelTTSEngine.TabIndex = 0;
            this.labelTTSEngine.Text = "Engine:";
            // 
            // comboBoxTTSEngine
            // 
            this.comboBoxTTSEngine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTTSEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTTSEngine.FormattingEnabled = true;
            this.comboBoxTTSEngine.Location = new System.Drawing.Point(53, 2);
            this.comboBoxTTSEngine.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTTSEngine.Name = "comboBoxTTSEngine";
            this.comboBoxTTSEngine.Size = new System.Drawing.Size(203, 20);
            this.comboBoxTTSEngine.TabIndex = 4;
            // 
            // checkBoxClearCacheExit
            // 
            this.checkBoxClearCacheExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxClearCacheExit.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxClearCacheExit, 2);
            this.checkBoxClearCacheExit.Enabled = false;
            this.checkBoxClearCacheExit.Location = new System.Drawing.Point(2, 26);
            this.checkBoxClearCacheExit.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxClearCacheExit.Name = "checkBoxClearCacheExit";
            this.checkBoxClearCacheExit.Size = new System.Drawing.Size(254, 16);
            this.checkBoxClearCacheExit.TabIndex = 5;
            this.checkBoxClearCacheExit.Text = "Clear Cache on Exit";
            this.checkBoxClearCacheExit.UseVisualStyleBackColor = true;
            this.checkBoxClearCacheExit.Visible = false;
            // 
            // linkLabelClearCache
            // 
            this.linkLabelClearCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelClearCache.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.linkLabelClearCache, 2);
            this.linkLabelClearCache.Location = new System.Drawing.Point(2, 87);
            this.linkLabelClearCache.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelClearCache.Name = "linkLabelClearCache";
            this.linkLabelClearCache.Size = new System.Drawing.Size(254, 12);
            this.linkLabelClearCache.TabIndex = 7;
            this.linkLabelClearCache.TabStop = true;
            this.linkLabelClearCache.Text = "Clear Cache Right Now";
            this.linkLabelClearCache.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClearCache_LinkClicked);
            // 
            // linkLabelOpenCacheDir
            // 
            this.linkLabelOpenCacheDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelOpenCacheDir.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.linkLabelOpenCacheDir, 2);
            this.linkLabelOpenCacheDir.Location = new System.Drawing.Point(2, 75);
            this.linkLabelOpenCacheDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelOpenCacheDir.Name = "linkLabelOpenCacheDir";
            this.linkLabelOpenCacheDir.Size = new System.Drawing.Size(254, 12);
            this.linkLabelOpenCacheDir.TabIndex = 6;
            this.linkLabelOpenCacheDir.TabStop = true;
            this.linkLabelOpenCacheDir.Text = "Open Cache Directory";
            this.linkLabelOpenCacheDir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenCacheDir_LinkClicked);
            // 
            // panelTTSEngineSettings
            // 
            this.panelTTSEngineSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTTSEngineSettings.AutoSize = true;
            this.panelTTSEngineSettings.Location = new System.Drawing.Point(271, 43);
            this.panelTTSEngineSettings.Margin = new System.Windows.Forms.Padding(2);
            this.panelTTSEngineSettings.Name = "panelTTSEngineSettings";
            this.panelTTSEngineSettings.Size = new System.Drawing.Size(727, 37);
            this.panelTTSEngineSettings.TabIndex = 14;
            // 
            // groupBoxPlayback
            // 
            this.groupBoxPlayback.Controls.Add(this.radioButtonPlaybackBuiltIn);
            this.groupBoxPlayback.Controls.Add(this.radioButtonPlaybackACT);
            this.groupBoxPlayback.Controls.Add(this.radioButtonPlaybackYukkuri);
            this.groupBoxPlayback.Controls.Add(this.tableLayoutPanelPlayback);
            this.groupBoxPlayback.Location = new System.Drawing.Point(5, 140);
            this.groupBoxPlayback.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPlayback.Name = "groupBoxPlayback";
            this.groupBoxPlayback.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPlayback.Size = new System.Drawing.Size(262, 197);
            this.groupBoxPlayback.TabIndex = 5;
            this.groupBoxPlayback.TabStop = false;
            this.groupBoxPlayback.Text = "Playback";
            // 
            // radioButtonPlaybackBuiltIn
            // 
            this.radioButtonPlaybackBuiltIn.AutoSize = true;
            this.radioButtonPlaybackBuiltIn.Location = new System.Drawing.Point(6, 63);
            this.radioButtonPlaybackBuiltIn.Name = "radioButtonPlaybackBuiltIn";
            this.radioButtonPlaybackBuiltIn.Size = new System.Drawing.Size(185, 16);
            this.radioButtonPlaybackBuiltIn.TabIndex = 3;
            this.radioButtonPlaybackBuiltIn.Text = "Use Built-in Sound Playback";
            this.radioButtonPlaybackBuiltIn.UseVisualStyleBackColor = true;
            // 
            // radioButtonPlaybackACT
            // 
            this.radioButtonPlaybackACT.AutoSize = true;
            this.radioButtonPlaybackACT.Checked = true;
            this.radioButtonPlaybackACT.Location = new System.Drawing.Point(6, 19);
            this.radioButtonPlaybackACT.Name = "radioButtonPlaybackACT";
            this.radioButtonPlaybackACT.Size = new System.Drawing.Size(179, 16);
            this.radioButtonPlaybackACT.TabIndex = 2;
            this.radioButtonPlaybackACT.TabStop = true;
            this.radioButtonPlaybackACT.Text = "Use ACT for Sound Playback";
            this.radioButtonPlaybackACT.UseVisualStyleBackColor = true;
            // 
            // radioButtonPlaybackYukkuri
            // 
            this.radioButtonPlaybackYukkuri.AutoSize = true;
            this.radioButtonPlaybackYukkuri.Location = new System.Drawing.Point(6, 41);
            this.radioButtonPlaybackYukkuri.Name = "radioButtonPlaybackYukkuri";
            this.radioButtonPlaybackYukkuri.Size = new System.Drawing.Size(221, 16);
            this.radioButtonPlaybackYukkuri.TabIndex = 1;
            this.radioButtonPlaybackYukkuri.Text = "Use TTSYukkuri for Sound Playback";
            this.radioButtonPlaybackYukkuri.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelPlayback
            // 
            this.tableLayoutPanelPlayback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelPlayback.ColumnCount = 3;
            this.tableLayoutPanelPlayback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelPlayback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPlayback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelPlayback.Controls.Add(this.labelPlaybackApi, 0, 0);
            this.tableLayoutPanelPlayback.Controls.Add(this.comboBoxPlaybackApi, 1, 0);
            this.tableLayoutPanelPlayback.Controls.Add(this.labelPlaybackDevice, 0, 1);
            this.tableLayoutPanelPlayback.Controls.Add(this.trackBarMasterVolume, 1, 2);
            this.tableLayoutPanelPlayback.Controls.Add(this.comboBoxPlaybackDevice, 1, 1);
            this.tableLayoutPanelPlayback.Controls.Add(this.labelCurrentVolume, 1, 2);
            this.tableLayoutPanelPlayback.Controls.Add(this.labelMasterVolume, 0, 2);
            this.tableLayoutPanelPlayback.Location = new System.Drawing.Point(5, 84);
            this.tableLayoutPanelPlayback.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelPlayback.Name = "tableLayoutPanelPlayback";
            this.tableLayoutPanelPlayback.RowCount = 4;
            this.tableLayoutPanelPlayback.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPlayback.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPlayback.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPlayback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPlayback.Size = new System.Drawing.Size(252, 108);
            this.tableLayoutPanelPlayback.TabIndex = 1;
            // 
            // labelPlaybackApi
            // 
            this.labelPlaybackApi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlaybackApi.AutoSize = true;
            this.labelPlaybackApi.Location = new System.Drawing.Point(2, 6);
            this.labelPlaybackApi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlaybackApi.Name = "labelPlaybackApi";
            this.labelPlaybackApi.Size = new System.Drawing.Size(77, 12);
            this.labelPlaybackApi.TabIndex = 3;
            this.labelPlaybackApi.Text = "Api:";
            // 
            // comboBoxPlaybackApi
            // 
            this.comboBoxPlaybackApi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelPlayback.SetColumnSpan(this.comboBoxPlaybackApi, 2);
            this.comboBoxPlaybackApi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlaybackApi.FormattingEnabled = true;
            this.comboBoxPlaybackApi.Location = new System.Drawing.Point(83, 2);
            this.comboBoxPlaybackApi.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPlaybackApi.Name = "comboBoxPlaybackApi";
            this.comboBoxPlaybackApi.Size = new System.Drawing.Size(167, 20);
            this.comboBoxPlaybackApi.TabIndex = 4;
            // 
            // labelPlaybackDevice
            // 
            this.labelPlaybackDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlaybackDevice.AutoSize = true;
            this.labelPlaybackDevice.Location = new System.Drawing.Point(2, 30);
            this.labelPlaybackDevice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlaybackDevice.Name = "labelPlaybackDevice";
            this.labelPlaybackDevice.Size = new System.Drawing.Size(77, 12);
            this.labelPlaybackDevice.TabIndex = 5;
            this.labelPlaybackDevice.Text = "Device:";
            // 
            // trackBarMasterVolume
            // 
            this.trackBarMasterVolume.BackColor = System.Drawing.SystemColors.Window;
            this.trackBarMasterVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarMasterVolume.Location = new System.Drawing.Point(83, 50);
            this.trackBarMasterVolume.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarMasterVolume.Maximum = 100;
            this.trackBarMasterVolume.Name = "trackBarMasterVolume";
            this.trackBarMasterVolume.Size = new System.Drawing.Size(133, 45);
            this.trackBarMasterVolume.TabIndex = 3;
            this.trackBarMasterVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarMasterVolume.Value = 100;
            // 
            // comboBoxPlaybackDevice
            // 
            this.comboBoxPlaybackDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelPlayback.SetColumnSpan(this.comboBoxPlaybackDevice, 2);
            this.comboBoxPlaybackDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlaybackDevice.FormattingEnabled = true;
            this.comboBoxPlaybackDevice.Location = new System.Drawing.Point(83, 26);
            this.comboBoxPlaybackDevice.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPlaybackDevice.Name = "comboBoxPlaybackDevice";
            this.comboBoxPlaybackDevice.Size = new System.Drawing.Size(167, 20);
            this.comboBoxPlaybackDevice.TabIndex = 6;
            // 
            // labelCurrentVolume
            // 
            this.labelCurrentVolume.AutoSize = true;
            this.labelCurrentVolume.Location = new System.Drawing.Point(220, 48);
            this.labelCurrentVolume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurrentVolume.MinimumSize = new System.Drawing.Size(30, 0);
            this.labelCurrentVolume.Name = "labelCurrentVolume";
            this.labelCurrentVolume.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labelCurrentVolume.Size = new System.Drawing.Size(30, 18);
            this.labelCurrentVolume.TabIndex = 2;
            this.labelCurrentVolume.Text = "100";
            // 
            // labelMasterVolume
            // 
            this.labelMasterVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMasterVolume.AutoSize = true;
            this.labelMasterVolume.Location = new System.Drawing.Point(2, 48);
            this.labelMasterVolume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMasterVolume.Name = "labelMasterVolume";
            this.labelMasterVolume.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labelMasterVolume.Size = new System.Drawing.Size(77, 18);
            this.labelMasterVolume.TabIndex = 0;
            this.labelMasterVolume.Text = "Master Vol.:";
            // 
            // groupBoxUpdate
            // 
            this.groupBoxUpdate.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxUpdate.Location = new System.Drawing.Point(5, 533);
            this.groupBoxUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxUpdate.Name = "groupBoxUpdate";
            this.groupBoxUpdate.Size = new System.Drawing.Size(262, 173);
            this.groupBoxUpdate.TabIndex = 4;
            this.groupBoxUpdate.TabStop = false;
            this.groupBoxUpdate.Text = "Update";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.labelCurrentVersion, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelCurrentVersionValue, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelLatestStableVersion, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelLatestVersion, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelLatestStableVersionValue, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelLatestVersionValue, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxCheckUpdate, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxNotifyStableOnly, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.buttonCheckUpdate, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.buttonDownloadUpdate, 0, 6);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(256, 153);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // labelCurrentVersion
            // 
            this.labelCurrentVersion.AutoSize = true;
            this.labelCurrentVersion.Location = new System.Drawing.Point(3, 0);
            this.labelCurrentVersion.Name = "labelCurrentVersion";
            this.labelCurrentVersion.Size = new System.Drawing.Size(101, 12);
            this.labelCurrentVersion.TabIndex = 0;
            this.labelCurrentVersion.Text = "Current Version:";
            // 
            // labelCurrentVersionValue
            // 
            this.labelCurrentVersionValue.AutoSize = true;
            this.labelCurrentVersionValue.Location = new System.Drawing.Point(146, 0);
            this.labelCurrentVersionValue.Name = "labelCurrentVersionValue";
            this.labelCurrentVersionValue.Size = new System.Drawing.Size(41, 12);
            this.labelCurrentVersionValue.TabIndex = 1;
            this.labelCurrentVersionValue.Text = "label2";
            // 
            // labelLatestStableVersion
            // 
            this.labelLatestStableVersion.AutoSize = true;
            this.labelLatestStableVersion.Location = new System.Drawing.Point(3, 12);
            this.labelLatestStableVersion.Name = "labelLatestStableVersion";
            this.labelLatestStableVersion.Size = new System.Drawing.Size(137, 12);
            this.labelLatestStableVersion.TabIndex = 2;
            this.labelLatestStableVersion.Text = "Latest Stable Version:";
            // 
            // labelLatestVersion
            // 
            this.labelLatestVersion.AutoSize = true;
            this.labelLatestVersion.Location = new System.Drawing.Point(3, 24);
            this.labelLatestVersion.Name = "labelLatestVersion";
            this.labelLatestVersion.Size = new System.Drawing.Size(95, 12);
            this.labelLatestVersion.TabIndex = 3;
            this.labelLatestVersion.Text = "Latest Version:";
            // 
            // labelLatestStableVersionValue
            // 
            this.labelLatestStableVersionValue.AutoSize = true;
            this.labelLatestStableVersionValue.Location = new System.Drawing.Point(146, 12);
            this.labelLatestStableVersionValue.Name = "labelLatestStableVersionValue";
            this.labelLatestStableVersionValue.Size = new System.Drawing.Size(41, 12);
            this.labelLatestStableVersionValue.TabIndex = 4;
            this.labelLatestStableVersionValue.Text = "label5";
            // 
            // labelLatestVersionValue
            // 
            this.labelLatestVersionValue.AutoSize = true;
            this.labelLatestVersionValue.Location = new System.Drawing.Point(146, 24);
            this.labelLatestVersionValue.Name = "labelLatestVersionValue";
            this.labelLatestVersionValue.Size = new System.Drawing.Size(41, 12);
            this.labelLatestVersionValue.TabIndex = 5;
            this.labelLatestVersionValue.Text = "label6";
            // 
            // checkBoxCheckUpdate
            // 
            this.checkBoxCheckUpdate.AutoSize = true;
            this.checkBoxCheckUpdate.Checked = true;
            this.checkBoxCheckUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel4.SetColumnSpan(this.checkBoxCheckUpdate, 2);
            this.checkBoxCheckUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCheckUpdate.Location = new System.Drawing.Point(3, 39);
            this.checkBoxCheckUpdate.Name = "checkBoxCheckUpdate";
            this.checkBoxCheckUpdate.Size = new System.Drawing.Size(250, 16);
            this.checkBoxCheckUpdate.TabIndex = 10;
            this.checkBoxCheckUpdate.Text = "Check Update on Startup";
            this.checkBoxCheckUpdate.UseVisualStyleBackColor = true;
            // 
            // checkBoxNotifyStableOnly
            // 
            this.checkBoxNotifyStableOnly.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.checkBoxNotifyStableOnly, 2);
            this.checkBoxNotifyStableOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxNotifyStableOnly.Location = new System.Drawing.Point(3, 61);
            this.checkBoxNotifyStableOnly.Name = "checkBoxNotifyStableOnly";
            this.checkBoxNotifyStableOnly.Size = new System.Drawing.Size(250, 16);
            this.checkBoxNotifyStableOnly.TabIndex = 11;
            this.checkBoxNotifyStableOnly.Text = "Check for Stable Version Only";
            this.checkBoxNotifyStableOnly.UseVisualStyleBackColor = true;
            // 
            // buttonCheckUpdate
            // 
            this.buttonCheckUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCheckUpdate.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.buttonCheckUpdate, 2);
            this.buttonCheckUpdate.Location = new System.Drawing.Point(108, 83);
            this.buttonCheckUpdate.Name = "buttonCheckUpdate";
            this.buttonCheckUpdate.Size = new System.Drawing.Size(145, 25);
            this.buttonCheckUpdate.TabIndex = 12;
            this.buttonCheckUpdate.Text = "Check Update Now";
            this.buttonCheckUpdate.UseVisualStyleBackColor = true;
            this.buttonCheckUpdate.Click += new System.EventHandler(this.buttonCheckUpdate_Click);
            // 
            // buttonDownloadUpdate
            // 
            this.buttonDownloadUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDownloadUpdate.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.buttonDownloadUpdate, 2);
            this.buttonDownloadUpdate.Location = new System.Drawing.Point(68, 114);
            this.buttonDownloadUpdate.Name = "buttonDownloadUpdate";
            this.buttonDownloadUpdate.Size = new System.Drawing.Size(185, 22);
            this.buttonDownloadUpdate.TabIndex = 13;
            this.buttonDownloadUpdate.Text = "Open Download Website";
            this.buttonDownloadUpdate.UseVisualStyleBackColor = true;
            this.buttonDownloadUpdate.Click += new System.EventHandler(this.buttonDownloadUpdate_Click);
            // 
            // tableLayoutPanelMainLanguage
            // 
            this.tableLayoutPanelMainLanguage.ColumnCount = 3;
            this.tableLayoutPanelMainLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMainLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMainLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMainLanguage.Controls.Add(this.comboBoxLanguage, 1, 0);
            this.tableLayoutPanelMainLanguage.Controls.Add(this.labelMainLanguage, 0, 0);
            this.tableLayoutPanelMainLanguage.Controls.Add(this.labelNeedToRestart, 2, 0);
            this.tableLayoutPanelMainLanguage.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanelMainLanguage.Name = "tableLayoutPanelMainLanguage";
            this.tableLayoutPanelMainLanguage.RowCount = 1;
            this.tableLayoutPanelMainLanguage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMainLanguage.Size = new System.Drawing.Size(505, 31);
            this.tableLayoutPanelMainLanguage.TabIndex = 0;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(68, 5);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(273, 20);
            this.comboBoxLanguage.TabIndex = 0;
            // 
            // labelMainLanguage
            // 
            this.labelMainLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMainLanguage.AutoSize = true;
            this.labelMainLanguage.Location = new System.Drawing.Point(3, 9);
            this.labelMainLanguage.Name = "labelMainLanguage";
            this.labelMainLanguage.Size = new System.Drawing.Size(59, 12);
            this.labelMainLanguage.TabIndex = 4;
            this.labelMainLanguage.Text = "Language:";
            // 
            // labelNeedToRestart
            // 
            this.labelNeedToRestart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNeedToRestart.AutoSize = true;
            this.labelNeedToRestart.Enabled = false;
            this.labelNeedToRestart.Location = new System.Drawing.Point(347, 9);
            this.labelNeedToRestart.Name = "labelNeedToRestart";
            this.labelNeedToRestart.Size = new System.Drawing.Size(155, 12);
            this.labelNeedToRestart.TabIndex = 5;
            this.labelNeedToRestart.Text = "*Need to restart the ACT.";
            // 
            // tabPageTextProcessor
            // 
            this.tabPageTextProcessor.AutoScroll = true;
            this.tabPageTextProcessor.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageTextProcessor.Controls.Add(this.groupBoxPreprocessRules);
            this.tabPageTextProcessor.Location = new System.Drawing.Point(4, 22);
            this.tabPageTextProcessor.Name = "tabPageTextProcessor";
            this.tabPageTextProcessor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTextProcessor.Size = new System.Drawing.Size(1001, 834);
            this.tabPageTextProcessor.TabIndex = 3;
            this.tabPageTextProcessor.Text = "Text Processor";
            // 
            // groupBoxPreprocessRules
            // 
            this.groupBoxPreprocessRules.AutoSize = true;
            this.groupBoxPreprocessRules.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxPreprocessRules.Controls.Add(this.tableEditRule);
            this.groupBoxPreprocessRules.Controls.Add(this.tableLayoutPanel3);
            this.groupBoxPreprocessRules.Controls.Add(this.dataGridViewRules);
            this.groupBoxPreprocessRules.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxPreprocessRules.Location = new System.Drawing.Point(3, 3);
            this.groupBoxPreprocessRules.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPreprocessRules.Name = "groupBoxPreprocessRules";
            this.groupBoxPreprocessRules.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPreprocessRules.Size = new System.Drawing.Size(995, 328);
            this.groupBoxPreprocessRules.TabIndex = 0;
            this.groupBoxPreprocessRules.TabStop = false;
            this.groupBoxPreprocessRules.Text = "Preprocess Rules";
            // 
            // tableEditRule
            // 
            this.tableEditRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableEditRule.AutoSize = true;
            this.tableEditRule.ColumnCount = 4;
            this.tableEditRule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableEditRule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableEditRule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableEditRule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableEditRule.Controls.Add(this.checkBoxUseRegex, 3, 0);
            this.tableEditRule.Controls.Add(this.labelFindPattern, 0, 1);
            this.tableEditRule.Controls.Add(this.labelReplacement, 0, 2);
            this.tableEditRule.Controls.Add(this.textBoxFindPattern, 1, 1);
            this.tableEditRule.Controls.Add(this.textBoxReplacement, 1, 2);
            this.tableEditRule.Controls.Add(this.checkBoxRuleEnabled, 1, 0);
            this.tableEditRule.Enabled = false;
            this.tableEditRule.Location = new System.Drawing.Point(6, 233);
            this.tableEditRule.Name = "tableEditRule";
            this.tableEditRule.RowCount = 3;
            this.tableEditRule.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableEditRule.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableEditRule.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableEditRule.Size = new System.Drawing.Size(982, 76);
            this.tableEditRule.TabIndex = 2;
            // 
            // checkBoxUseRegex
            // 
            this.checkBoxUseRegex.AutoSize = true;
            this.checkBoxUseRegex.Location = new System.Drawing.Point(228, 3);
            this.checkBoxUseRegex.Name = "checkBoxUseRegex";
            this.checkBoxUseRegex.Size = new System.Drawing.Size(78, 16);
            this.checkBoxUseRegex.TabIndex = 3;
            this.checkBoxUseRegex.Text = "Use Regex";
            this.checkBoxUseRegex.UseVisualStyleBackColor = true;
            this.checkBoxUseRegex.CheckedChanged += new System.EventHandler(this.checkBoxUseRegex_CheckedChanged);
            // 
            // labelFindPattern
            // 
            this.labelFindPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFindPattern.AutoSize = true;
            this.labelFindPattern.Location = new System.Drawing.Point(3, 29);
            this.labelFindPattern.Name = "labelFindPattern";
            this.labelFindPattern.Size = new System.Drawing.Size(83, 12);
            this.labelFindPattern.TabIndex = 4;
            this.labelFindPattern.Text = "Find Pattern:";
            // 
            // labelReplacement
            // 
            this.labelReplacement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReplacement.AutoSize = true;
            this.labelReplacement.Location = new System.Drawing.Point(3, 56);
            this.labelReplacement.Name = "labelReplacement";
            this.labelReplacement.Size = new System.Drawing.Size(83, 12);
            this.labelReplacement.TabIndex = 5;
            this.labelReplacement.Text = "Replacement:";
            // 
            // textBoxFindPattern
            // 
            this.textBoxFindPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableEditRule.SetColumnSpan(this.textBoxFindPattern, 3);
            this.textBoxFindPattern.Location = new System.Drawing.Point(92, 25);
            this.textBoxFindPattern.Name = "textBoxFindPattern";
            this.textBoxFindPattern.Size = new System.Drawing.Size(887, 21);
            this.textBoxFindPattern.TabIndex = 6;
            this.textBoxFindPattern.TextChanged += new System.EventHandler(this.textBoxFindPattern_TextChanged);
            // 
            // textBoxReplacement
            // 
            this.textBoxReplacement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableEditRule.SetColumnSpan(this.textBoxReplacement, 3);
            this.textBoxReplacement.Location = new System.Drawing.Point(92, 52);
            this.textBoxReplacement.Name = "textBoxReplacement";
            this.textBoxReplacement.Size = new System.Drawing.Size(887, 21);
            this.textBoxReplacement.TabIndex = 7;
            this.textBoxReplacement.TextChanged += new System.EventHandler(this.textBoxReplacement_TextChanged);
            // 
            // checkBoxRuleEnabled
            // 
            this.checkBoxRuleEnabled.AutoSize = true;
            this.checkBoxRuleEnabled.Location = new System.Drawing.Point(92, 3);
            this.checkBoxRuleEnabled.Name = "checkBoxRuleEnabled";
            this.checkBoxRuleEnabled.Size = new System.Drawing.Size(66, 16);
            this.checkBoxRuleEnabled.TabIndex = 2;
            this.checkBoxRuleEnabled.Text = "Enabled";
            this.checkBoxRuleEnabled.UseVisualStyleBackColor = true;
            this.checkBoxRuleEnabled.CheckedChanged += new System.EventHandler(this.checkBoxRuleEnabled_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.buttonAddRule, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonDupRule, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonDelRule, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonMoveDown, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonMoveUp, 4, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 202);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(986, 26);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // buttonAddRule
            // 
            this.buttonAddRule.AutoSize = true;
            this.buttonAddRule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddRule.Location = new System.Drawing.Point(2, 2);
            this.buttonAddRule.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddRule.Name = "buttonAddRule";
            this.buttonAddRule.Size = new System.Drawing.Size(63, 22);
            this.buttonAddRule.TabIndex = 0;
            this.buttonAddRule.Text = "Add Rule";
            this.buttonAddRule.UseVisualStyleBackColor = true;
            this.buttonAddRule.Click += new System.EventHandler(this.buttonAddRule_Click);
            // 
            // buttonDupRule
            // 
            this.buttonDupRule.AutoSize = true;
            this.buttonDupRule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDupRule.Enabled = false;
            this.buttonDupRule.Location = new System.Drawing.Point(69, 2);
            this.buttonDupRule.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDupRule.Name = "buttonDupRule";
            this.buttonDupRule.Size = new System.Drawing.Size(63, 22);
            this.buttonDupRule.TabIndex = 1;
            this.buttonDupRule.Text = "Dup Rule";
            this.buttonDupRule.UseVisualStyleBackColor = true;
            this.buttonDupRule.Click += new System.EventHandler(this.buttonDupRule_Click);
            // 
            // buttonDelRule
            // 
            this.buttonDelRule.AutoSize = true;
            this.buttonDelRule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDelRule.Enabled = false;
            this.buttonDelRule.Location = new System.Drawing.Point(136, 2);
            this.buttonDelRule.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelRule.Name = "buttonDelRule";
            this.buttonDelRule.Size = new System.Drawing.Size(81, 22);
            this.buttonDelRule.TabIndex = 2;
            this.buttonDelRule.Text = "Delete Rule";
            this.buttonDelRule.UseVisualStyleBackColor = true;
            this.buttonDelRule.Click += new System.EventHandler(this.buttonDelRule_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.AutoSize = true;
            this.buttonMoveDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonMoveDown.Enabled = false;
            this.buttonMoveDown.Location = new System.Drawing.Point(314, 2);
            this.buttonMoveDown.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(69, 22);
            this.buttonMoveDown.TabIndex = 4;
            this.buttonMoveDown.Text = "Move Down";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.AutoSize = true;
            this.buttonMoveUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonMoveUp.Enabled = false;
            this.buttonMoveUp.Location = new System.Drawing.Point(253, 2);
            this.buttonMoveUp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(57, 22);
            this.buttonMoveUp.TabIndex = 3;
            this.buttonMoveUp.Text = "Move Up";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // dataGridViewRules
            // 
            this.dataGridViewRules.AllowUserToAddRows = false;
            this.dataGridViewRules.AllowUserToDeleteRows = false;
            this.dataGridViewRules.AllowUserToResizeRows = false;
            this.dataGridViewRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOrder,
            this.ColumnEnabled,
            this.ColumnFindPattern,
            this.ColumnReplacement,
            this.ColumnUseRegex});
            this.dataGridViewRules.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewRules.Location = new System.Drawing.Point(2, 16);
            this.dataGridViewRules.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewRules.MultiSelect = false;
            this.dataGridViewRules.Name = "dataGridViewRules";
            this.dataGridViewRules.ReadOnly = true;
            this.dataGridViewRules.RowHeadersVisible = false;
            this.dataGridViewRules.RowHeadersWidth = 100;
            this.dataGridViewRules.RowTemplate.Height = 27;
            this.dataGridViewRules.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRules.Size = new System.Drawing.Size(991, 178);
            this.dataGridViewRules.TabIndex = 0;
            // 
            // ColumnOrder
            // 
            this.ColumnOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnOrder.HeaderText = "";
            this.ColumnOrder.MinimumWidth = 40;
            this.ColumnOrder.Name = "ColumnOrder";
            this.ColumnOrder.ReadOnly = true;
            this.ColumnOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnOrder.Width = 40;
            // 
            // ColumnEnabled
            // 
            this.ColumnEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnEnabled.HeaderText = "Enabled";
            this.ColumnEnabled.MinimumWidth = 6;
            this.ColumnEnabled.Name = "ColumnEnabled";
            this.ColumnEnabled.ReadOnly = true;
            this.ColumnEnabled.Width = 53;
            // 
            // ColumnFindPattern
            // 
            this.ColumnFindPattern.HeaderText = "Find Pattern";
            this.ColumnFindPattern.MinimumWidth = 6;
            this.ColumnFindPattern.Name = "ColumnFindPattern";
            this.ColumnFindPattern.ReadOnly = true;
            this.ColumnFindPattern.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnFindPattern.Width = 125;
            // 
            // ColumnReplacement
            // 
            this.ColumnReplacement.HeaderText = "Replacement";
            this.ColumnReplacement.MinimumWidth = 6;
            this.ColumnReplacement.Name = "ColumnReplacement";
            this.ColumnReplacement.ReadOnly = true;
            this.ColumnReplacement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnReplacement.Width = 125;
            // 
            // ColumnUseRegex
            // 
            this.ColumnUseRegex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnUseRegex.HeaderText = "Use Regex";
            this.ColumnUseRegex.MinimumWidth = 6;
            this.ColumnUseRegex.Name = "ColumnUseRegex";
            this.ColumnUseRegex.ReadOnly = true;
            this.ColumnUseRegex.Width = 59;
            // 
            // tabPageLog
            // 
            this.tabPageLog.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageLog.Controls.Add(this.tableLayoutPanel5);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(1001, 834);
            this.tabPageLog.TabIndex = 2;
            this.tabPageLog.Text = "Log";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.richTextBoxLog, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.checkBoxDebugLogging, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(995, 828);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(3, 25);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(989, 800);
            this.richTextBoxLog.TabIndex = 6;
            this.richTextBoxLog.Text = "";
            // 
            // checkBoxDebugLogging
            // 
            this.checkBoxDebugLogging.AutoSize = true;
            this.checkBoxDebugLogging.Location = new System.Drawing.Point(3, 3);
            this.checkBoxDebugLogging.Name = "checkBoxDebugLogging";
            this.checkBoxDebugLogging.Size = new System.Drawing.Size(132, 16);
            this.checkBoxDebugLogging.TabIndex = 7;
            this.checkBoxDebugLogging.Text = "Show Debug Logging";
            this.checkBoxDebugLogging.UseVisualStyleBackColor = true;
            this.checkBoxDebugLogging.CheckedChanged += new System.EventHandler(this.checkBoxDebugLogging_CheckedChanged);
            // 
            // FoxTTSTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FoxTTSTabControl";
            this.Size = new System.Drawing.Size(1009, 860);
            this.tabControl1.ResumeLayout(false);
            this.tabPageGeneralSettings.ResumeLayout(false);
            this.tabPageGeneralSettings.PerformLayout();
            this.groupBoxIntegration.ResumeLayout(false);
            this.groupBoxIntegration.PerformLayout();
            this.groupBoxPreview.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBoxTTSEngine.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxPlayback.ResumeLayout(false);
            this.groupBoxPlayback.PerformLayout();
            this.tableLayoutPanelPlayback.ResumeLayout(false);
            this.tableLayoutPanelPlayback.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterVolume)).EndInit();
            this.groupBoxUpdate.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanelMainLanguage.ResumeLayout(false);
            this.tableLayoutPanelMainLanguage.PerformLayout();
            this.tabPageTextProcessor.ResumeLayout(false);
            this.tabPageTextProcessor.PerformLayout();
            this.groupBoxPreprocessRules.ResumeLayout(false);
            this.groupBoxPreprocessRules.PerformLayout();
            this.tableEditRule.ResumeLayout(false);
            this.tableEditRule.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRules)).EndInit();
            this.tabPageLog.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGeneralSettings;
        private System.Windows.Forms.GroupBox groupBoxUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelCurrentVersion;
        private System.Windows.Forms.Label labelCurrentVersionValue;
        private System.Windows.Forms.Label labelLatestStableVersion;
        private System.Windows.Forms.Label labelLatestVersion;
        private System.Windows.Forms.Label labelLatestStableVersionValue;
        private System.Windows.Forms.Label labelLatestVersionValue;
        private System.Windows.Forms.CheckBox checkBoxCheckUpdate;
        private System.Windows.Forms.CheckBox checkBoxNotifyStableOnly;
        private System.Windows.Forms.Button buttonCheckUpdate;
        private System.Windows.Forms.Button buttonDownloadUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainLanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelMainLanguage;
        private System.Windows.Forms.Label labelNeedToRestart;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.GroupBox groupBoxPlayback;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPlayback;
        private System.Windows.Forms.Label labelMasterVolume;
        private System.Windows.Forms.TrackBar trackBarMasterVolume;
        private System.Windows.Forms.Label labelCurrentVolume;
        private System.Windows.Forms.Label labelPlaybackApi;
        private System.Windows.Forms.ComboBox comboBoxPlaybackApi;
        private System.Windows.Forms.Label labelPlaybackDevice;
        private System.Windows.Forms.ComboBox comboBoxPlaybackDevice;
        public System.Windows.Forms.Panel panelTTSEngineSettings;
        private System.Windows.Forms.GroupBox groupBoxTTSEngine;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTTSEngine;
        private System.Windows.Forms.ComboBox comboBoxTTSEngine;
        private System.Windows.Forms.CheckBox checkBoxClearCacheExit;
        private System.Windows.Forms.LinkLabel linkLabelClearCache;
        private System.Windows.Forms.LinkLabel linkLabelOpenCacheDir;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxPreview;
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.RadioButton radioButtonPlaybackACT;
        private System.Windows.Forms.RadioButton radioButtonPlaybackYukkuri;
        private System.Windows.Forms.GroupBox groupBoxIntegration;
        private System.Windows.Forms.RadioButton radioButtonIntegrationYukkuri;
        private System.Windows.Forms.RadioButton radioButtonIntegrationAct;
        private System.Windows.Forms.RadioButton radioButtonIntegrationAuto;
        private System.Windows.Forms.RadioButton radioButtonPlaybackBuiltIn;
        private System.Windows.Forms.TabPage tabPageTextProcessor;
        private System.Windows.Forms.GroupBox groupBoxPreprocessRules;
        private System.Windows.Forms.DataGridView dataGridViewRules;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonAddRule;
        private System.Windows.Forms.Button buttonDupRule;
        private System.Windows.Forms.Button buttonDelRule;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.CheckBox checkBoxRuleEnabled;
        private System.Windows.Forms.TableLayoutPanel tableEditRule;
        private System.Windows.Forms.CheckBox checkBoxUseRegex;
        private System.Windows.Forms.Label labelFindPattern;
        private System.Windows.Forms.Label labelReplacement;
        private System.Windows.Forms.TextBox textBoxFindPattern;
        private System.Windows.Forms.TextBox textBoxReplacement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFindPattern;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReplacement;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnUseRegex;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox checkBoxDebugLogging;
    }
}
