namespace NetCafe
{
    partial class FrmReportChoose
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMonth = new System.Windows.Forms.TabPage();
            this.frmMonthlyReceiptReport1 = new NetCafe.FrmMonthlyReceiptReport();
            this.tpDay = new System.Windows.Forms.TabPage();
            this.frmTimeUserReport1 = new NetCafe.FrmTimeUserReport();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tpMonth.SuspendLayout();
            this.tpDay.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMonth);
            this.tabControl1.Controls.Add(this.tpDay);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 21);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(918, 483);
            this.tabControl1.TabIndex = 4;
            // 
            // tpMonth
            // 
            this.tpMonth.Controls.Add(this.frmMonthlyReceiptReport1);
            this.tpMonth.Location = new System.Drawing.Point(4, 25);
            this.tpMonth.Name = "tpMonth";
            this.tpMonth.Padding = new System.Windows.Forms.Padding(3);
            this.tpMonth.Size = new System.Drawing.Size(910, 454);
            this.tpMonth.TabIndex = 0;
            this.tpMonth.Text = "Doanh thu tháng";
            this.tpMonth.ToolTipText = "Bấm vào đây để xem doanh thu tháng";
            this.tpMonth.UseVisualStyleBackColor = true;
            // 
            // frmMonthlyReceiptReport1
            // 
            this.frmMonthlyReceiptReport1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.frmMonthlyReceiptReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmMonthlyReceiptReport1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmMonthlyReceiptReport1.Location = new System.Drawing.Point(3, 3);
            this.frmMonthlyReceiptReport1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.frmMonthlyReceiptReport1.Name = "frmMonthlyReceiptReport1";
            this.frmMonthlyReceiptReport1.Size = new System.Drawing.Size(904, 448);
            this.frmMonthlyReceiptReport1.TabIndex = 0;
            this.frmMonthlyReceiptReport1.OnClose += new NetCafe.OnFormClose(this.frmMonthlyReceiptReport1_OnClose);
            // 
            // tpDay
            // 
            this.tpDay.Controls.Add(this.frmTimeUserReport1);
            this.tpDay.Location = new System.Drawing.Point(4, 25);
            this.tpDay.Name = "tpDay";
            this.tpDay.Padding = new System.Windows.Forms.Padding(3);
            this.tpDay.Size = new System.Drawing.Size(910, 454);
            this.tpDay.TabIndex = 1;
            this.tpDay.Text = "Doanh thu ngày";
            this.tpDay.ToolTipText = "Bấm vào đây để xem doanh thu ngày";
            this.tpDay.UseVisualStyleBackColor = true;
            // 
            // frmTimeUserReport1
            // 
            this.frmTimeUserReport1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.frmTimeUserReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmTimeUserReport1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmTimeUserReport1.Location = new System.Drawing.Point(3, 3);
            this.frmTimeUserReport1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.frmTimeUserReport1.Name = "frmTimeUserReport1";
            this.frmTimeUserReport1.Size = new System.Drawing.Size(904, 448);
            this.frmTimeUserReport1.TabIndex = 0;
            this.frmTimeUserReport1.Load += new System.EventHandler(this.frmTimeUserReport1_Load);
            this.frmTimeUserReport1.OnClose += new NetCafe.OnMyFormClose(this.frmTimeUserReport1_OnClose);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Marlett", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(892, 0);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(24, 20);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "r";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(2, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Báo cáo tổng hợp";
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 21);
            this.panel2.TabIndex = 56;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // FrmReportChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(918, 504);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReportChoose";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportChoose";
            this.Load += new System.EventHandler(this.FrmReportChoose_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpMonth.ResumeLayout(false);
            this.tpDay.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpMonth;
        private System.Windows.Forms.TabPage tpDay;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private FrmTimeUserReport frmTimeUserReport1;
        private FrmMonthlyReceiptReport frmMonthlyReceiptReport1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}