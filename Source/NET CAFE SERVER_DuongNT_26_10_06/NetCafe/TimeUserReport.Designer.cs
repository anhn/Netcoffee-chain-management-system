namespace NetCafe
{
    partial class FrmTimeUserReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimeUserReport));
            this.dgvTime = new AdvancedDataGridView.TreeGridView();
            this.Column1 = new AdvancedDataGridView.TreeGridColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.gradientPanel2 = new NetCafe.GradientPanel(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.mo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Thoát = new System.Windows.Forms.ToolStripButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTime)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTime
            // 
            this.dgvTime.AllowUserToAddRows = false;
            this.dgvTime.AllowUserToDeleteRows = false;
            this.dgvTime.AllowUserToResizeColumns = false;
            this.dgvTime.AllowUserToResizeRows = false;
            this.dgvTime.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTime.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTime.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTime.ImageList = this.imageList1;
            this.dgvTime.Location = new System.Drawing.Point(0, 40);
            this.dgvTime.Name = "dgvTime";
            this.dgvTime.ReadOnly = true;
            this.dgvTime.RowHeadersVisible = false;
            this.dgvTime.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTime.Size = new System.Drawing.Size(768, 577);
            this.dgvTime.TabIndex = 5;
            this.dgvTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTime_KeyDown);
            // 
            // Column1
            // 
            this.Column1.DefaultNodeImage = null;
            this.Column1.HeaderText = "Tên máy";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.ToolTipText = "Tên máy trong cửa hàng";
            this.Column1.Width = 180;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Bắt đầu sử dụng";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.ToolTipText = "Thời điểm máy bắt dầu được sử dụng";
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column3.HeaderText = "Thời gian sử dụng (phút)";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.ToolTipText = "Số phút sử dụng";
            this.Column3.Width = 132;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Thành tiền (đồng)";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.ToolTipText = "Số tiền được tính cho thời gian tương ứng";
            this.Column4.Width = 200;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "krdc.png");
            this.imageList1.Images.SetKeyName(1, "dateIcon copy.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "krdc.png");
            this.imageList2.Images.SetKeyName(1, "dateIcon copy.png");
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Color1 = System.Drawing.SystemColors.InactiveCaptionText;
            this.gradientPanel2.Color2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gradientPanel2.Controls.Add(this.label2);
            this.gradientPanel2.Controls.Add(this.toolStrip1);
            this.gradientPanel2.Controls.Add(this.dateTimePicker1);
            this.gradientPanel2.Direct = true;
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(768, 40);
            this.gradientPanel2.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Báo cáo doanh thu ngày:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.mo,
            this.toolStripSeparator1,
            this.Thoát});
            this.toolStrip1.Location = new System.Drawing.Point(550, 1);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(36, 39);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(157, 39);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::NetCafe.Properties.Resources.refesh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Làm mới báo cáo";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mo
            // 
            this.mo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mo.Image = global::NetCafe.Properties.Resources.kword_del1;
            this.mo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mo.Name = "mo";
            this.mo.Size = new System.Drawing.Size(36, 36);
            this.mo.Text = "Xóa báo cáo tháng";
            this.mo.ToolTipText = "Xóa báo cáo";
            this.mo.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // Thoát
            // 
            this.Thoát.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Thoát.Image = ((System.Drawing.Image)(resources.GetObject("Thoát.Image")));
            this.Thoát.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Thoát.Name = "Thoát";
            this.Thoát.Size = new System.Drawing.Size(36, 36);
            this.Thoát.Text = "toolStripButton3";
            this.Thoát.ToolTipText = "Thoát";
            this.Thoát.Click += new System.EventHandler(this.button3_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(205, 9);
            this.dateTimePicker1.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(213, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // FrmTimeUserReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Controls.Add(this.dgvTime);
            this.Controls.Add(this.gradientPanel2);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Name = "FrmTimeUserReport";
            this.Size = new System.Drawing.Size(768, 617);
            this.Load += new System.EventHandler(this.FrmTimeUserReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTime)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private AdvancedDataGridView.TreeGridView dgvTime;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Thoát;
        private GradientPanel gradientPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList2;
        private AdvancedDataGridView.TreeGridColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}