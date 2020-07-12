namespace ACT.FoxTTS.engine.sapi5
{
    partial class SAPI5SettingsControl
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
            this.groupBoxTTSEngineDetail = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelPitch = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.labelPerson = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.comboBoxPerson = new System.Windows.Forms.ComboBox();
            this.labelSpeedValue = new System.Windows.Forms.Label();
            this.labelVolumeValue = new System.Windows.Forms.Label();
            this.comboBoxPitch = new System.Windows.Forms.ComboBox();
            this.linkLabelCopyVoice = new System.Windows.Forms.LinkLabel();
            this.groupBoxTTSEngineDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxTTSEngineDetail
            // 
            this.groupBoxTTSEngineDetail.BackColor = System.Drawing.SystemColors.Window;
            this.groupBoxTTSEngineDetail.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxTTSEngineDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTTSEngineDetail.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTTSEngineDetail.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxTTSEngineDetail.Name = "groupBoxTTSEngineDetail";
            this.groupBoxTTSEngineDetail.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxTTSEngineDetail.Size = new System.Drawing.Size(792, 622);
            this.groupBoxTTSEngineDetail.TabIndex = 0;
            this.groupBoxTTSEngineDetail.TabStop = false;
            this.groupBoxTTSEngineDetail.Text = "Engine Detail";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelSpeed, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelPitch, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelVolume, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPerson, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBarSpeed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.trackBarVolume, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPerson, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelSpeedValue, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelVolumeValue, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPitch, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.linkLabelCopyVoice, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 22);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 596);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(4, 0);
            this.labelSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(63, 15);
            this.labelSpeed.TabIndex = 0;
            this.labelSpeed.Text = "Speed:";
            // 
            // labelPitch
            // 
            this.labelPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPitch.AutoSize = true;
            this.labelPitch.Location = new System.Drawing.Point(4, 72);
            this.labelPitch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPitch.Name = "labelPitch";
            this.labelPitch.Size = new System.Drawing.Size(63, 15);
            this.labelPitch.TabIndex = 1;
            this.labelPitch.Text = "Pitch:";
            // 
            // labelVolume
            // 
            this.labelVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(4, 95);
            this.labelVolume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(63, 15);
            this.labelVolume.TabIndex = 2;
            this.labelVolume.Text = "Volume:";
            // 
            // labelPerson
            // 
            this.labelPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPerson.AutoSize = true;
            this.labelPerson.Location = new System.Drawing.Point(4, 167);
            this.labelPerson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPerson.Name = "labelPerson";
            this.labelPerson.Size = new System.Drawing.Size(63, 15);
            this.labelPerson.TabIndex = 0;
            this.labelPerson.Text = "Person:";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSpeed.LargeChange = 2;
            this.trackBarSpeed.Location = new System.Drawing.Point(75, 4);
            this.trackBarSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarSpeed.Minimum = -10;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(666, 56);
            this.trackBarSpeed.TabIndex = 3;
            this.trackBarSpeed.TickFrequency = 2;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.LargeChange = 10;
            this.trackBarVolume.Location = new System.Drawing.Point(75, 99);
            this.trackBarVolume.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(666, 56);
            this.trackBarVolume.TabIndex = 5;
            this.trackBarVolume.TickFrequency = 10;
            this.trackBarVolume.Value = 100;
            // 
            // comboBoxPerson
            // 
            this.comboBoxPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxPerson, 2);
            this.comboBoxPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPerson.FormattingEnabled = true;
            this.comboBoxPerson.Location = new System.Drawing.Point(75, 163);
            this.comboBoxPerson.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(705, 23);
            this.comboBoxPerson.TabIndex = 6;
            // 
            // labelSpeedValue
            // 
            this.labelSpeedValue.AutoSize = true;
            this.labelSpeedValue.Location = new System.Drawing.Point(749, 0);
            this.labelSpeedValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSpeedValue.MinimumSize = new System.Drawing.Size(29, 0);
            this.labelSpeedValue.Name = "labelSpeedValue";
            this.labelSpeedValue.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.labelSpeedValue.Size = new System.Drawing.Size(29, 27);
            this.labelSpeedValue.TabIndex = 7;
            this.labelSpeedValue.Text = "0";
            // 
            // labelVolumeValue
            // 
            this.labelVolumeValue.AutoSize = true;
            this.labelVolumeValue.Location = new System.Drawing.Point(749, 95);
            this.labelVolumeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVolumeValue.MinimumSize = new System.Drawing.Size(29, 0);
            this.labelVolumeValue.Name = "labelVolumeValue";
            this.labelVolumeValue.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.labelVolumeValue.Size = new System.Drawing.Size(31, 27);
            this.labelVolumeValue.TabIndex = 9;
            this.labelVolumeValue.Text = "100";
            // 
            // comboBoxPitch
            // 
            this.comboBoxPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxPitch, 2);
            this.comboBoxPitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPitch.FormattingEnabled = true;
            this.comboBoxPitch.Items.AddRange(new object[] {
            "Default",
            "XLow",
            "Low",
            "Medium",
            "High",
            "XHigh"});
            this.comboBoxPitch.Location = new System.Drawing.Point(75, 68);
            this.comboBoxPitch.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPitch.Name = "comboBoxPitch";
            this.comboBoxPitch.Size = new System.Drawing.Size(705, 23);
            this.comboBoxPitch.TabIndex = 4;
            // 
            // linkLabelCopyVoice
            // 
            this.linkLabelCopyVoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelCopyVoice.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.linkLabelCopyVoice, 3);
            this.linkLabelCopyVoice.Location = new System.Drawing.Point(3, 209);
            this.linkLabelCopyVoice.Margin = new System.Windows.Forms.Padding(3, 19, 3, 0);
            this.linkLabelCopyVoice.Name = "linkLabelCopyVoice";
            this.linkLabelCopyVoice.Size = new System.Drawing.Size(778, 15);
            this.linkLabelCopyVoice.TabIndex = 10;
            this.linkLabelCopyVoice.TabStop = true;
            this.linkLabelCopyVoice.Text = "Fix Win10 TTS voices";
            this.linkLabelCopyVoice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCopyVoice_LinkClicked);
            // 
            // SAPI5SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxTTSEngineDetail);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SAPI5SettingsControl";
            this.Size = new System.Drawing.Size(792, 622);
            this.groupBoxTTSEngineDetail.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTTSEngineDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelPitch;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Label labelPerson;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.ComboBox comboBoxPerson;
        private System.Windows.Forms.Label labelSpeedValue;
        private System.Windows.Forms.Label labelVolumeValue;
        private System.Windows.Forms.ComboBox comboBoxPitch;
        private System.Windows.Forms.LinkLabel linkLabelCopyVoice;
    }
}
