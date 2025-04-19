namespace HaiSinhManagement
{
    partial class CTBH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTBH));
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            btnTimKiem = new Button();
            txtThanhTien = new TextBox();
            btnSua = new Button();
            btnXoa = new Button();
            btnMoi = new Button();
            label2 = new Label();
            btnThem = new Button();
            label3 = new Label();
            label1 = new Label();
            cbMaHH = new ComboBox();
            txtMaDBH = new TextBox();
            txtSoLuong = new TextBox();
            label5 = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ScrollBar;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.SteelBlue;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.SteelBlue;
            dataGridViewCellStyle2.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.GridColor = SystemColors.ScrollBar;
            dataGridView1.Location = new Point(13, 29);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.Size = new Size(684, 203);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(9, 193);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(708, 241);
            panel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(675, 6);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(22, 20);
            pictureBox2.TabIndex = 28;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(13, 6);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(117, 18);
            label4.TabIndex = 27;
            label4.Text = "Chi tiết bán hàng";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.FlatStyle = FlatStyle.Popup;
            btnTimKiem.Font = new Font("Tahoma", 10F);
            btnTimKiem.ForeColor = SystemColors.ControlLightLight;
            btnTimKiem.Location = new Point(225, 125);
            btnTimKiem.Margin = new Padding(2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.RightToLeft = RightToLeft.No;
            btnTimKiem.Size = new Size(83, 27);
            btnTimKiem.TabIndex = 22;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtThanhTien
            // 
            txtThanhTien.Location = new Point(269, 85);
            txtThanhTien.Margin = new Padding(2);
            txtThanhTien.Name = "txtThanhTien";
            txtThanhTien.Size = new Size(129, 23);
            txtThanhTien.TabIndex = 26;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.ActiveCaption;
            btnSua.FlatStyle = FlatStyle.Popup;
            btnSua.Font = new Font("Tahoma", 10F);
            btnSua.ForeColor = SystemColors.ControlLightLight;
            btnSua.Location = new Point(90, 125);
            btnSua.Margin = new Padding(2);
            btnSua.Name = "btnSua";
            btnSua.RightToLeft = RightToLeft.No;
            btnSua.Size = new Size(64, 27);
            btnSua.TabIndex = 17;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.ActiveCaption;
            btnXoa.FlatStyle = FlatStyle.Popup;
            btnXoa.Font = new Font("Tahoma", 10F);
            btnXoa.ForeColor = SystemColors.ControlLightLight;
            btnXoa.Location = new Point(158, 125);
            btnXoa.Margin = new Padding(2);
            btnXoa.Name = "btnXoa";
            btnXoa.RightToLeft = RightToLeft.No;
            btnXoa.Size = new Size(64, 27);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnMoi
            // 
            btnMoi.BackColor = SystemColors.ActiveCaption;
            btnMoi.FlatStyle = FlatStyle.Popup;
            btnMoi.Font = new Font("Tahoma", 10F);
            btnMoi.ForeColor = SystemColors.ControlLightLight;
            btnMoi.Location = new Point(313, 125);
            btnMoi.Margin = new Padding(2);
            btnMoi.Name = "btnMoi";
            btnMoi.RightToLeft = RightToLeft.No;
            btnMoi.Size = new Size(83, 27);
            btnMoi.TabIndex = 20;
            btnMoi.Text = "Làm mới";
            btnMoi.UseVisualStyleBackColor = false;
            btnMoi.Click += btnMoi_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(269, 66);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 25;
            label2.Text = "Thành tiền";
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ActiveCaption;
            btnThem.FlatStyle = FlatStyle.Popup;
            btnThem.Font = new Font("Tahoma", 10F);
            btnThem.ForeColor = SystemColors.ControlLightLight;
            btnThem.Location = new Point(22, 125);
            btnThem.Margin = new Padding(2);
            btnThem.Name = "btnThem";
            btnThem.RightToLeft = RightToLeft.No;
            btnThem.Size = new Size(64, 27);
            btnThem.TabIndex = 16;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(15, 66);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 5;
            label3.Text = "Số lượng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(15, 16);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã đơn bán hàng";
            // 
            // cbMaHH
            // 
            cbMaHH.FormattingEnabled = true;
            cbMaHH.Location = new Point(269, 33);
            cbMaHH.Margin = new Padding(2);
            cbMaHH.Name = "cbMaHH";
            cbMaHH.Size = new Size(129, 23);
            cbMaHH.TabIndex = 24;
            cbMaHH.DropDown += cbMaHH_DropDown;
            cbMaHH.SelectedIndexChanged += cbMaHH_SelectedIndexChanged;
            // 
            // txtMaDBH
            // 
            txtMaDBH.Location = new Point(15, 34);
            txtMaDBH.Margin = new Padding(2);
            txtMaDBH.Name = "txtMaDBH";
            txtMaDBH.Size = new Size(136, 23);
            txtMaDBH.TabIndex = 2;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(15, 85);
            txtSoLuong.Margin = new Padding(2);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(136, 23);
            txtSoLuong.TabIndex = 6;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(269, 14);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 9;
            label5.Text = "Mã hàng hoá";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(btnTimKiem);
            panel2.Controls.Add(txtThanhTien);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(btnMoi);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnThem);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cbMaHH);
            panel2.Controls.Add(txtMaDBH);
            panel2.Controls.Add(txtSoLuong);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(306, 11);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(412, 173);
            panel2.TabIndex = 7;
            panel2.Paint += panel2_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 11);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(283, 173);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // CTBH
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(2);
            Name = "CTBH";
            Size = new Size(727, 445);
            Load += CTBH_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Button btnTimKiem;
        private TextBox txtThanhTien;
        private Button btnSua;
        private Button btnXoa;
        private Button btnMoi;
        private Label label2;
        private Button btnThem;
        private Label label3;
        private Label label1;
        private ComboBox cbMaHH;
        private TextBox txtMaDBH;
        private TextBox txtSoLuong;
        private Label label5;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label4;
        private PictureBox pictureBox2;
    }
}
