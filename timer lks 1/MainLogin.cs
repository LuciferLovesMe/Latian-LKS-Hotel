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

namespace timer_lks_1
{
    public partial class MainLogin : Form
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        public MainLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you Sure to Close ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else if(checkBox1.Checked == false)
            {
                textBox2.PasswordChar = '*';
            }
        }

        private bool val()
        {
            if(textBox1.TextLength < 1 || textBox2.TextLength < 1)
            {
                MessageBox.Show("Field Must be Filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(textBox2.TextLength < 8)
            {
                MessageBox.Show("Password Must be at Least 8 Chars!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (val())
            {
                String pass = Enc.encrypt(textBox2.Text);
                SqlCommand command = new SqlCommand("select * from employee where username ='" + textBox1.Text + "' and password = '" + textBox2.Text + "'", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Model.id = Convert.ToInt32(reader["id"]);
                    Model.name = Convert.ToString(reader["name"]);
                    Model.username = Convert.ToString(reader["username"]);
                    Model.job_id = Convert.ToInt32(reader["jobId"]);

                    if(Model.job_id == 1)
                    {
                        MainAdmin main = new MainAdmin();
                        this.Hide();
                        main.ShowDialog();
                        connection.Close();
                    }
                    else if(Model.job_id == 2)
                    {
                        MainFrontOffice main = new MainFrontOffice();
                        this.Hide();
                        main.ShowDialog();
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("User Can't be Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                }
                connection.Close();
            }
        }
    }
}
