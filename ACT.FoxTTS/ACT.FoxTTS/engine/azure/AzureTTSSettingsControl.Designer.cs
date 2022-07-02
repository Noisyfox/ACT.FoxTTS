namespace ACT.FoxTTS.engine.azure
{
    partial class AzureTTSSettingsControl
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxTTSEngineDetail = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.comboBoxStyle = new System.Windows.Forms.ComboBox();
            this.labelStyle = new System.Windows.Forms.Label();
            this.textBoxRegion = new System.Windows.Forms.TextBox();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.linkLabelOpenXfyunReg = new System.Windows.Forms.LinkLabel();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelPitch = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.labelPerson = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.trackBarPitch = new System.Windows.Forms.TrackBar();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.comboBoxPerson = new System.Windows.Forms.ComboBox();
            this.labelSpeedValue = new System.Windows.Forms.Label();
            this.labelPitchValue = new System.Windows.Forms.Label();
            this.labelVolumeValue = new System.Windows.Forms.Label();
            this.checkBoxApiKey = new System.Windows.Forms.CheckBox();
            this.labelRegion = new System.Windows.Forms.Label();
            this.trackBarStyleDegree = new System.Windows.Forms.TrackBar();
            this.labelStyleDegree = new System.Windows.Forms.Label();
            this.labelStyleDegreeValue = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timerHideKey = new System.Windows.Forms.Timer(this.components);
            this.labelStyleDescription = new System.Windows.Forms.Label();
            this.groupBoxTTSEngineDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStyleDegree)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxTTSEngineDetail
            // 
            this.groupBoxTTSEngineDetail.AutoSize = true;
            this.groupBoxTTSEngineDetail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxTTSEngineDetail.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxTTSEngineDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTTSEngineDetail.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTTSEngineDetail.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxTTSEngineDetail.Name = "groupBoxTTSEngineDetail";
            this.groupBoxTTSEngineDetail.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxTTSEngineDetail.Size = new System.Drawing.Size(366, 410);
            this.groupBoxTTSEngineDetail.TabIndex = 2;
            this.groupBoxTTSEngineDetail.TabStop = false;
            this.groupBoxTTSEngineDetail.Text = "Engine Detail";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.comboBoxRole, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxStyle, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelStyle, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBoxRegion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxApiKey, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.linkLabelOpenXfyunReg, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.labelSpeed, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPitch, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelVolume, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelPerson, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.trackBarSpeed, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.trackBarPitch, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBarVolume, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPerson, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelSpeedValue, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPitchValue, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelVolumeValue, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxApiKey, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelRegion, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.trackBarStyleDegree, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelStyleDegree, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelStyleDegreeValue, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelRole, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelStyleDescription, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(362, 392);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxRole, 2);
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(89, 325);
            this.comboBoxRole.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(271, 20);
            this.comboBoxRole.TabIndex = 30;
            // 
            // comboBoxStyle
            // 
            this.comboBoxStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxStyle, 2);
            this.comboBoxStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStyle.FormattingEnabled = true;
            this.comboBoxStyle.Location = new System.Drawing.Point(89, 223);
            this.comboBoxStyle.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStyle.Name = "comboBoxStyle";
            this.comboBoxStyle.Size = new System.Drawing.Size(271, 20);
            this.comboBoxStyle.TabIndex = 29;
            // 
            // labelStyle
            // 
            this.labelStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStyle.AutoSize = true;
            this.labelStyle.Location = new System.Drawing.Point(2, 227);
            this.labelStyle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStyle.Name = "labelStyle";
            this.labelStyle.Size = new System.Drawing.Size(83, 12);
            this.labelStyle.TabIndex = 27;
            this.labelStyle.Text = "Style:";
            // 
            // textBoxRegion
            // 
            this.textBoxRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxRegion, 2);
            this.textBoxRegion.Location = new System.Drawing.Point(89, 27);
            this.textBoxRegion.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRegion.Name = "textBoxRegion";
            this.textBoxRegion.Size = new System.Drawing.Size(271, 21);
            this.textBoxRegion.TabIndex = 23;
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxApiKey, 2);
            this.textBoxApiKey.Location = new System.Drawing.Point(89, 2);
            this.textBoxApiKey.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(271, 21);
            this.textBoxApiKey.TabIndex = 22;
            // 
            // linkLabelOpenXfyunReg
            // 
            this.linkLabelOpenXfyunReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelOpenXfyunReg.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.linkLabelOpenXfyunReg, 3);
            this.linkLabelOpenXfyunReg.Location = new System.Drawing.Point(2, 362);
            this.linkLabelOpenXfyunReg.Margin = new System.Windows.Forms.Padding(2, 15, 2, 10);
            this.linkLabelOpenXfyunReg.Name = "linkLabelOpenXfyunReg";
            this.linkLabelOpenXfyunReg.Size = new System.Drawing.Size(358, 12);
            this.linkLabelOpenXfyunReg.TabIndex = 16;
            this.linkLabelOpenXfyunReg.TabStop = true;
            this.linkLabelOpenXfyunReg.Text = "Register Your Own API Keys";
            this.linkLabelOpenXfyunReg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenXfyunReg_LinkClicked);
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(2, 50);
            this.labelSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelSpeed.Size = new System.Drawing.Size(83, 22);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = "Speed:";
            // 
            // labelPitch
            // 
            this.labelPitch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPitch.AutoSize = true;
            this.labelPitch.Location = new System.Drawing.Point(2, 99);
            this.labelPitch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPitch.Name = "labelPitch";
            this.labelPitch.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelPitch.Size = new System.Drawing.Size(83, 22);
            this.labelPitch.TabIndex = 5;
            this.labelPitch.Text = "Pitch:";
            // 
            // labelVolume
            // 
            this.labelVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(2, 148);
            this.labelVolume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelVolume.Size = new System.Drawing.Size(83, 22);
            this.labelVolume.TabIndex = 6;
            this.labelVolume.Text = "Volume:";
            // 
            // labelPerson
            // 
            this.labelPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPerson.AutoSize = true;
            this.labelPerson.Location = new System.Drawing.Point(2, 203);
            this.labelPerson.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPerson.Name = "labelPerson";
            this.labelPerson.Size = new System.Drawing.Size(83, 12);
            this.labelPerson.TabIndex = 7;
            this.labelPerson.Text = "Person:";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSpeed.Location = new System.Drawing.Point(89, 52);
            this.trackBarSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarSpeed.Maximum = 300;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(245, 45);
            this.trackBarSpeed.TabIndex = 8;
            this.trackBarSpeed.TickFrequency = 20;
            this.trackBarSpeed.Value = 100;
            // 
            // trackBarPitch
            // 
            this.trackBarPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarPitch.Location = new System.Drawing.Point(89, 101);
            this.trackBarPitch.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarPitch.Maximum = 200;
            this.trackBarPitch.Name = "trackBarPitch";
            this.trackBarPitch.Size = new System.Drawing.Size(245, 45);
            this.trackBarPitch.TabIndex = 9;
            this.trackBarPitch.TickFrequency = 20;
            this.trackBarPitch.Value = 100;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.Location = new System.Drawing.Point(89, 150);
            this.trackBarVolume.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(245, 45);
            this.trackBarVolume.TabIndex = 10;
            this.trackBarVolume.TickFrequency = 10;
            this.trackBarVolume.Value = 50;
            // 
            // comboBoxPerson
            // 
            this.comboBoxPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxPerson, 2);
            this.comboBoxPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPerson.FormattingEnabled = true;
            this.comboBoxPerson.Location = new System.Drawing.Point(89, 199);
            this.comboBoxPerson.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(271, 20);
            this.comboBoxPerson.TabIndex = 11;
            // 
            // labelSpeedValue
            // 
            this.labelSpeedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeedValue.AutoSize = true;
            this.labelSpeedValue.Location = new System.Drawing.Point(338, 50);
            this.labelSpeedValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSpeedValue.MinimumSize = new System.Drawing.Size(22, 0);
            this.labelSpeedValue.Name = "labelSpeedValue";
            this.labelSpeedValue.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelSpeedValue.Size = new System.Drawing.Size(22, 22);
            this.labelSpeedValue.TabIndex = 12;
            this.labelSpeedValue.Text = "5";
            // 
            // labelPitchValue
            // 
            this.labelPitchValue.AutoSize = true;
            this.labelPitchValue.Location = new System.Drawing.Point(338, 99);
            this.labelPitchValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPitchValue.MinimumSize = new System.Drawing.Size(22, 0);
            this.labelPitchValue.Name = "labelPitchValue";
            this.labelPitchValue.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelPitchValue.Size = new System.Drawing.Size(22, 22);
            this.labelPitchValue.TabIndex = 13;
            this.labelPitchValue.Text = "5";
            // 
            // labelVolumeValue
            // 
            this.labelVolumeValue.AutoSize = true;
            this.labelVolumeValue.Location = new System.Drawing.Point(338, 148);
            this.labelVolumeValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVolumeValue.MinimumSize = new System.Drawing.Size(22, 0);
            this.labelVolumeValue.Name = "labelVolumeValue";
            this.labelVolumeValue.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelVolumeValue.Size = new System.Drawing.Size(22, 22);
            this.labelVolumeValue.TabIndex = 14;
            this.labelVolumeValue.Text = "5";
            // 
            // checkBoxApiKey
            // 
            this.checkBoxApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxApiKey.AutoSize = true;
            this.checkBoxApiKey.Location = new System.Drawing.Point(3, 4);
            this.checkBoxApiKey.Name = "checkBoxApiKey";
            this.checkBoxApiKey.Size = new System.Drawing.Size(81, 16);
            this.checkBoxApiKey.TabIndex = 19;
            this.checkBoxApiKey.Text = "API Key:";
            this.checkBoxApiKey.UseVisualStyleBackColor = true;
            this.checkBoxApiKey.CheckedChanged += new System.EventHandler(this.checkBoxApiKey_CheckedChanged);
            // 
            // labelRegion
            // 
            this.labelRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRegion.AutoSize = true;
            this.labelRegion.Location = new System.Drawing.Point(2, 31);
            this.labelRegion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(83, 12);
            this.labelRegion.TabIndex = 20;
            this.labelRegion.Text = "Region:";
            // 
            // trackBarStyleDegree
            // 
            this.trackBarStyleDegree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarStyleDegree.Location = new System.Drawing.Point(90, 275);
            this.trackBarStyleDegree.Maximum = 200;
            this.trackBarStyleDegree.Name = "trackBarStyleDegree";
            this.trackBarStyleDegree.Size = new System.Drawing.Size(243, 45);
            this.trackBarStyleDegree.TabIndex = 24;
            this.trackBarStyleDegree.TickFrequency = 20;
            this.trackBarStyleDegree.Value = 100;
            // 
            // labelStyleDegree
            // 
            this.labelStyleDegree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStyleDegree.AutoSize = true;
            this.labelStyleDegree.Location = new System.Drawing.Point(2, 272);
            this.labelStyleDegree.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStyleDegree.Name = "labelStyleDegree";
            this.labelStyleDegree.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelStyleDegree.Size = new System.Drawing.Size(83, 22);
            this.labelStyleDegree.TabIndex = 25;
            this.labelStyleDegree.Text = "Style Degree:";
            // 
            // labelStyleDegreeValue
            // 
            this.labelStyleDegreeValue.AutoSize = true;
            this.labelStyleDegreeValue.Location = new System.Drawing.Point(338, 272);
            this.labelStyleDegreeValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStyleDegreeValue.MinimumSize = new System.Drawing.Size(22, 0);
            this.labelStyleDegreeValue.Name = "labelStyleDegreeValue";
            this.labelStyleDegreeValue.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelStyleDegreeValue.Size = new System.Drawing.Size(22, 22);
            this.labelStyleDegreeValue.TabIndex = 26;
            this.labelStyleDegreeValue.Text = "5";
            // 
            // labelRole
            // 
            this.labelRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(2, 329);
            this.labelRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(83, 12);
            this.labelRole.TabIndex = 28;
            this.labelRole.Text = "Role:";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 1;
            this.toolTip1.AutoPopDelay = 0;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 0;
            // 
            // timerHideKey
            // 
            this.timerHideKey.Interval = 5000;
            this.timerHideKey.Tick += new System.EventHandler(this.timerHideKey_Tick);
            // 
            // labelStyleDescription
            // 
            this.labelStyleDescription.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelStyleDescription, 2);
            this.labelStyleDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStyleDescription.Location = new System.Drawing.Point(90, 245);
            this.labelStyleDescription.Name = "labelStyleDescription";
            this.labelStyleDescription.Padding = new System.Windows.Forms.Padding(0, 5, 0, 10);
            this.labelStyleDescription.Size = new System.Drawing.Size(269, 27);
            this.labelStyleDescription.TabIndex = 31;
            this.labelStyleDescription.Text = "Style description";
            // 
            // AzureTTSSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxTTSEngineDetail);
            this.Name = "AzureTTSSettingsControl";
            this.Size = new System.Drawing.Size(366, 474);
            this.groupBoxTTSEngineDetail.ResumeLayout(false);
            this.groupBoxTTSEngineDetail.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStyleDegree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTTSEngineDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelPitch;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Label labelPerson;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.TrackBar trackBarPitch;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.ComboBox comboBoxPerson;
        private System.Windows.Forms.Label labelSpeedValue;
        private System.Windows.Forms.Label labelPitchValue;
        private System.Windows.Forms.Label labelVolumeValue;
        private System.Windows.Forms.CheckBox checkBoxApiKey;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.LinkLabel linkLabelOpenXfyunReg;
        private System.Windows.Forms.TextBox textBoxRegion;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.TrackBar trackBarStyleDegree;
        private System.Windows.Forms.Label labelStyleDegree;
        private System.Windows.Forms.Label labelStyleDegreeValue;
        private System.Windows.Forms.Label labelStyle;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.ComboBox comboBoxStyle;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timerHideKey;
        private System.Windows.Forms.Label labelStyleDescription;
    }
}
