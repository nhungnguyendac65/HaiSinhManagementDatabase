using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaiSinhManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kh1.Visible = true;
            hh1.Visible = false;
            bh1.Visible = false;
            ctbh1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kh1.Visible = false;
            hh1.Visible = true;
            bh1.Visible = false;
            ctbh1.Visible = false;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            kh1.Visible = false;
            hh1.Visible = false;
            bh1.Visible = true;
            ctbh1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kh1.Visible = false;
            hh1.Visible = false;
            bh1.Visible = false;
            ctbh1.Visible = true;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn đăng xuất không?"
            , "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
