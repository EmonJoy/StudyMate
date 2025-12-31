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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // ekhan theke shuru korbi
            // file has touched by Asif
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // touched by Emon
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide(); // ** DO NOT  UNCOMMENT THIS ** 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            signup s = new signup();
            s.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //studyMateMain s = new studyMateMain();
            //s.Show();
            //this.Hide();
            MessageBox.Show("This button is disabled by EmonJoy", 
                "error",
                MessageBoxButtons.OK ,
                MessageBoxIcon.Warning
                );
        }
    }
}
