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
    public partial class signup : Form
    {

        

        public signup()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void signup_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.BackColor = Color.White;
        }

        // exit korar jonno
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.Exit();
            base.OnFormClosed(e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked;
            button1.BackColor = Color.LightSkyBlue;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Something need to show");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }




        
        



        // DATABASE CONNECTION - 
        string connectionString = "data source=DESKTOP-BF5OMUT\\SQLEXPRESS; database=KK; integrated security=SSPI";
        private void button1_Click(object sender, EventArgs e)
        {

            
            

            string email = textBox1.Text;
            string user_name = textBox2.Text;
            string password = textBox3.Text;
            string match_passwordForCheck = textBox4.Text;
            if(password.Equals(match_passwordForCheck))
            {

                if (string.IsNullOrWhiteSpace(email) 
                    || string.IsNullOrWhiteSpace(user_name)
                    || string.IsNullOrWhiteSpace(password) 
                    || string.IsNullOrWhiteSpace(match_passwordForCheck))
                {
                    MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "INSERT INTO Users (Email, UserName, Password) " +"VALUES (@Email, @UserName, @Password); " +
               "SELECT SCOPE_IDENTITY();";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); 

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@UserName", user_name);
                        command.Parameters.AddWithValue("@Password", password);

                     
                        var result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int newUserId = Convert.ToInt32(result);
                            MessageBox.Show($"Sign UP successfully!\nyour user id is: {newUserId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login f = new Login();
                            this.Hide();
                            f.ShowDialog();
                            
                        }
                        else
                        {
                            MessageBox.Show("Sign UP Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }





                //MessageBox.Show("Successfull");
            }
            else { MessageBox.Show("Can not login"); }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
