namespace ACT.FoxTTS.engine.youdao
{
    partial class YoudaoTTSSettingsControl
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
            this.textBoxAppSecret = new System.Windows.Forms.TextBox();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelSpeedValue = new System.Windows.Forms.Label();
            this.labelVolumeValue = new System.Windows.Forms.Label();
            this.linkLabelOpenYoudaoReg = new System.Windows.Forms.LinkLabel();
            this.checkBoxAppId = new System.Windows.Forms.CheckBox();
            this.checkBoxAppSecret = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timerHideKey = new System.Windows.Forms.Timer(this.components);
            this.groupBoxTTSEngineDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
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
            this.groupBoxTTSEngineDetail.Size = new System.Drawing.Size(276, 203);
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
            this.tableLayoutPanel1.Controls.Add(this.textBoxAppSecret, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSpeed, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelVolume, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBarSpeed, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.trackBarVolume, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelSpeedValue, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelVolumeValue, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.linkLabelOpenYoudaoReg, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxAppId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxAppSecret, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(272, 185);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxAppId
            // 
            this.textBoxAppId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxAppId, 2);
            this.textBoxAppId.Location = new System.Drawing.Point(98, 2);
            this.textBoxAppId.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAppId.Name = "textBoxAppId";
            this.textBoxAppId.Size = new System.Drawing.Size(172, 21);
            this.textBoxAppId.TabIndex = 2;
            // 
            // textBoxAppSecret
            // 
            this.textBoxAppSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxAppSecret, 2);
            this.textBoxAppSecret.Location = new System.Drawing.Point(98, 27);
            this.textBoxAppSecret.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAppSecret.Name = "textBoxAppSecret";
            this.textBoxAppSecret.Size = new System.Drawing.Size(172, 21);
            this.textBoxAppSecret.TabIndex = 3;
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
            this.labelSpeed.Size = new System.Drawing.Size(92, 22);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = "Speed:";
            // 
            // labelVolume
            // 
            this.labelVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(2, 99);
            this.labelVolume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelVolume.Size = new System.Drawing.Size(92, 22);
            this.labelVolume.TabIndex = 6;
            this.labelVolume.Text = "Volume:";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSpeed.Location = new System.Drawing.Point(98, 52);
            this.trackBarSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarSpeed.Maximum = 20;
            this.trackBarSpeed.Minimum = 1;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(146, 45);
            this.trackBarSpeed.TabIndex = 8;
            this.trackBarSpeed.TickFrequency = 2;
            this.trackBarSpeed.Value = 10;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.Location = new System.Drawing.Point(98, 101);
            this.trackBarVolume.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarVolume.Maximum = 50;
            this.trackBarVolume.Minimum = 5;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(146, 45);
            this.trackBarVolume.TabIndex = 10;
            this.trackBarVolume.TickFrequency = 5;
            this.trackBarVolume.Value = 10;
            // 
            // labelSpeedValue
            // 
            this.labelSpeedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeedValue.AutoSize = true;
            this.labelSpeedValue.Location = new System.Drawing.Point(248, 50);
            this.labelSpeedValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSpeedValue.MinimumSize = new System.Drawing.Size(22, 0);
            this.labelSpeedValue.Name = "labelSpeedValue";
            this.labelSpeedValue.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelSpeedValue.Size = new System.Drawing.Size(22, 22);
            this.labelSpeedValue.TabIndex = 12;
            this.labelSpeedValue.Text = "1";
            // 
            // labelVolumeValue
            // 
            this.labelVolumeValue.AutoSize = true;
            this.labelVolumeValue.Location = new System.Drawing.Point(248, 99);
            this.labelVolumeValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVolumeValue.MinimumSize = new System.Drawing.Size(22, 0);
            this.labelVolumeValue.Name = "labelVolumeValue";
            this.labelVolumeValue.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelVolumeValue.Size = new System.Drawing.Size(22, 22);
            this.labelVolumeValue.TabIndex = 14;
            this.labelVolumeValue.Text = "1";
            // 
            // linkLabelOpenYoudaoReg
            // 
            this.linkLabelOpenYoudaoReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelOpenYoudaoReg.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.linkLabelOpenYoudaoReg, 3);
            this.linkLabelOpenYoudaoReg.Location = new System.Drawing.Point(2, 163);
            this.linkLabelOpenYoudaoReg.Margin = new System.Windows.Forms.Padding(2, 15, 2, 10);
            this.linkLabelOpenYoudaoReg.Name = "linkLabelOpenYoudaoReg";
            this.linkLabelOpenYoudaoReg.Size = new System.Drawing.Size(268, 12);
            this.linkLabelOpenYoudaoReg.TabIndex = 15;
            this.linkLabelOpenYoudaoReg.TabStop = true;
            this.linkLabelOpenYoudaoReg.Text = "Register Your Own API Keys";
            this.linkLabelOpenYoudaoReg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenYoudaoReg_LinkClicked);
            // 
            // checkBoxAppId
            // 
            this.checkBoxAppId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAppId.AutoSize = true;
            this.checkBoxAppId.Location = new System.Drawing.Point(3, 4);
            this.checkBoxAppId.Name = "checkBoxAppId";
            this.checkBoxAppId.Size = new System.Drawing.Size(90, 16);
            this.checkBoxAppId.TabIndex = 18;
            this.checkBoxAppId.Text = "App ID:";
            this.checkBoxAppId.UseVisualStyleBackColor = true;
            this.checkBoxAppId.CheckedChanged += new System.EventHandler(this.checkBoxAppKey_CheckedChanged);
            // 
            // checkBoxAppSecret
            // 
            this.checkBoxAppSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAppSecret.AutoSize = true;
            this.checkBoxAppSecret.Location = new System.Drawing.Point(3, 29);
            this.checkBoxAppSecret.Name = "checkBoxAppSecret";
            this.checkBoxAppSecret.Size = new System.Drawing.Size(90, 16);
            this.checkBoxAppSecret.TabIndex = 19;
            this.checkBoxAppSecret.Text = "App Secret:";
            this.checkBoxAppSecret.UseVisualStyleBackColor = true;
            this.checkBoxAppSecret.CheckedChanged += new System.EventHandler(this.checkBoxAppKey_CheckedChanged);
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
            // YoudaoTTSSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBoxTTSEngineDetail);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "YoudaoTTSSettingsControl";
            this.Size = new System.Drawing.Size(276, 203);
            this.groupBoxTTSEngineDetail.ResumeLayout(false);
            this.groupBoxTTSEngineDetail.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTTSEngineDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxAppId;
        private System.Windows.Forms.TextBox textBoxAppSecret;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelSpeedValue;
        private System.Windows.Forms.Label labelVolumeValue;
        private System.Windows.Forms.LinkLabel linkLabelOpenYoudaoReg;
        private System.Windows.Forms.CheckBox checkBoxAppId;
        private System.Windows.Forms.CheckBox checkBoxAppSecret;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timerHideKey;
    }
}
