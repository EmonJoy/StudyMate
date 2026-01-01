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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // form properly exit korar jnne ** DO NOT TOUCHED the func ** 
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.Exit();
            base.OnFormClosed(e);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }


        // 
        string connectionString = "data source=DESKTOP-BF5OMUT\\SQLEXPRESS; database=KK; integrated security=SSPI";
        private void button1_Click(object sender, EventArgs e)
        {
            string email_forLogin = textBox1.Text;
            string password_forLogin = textBox2.Text;

            string query = "SELECT Id, UserName FROM Users " +
               "WHERE Email = @Email AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email_forLogin);
                    command.Parameters.AddWithValue("@Password", password_forLogin);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int userId = (int)reader["Id"];
                        string user_forCheck = reader["userName"].ToString();


                        studyMateMain m = new studyMateMain(user_forCheck);
                        m.Show();
                        this.Hide();
                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            }

        }
    }
}
