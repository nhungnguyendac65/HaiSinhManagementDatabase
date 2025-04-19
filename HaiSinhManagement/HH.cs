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
using System.Windows;


namespace HaiSinhManagement

{
    public partial class HH : UserControl
    {
        private string connectionString = @"Data Source=DESKTOP-L739AP9;Initial Catalog=QuanLyBanHang;Integrated Security=True;Trust Server Certificate=True";

        public HH()
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
                    string sQuery = "SELECT * FROM hang_hoa";
                    SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt; // Gán dữ liệu vào DataGridView
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void HH_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //ADD
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHH.Text))
            {
                System.Windows.MessageBox.Show("Mã hàng hóa không được để trống!");
                return;
            }

            string query = "INSERT INTO hang_hoa (ma_hh, ten_hh, dvt, dongia, mamau, sl_tonkho, tinhtrang_tonkho) " +
                           "VALUES (@ma_hh, @ten_hh, @dvt, @dongia, @mamau, @sl_tonkho, @tinhtrang_tonkho)";
            try
            {
                ExecuteQuery(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@ma_hh", txtMaHH.Text.Trim());
                    cmd.Parameters.AddWithValue("@ten_hh", txtTenHH.Text);
                    cmd.Parameters.AddWithValue("@dvt", txtDVT.Text);
                    cmd.Parameters.AddWithValue("@dongia", float.Parse(txtDonGia.Text));
                    cmd.Parameters.AddWithValue("@mamau", txtMaMau.Text);
                    cmd.Parameters.AddWithValue("@sl_tonkho", int.Parse(txtSoLuongTK.Text));
                    cmd.Parameters.AddWithValue("@tinhtrang_tonkho", rbConHang.Checked ? "1" : "0");
                });
                System.Windows.MessageBox.Show("Thêm hàng hóa thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        //UPDATE
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHH.Text))
            {
                System.Windows.MessageBox.Show("Mã hàng hóa không được để trống!");
                return;
            }

            string query = "UPDATE hang_hoa SET ten_hh=@ten_hh, dvt=@dvt, dongia=@dongia, mamau=@mamau, " +
                           "sl_tonkho=@sl_tonkho, tinhtrang_tonkho=@tinhtrang_tonkho WHERE ma_hh=@ma_hh";
            try
            {
                ExecuteQuery(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@ma_hh", txtMaHH.Text.Trim());
                    cmd.Parameters.AddWithValue("@ten_hh", txtTenHH.Text);
                    cmd.Parameters.AddWithValue("@dvt", txtDVT.Text);
                    cmd.Parameters.AddWithValue("@dongia", float.Parse(txtDonGia.Text));
                    cmd.Parameters.AddWithValue("@mamau", txtMaMau.Text);
                    cmd.Parameters.AddWithValue("@sl_tonkho", int.Parse(txtSoLuongTK.Text));
                    cmd.Parameters.AddWithValue("@tinhtrang_tonkho", rbConHang.Checked ? "1" : "0");
                });
                System.Windows.MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        //DELETE
        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Xóa dữ liệu trong chitiet_banhang trước
                    string deleteChildQuery = "DELETE FROM chitiet_banhang WHERE ma_hh=@ma_hh";
                    SqlCommand cmdChild = new SqlCommand(deleteChildQuery, conn);
                    cmdChild.Parameters.AddWithValue("@ma_hh", txtMaHH.Text);
                    cmdChild.ExecuteNonQuery();

                    // Xóa dữ liệu trong hang_hoa
                    string deleteParentQuery = "DELETE FROM hang_hoa WHERE ma_hh=@ma_hh";
                    SqlCommand cmdParent = new SqlCommand(deleteParentQuery, conn);
                    cmdParent.Parameters.AddWithValue("@ma_hh", txtMaHH.Text);
                    cmdParent.ExecuteNonQuery();

                    System.Windows.MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message);
                }
            }
        }

        //SEARCH
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtMaHH.Text.Trim(); // Lấy từ khóa tìm kiếm
                if (string.IsNullOrEmpty(keyword))
                {
                    System.Windows.MessageBox.Show("Vui lòng nhập mã hàng hóa cần tìm kiếm!", "Thông báo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Truy vấn tìm kiếm dữ liệu từ bảng `hang_hoa`
                    string query = "SELECT * FROM hang_hoa WHERE ma_hh LIKE @keyword";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    // Thêm tham số để tránh SQL Injection
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    // Đổ dữ liệu kết quả tìm kiếm vào DataTable
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán DataTable vào DataGridView
                    dataGridView1.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        System.Windows.MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }

        }







        //CLEAR
        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtMaMau.Text = "";
            txtDVT.Text = "";
            txtDonGia.Text = "";
            txtSoLuongTK.Text = "";
            rbConHang.Checked = false;
            rbHetHang.Checked = false;
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
            // Kiểm tra nếu người dùng click vào một hàng hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Lấy dữ liệu từ các cột trong hàng được chọn và gán vào các control
                txtMaHH.Text = dataGridView1.Rows[e.RowIndex].Cells["ma_hh"].Value.ToString();
                txtTenHH.Text = dataGridView1.Rows[e.RowIndex].Cells["ten_hh"].Value.ToString();
                txtMaMau.Text = dataGridView1.Rows[e.RowIndex].Cells["mamau"].Value.ToString();
                txtDVT.Text = dataGridView1.Rows[e.RowIndex].Cells["dvt"].Value.ToString();
                txtDonGia.Text = dataGridView1.Rows[e.RowIndex].Cells["dongia"].Value.ToString();
                txtSoLuongTK.Text = dataGridView1.Rows[e.RowIndex].Cells["sl_tonkho"].Value.ToString();

                // Nếu sử dụng radio buttons để xác định tình trạng hàng (còn hàng hay hết hàng)
                var tinhTrang = dataGridView1.Rows[e.RowIndex].Cells["tinhtrang_tonkho"].Value.ToString();
                rbConHang.Checked = (tinhTrang == "1");
                rbHetHang.Checked = (tinhTrang == "0");
            }
        }





    }
}
