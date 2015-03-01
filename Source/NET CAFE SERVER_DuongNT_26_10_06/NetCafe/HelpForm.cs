using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCafe
{
    public partial class FrmHelpForm : Form
    {
        public FrmHelpForm()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmHelpForm_Load(object sender, EventArgs e)
        {
            try
            {
                rtbHelpContent.LoadFile("Help.rtf");
            }
            catch (Exception)
            {
               rtbHelpContent.Text = "Hic, Thằng nào xóa mất file Help.rtf rùi!";
            }
        }
    }
}