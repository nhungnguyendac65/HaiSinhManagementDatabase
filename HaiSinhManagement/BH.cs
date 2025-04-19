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

    public partial class BH : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-L739AP9;Initial Catalog=QuanLyBanHang;Integrated Security=True;Trust Server Certificate=True";

        public BH()
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
                    string sQuery = "SELECT * FROM ban_hang";
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

        private void BH_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maDBH = txtMaDBH.Text.Trim();
            string maKH = txtMaKH.Text.Trim();  // Lấy mã khách hàng từ ô nhập

            // Kiểm tra nếu cả hai đều để trống
            if (string.IsNullOrEmpty(maDBH) && string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Mã đơn bán hàng hoặc mã khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xây dựng câu lệnh SQL động tùy vào điều kiện
            string query = "SELECT ma_dbh AS [Mã ĐBH], ma_kh AS [Mã KH], ngay_bh AS [Ngày bán], tongtien AS [Tổng tiền], tinhtrang_thanhtoan AS [Tình trạng thanh toán] " +
                           "FROM ban_hang WHERE 1=1"; // Điều kiện mặc định

            // Nếu mã đơn bán hàng có giá trị, thêm điều kiện vào câu lệnh
            if (!string.IsNullOrEmpty(maDBH))
            {
                query += " AND ma_dbh = @maDBH";
            }

            // Nếu mã khách hàng có giá trị, thêm điều kiện vào câu lệnh
            if (!string.IsNullOrEmpty(maKH))
            {
                query += " AND ma_kh = @maKH";
            }

            // Kết nối và thực thi câu lệnh SQL
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số cho mã đơn bán hàng nếu có
                        if (!string.IsNullOrEmpty(maDBH))
                        {
                            cmd.Parameters.AddWithValue("@maDBH", maDBH);
                        }

                        // Thêm tham số cho mã khách hàng nếu có
                        if (!string.IsNullOrEmpty(maKH))
                        {
                            cmd.Parameters.AddWithValue("@maKH", maKH);
                        }

                        // Thực thi câu lệnh và hiển thị kết quả
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Kiểm tra nếu không có dữ liệu
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu với mã đơn bán hàng hoặc mã khách hàng tương ứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Hiển thị kết quả lên DataGridView
                        dataGridView1.DataSource = dt;

                        // Thông báo nếu có dữ liệu
                        MessageBox.Show("Tìm thấy " + dt.Rows.Count + " kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //ADD
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các controls
            string maDbh = txtMaDBH.Text;
            string maKh = txtMaKH.Text;
            DateTime ngayBh = dtpNgayBH.Value;
            string tinhTrangThanhToan = rbDaThanhToan.Checked ? "1" : "0";

            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrEmpty(maDbh) || string.IsNullOrEmpty(maKh))
            {
                MessageBox.Show("Mã đơn bán hàng và mã khách hàng không được để trống.");
                return;
            }

            // Kết nối đến SQL Server
            string connectionString = "Data Source=DESKTOP-L739AP9;Initial Catalog=QuanLyBanHang;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Tính tổng tiền từ bảng chitiet_banhang
                    string sqlTongTien = @"
                                            SELECT SUM(thanhtien)
                                            FROM chitiet_banhang
                                            WHERE ma_dbh = @ma_dbh";
                    using (SqlCommand cmdTongTien = new SqlCommand(sqlTongTien, conn))
                    {
                        cmdTongTien.Parameters.AddWithValue("@ma_dbh", maDbh);
                        object result = cmdTongTien.ExecuteScalar();

                        // Nếu không có kết quả (không có chi tiết bán hàng cho mã đơn này)
                        float tongTien = (result == DBNull.Value) ? 0 : Convert.ToSingle(result);

                        // Thêm vào bảng ban_hang
                        string sqlInsertBanHang = @"
                    INSERT INTO ban_hang (ma_dbh, ma_kh, ngay_bh, tongtien, tinhtrang_thanhtoan)
                    VALUES (@ma_dbh, @ma_kh, @ngay_bh, @tongtien, @tinhtrang_thanhtoan)";

                        using (SqlCommand cmdInsert = new SqlCommand(sqlInsertBanHang, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@ma_dbh", maDbh);
                            cmdInsert.Parameters.AddWithValue("@ma_kh", maKh);
                            cmdInsert.Parameters.AddWithValue("@ngay_bh", ngayBh);
                            cmdInsert.Parameters.AddWithValue("@tongtien", tongTien);
                            cmdInsert.Parameters.AddWithValue("@tinhtrang_thanhtoan", tinhTrangThanhToan);

                            // Thực thi lệnh insert
                            cmdInsert.ExecuteNonQuery();
                            LoadData();
                            MessageBox.Show("Đơn bán hàng đã được thêm thành công!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        //UPDATE
        // Hàm lấy tổng tiền hiện tại từ CSDL
        private float GetCurrentTongTien(string maDBH)
        {
            string connectionString = "Data Source=DESKTOP-L739AP9;Initial Catalog=QuanLyBanHang;Integrated Security=True;Trust Server Certificate=True";
            string query = "SELECT tongtien FROM ban_hang WHERE ma_dbh = @maDBH";
            float tongTien = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDBH", maDBH);
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            tongTien = Convert.ToSingle(result);
                        }
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu tổng tiền: " + ex.Message);
                }
            }

            return tongTien;
        }

        // Hàm lấy ngày bán hàng hiện tại từ CSDL
        private DateTime GetCurrentNgayBH(string maDBH)
        {
            string connectionString = "Server=localhost;Database=QuanLyBanHang;Integrated Security=True;";
            string query = "SELECT ngay_bh FROM ban_hang WHERE ma_dbh = @maDBH";
            DateTime ngayBH = DateTime.Now;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDBH", maDBH);
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            ngayBH = Convert.ToDateTime(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu ngày bán hàng: " + ex.Message);
                }
            }

            return ngayBH;
        }

        // Hàm lấy tình trạng thanh toán hiện tại từ CSDL
        private string GetCurrentTinhTrangThanhToan(string maDBH)
        {
            string query = "SELECT tinhtrang_thanhtoan FROM ban_hang WHERE ma_dbh = @maDBH";
            string tinhTrang = "2"; // Mặc định là chưa thanh toán

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDBH", maDBH);
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            tinhTrang = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu tình trạng thanh toán: " + ex.Message);
                }
            }

            return tinhTrang;
        }

        //Main
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các trường dữ liệu
            string maDBH = txtMaDBH.Text;
            string maKH = txtMaKH.Text;

            // Kiểm tra xem mã DBH và mã KH có rỗng không
            if (string.IsNullOrEmpty(maDBH) || string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Vui lòng nhập mã đơn bán hàng và mã khách hàng!");
                return;
            }

            // Các giá trị mặc định (giữ nguyên nếu không thay đổi)
            DateTime ngayBH = dtpNgayBH.Value;
            float tongTien = 0;
            string tinhTrangThanhToan = rbDaThanhToan.Checked ? "1" : "2";

            // Kiểm tra và lấy giá trị từ các trường nếu có thay đổi
            if (!string.IsNullOrEmpty(txtTongTien.Text) && float.TryParse(txtTongTien.Text, out tongTien))
            {
                // Nếu có nhập tổng tiền, cập nhật giá trị
            }
            else
            {
                // Nếu không nhập, giữ nguyên tổng tiền cũ
                tongTien = GetCurrentTongTien(maDBH); // Hàm này sẽ lấy tổng tiền hiện tại từ CSDL
            }

            // Kiểm tra và lấy ngày bán hàng nếu có thay đổi
            if (dtpNgayBH.Checked)
            {
                ngayBH = dtpNgayBH.Value;
            }
            else
            {
                ngayBH = GetCurrentNgayBH(maDBH); // Hàm này sẽ lấy ngày bán hàng hiện tại từ CSDL
            }

            // Kiểm tra và lấy tình trạng thanh toán nếu có thay đổi
            if (rbDaThanhToan.Checked || rbChuaThanhToan.Checked)
            {
                tinhTrangThanhToan = rbDaThanhToan.Checked ? "1" : "0";
            }
            else
            {
                tinhTrangThanhToan = GetCurrentTinhTrangThanhToan(maDBH); // Lấy tình trạng thanh toán cũ từ CSDL
            }


            //UPDATE
            string query = "UPDATE ban_hang SET " +
                           "ma_kh = @maKH, " +
                           "ngay_bh = @ngayBH, " +
                           "tongtien = @tongTien, " +
                           "tinhtrang_thanhtoan = @tinhTrangThanhToan " +
                           "WHERE ma_dbh = @maDBH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số vào SqlCommand
                        cmd.Parameters.AddWithValue("@maDBH", maDBH);
                        cmd.Parameters.AddWithValue("@maKH", maKH);
                        cmd.Parameters.AddWithValue("@ngayBH", ngayBH);
                        cmd.Parameters.AddWithValue("@tongTien", tongTien);
                        cmd.Parameters.AddWithValue("@tinhTrangThanhToan", tinhTrangThanhToan);

                        // Thực thi câu lệnh UPDATE
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật đơn bán hàng thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy đơn bán hàng với mã này!");
                        }
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
                }
            }
        }

        //DELETE
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maDBH = txtMaDBH.Text;

            // Kiểm tra mã DBH có hợp lệ không
            if (string.IsNullOrEmpty(maDBH))
            {
                MessageBox.Show("Vui lòng nhập mã đơn bán hàng để xóa!");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Bắt đầu giao dịch để đảm bảo tính toàn vẹn dữ liệu
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Xoá dữ liệu trong bảng chitiet_banhang
                            string queryChiTiet = "DELETE FROM chitiet_banhang WHERE ma_dbh = @maDBH";
                            using (SqlCommand cmdChiTiet = new SqlCommand(queryChiTiet, conn, transaction))
                            {
                                cmdChiTiet.Parameters.AddWithValue("@maDBH", maDBH);
                                cmdChiTiet.ExecuteNonQuery();
                            }

                            // Xoá dữ liệu trong bảng ban_hang
                            string queryBanHang = "DELETE FROM ban_hang WHERE ma_dbh = @maDBH";
                            using (SqlCommand cmdBanHang = new SqlCommand(queryBanHang, conn, transaction))
                            {
                                cmdBanHang.Parameters.AddWithValue("@maDBH", maDBH);
                                cmdBanHang.ExecuteNonQuery();
                            }

                            // Commit giao dịch
                            transaction.Commit();
                            MessageBox.Show("Đã xóa đơn bán hàng và các dữ liệu liên quan thành công!");
                        }
                        catch (Exception ex)
                        {
                            // Rollback nếu có lỗi
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                        }
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        //CLEAR
        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaDBH.Clear();
            txtTongTien.Clear();

            txtMaKH.Clear();

            dtpNgayBH.Value = DateTime.Now;

            rbDaThanhToan.Checked = false;
            rbChuaThanhToan.Checked = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng click vào vùng hợp lệ trong DataGridView
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Gán giá trị từ các cột trong DataGridView vào các controls
                txtMaDBH.Text = dataGridView1.Rows[e.RowIndex].Cells["ma_dbh"].Value.ToString();
                txtMaKH.Text = dataGridView1.Rows[e.RowIndex].Cells["ma_kh"].Value.ToString();
                dtpNgayBH.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["ngay_bh"].Value);
                txtTongTien.Text = dataGridView1.Rows[e.RowIndex].Cells["tongtien"].Value.ToString();

                int paymentStatus = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["tinhtrang_thanhtoan"].Value);

                // Kiểm tra tình trạng thanh toán và cập nhật radio button
                if (paymentStatus == 1)
                {
                    rbDaThanhToan.Checked = true;
                }
                else
                {
                    rbChuaThanhToan.Checked = true;
                }

                // Khóa ô nhập mã đơn bán hàng
                txtMaDBH.Enabled = false;
            }
        }

    }

}
