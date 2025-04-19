using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaiSinhManagement
{
    public partial class CTBH : UserControl
    {
        private string connectionString = @"Data Source=DESKTOP-L739AP9;Initial Catalog=QuanLyBanHang;Integrated Security=True;Trust Server Certificate=True";

        public CTBH()
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
                    string sQuery = "SELECT * FROM chitiet_banhang";
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

        private void CTBH_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private bool ValidateInput()
        {
            // Kiểm tra các trường không được để trống
            if (string.IsNullOrWhiteSpace(cbMaHH.Text) ||
                string.IsNullOrWhiteSpace(txtMaDBH.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra số lượng phải là số nguyên dương
            if (!int.TryParse(txtSoLuong.Text, out int sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }
        private void CalculateThanhTien()
        {
            ;
        }
        // Tính thành tiền tự động khi thay đổi số lượng hoặc mã hàng hóa
        private double CalculateThanhTien(string maHH, int soLuong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT dongia FROM hang_hoa WHERE ma_hh = @ma_hh";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma_hh", maHH);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        double dongia = Convert.ToDouble(result);
                        return soLuong * dongia; // Tính thành tiền
                    }
                }
            }
            return 0; // Nếu không tìm thấy giá
        }

        private void cbMaHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string keyword = cbMaHH.Text.Trim();
                    string query = "SELECT ma_hh FROM hang_hoa WHERE ma_hh LIKE @keyword";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbMaHH.DataSource = dt;
                    cbMaHH.DisplayMember = "ma_hh";
                    cbMaHH.ValueMember = "ma_hh";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm mã hàng hóa: " + ex.Message);
                }
                CalculateThanhTien();
            }
        }

        private void cbMaHH_DropDown(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string keyword = cbMaHH.Text.Trim(); // Lấy từ khóa hiện tại trong ComboBox
                    string query = "SELECT ma_hh FROM hang_hoa WHERE ma_hh LIKE @keyword";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbMaHH.DataSource = dt;         // Gán nguồn dữ liệu cho ComboBox
                    cbMaHH.DisplayMember = "ma_hh"; // Hiển thị mã hàng hóa
                    cbMaHH.ValueMember = "ma_hh";   // Giá trị mã hàng hóa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        //Ràng buộc số lượng tồn kho
        //Trước khi thêm/sửa, kiểm tra sl không vượt quá sl_tonkho trong bảng hang_hoa.
        private bool CheckTonKho(string maHH, int soLuong)
        {
            int tonKho = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT sl_tonkho FROM hang_hoa WHERE ma_hh = @ma_hh";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma_hh", maHH);
                    tonKho = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            if (soLuong > tonKho)
            {
                MessageBox.Show("Số lượng bán vượt quá tồn kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        //ADD
        //Check Mã đơn bán hàng bên bảng ban_hang
        private bool CheckMaDBHExists(string maDBH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM ban_hang WHERE ma_dbh = @ma_dbh";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma_dbh", maDBH);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // Nếu tồn tại, trả về true
                }
            }
        }
        //Trừ tồn kho sau khi thêm bản ghi
        private void UpdateTonKho(string maHH, int soLuong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE hang_hoa SET sl_tonkho = sl_tonkho - @soLuong WHERE ma_hh = @maHH";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@soLuong", soLuong);
                    cmd.Parameters.AddWithValue("@maHH", maHH);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Main
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (!CheckTonKho(cbMaHH.Text.Trim(), int.Parse(txtSoLuong.Text.Trim()))) return;
            if (!CheckMaDBHExists(txtMaDBH.Text.Trim()))
            {
                MessageBox.Show("Mã đơn bán hàng không tồn tại trong bảng bán hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Thêm bản ghi vào bảng chitiet_banhang
                    string query = "INSERT INTO chitiet_banhang (ma_dbh, ma_hh, sl, thanhtien) " +
                                   "VALUES (@ma_dbh, @ma_hh, @sl, @thanhtien)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma_dbh", txtMaDBH.Text.Trim());
                        cmd.Parameters.AddWithValue("@ma_hh", cbMaHH.Text.Trim());
                        int soLuong = int.Parse(txtSoLuong.Text.Trim());
                        cmd.Parameters.AddWithValue("@sl", soLuong);


                        // Tính thành tiền
                        txtThanhTien.ReadOnly = true;
                        cmd.Parameters.AddWithValue("@thanhtien", CalculateThanhTien(cbMaHH.Text.Trim(), soLuong));

                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật tồn kho sau khi thêm
                    UpdateTonKho(cbMaHH.Text.Trim(), int.Parse(txtSoLuong.Text.Trim()));

                    MessageBox.Show("Thêm chi tiết bán hàng thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết bán hàng: " + ex.Message);
            }
        }

        //UPDATE
        //Hàm tính tổng tiền mới của một đơn hàng
        private double CalculateTongTien(string maDBH)
        {
            double tongTien = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SUM(thanhtien) FROM chitiet_banhang WHERE ma_dbh = @ma_dbh";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma_dbh", maDBH);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        tongTien = Convert.ToDouble(result);
                    }
                }
            }
            return tongTien;
        }
        //Hàm cập nhật tổng tiền trong bảng ban_hang
        private void UpdateTongTienBanHang(string maDBH)
        {
            double tongTien = CalculateTongTien(maDBH);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE ban_hang SET tongtien = @tongtien WHERE ma_dbh = @ma_dbh";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tongtien", tongTien);
                    cmd.Parameters.AddWithValue("@ma_dbh", maDBH);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Update tồn kho sau khi sửa
        private void UpdateTonKhoAfterEdit(string maHH, int soLuongCu, int soLuongMoi)
        {
            int chenhLech = soLuongMoi - soLuongCu;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE hang_hoa SET sl_tonkho = sl_tonkho - @chenhLech WHERE ma_hh = @ma_hh";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@chenhLech", chenhLech);
                    cmd.Parameters.AddWithValue("@ma_hh", maHH);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Lấy số lượng cũ từ cơ sở dữ liệu trước khi chỉnh sửa
        private int GetSoLuongCu(string maHD, string maHH)
        {
            int soLuongCu = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT so_luong FROM chi_tiet_ban_hang WHERE ma_hd = @ma_hd AND ma_hh = @ma_hh";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma_hd", maHD);
                    cmd.Parameters.AddWithValue("@ma_hh", maHH);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        soLuongCu = Convert.ToInt32(result);
                    }
                }
            }
            return soLuongCu;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string maDBH = txtMaDBH.Text.Trim();
            string maHH = cbMaHH.Text.Trim();
            int soLuongMoi = int.Parse(txtSoLuong.Text.Trim());

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy số lượng cũ
                    int soLuongCu = GetSoLuongCu(maDBH, maHH);

                    if (soLuongCu == -1)
                    {
                        MessageBox.Show("Bản ghi cần sửa không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra tồn kho
                    if (!CheckTonKho(maHH, soLuongMoi - soLuongCu)) return;

                    // Cập nhật chi tiết bán hàng
                    string queryUpdate = "UPDATE chitiet_banhang SET sl = @sl, thanhtien = @thanhtien WHERE ma_dbh = @ma_dbh AND ma_hh = @ma_hh";

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma_dbh", maDBH);
                        cmd.Parameters.AddWithValue("@ma_hh", maHH);
                        cmd.Parameters.AddWithValue("@sl", soLuongMoi);
                        double thanhTien = CalculateThanhTien(maHH, soLuongMoi);
                        cmd.Parameters.AddWithValue("@thanhtien", thanhTien);

                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật tồn kho
                    UpdateTonKhoAfterEdit(maHH, soLuongCu, soLuongMoi);

                    // Cập nhật tổng tiền trong bảng ban_hang
                    UpdateTongTienBanHang(maDBH);

                    MessageBox.Show("Cập nhật chi tiết bán hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chi tiết bán hàng: " + ex.Message);
            }
        }

        //DELETE

        // Kiểm tra xem chi tiết bán hàng có tồn tại không
        private bool CheckChiTietBanHangExists(string maDBH, string maHH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM chitiet_banhang WHERE ma_dbh = @ma_dbh AND ma_hh = @ma_hh";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ma_dbh", maDBH);
                cmd.Parameters.AddWithValue("@ma_hh", maHH);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Cập nhật tồn kho sau khi xóa chi tiết bán hàng
        private void UpdateTonKhoAfterDelete(string maHH, int soLuong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE hang_hoa SET sl_tonkho = sl_tonkho + @soLuong WHERE ma_hh = @ma_hh";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@soLuong", soLuong);
                    cmd.Parameters.AddWithValue("@ma_hh", maHH);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //main
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào (có ghi bản ghi cần xóa không)
            if (string.IsNullOrWhiteSpace(txtMaDBH.Text) || string.IsNullOrWhiteSpace(cbMaHH.Text))
            {
                MessageBox.Show("Vui lòng nhập mã đơn bán hàng và mã hàng hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Kiểm tra tồn tại bản ghi trong bảng chitiet_banhang
            if (!CheckChiTietBanHangExists(txtMaDBH.Text.Trim(), cbMaHH.Text.Trim()))
            {
                MessageBox.Show("Bản ghi chi tiết bán hàng không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy số lượng và mã hàng hóa trước khi xóa để cập nhật lại tồn kho
                    string queryGetInfo = "SELECT sl FROM chitiet_banhang WHERE ma_dbh = @ma_dbh AND ma_hh = @ma_hh";
                    SqlCommand cmdGetInfo = new SqlCommand(queryGetInfo, conn);
                    cmdGetInfo.Parameters.AddWithValue("@ma_dbh", txtMaDBH.Text.Trim());
                    cmdGetInfo.Parameters.AddWithValue("@ma_hh", cbMaHH.Text.Trim());

                    int soLuong = 0;
                    object result = cmdGetInfo.ExecuteScalar();
                    if (result != null)
                    {
                        soLuong = Convert.ToInt32(result);
                    }

                    // Xóa bản ghi trong bảng chitiet_banhang
                    string queryDelete = "DELETE FROM chitiet_banhang WHERE ma_dbh = @ma_dbh AND ma_hh = @ma_hh";
                    SqlCommand cmdDelete = new SqlCommand(queryDelete, conn);
                    cmdDelete.Parameters.AddWithValue("@ma_dbh", txtMaDBH.Text.Trim());
                    cmdDelete.Parameters.AddWithValue("@ma_hh", cbMaHH.Text.Trim());
                    cmdDelete.ExecuteNonQuery();

                    // Cập nhật lại tồn kho trong bảng hang_hoa
                    UpdateTonKhoAfterDelete(cbMaHH.Text.Trim(), soLuong);

                    MessageBox.Show("Xóa chi tiết bán hàng thành công!");
                    LoadData(); // Cập nhật lại dữ liệu trong DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết bán hàng: " + ex.Message);
            }
        }

        //SEARCH
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maDBH = txtMaDBH.Text.Trim();  // Mã đơn bán hàng từ ô nhập
            string maHH = cbMaHH.Text.Trim();     // Mã hàng hóa từ combo box

            // Kiểm tra nếu cả hai đều để trống
            if (string.IsNullOrEmpty(maDBH) && string.IsNullOrEmpty(maHH))
            {
                MessageBox.Show("Mã đơn bán hàng hoặc mã hàng hóa không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xây dựng câu lệnh SQL động tùy vào điều kiện
            string query = "SELECT ma_dbh AS [Mã ĐBH], ma_hh AS [Mã HH], sl AS [Số Lượng], thanhtien AS [Thành tiền] " +
                           "FROM chitiet_banhang WHERE 1=1"; // Điều kiện mặc định

            // Nếu mã đơn bán hàng có giá trị, thêm điều kiện vào câu lệnh
            if (!string.IsNullOrEmpty(maDBH))
            {
                query += " AND ma_dbh = @maDBH";
            }

            // Nếu mã hàng hóa có giá trị, thêm điều kiện vào câu lệnh
            if (!string.IsNullOrEmpty(maHH))
            {
                query += " AND ma_hh = @maHH";
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

                        // Thêm tham số cho mã hàng hóa nếu có
                        if (!string.IsNullOrEmpty(maHH))
                        {
                            cmd.Parameters.AddWithValue("@maHH", maHH);
                        }

                        // Thực thi câu lệnh và hiển thị kết quả
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Kiểm tra nếu không có dữ liệu
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu với mã đơn bán hàng hoặc mã hàng hóa tương ứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //CLEAR
        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaDBH.Clear();
            txtSoLuong.Clear();
            txtThanhTien.Clear();
            cbMaHH.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is selected
            {
                // Get the data from the selected row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Assign values to the respective controls
                txtMaDBH.Text = row.Cells["ma_dbh"].Value.ToString();
                cbMaHH.Text = row.Cells["ma_hh"].Value.ToString();
                txtSoLuong.Text = row.Cells["sl"].Value.ToString();

                // Calculate the total amount (thành tiền)
                int soLuong = int.Parse(txtSoLuong.Text);
                string maHH = cbMaHH.Text;
                double thanhTien = CalculateThanhTien(maHH, soLuong);
                txtThanhTien.Text = thanhTien.ToString("F2"); // Format as currency or with two decimal places
            }
        }

    }
}
