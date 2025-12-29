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
            textBox1.KeyDown += enterToSend;

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

        private void pictureBox1_Click(object sender, EventArgs e, KeyEventArgs ae)
        {

        }



        // enter Button 
        private void enterToSend(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; button1.PerformClick();
            }


        }

        private async void button1_Click(object sender, EventArgs e)
        {


           



            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            string text = textBox1.Text.Trim();

         
            AddMsg(text, true);
            textBox1.Clear();

            
            await Task.Delay(1000);


            int num;
            List<int> numbers = new List<int>();

            if (int.TryParse(text, out num))
            {
                numbers.Add(num);
                //AddMsg(numbers[0].ToString());
                // EKhan theke shuru korte hbe
                
            }



            if (text.Equals("hello", StringComparison.OrdinalIgnoreCase) ||
                text.Equals("Helllo", StringComparison.OrdinalIgnoreCase)||
                text.Equals("Hi", StringComparison.OrdinalIgnoreCase)||
                text.Equals("hi", StringComparison.OrdinalIgnoreCase))
            {
                AddMsg("Hello! I am Coco, Nice to meet you ;)", false);
            }
            else if (text.Equals("what can you do for me?", StringComparison.OrdinalIgnoreCase))
            {
                AddMsg("I can help you with your studies or tools.", false);
            }
            else if (text.Equals("is Asif Gay?", StringComparison.OrdinalIgnoreCase))
            {
                AddMsg("100% , He is Gay.", false);
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // pdf to word
            // amra ekhane spire.PDF and spire.DOC use korbo to convert PDF

            pdWord pd = new pdWord();
            pd.Show();

        }
    }
}
