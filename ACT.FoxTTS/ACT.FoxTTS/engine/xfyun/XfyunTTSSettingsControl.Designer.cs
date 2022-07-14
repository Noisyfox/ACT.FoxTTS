namespace ACT.FoxTTS.engine.xfyun
{
    partial class XfyunTTSSettingsControl
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
            this.textBoxAppId = new System.Windows.Forms.TextBox();
            this.checkBoxAppId = new System.Windows.Forms.CheckBox();
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
            this.linkLabelOpenXfyunReg = new System.Windows.Forms.LinkLabel();
            this.checkBoxApiKey = new System.Windows.Forms.CheckBox();
            this.checkBoxApiSecret = new System.Windows.Forms.CheckBox();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.textBoxApiSecret = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timerHideKey = new System.Windows.Forms.Timer(this.components);
            this.groupBoxTTSEngineDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
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
            this.groupBoxTTSEngineDetail.Size = new System.Drawing.Size(287, 301);
            this.groupBoxTTSEngineDetail.TabIndex = 1;
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
            this.tableLayoutPanel1.Controls.Add(this.textBoxAppId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxAppId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSpeed, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelPitch, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelVolume, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelPerson, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.trackBarSpeed, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBarPitch, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.trackBarVolume, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPerson, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelSpeedValue, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelPitchValue, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelVolumeValue, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.linkLabelOpenXfyunReg, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxApiKey, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxApiSecret, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxApiKey, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxApiSecret, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(283, 283);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxAppId
            // 
            this.textBoxAppId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxAppId, 2);
            this.textBoxAppId.Location = new System.Drawing.Point(98, 2);
            this.textBoxAppId.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAppId.Name = "textBoxAppId";
            this.textBoxAppId.Size = new System.Drawing.Size(183, 21);
            this.textBoxAppId.TabIndex = 21;
            // 
            // checkBoxAppId
            // 
            this.checkBoxAppId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAppId.AutoSize = true;
            this.checkBoxAppId.Location = new System.Drawing.Point(3, 4);
            this.checkBoxAppId.Name = "checkBoxAppId";
            this.checkBoxAppId.Size = new System.Drawing.Size(90, 16);
            this.checkBoxAppId.TabIndex = 20;
            this.checkBoxAppId.Text = "App ID:";
            this.checkBoxAppId.UseVisualStyleBackColor = true;
            this.checkBoxAppId.CheckedChanged += new System.EventHandler(this.checkBoxApiKey_CheckedChanged);
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(2, 75);
            this.labelSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelSpeed.Size = new System.Drawing.Size(92, 22);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = "Speed:";
            // 
            // labelPitch
            // 
            this.labelPitch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPitch.AutoSize = true;
            this.labelPitch.Location = new System.Drawing.Point(2, 124);
            this.labelPitch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPitch.Name = "labelPitch";
            this.labelPitch.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelPitch.Size = new System.Drawing.Size(92, 22);
            this.labelPitch.TabIndex = 5;
            this.labelPitch.Text = "Pitch:";
            // 
            // labelVolume
            // 
            this.labelVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(2, 173);
            this.labelVolume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelVolume.Size = new System.Drawing.Size(92, 22);
            this.labelVolume.TabIndex = 6;
            this.labelVolume.Text = "Volume:";
            // 
            // labelPerson
            // 
            this.labelPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPerson.AutoSize = true;
            this.labelPerson.Location = new System.Drawing.Point(2, 228);
            this.labelPerson.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPerson.Name = "labelPerson";
            this.labelPerson.Size = new System.Drawing.Size(92, 12);
            this.labelPerson.TabIndex = 7;
            this.labelPerson.Text = "Person:";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSpeed.Location = new System.Drawing.Point(98, 77);
            this.trackBarSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(157, 45);
            this.trackBarSpeed.TabIndex = 8;
            this.trackBarSpeed.Value = 5;
            // 
            // trackBarPitch
            // 
            this.trackBarPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarPitch.Location = new System.Drawing.Point(98, 126);
            this.trackBarPitch.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarPitch.Name = "trackBarPitch";
            this.trackBarPitch.Size = new System.Drawing.Size(157, 45);
            this.trackBarPitch.TabIndex = 9;
            this.trackBarPitch.Value = 5;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.Location = new System.Drawing.Point(98, 175);
            this.trackBarVolume.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(157, 45);
            this.trackBarVolume.TabIndex = 10;
            this.trackBarVolume.Value = 5;
            // 
            // comboBoxPerson
            // 
            this.comboBoxPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxPerson, 2);
            this.comboBoxPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPerson.FormattingEnabled = true;
            this.comboBoxPerson.Items.AddRange(new object[] {
            "度小美",
            "度小宇",
            "度逍遥",
            "度丫丫",
            "度博文",
            "度小童",
            "度小萌",
            "度米朵",
            "度小娇"});
            this.comboBoxPerson.Location = new System.Drawing.Point(98, 224);
            this.comboBoxPerson.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(183, 20);
            this.comboBoxPerson.TabIndex = 11;
            // 
            // labelSpeedValue
            // 
            this.labelSpeedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeedValue.AutoSize = true;
            this.labelSpeedValue.Location = new System.Drawing.Point(259, 75);
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
            this.labelPitchValue.Location = new System.Drawing.Point(259, 124);
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
            this.labelVolumeValue.Location = new System.Drawing.Point(259, 173);
            this.labelVolumeValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVolumeValue.MinimumSize = new System.Drawing.Size(22, 0);
            this.labelVolumeValue.Name = "labelVolumeValue";
            this.labelVolumeValue.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelVolumeValue.Size = new System.Drawing.Size(22, 22);
            this.labelVolumeValue.TabIndex = 14;
            this.labelVolumeValue.Text = "5";
            // 
            // linkLabelOpenXfyunReg
            // 
            this.linkLabelOpenXfyunReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelOpenXfyunReg.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.linkLabelOpenXfyunReg, 3);
            this.linkLabelOpenXfyunReg.Location = new System.Drawing.Point(2, 261);
            this.linkLabelOpenXfyunReg.Margin = new System.Windows.Forms.Padding(2, 15, 2, 10);
            this.linkLabelOpenXfyunReg.Name = "linkLabelOpenXfyunReg";
            this.linkLabelOpenXfyunReg.Size = new System.Drawing.Size(279, 12);
            this.linkLabelOpenXfyunReg.TabIndex = 15;
            this.linkLabelOpenXfyunReg.TabStop = true;
            this.linkLabelOpenXfyunReg.Text = "Register Your Own API Keys";
            this.linkLabelOpenXfyunReg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenXfyunReg_LinkClicked);
            // 
            // checkBoxApiKey
            // 
            this.checkBoxApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxApiKey.AutoSize = true;
            this.checkBoxApiKey.Location = new System.Drawing.Point(3, 54);
            this.checkBoxApiKey.Name = "checkBoxApiKey";
            this.checkBoxApiKey.Size = new System.Drawing.Size(90, 16);
            this.checkBoxApiKey.TabIndex = 18;
            this.checkBoxApiKey.Text = "API Key:";
            this.checkBoxApiKey.UseVisualStyleBackColor = true;
            this.checkBoxApiKey.CheckedChanged += new System.EventHandler(this.checkBoxApiKey_CheckedChanged);
            // 
            // checkBoxApiSecret
            // 
            this.checkBoxApiSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxApiSecret.AutoSize = true;
            this.checkBoxApiSecret.Location = new System.Drawing.Point(3, 29);
            this.checkBoxApiSecret.Name = "checkBoxApiSecret";
            this.checkBoxApiSecret.Size = new System.Drawing.Size(90, 16);
            this.checkBoxApiSecret.TabIndex = 19;
            this.checkBoxApiSecret.Text = "API Secret:";
            this.checkBoxApiSecret.UseVisualStyleBackColor = true;
            this.checkBoxApiSecret.CheckedChanged += new System.EventHandler(this.checkBoxApiKey_CheckedChanged);
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxApiKey, 2);
            this.textBoxApiKey.Location = new System.Drawing.Point(98, 52);
            this.textBoxApiKey.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(183, 21);
            this.textBoxApiKey.TabIndex = 2;
            // 
            // textBoxApiSecret
            // 
            this.textBoxApiSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxApiSecret, 2);
            this.textBoxApiSecret.Location = new System.Drawing.Point(98, 27);
            this.textBoxApiSecret.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxApiSecret.Name = "textBoxApiSecret";
            this.textBoxApiSecret.Size = new System.Drawing.Size(183, 21);
            this.textBoxApiSecret.TabIndex = 3;
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
            // XfyunTTSSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBoxTTSEngineDetail);
            this.Name = "XfyunTTSSettingsControl";
            this.Size = new System.Drawing.Size(287, 301);
            this.groupBoxTTSEngineDetail.ResumeLayout(false);
            this.groupBoxTTSEngineDetail.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTTSEngineDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.TextBox textBoxApiSecret;
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
        private System.Windows.Forms.LinkLabel linkLabelOpenXfyunReg;
        private System.Windows.Forms.CheckBox checkBoxApiKey;
        private System.Windows.Forms.CheckBox checkBoxApiSecret;
        private System.Windows.Forms.TextBox textBoxAppId;
        private System.Windows.Forms.CheckBox checkBoxAppId;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timerHideKey;
    }
}
