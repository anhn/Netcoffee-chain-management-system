using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace NetCafe
{
    public partial class GradientPanel : Panel
    {
        private bool status = true;
        private Color cColor1;
        private Color cColor2;
                
        private LinearGradientBrush GBrush;
        private Rectangle rect; 
        public bool Direct
        {
            get { return status; }
            set { 
                status = value;
                SetParam();
                Refresh(); 
            }
        }
        public Color Color1
        {
            get { return cColor1; }
            set { cColor1 = value;
                    SetParam();
                    Refresh();
                }
        }
        public Color Color2
        {
            get { return cColor2; }
            set { 
                cColor2 = value;
                SetParam();
                Refresh(); 
            }
        }
        public GradientPanel()
        {
            InitializeComponent();
            cColor1 = Color.White;
            cColor2 = Color.Black;
        }

        public GradientPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void GradientPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(GBrush, rect);
        }
        private void SetParam()
        {
            if (status)
                GBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, this.Height), Color1, Color2);
            else
                GBrush = new LinearGradientBrush(new Point(0, 0), new Point(this.Width, 0), Color1, Color2);
            rect = new Rectangle(0, 0, this.Width, this.Height);            
        }
        private void GradientPanel_Resize(object sender, EventArgs e)
        {
            SetParam();
         
        }
    }
}
