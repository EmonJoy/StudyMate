using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using System.IO;


namespace myproject
{
    public partial class zipBooster : Form
    {
        List<string> selectedFiles = new List<string>();
        public zipBooster()
        {
            InitializeComponent();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.Exit();
            base.OnFormClosed(e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "Select files to zip";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedFiles.Clear();
                selectedFiles.AddRange(ofd.FileNames);

                label1.Text = $"{selectedFiles.Count} file(s) selected";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedFiles.Count == 0)
            {
                MessageBox.Show("Please select at least one file.","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Zip files (*.zip)|*.zip";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string zipPath = sfd.FileName;
            string password = textBox1.Text.Trim();

            using (ZipFile zip = new ZipFile())
            {
                if (!string.IsNullOrEmpty(password))
                {
                    zip.Password = password;
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                }

                foreach (string file in selectedFiles)
                {
                    zip.AddFile(file, "");
                }

                zip.Save(zipPath);
            }

            MessageBox.Show("Zip file created successfully!");
        }

        private void zipBooster_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
