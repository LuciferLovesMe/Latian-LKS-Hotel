using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timer_lks_1
{
    public partial class MasterEmployee : Form
    {
        public MasterEmployee()
        {
            InitializeComponent();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            MasterEmployee master = new MasterEmployee();
            this.Hide();
            master.ShowDialog();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            MasterFD master = new MasterFD();
            this.Hide();
            master.ShowDialog();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            MasterItem master = new MasterItem();
            this.Hide();
            master.ShowDialog();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            MasterRoomType master = new MasterRoomType();
            this.Hide();
            master.ShowDialog();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            MasterRoom master = new MasterRoom();
            this.Hide();
            master.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you Sure to Close ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private bool val()
        {
            if(txtusername.TextLength < 1 || txtname.TextLength < 1 || txtpass.TextLength < 1 || txtconf.TextLength < 1 || txtemail.TextLength < 1 || txtaddress.TextLength < 1 || pictureBox1.Image == null || dtdob.Value == null || comboBox1.Text.Length < 1)
            {
                MessageBox.Show("All Fields Must be Filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(txtconf.TextLength < 8 || txtpass.TextLength < 8)
            {
                MessageBox.Show("Password and Confirm Password Must be at Least 8 Chars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
