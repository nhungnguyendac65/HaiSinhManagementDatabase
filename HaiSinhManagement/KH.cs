using Microsoft.VisualBasic;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaiSinhManagement
{
    public partial class KH : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-L739AP9;Initial Catalog=QuanLyBanHang;Integrated Security=True;Trust Server Certificate=True";

        public KH()
        {
            InitializeComponent();
        }

        private void ExecuteQuery(string query, Action<SqlCommand> parameterAction)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    parameterAction(cmd);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sQuery = "SELECT * FROM khach_hang";
                    SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt; // Gán dữ liệu vào DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void KH_Load(object sender, EventArgs e)
        {
            LoadData();


        }

        // Hàm kiểm tra dữ liệu NOT NULL
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKH.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }
            return true;
        }

        //ADD
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return; // Nếu đầu vào không hợp lệ, dừng việc thực hiện
            }
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO khach_hang (ma_kh, ten_kh, diachi, sdt) VALUES (@ma_kh, @ten_kh, @diachi, @sdt)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ma_kh", txtMaKH.Text);
                        cmd.Parameters.AddWithValue("@ten_kh", txtTenKH.Text);
                        cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm khách hàng thành công!");
                        LoadData();  // Tải lại dữ liệu
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        //UPDATE
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return; // Nếu đầu vào không hợp lệ, dừng việc thực hiện
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy giá trị cũ từ database
                    string selectQuery = "SELECT ten_kh, diachi, sdt FROM khach_hang WHERE ma_kh=@ma_kh";
                    SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                    selectCmd.Parameters.AddWithValue("@ma_kh", txtMaKH.Text);

                    SqlDataReader reader = selectCmd.ExecuteReader();
                    string oldTenKH = "", oldDiaChi = "", oldSDT = "";

                    if (reader.Read())
                    {
                        oldTenKH = reader["ten_kh"].ToString();
                        oldDiaChi = reader["diachi"].ToString();
                        oldSDT = reader["sdt"].ToString();
                    }
                    reader.Close();

                    // Kiểm tra các giá trị mới, nếu trống thì giữ nguyên giá trị cũ
                    string newTenKH = string.IsNullOrWhiteSpace(txtTenKH.Text) ? oldTenKH : txtTenKH.Text;
                    string newDiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? oldDiaChi : txtDiaChi.Text;
                    string newSDT = string.IsNullOrWhiteSpace(txtSDT.Text) ? oldSDT : txtSDT.Text;

                    // Cập nhật dữ liệu
                    string updateQuery = "UPDATE khach_hang SET ten_kh=@ten_kh, diachi=@diachi, sdt=@sdt WHERE ma_kh=@ma_kh";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@ma_kh", txtMaKH.Text);
                        updateCmd.Parameters.AddWithValue("@ten_kh", newTenKH);
                        updateCmd.Parameters.AddWithValue("@diachi", newDiaChi);
                        updateCmd.Parameters.AddWithValue("@sdt", newSDT);

                        updateCmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật khách hàng thành công!");
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
        }

        //DELETE
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống khi xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Xóa dữ liệu trong các bảng con trước
                    string deleteDetails = "DELETE FROM chitiet_banhang WHERE ma_dbh IN (SELECT ma_dbh FROM ban_hang WHERE ma_kh=@ma_kh)";
                    string deleteBanHang = "DELETE FROM ban_hang WHERE ma_kh=@ma_kh";
                    string deleteKhachHang = "DELETE FROM khach_hang WHERE ma_kh=@ma_kh";

                    using (SqlCommand cmd = new SqlCommand(deleteDetails, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma_kh", txtMaKH.Text);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(deleteBanHang, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma_kh", txtMaKH.Text);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(deleteKhachHang, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma_kh", txtMaKH.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa khách hàng và các dữ liệu liên quan thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
            }
        }

        //SEARCH
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Tạo câu lệnh truy vấn tìm kiếm
                    string query = "SELECT * FROM khach_hang WHERE ma_kh LIKE @search";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Thêm tham số tìm kiếm
                    cmd.Parameters.AddWithValue("@search", "%" + txtMaKH.Text.Trim() + "%");

                    // Đổ dữ liệu vào DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Hiển thị kết quả lên DataGridView
                    dataGridView1.DataSource = table;

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng nào!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
                }
            }
        }

        //CLEAR
        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
{
    // Kiểm tra nếu có một dòng được chọn
    if (e.RowIndex >= 0)
    {
        // Lấy dữ liệu từ dòng đã chọn
        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

        // Gán giá trị vào các TextBox
        txtMaKH.Text = row.Cells["ma_kh"].Value.ToString();
        txtTenKH.Text = row.Cells["ten_kh"].Value.ToString();
        txtDiaChi.Text = row.Cells["diachi"].Value.ToString();
        txtSDT.Text = row.Cells["sdt"].Value.ToString();
      
    }
}


    }
}
