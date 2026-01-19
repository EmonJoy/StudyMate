using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace myproject
{
    public partial class mergePdf : Form
    {
        public mergePdf()
        {
            InitializeComponent();

          
            button1.AllowDrop = true;
            button1.DragEnter += button1_DragEnter;
            button1.DragDrop += button1_DragDrop;
        }

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

   
        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string filePath in files)
            {
                if (Path.GetExtension(filePath).ToLower() != ".pdf")
                    continue;

   
                bool exists = listView1.Items
                    .Cast<ListViewItem>()
                    .Any(i => i.Tag != null && i.Tag.ToString() == filePath);

                if (exists)
                    continue;

                ListViewItem item = new ListViewItem(Path.GetFileName(filePath));
                item.Tag = filePath;
                listView1.Items.Add(item);
            }
        }

  
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Files (*.pdf)|*.pdf";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Clear();

                foreach (string filePath in ofd.FileNames)
                {
                    ListViewItem item = new ListViewItem(Path.GetFileName(filePath));
                    item.Tag = filePath;
                    listView1.Items.Add(item);
                }
            }
        }

 
        public void MergePDFs()
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("No files selected");
                return;
            }

            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                string outputPath = Path.Combine(fbd.SelectedPath, "Merged.pdf");

                try
                {
                    var mergedDoc = new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfWriter(outputPath));
                    var merger = new iText.Kernel.Utils.PdfMerger(mergedDoc);

                    foreach (ListViewItem item in listView1.Items)
                    {
                        string pdfPath = item.Tag?.ToString();
                        if (string.IsNullOrEmpty(pdfPath) || !File.Exists(pdfPath))
                            continue;

                        var srcDoc = new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfReader(pdfPath));
                        merger.Merge(srcDoc, 1, srcDoc.GetNumberOfPages());
                        srcDoc.Close();
                    }

                    mergedDoc.Close();
                    MessageBox.Show("PDF Merge Complete ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


    
        private void button2_Click(object sender, EventArgs e)
        {
            MergePDFs();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
