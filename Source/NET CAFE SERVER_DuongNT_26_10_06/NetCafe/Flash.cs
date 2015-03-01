using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace NetCafe
{
    public partial class FrmFlash : Form
    {
        public FrmFlash()
        {
            InitializeComponent();
            WinEffect.AnimateWindow(this, 2000, AnimateWindowStyle.AW_BLEND);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();                        
        }

        private void FrmFlash_Load(object sender, EventArgs e)
        {
            
        }
    }
}