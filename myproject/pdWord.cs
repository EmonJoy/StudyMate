using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using System.IO;

namespace myproject
{
    public partial class pdWord : Form
    {
        public pdWord()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.WindowState = FormWindowState.Normal;           
            this.Size = new Size(1646, 1111);
        }

        int id;
        string user_name;
        public pdWord(string user_name,int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.WindowState = FormWindowState.Normal;           
            this.Size = new Size(1646, 1111);
            this.id = id;
            this.user_name = user_name;
            label2.Text = user_name;

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
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.Exit();
            base.OnFormClosed(e);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Files (*.pdf)|*.pdf";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in ofd.FileNames)
                {
                    ListViewItem item = new ListViewItem(
                        Path.GetFileName(filePath)
                    );

                    item.Tag = filePath;   
                    listView1.Items.Add(item);
                }
            }
        }


        private void pdWord_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("No files selected");
                return;
            }

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string saveFolder = fbd.SelectedPath;

                foreach (ListViewItem item in listView1.Items)
                {
                    string pdfPath = item.Tag.ToString();
                    string outputPath = Path.Combine(saveFolder,Path.GetFileNameWithoutExtension(pdfPath) + ".docx");

                    PdfDocument pdf = new PdfDocument();
                    pdf.LoadFromFile(pdfPath);
                    pdf.SaveToFile(outputPath, FileFormat.DOCX);
                    pdf.Close();
                }

                MessageBox.Show("Task Complete");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            studyMateMain m = new studyMateMain(user_name, id);
            m.ShowDialog();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            wordToPdf w = new wordToPdf();
            this.Hide();
            w.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
