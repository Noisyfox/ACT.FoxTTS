
namespace ACT.FoxTTS.engine.baipiao
{
    partial class BaipiaoSettingsControl
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
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.labelSpeedValue = new System.Windows.Forms.Label();
            this.labelBaipiaoDisclaimer = new System.Windows.Forms.Label();
            this.groupBoxTTSEngineDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
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
            this.groupBoxTTSEngineDetail.Size = new System.Drawing.Size(319, 104);
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
            this.tableLayoutPanel1.Controls.Add(this.labelSpeed, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.trackBarSpeed, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSpeedValue, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelBaipiaoDisclaimer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(315, 86);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(2, 37);
            this.labelSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelSpeed.Size = new System.Drawing.Size(41, 22);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = "Speed:";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSpeed.LargeChange = 3;
            this.trackBarSpeed.Location = new System.Drawing.Point(47, 39);
            this.trackBarSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarSpeed.Maximum = 7;
            this.trackBarSpeed.Minimum = 1;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(240, 45);
            this.trackBarSpeed.TabIndex = 8;
            this.trackBarSpeed.Value = 4;
            // 
            // labelSpeedValue
            // 
            this.labelSpeedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeedValue.AutoSize = true;
            this.labelSpeedValue.Location = new System.Drawing.Point(291, 37);
            this.labelSpeedValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSpeedValue.MinimumSize = new System.Drawing.Size(22, 0);
            this.labelSpeedValue.Name = "labelSpeedValue";
            this.labelSpeedValue.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelSpeedValue.Size = new System.Drawing.Size(22, 22);
            this.labelSpeedValue.TabIndex = 12;
            this.labelSpeedValue.Text = "5";
            // 
            // labelBaipiaoDisclaimer
            // 
            this.labelBaipiaoDisclaimer.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelBaipiaoDisclaimer, 3);
            this.labelBaipiaoDisclaimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBaipiaoDisclaimer.Location = new System.Drawing.Point(3, 15);
            this.labelBaipiaoDisclaimer.Margin = new System.Windows.Forms.Padding(3, 15, 3, 10);
            this.labelBaipiaoDisclaimer.Name = "labelBaipiaoDisclaimer";
            this.labelBaipiaoDisclaimer.Size = new System.Drawing.Size(309, 12);
            this.labelBaipiaoDisclaimer.TabIndex = 13;
            this.labelBaipiaoDisclaimer.Text = "Disclaimer";
            // 
            // BaipiaoSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBoxTTSEngineDetail);
            this.Name = "BaipiaoSettingsControl";
            this.Size = new System.Drawing.Size(319, 311);
            this.groupBoxTTSEngineDetail.ResumeLayout(false);
            this.groupBoxTTSEngineDetail.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTTSEngineDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Label labelSpeedValue;
        private System.Windows.Forms.Label labelBaipiaoDisclaimer;
    }
}
