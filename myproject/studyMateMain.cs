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

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            string text = textBox1.Text.Trim();

         
            AddMsg(text, true);
            textBox1.Clear();

            
            await Task.Delay(1000); 

     
            if (text.Equals("hello", StringComparison.OrdinalIgnoreCase))
            {
                AddMsg("Hello! I am Coco, Nice to meet you ;)", false);
            }
            else if (text.Equals("what can you do for me?", StringComparison.OrdinalIgnoreCase))
            {
                AddMsg("I can help you with your studies or tools.", false);
            }
            else
            {
                AddMsg("Hmm... I’m thinking about that ", false);
            }
        }

        private void AddMsg(string text, bool is_me)
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(250, 0);
            lbl.Text = text;
            lbl.Padding= new Padding(8);
            lbl.Margin= new Padding(5);
            if(is_me)
            {
                lbl.BackColor = Color.LightGreen;
            }else { lbl.BackColor = Color.LightGray; }

            flowLayoutPanel1.Controls.Add(lbl); 
            flowLayoutPanel1.ScrollControlIntoView(lbl);
        }
    }
}
