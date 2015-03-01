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
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
            //WinEffect.AnimateWindow(this, 2000, AnimateWindowStyle.AW_BLEND);
        }

        private void FrmFlash_Load(object sender, EventArgs e)
        {
            
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}