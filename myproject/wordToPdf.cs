using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myproject
{
    public partial class wordToPdf : Form
    {
        public wordToPdf()
        {
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.Exit();
            base.OnFormClosed(e);
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
        private void wordToPdf_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Word Files (*.doc;*.docx)|*.doc;*.docx";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("No files selected");
                return;
            }

            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string saveFolder = fbd.SelectedPath;

                    foreach (ListViewItem item in listView1.Items)
                    {
                        string wordPath = item.Tag.ToString();

                        string outputPath = Path.Combine(
                            saveFolder,
                            Path.GetFileNameWithoutExtension(wordPath) + ".pdf"
                        );

                        Spire.Doc.Document doc = new Spire.Doc.Document();
                        doc.LoadFromFile(wordPath);

                        
                        doc.SaveToFile(outputPath, Spire.Doc.FileFormat.PDF);
                        doc.Close();
                    }

                    MessageBox.Show("Task Complete");
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pdWord p = new pdWord();
            p.Show();
            this.Hide();
        }
    }
}
