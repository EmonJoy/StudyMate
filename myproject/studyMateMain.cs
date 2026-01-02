using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myproject
{
    public partial class studyMateMain : Form
    {
        int id;
        public studyMateMain(string user_name, int userID)
        {

            
            InitializeComponent();
            textBox1.KeyDown += enterToSend;
            label5.Text = user_name;
             id = userID;

            LoadUserTasks();
        }
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

                
            }



            if (text.Equals("hello", StringComparison.OrdinalIgnoreCase) ||
                text.Equals("Hello", StringComparison.OrdinalIgnoreCase)||
                text.Equals("Hi", StringComparison.OrdinalIgnoreCase)||
                text.Equals("hi", StringComparison.OrdinalIgnoreCase) ||
                text.Equals("hey", StringComparison.OrdinalIgnoreCase))
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.Exit();
            base.OnFormClosed(e);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // pdf to word
            // amra ekhane spire.PDF and spire.DOC use korbo to convert PDF

            pdWord pd = new pdWord();
            pd.Show();
            this.Hide();

        }

        private void studyMateMain_Load(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        string connectionString = "data source=DESKTOP-BF5OMUT\\SQLEXPRESS; database=KK; " +
                                    "integrated security=SSPI";
        public void LoadUserTasks()
        {
            string query = "SELECT id , TaskName FROM Tasks WHERE userId = @id";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt; 

                
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                
                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.RowTemplate.DefaultCellStyle.Padding = new Padding(5);

                
                dataGridView1.Columns["id"].Visible = false;
            }
        }









        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       

        }



        private void DeleteTaskFromDB(int taskId)
        {
            string query = "DELETE FROM Tasks WHERE Id = @taskId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@taskId", taskId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a task to delete.");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Are you sure you want to delete the selected task?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dr == DialogResult.Yes)
            {
                
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int taskId = Convert.ToInt32(selectedRow.Cells["Id"].Value); 

                
                DeleteTaskFromDB(taskId);

           
                dataGridView1.Rows.Remove(selectedRow);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addTask t = new addTask(id, this);
            t.ShowDialog();
        }
    }
}
