using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myproject
{
    public partial class studyMateMain : Form
    {
        public studyMateMain()
        {
            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
            Panel p = sender as Panel;

            if (p != null)
            {
                Color borderColor = Color.FromArgb(200, 200, 200); 
                using (Pen pen = new Pen(borderColor, 1))
                {
                   
                    e.Graphics.DrawLine(pen, 6, p.Height - 1, p.Width, p.Height - 1);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
