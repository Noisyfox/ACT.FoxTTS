namespace ACT.FoxTTS.engine.baidu
{
    partial class BaiduTTSSettingsControl
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
            this.labelApiKey = new System.Windows.Forms.Label();
            this.labelSecretKey = new System.Windows.Forms.Label();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.textBoxSecretKey = new System.Windows.Forms.TextBox();
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
            this.groupBoxTTSEngineDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxTTSEngineDetail
            // 
            this.groupBoxTTSEngineDetail.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxTTSEngineDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTTSEngineDetail.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTTSEngineDetail.Name = "groupBoxTTSEngineDetail";
            this.groupBoxTTSEngineDetail.Size = new System.Drawing.Size(693, 564);
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
            this.tableLayoutPanel1.Controls.Add(this.labelApiKey, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSecretKey, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxApiKey, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSecretKey, 1, 1);
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(687, 540);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelApiKey
            // 
            this.labelApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelApiKey.AutoSize = true;
            this.labelApiKey.Location = new System.Drawing.Point(3, 8);
            this.labelApiKey.Name = "labelApiKey";
            this.labelApiKey.Size = new System.Drawing.Size(95, 15);
            this.labelApiKey.TabIndex = 0;
            this.labelApiKey.Text = "API Key:";
            // 
            // labelSecretKey
            // 
            this.labelSecretKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSecretKey.AutoSize = true;
            this.labelSecretKey.Location = new System.Drawing.Point(3, 39);
            this.labelSecretKey.Name = "labelSecretKey";
            this.labelSecretKey.Size = new System.Drawing.Size(95, 15);
            this.labelSecretKey.TabIndex = 1;
            this.labelSecretKey.Text = "Secret Key:";
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxApiKey, 2);
            this.textBoxApiKey.Location = new System.Drawing.Point(104, 3);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(580, 25);
            this.textBoxApiKey.TabIndex = 2;
            // 
            // textBoxSecretKey
            // 
            this.textBoxSecretKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxSecretKey, 2);
            this.textBoxSecretKey.Location = new System.Drawing.Point(104, 34);
            this.textBoxSecretKey.Name = "textBoxSecretKey";
            this.textBoxSecretKey.Size = new System.Drawing.Size(580, 25);
            this.textBoxSecretKey.TabIndex = 3;
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(3, 62);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.labelSpeed.Size = new System.Drawing.Size(95, 27);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = "Speed:";
            // 
            // labelPitch
            // 
            this.labelPitch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPitch.AutoSize = true;
            this.labelPitch.Location = new System.Drawing.Point(3, 124);
            this.labelPitch.Name = "labelPitch";
            this.labelPitch.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.labelPitch.Size = new System.Drawing.Size(95, 27);
            this.labelPitch.TabIndex = 5;
            this.labelPitch.Text = "Pitch:";
            // 
            // labelVolume
            // 
            this.labelVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(3, 186);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.labelVolume.Size = new System.Drawing.Size(95, 27);
            this.labelVolume.TabIndex = 6;
            this.labelVolume.Text = "Volume:";
            // 
            // labelPerson
            // 
            this.labelPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPerson.AutoSize = true;
            this.labelPerson.Location = new System.Drawing.Point(3, 255);
            this.labelPerson.Name = "labelPerson";
            this.labelPerson.Size = new System.Drawing.Size(95, 15);
            this.labelPerson.TabIndex = 7;
            this.labelPerson.Text = "Person:";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSpeed.Location = new System.Drawing.Point(104, 65);
            this.trackBarSpeed.Maximum = 9;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(544, 56);
            this.trackBarSpeed.TabIndex = 8;
            this.trackBarSpeed.Value = 5;
            // 
            // trackBarPitch
            // 
            this.trackBarPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarPitch.Location = new System.Drawing.Point(104, 127);
            this.trackBarPitch.Maximum = 9;
            this.trackBarPitch.Name = "trackBarPitch";
            this.trackBarPitch.Size = new System.Drawing.Size(544, 56);
            this.trackBarPitch.TabIndex = 9;
            this.trackBarPitch.Value = 5;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.Location = new System.Drawing.Point(104, 189);
            this.trackBarVolume.Maximum = 15;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(544, 56);
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
            "女声",
            "男声",
            "度逍遥",
            "度丫丫"});
            this.comboBoxPerson.Location = new System.Drawing.Point(104, 251);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(580, 23);
            this.comboBoxPerson.TabIndex = 11;
            // 
            // labelSpeedValue
            // 
            this.labelSpeedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeedValue.AutoSize = true;
            this.labelSpeedValue.Location = new System.Drawing.Point(654, 62);
            this.labelSpeedValue.MinimumSize = new System.Drawing.Size(30, 0);
            this.labelSpeedValue.Name = "labelSpeedValue";
            this.labelSpeedValue.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.labelSpeedValue.Size = new System.Drawing.Size(30, 27);
            this.labelSpeedValue.TabIndex = 12;
            this.labelSpeedValue.Text = "5";
            // 
            // labelPitchValue
            // 
            this.labelPitchValue.AutoSize = true;
            this.labelPitchValue.Location = new System.Drawing.Point(654, 124);
            this.labelPitchValue.MinimumSize = new System.Drawing.Size(30, 0);
            this.labelPitchValue.Name = "labelPitchValue";
            this.labelPitchValue.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.labelPitchValue.Size = new System.Drawing.Size(30, 27);
            this.labelPitchValue.TabIndex = 13;
            this.labelPitchValue.Text = "5";
            // 
            // labelVolumeValue
            // 
            this.labelVolumeValue.AutoSize = true;
            this.labelVolumeValue.Location = new System.Drawing.Point(654, 186);
            this.labelVolumeValue.MinimumSize = new System.Drawing.Size(30, 0);
            this.labelVolumeValue.Name = "labelVolumeValue";
            this.labelVolumeValue.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.labelVolumeValue.Size = new System.Drawing.Size(30, 27);
            this.labelVolumeValue.TabIndex = 14;
            this.labelVolumeValue.Text = "5";
            // 
            // BaiduTTSSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBoxTTSEngineDetail);
            this.Name = "BaiduTTSSettingsControl";
            this.Size = new System.Drawing.Size(693, 564);
            this.groupBoxTTSEngineDetail.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTTSEngineDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelApiKey;
        private System.Windows.Forms.Label labelSecretKey;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.TextBox textBoxSecretKey;
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
    }
}
