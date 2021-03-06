namespace NetCafe
{
    partial class FrmHelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHelpForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rtbHelpContent = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 45);
            this.panel1.TabIndex = 0;
            // 
            // btClose
            // 
            this.btClose.ImageIndex = 0;
            this.btClose.ImageList = this.imageList1;
            this.btClose.Location = new System.Drawing.Point(3, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(85, 42);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "Thoát";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "door.png");
            // 
            // rtbHelpContent
            // 
            this.rtbHelpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHelpContent.EnableAutoDragDrop = true;
            this.rtbHelpContent.Location = new System.Drawing.Point(0, 0);
            this.rtbHelpContent.Name = "rtbHelpContent";
            this.rtbHelpContent.Size = new System.Drawing.Size(632, 401);
            this.rtbHelpContent.TabIndex = 1;
            this.rtbHelpContent.Text = "";
            // 
            // FrmHelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.rtbHelpContent);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHelpForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trợ giúp";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmHelpForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.RichTextBox rtbHelpContent;
        private System.Windows.Forms.ImageList imageList1;
    }
}