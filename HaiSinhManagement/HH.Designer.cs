namespace HaiSinhManagement
{
    partial class HH
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HH));
            btnTimKiem = new Button();
            btnXoa = new Button();
            label4 = new Label();
            label1 = new Label();
            btnMoi = new Button();
            panel2 = new Panel();
            rbHetHang = new RadioButton();
            rbConHang = new RadioButton();
            txtMaMau = new TextBox();
            label7 = new Label();
            txtDVT = new TextBox();
            txtDonGia = new TextBox();
            label6 = new Label();
            btnSua = new Button();
            txtSoLuongTK = new TextBox();
            label5 = new Label();
            btnThem = new Button();
            txtMaHH = new TextBox();
            label3 = new Label();
            txtTenHH = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label8 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.FlatStyle = FlatStyle.Popup;
            btnTimKiem.Font = new Font("Tahoma", 10F);
            btnTimKiem.ForeColor = SystemColors.ButtonHighlight;
            btnTimKiem.Location = new Point(396, 133);
            btnTimKiem.Margin = new Padding(2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.RightToLeft = RightToLeft.No;
            btnTimKiem.Size = new Size(94, 27);
            btnTimKiem.TabIndex = 22;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.ActiveCaption;
            btnXoa.FlatStyle = FlatStyle.Popup;
            btnXoa.Font = new Font("Tahoma", 10F);
            btnXoa.ForeColor = SystemColors.ButtonHighlight;
            btnXoa.Location = new Point(307, 133);
            btnXoa.Margin = new Padding(2);
            btnXoa.Name = "btnXoa";
            btnXoa.RightToLeft = RightToLeft.No;
            btnXoa.Size = new Size(80, 27);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(382, 28);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 7;
            label4.Text = "Đơn vị tính";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(20, 25);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã hàng hoá";
            // 
            // btnMoi
            // 
            btnMoi.BackColor = SystemColors.ActiveCaption;
            btnMoi.FlatStyle = FlatStyle.Popup;
            btnMoi.Font = new Font("Tahoma", 10F);
            btnMoi.ForeColor = SystemColors.ButtonHighlight;
            btnMoi.Location = new Point(500, 133);
            btnMoi.Margin = new Padding(2);
            btnMoi.Name = "btnMoi";
            btnMoi.RightToLeft = RightToLeft.No;
            btnMoi.Size = new Size(94, 27);
            btnMoi.TabIndex = 20;
            btnMoi.Text = "Làm mới";
            btnMoi.UseVisualStyleBackColor = false;
            btnMoi.Click += btnMoi_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(rbHetHang);
            panel2.Controls.Add(btnTimKiem);
            panel2.Controls.Add(rbConHang);
            panel2.Controls.Add(txtMaMau);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(txtDVT);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtDonGia);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtSoLuongTK);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(btnMoi);
            panel2.Controls.Add(btnThem);
            panel2.Controls.Add(txtMaHH);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtTenHH);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(8, 254);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(710, 183);
            panel2.TabIndex = 26;
            // 
            // rbHetHang
            // 
            rbHetHang.AutoSize = true;
            rbHetHang.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbHetHang.ForeColor = SystemColors.ActiveCaptionText;
            rbHetHang.Location = new Point(556, 80);
            rbHetHang.Margin = new Padding(2);
            rbHetHang.Name = "rbHetHang";
            rbHetHang.Size = new Size(84, 21);
            rbHetHang.TabIndex = 15;
            rbHetHang.TabStop = true;
            rbHetHang.Text = "Hết hàng";
            rbHetHang.UseVisualStyleBackColor = true;
            // 
            // rbConHang
            // 
            rbConHang.AutoSize = true;
            rbConHang.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbConHang.ForeColor = SystemColors.ActiveCaptionText;
            rbConHang.Location = new Point(556, 56);
            rbConHang.Margin = new Padding(2);
            rbConHang.Name = "rbConHang";
            rbConHang.Size = new Size(87, 21);
            rbConHang.TabIndex = 14;
            rbConHang.TabStop = true;
            rbConHang.Text = "Còn hàng";
            rbConHang.UseVisualStyleBackColor = true;
            // 
            // txtMaMau
            // 
            txtMaMau.Location = new Point(20, 94);
            txtMaMau.Margin = new Padding(2);
            txtMaMau.Name = "txtMaMau";
            txtMaMau.Size = new Size(153, 23);
            txtMaMau.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(556, 28);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(129, 20);
            label7.TabIndex = 13;
            label7.Text = "Tình trạng tồn kho";
            // 
            // txtDVT
            // 
            txtDVT.Location = new Point(382, 46);
            txtDVT.Margin = new Padding(2);
            txtDVT.Name = "txtDVT";
            txtDVT.Size = new Size(153, 23);
            txtDVT.TabIndex = 8;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(382, 94);
            txtDonGia.Margin = new Padding(2);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(153, 23);
            txtDonGia.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(382, 76);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 11;
            label6.Text = "Đơn giá";
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.ActiveCaption;
            btnSua.FlatStyle = FlatStyle.Popup;
            btnSua.Font = new Font("Tahoma", 10F);
            btnSua.ForeColor = SystemColors.ButtonHighlight;
            btnSua.Location = new Point(216, 133);
            btnSua.Margin = new Padding(2);
            btnSua.Name = "btnSua";
            btnSua.RightToLeft = RightToLeft.No;
            btnSua.Size = new Size(80, 27);
            btnSua.TabIndex = 17;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // txtSoLuongTK
            // 
            txtSoLuongTK.Location = new Point(202, 94);
            txtSoLuongTK.Margin = new Padding(2);
            txtSoLuongTK.Name = "txtSoLuongTK";
            txtSoLuongTK.Size = new Size(153, 23);
            txtSoLuongTK.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(202, 76);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(123, 20);
            label5.TabIndex = 9;
            label5.Text = "Số lượng tồn kho";
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ActiveCaption;
            btnThem.FlatStyle = FlatStyle.Popup;
            btnThem.Font = new Font("Tahoma", 10F);
            btnThem.ForeColor = SystemColors.ButtonHighlight;
            btnThem.Location = new Point(123, 133);
            btnThem.Margin = new Padding(2);
            btnThem.Name = "btnThem";
            btnThem.RightToLeft = RightToLeft.No;
            btnThem.Size = new Size(80, 27);
            btnThem.TabIndex = 16;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtMaHH
            // 
            txtMaHH.Location = new Point(20, 44);
            txtMaHH.Margin = new Padding(2);
            txtMaHH.Name = "txtMaHH";
            txtMaHH.Size = new Size(153, 23);
            txtMaHH.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(20, 76);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 5;
            label3.Text = "Mã màu";
            // 
            // txtTenHH
            // 
            txtTenHH.Location = new Point(202, 44);
            txtTenHH.Margin = new Padding(2);
            txtTenHH.Multiline = true;
            txtTenHH.Name = "txtTenHH";
            txtTenHH.Size = new Size(154, 23);
            txtTenHH.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(202, 25);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 3;
            label2.Text = "Tên hàng hoá";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ScrollBar;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.SteelBlue;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.SteelBlue;
            dataGridViewCellStyle2.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(10, 36);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(690, 184);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(8, 7);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(710, 227);
            panel1.TabIndex = 25;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(676, 8);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(23, 18);
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(10, 11);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(134, 18);
            label8.TabIndex = 23;
            label8.Text = "Thông tin hàng hoá";
            // 
            // HH
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "HH";
            Size = new Size(727, 445);
            Load += HH_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnTimKiem;
        private Button btnXoa;
        private Label label4;
        private Label label1;
        private Button btnMoi;
        private Panel panel2;
        private RadioButton rbHetHang;
        private RadioButton rbConHang;
        private TextBox txtMaMau;
        private Label label7;
        private TextBox txtDVT;
        private TextBox txtDonGia;
        private Label label6;
        private Button btnSua;
        private TextBox txtSoLuongTK;
        private Label label5;
        private Button btnThem;
        private TextBox txtMaHH;
        private Label label3;
        private TextBox txtTenHH;
        private Label label2;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Label label8;
        private PictureBox pictureBox1;
    }
}
