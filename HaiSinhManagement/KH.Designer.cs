namespace HaiSinhManagement
{
    partial class KH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KH));
            txtDiaChi = new RichTextBox();
            btnXoa = new Button();
            btnSua = new Button();
            label1 = new Label();
            btnThem = new Button();
            txtMaKH = new TextBox();
            label5 = new Label();
            txtSDT = new TextBox();
            label4 = new Label();
            txtTenKH = new TextBox();
            label3 = new Label();
            panel2 = new Panel();
            btnTimKiem = new Button();
            btnMoi = new Button();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(228, 88);
            txtDiaChi.Margin = new Padding(2);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(421, 51);
            txtDiaChi.TabIndex = 23;
            txtDiaChi.Text = "";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.ActiveCaption;
            btnXoa.FlatStyle = FlatStyle.Popup;
            btnXoa.Font = new Font("Tahoma", 10F);
            btnXoa.ForeColor = SystemColors.ControlLightLight;
            btnXoa.Location = new Point(398, 149);
            btnXoa.Margin = new Padding(2);
            btnXoa.Name = "btnXoa";
            btnXoa.RightToLeft = RightToLeft.No;
            btnXoa.Size = new Size(73, 25);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.ActiveCaption;
            btnSua.FlatStyle = FlatStyle.Popup;
            btnSua.Font = new Font("Tahoma", 10F);
            btnSua.ForeColor = SystemColors.ControlLightLight;
            btnSua.Location = new Point(314, 149);
            btnSua.Margin = new Padding(2);
            btnSua.Name = "btnSua";
            btnSua.RightToLeft = RightToLeft.No;
            btnSua.Size = new Size(71, 25);
            btnSua.TabIndex = 17;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(54, 20);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã khách hàng";
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ActiveCaption;
            btnThem.FlatStyle = FlatStyle.Popup;
            btnThem.Font = new Font("Tahoma", 10F);
            btnThem.ForeColor = SystemColors.ControlLightLight;
            btnThem.Location = new Point(230, 149);
            btnThem.Margin = new Padding(2);
            btnThem.Name = "btnThem";
            btnThem.RightToLeft = RightToLeft.No;
            btnThem.Size = new Size(73, 25);
            btnThem.TabIndex = 16;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(54, 40);
            txtMaKH.Margin = new Padding(2);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(136, 23);
            txtMaKH.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(54, 69);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 9;
            label5.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(54, 88);
            txtSDT.Margin = new Padding(2);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(146, 23);
            txtSDT.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(228, 69);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 7;
            label4.Text = "Địa chỉ";
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(228, 40);
            txtTenKH.Margin = new Padding(2);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(421, 23);
            txtTenKH.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(228, 20);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 5;
            label3.Text = "Tên khách hàng";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(btnTimKiem);
            panel2.Controls.Add(txtDiaChi);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(btnMoi);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnThem);
            panel2.Controls.Add(txtMaKH);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtSDT);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtTenKH);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(10, 251);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(708, 186);
            panel2.TabIndex = 6;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.FlatStyle = FlatStyle.Popup;
            btnTimKiem.Font = new Font("Tahoma", 10F);
            btnTimKiem.ForeColor = SystemColors.ControlLightLight;
            btnTimKiem.Location = new Point(482, 149);
            btnTimKiem.Margin = new Padding(2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.RightToLeft = RightToLeft.No;
            btnTimKiem.Size = new Size(87, 25);
            btnTimKiem.TabIndex = 22;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnMoi
            // 
            btnMoi.BackColor = SystemColors.ActiveCaption;
            btnMoi.FlatStyle = FlatStyle.Popup;
            btnMoi.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMoi.ForeColor = SystemColors.ButtonHighlight;
            btnMoi.Location = new Point(573, 149);
            btnMoi.Margin = new Padding(2);
            btnMoi.Name = "btnMoi";
            btnMoi.RightToLeft = RightToLeft.No;
            btnMoi.Size = new Size(78, 25);
            btnMoi.TabIndex = 20;
            btnMoi.Text = "Làm mới";
            btnMoi.UseVisualStyleBackColor = false;
            btnMoi.Click += btnMoi_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ScrollBar;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.SteelBlue;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.SteelBlue;
            dataGridViewCellStyle2.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.GridColor = SystemColors.InactiveCaptionText;
            dataGridView1.Location = new Point(13, 34);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(682, 184);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dataGridView1);
            panel1.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(9, 7);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(709, 227);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(672, 9);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(23, 21);
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(13, 9);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(149, 18);
            label2.TabIndex = 24;
            label2.Text = "Thông tin khách hàng";
            // 
            // KH
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(2);
            Name = "KH";
            Size = new Size(727, 445);
            Load += KH_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox txtDiaChi;
        private Button btnXoa;
        private Button btnSua;
        private Label label1;
        private Button btnThem;
        private TextBox txtMaKH;
        private Label label5;
        private TextBox txtSDT;
        private Label label4;
        private TextBox txtTenKH;
        private Label label3;
        private Panel panel2;
        private Button btnTimKiem;
        private Button btnMoi;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
