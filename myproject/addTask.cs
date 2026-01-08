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

    
    public partial class addTask : Form
    {

        studyMateMain mainForm;
        int id;

        public addTask(int id, studyMateMain mainForm)
        {
            InitializeComponent();
            this.id = id;
            this.mainForm = mainForm;
        }



        string connectionString = "data source=DESKTOP-BF5OMUT\\SQLEXPRESS; database=KK; " +
                                   "integrated security=SSPI";

        private void addBtn_Click(object sender, EventArgs e)
        {
            string task = richTextBox1.Text;
            if (string.IsNullOrEmpty(task))
            {
                MessageBox.Show("Task name cannot be empty","Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO Tasks (userId, TaskName) VALUES (@userId, @taskName)";


            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userId", id);
                cmd.Parameters.AddWithValue("@taskName", task);

                con.Open();
                cmd.ExecuteNonQuery();

            }
          
            richTextBox1.Clear();
            mainForm.LoadUserTasks();
            this.Hide();

        }
    }
}
