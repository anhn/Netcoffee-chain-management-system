namespace NetCafe
{
    partial class FrmCalMoney
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalMoney));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gradientPanel2 = new NetCafe.GradientPanel(this.components);
            this.gradientPanel7 = new NetCafe.GradientPanel(this.components);
            this.gradientPanel4 = new NetCafe.GradientPanel(this.components);
            this.gradientPanel3 = new NetCafe.GradientPanel(this.components);
            this.gradientPanel5 = new NetCafe.GradientPanel(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbMoney = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTimeUsed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTimeStart = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gradientPanel1 = new NetCafe.GradientPanel(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "door.png");
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.BackColor = System.Drawing.Color.DarkGray;
            this.gradientPanel2.Color1 = System.Drawing.SystemColors.HighlightText;
            this.gradientPanel2.Color2 = System.Drawing.Color.LightSteelBlue;
            this.gradientPanel2.Controls.Add(this.gradientPanel7);
            this.gradientPanel2.Controls.Add(this.gradientPanel4);
            this.gradientPanel2.Controls.Add(this.gradientPanel3);
            this.gradientPanel2.Controls.Add(this.gradientPanel5);
            this.gradientPanel2.Controls.Add(this.button1);
            this.gradientPanel2.Controls.Add(this.label5);
            this.gradientPanel2.Controls.Add(this.lbMoney);
            this.gradientPanel2.Controls.Add(this.label3);
            this.gradientPanel2.Controls.Add(this.lbTimeUsed);
            this.gradientPanel2.Controls.Add(this.label1);
            this.gradientPanel2.Controls.Add(this.lbTimeStart);
            this.gradientPanel2.Controls.Add(this.pictureBox1);
            this.gradientPanel2.Direct = true;
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 22);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(343, 127);
            this.gradientPanel2.TabIndex = 8;
            this.gradientPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel2_Paint);
            // 
            // gradientPanel7
            // 
            this.gradientPanel7.Color1 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel7.Color2 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel7.Direct = true;
            this.gradientPanel7.Location = new System.Drawing.Point(8, 2);
            this.gradientPanel7.Name = "gradientPanel7";
            this.gradientPanel7.Size = new System.Drawing.Size(1, 115);
            this.gradientPanel7.TabIndex = 19;
            // 
            // gradientPanel4
            // 
            this.gradientPanel4.Color1 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel4.Color2 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel4.Direct = false;
            this.gradientPanel4.Location = new System.Drawing.Point(0, 13);
            this.gradientPanel4.Name = "gradientPanel4";
            this.gradientPanel4.Size = new System.Drawing.Size(240, 1);
            this.gradientPanel4.TabIndex = 64;
            // 
            // gradientPanel3
            // 
            this.gradientPanel3.Color1 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel3.Color2 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel3.Direct = false;
            this.gradientPanel3.Location = new System.Drawing.Point(0, 20);
            this.gradientPanel3.Name = "gradientPanel3";
            this.gradientPanel3.Size = new System.Drawing.Size(140, 1);
            this.gradientPanel3.TabIndex = 64;
            // 
            // gradientPanel5
            // 
            this.gradientPanel5.Color1 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel5.Color2 = System.Drawing.Color.RoyalBlue;
            this.gradientPanel5.Direct = false;
            this.gradientPanel5.Location = new System.Drawing.Point(0, 6);
            this.gradientPanel5.Name = "gradientPanel5";
            this.gradientPanel5.Size = new System.Drawing.Size(340, 1);
            this.gradientPanel5.TabIndex = 63;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(241, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thoát";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(9, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thành tiền :";
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.BackColor = System.Drawing.Color.Transparent;
            this.lbMoney.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoney.ForeColor = System.Drawing.Color.Red;
            this.lbMoney.Location = new System.Drawing.Point(199, 82);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(22, 24);
            this.lbMoney.TabIndex = 3;
            this.lbMoney.Text = "a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(9, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thời gian sử dụng :";
            // 
            // lbTimeUsed
            // 
            this.lbTimeUsed.AutoSize = true;
            this.lbTimeUsed.BackColor = System.Drawing.Color.Transparent;
            this.lbTimeUsed.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeUsed.ForeColor = System.Drawing.Color.Blue;
            this.lbTimeUsed.Location = new System.Drawing.Point(199, 58);
            this.lbTimeUsed.Name = "lbTimeUsed";
            this.lbTimeUsed.Size = new System.Drawing.Size(22, 24);
            this.lbTimeUsed.TabIndex = 2;
            this.lbTimeUsed.Text = "a";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thời gian bắt đầu :";
            // 
            // lbTimeStart
            // 
            this.lbTimeStart.AutoSize = true;
            this.lbTimeStart.BackColor = System.Drawing.Color.Transparent;
            this.lbTimeStart.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeStart.ForeColor = System.Drawing.Color.Blue;
            this.lbTimeStart.Location = new System.Drawing.Point(199, 34);
            this.lbTimeStart.Name = "lbTimeStart";
            this.lbTimeStart.Size = new System.Drawing.Size(22, 24);
            this.lbTimeStart.TabIndex = 1;
            this.lbTimeStart.Text = "a";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(214, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 124);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.gradientPanel1.Color1 = System.Drawing.SystemColors.InactiveCaption;
            this.gradientPanel1.Color2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Controls.Add(this.button2);
            this.gradientPanel1.Direct = false;
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(343, 22);
            this.gradientPanel1.TabIndex = 7;
            this.gradientPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tính tiền";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseDown);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Font = new System.Drawing.Font("Marlett", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(322, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 22);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Text = "r";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmCalMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(343, 149);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.gradientPanel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCalMoney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính ti`ên";
            this.TopMost = true;
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTimeStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTimeUsed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbMoney;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private GradientPanel gradientPanel5;
        private GradientPanel gradientPanel3;
        private GradientPanel gradientPanel4;
        private GradientPanel gradientPanel2;
        private GradientPanel gradientPanel7;
    }
}