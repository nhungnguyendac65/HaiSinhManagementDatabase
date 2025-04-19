using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HaiSinhManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(@"Data Source=DESKTOP-L739AP9;Initial Catalog=QuanLyBanHang;Integrated Security=True;Trust Server Certificate=True");
            con.Open();
            string username = txtPassword.Text;
            string password = txtPassword.Text;
            Microsoft.Data.SqlClient.SqlCommand cnn = new Microsoft.Data.SqlClient.SqlCommand("select Username, Password from logintab where Username='" + txtUsername.Text + "'and Password = '" + txtPassword.Text + "'", con);
            Microsoft.Data.SqlClient.SqlDataAdapter da = new Microsoft.Data.SqlClient.SqlDataAdapter(cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Main mn = new Main();
                mn.Show();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu hoặc tên đăng nhập!");

            }
            con.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void chbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chbHienMatKhau.Checked ? '\0' : '*';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
