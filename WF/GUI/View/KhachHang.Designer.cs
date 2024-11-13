namespace WF.Form_Chức_Năng.Form_Chức_Năng___NhanVien
{
    partial class KhachHang
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label5 = new Label();
            panel2 = new Panel();
            btnLammoi = new Button();
            btnSua = new Button();
            btnThem = new Button();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            txtDiaChi = new TextBox();
            txtSĐT = new TextBox();
            txtTenKh = new TextBox();
            txtMaKH = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            dgvDanhSachkh = new DataGridView();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            txtTimKiemkh = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachkh).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Times New Roman", 26F, FontStyle.Bold, GraphicsUnit.Point);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8, 8, 8, 8);
            panel1.Size = new Size(1041, 66);
            panel1.TabIndex = 41;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(338, 10);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(393, 45);
            label5.TabIndex = 3;
            label5.Text = "Quản Lý Khách Hàng";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(btnLammoi);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(btnThem);
            panel2.Controls.Add(rdoNu);
            panel2.Controls.Add(rdoNam);
            panel2.Controls.Add(txtDiaChi);
            panel2.Controls.Add(txtSĐT);
            panel2.Controls.Add(txtTenKh);
            panel2.Controls.Add(txtMaKH);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 66);
            panel2.Margin = new Padding(2, 2, 2, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1041, 223);
            panel2.TabIndex = 42;
            // 
            // btnLammoi
            // 
            btnLammoi.BackColor = Color.RosyBrown;
            btnLammoi.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnLammoi.Location = new Point(894, 138);
            btnLammoi.Margin = new Padding(2, 2, 2, 2);
            btnLammoi.Name = "btnLammoi";
            btnLammoi.Size = new Size(111, 42);
            btnLammoi.TabIndex = 13;
            btnLammoi.Text = "Làm mới";
            btnLammoi.UseVisualStyleBackColor = false;
            btnLammoi.Click += btnLammoi_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.RosyBrown;
            btnSua.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnSua.Location = new Point(754, 138);
            btnSua.Margin = new Padding(2, 2, 2, 2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(111, 42);
            btnSua.TabIndex = 12;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.RosyBrown;
            btnThem.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnThem.Location = new Point(607, 138);
            btnThem.Margin = new Padding(2, 2, 2, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(111, 42);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(308, 114);
            rdoNu.Margin = new Padding(2, 2, 2, 2);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(50, 24);
            rdoNu.TabIndex = 10;
            rdoNu.TabStop = true;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(201, 116);
            rdoNam.Margin = new Padding(2, 2, 2, 2);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(62, 24);
            rdoNam.TabIndex = 9;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(671, 25);
            txtDiaChi.Margin = new Padding(2, 2, 2, 2);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(361, 67);
            txtDiaChi.TabIndex = 8;
            // 
            // txtSĐT
            // 
            txtSĐT.Location = new Point(201, 165);
            txtSĐT.Margin = new Padding(2, 2, 2, 2);
            txtSĐT.Name = "txtSĐT";
            txtSĐT.Size = new Size(357, 27);
            txtSĐT.TabIndex = 7;
            // 
            // txtTenKh
            // 
            txtTenKh.Location = new Point(201, 70);
            txtTenKh.Margin = new Padding(2, 2, 2, 2);
            txtTenKh.Name = "txtTenKh";
            txtTenKh.Size = new Size(357, 27);
            txtTenKh.TabIndex = 6;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(201, 26);
            txtMaKH.Margin = new Padding(2, 2, 2, 2);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(357, 27);
            txtMaKH.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(592, 25);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(79, 22);
            label6.TabIndex = 4;
            label6.Text = "Địa chỉ :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(42, 165);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(125, 22);
            label4.TabIndex = 3;
            label4.Text = "Số điện thoại :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(42, 116);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(92, 22);
            label3.TabIndex = 2;
            label3.Text = "Giới tính :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(42, 70);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(142, 22);
            label2.TabIndex = 1;
            label2.Text = "Tên khách hàng :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(42, 26);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(143, 22);
            label1.TabIndex = 0;
            label1.Text = "Mã Khách hàng :";
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 289);
            panel3.Margin = new Padding(2, 2, 2, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1041, 380);
            panel3.TabIndex = 43;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(dgvDanhSachkh);
            groupBox1.Controls.Add(panel4);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(2, 2, 2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 2, 2, 2);
            groupBox1.Size = new Size(1041, 380);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách khách hàng";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // dgvDanhSachkh
            // 
            dgvDanhSachkh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachkh.BackgroundColor = SystemColors.ButtonHighlight;
            dgvDanhSachkh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachkh.Dock = DockStyle.Fill;
            dgvDanhSachkh.Location = new Point(2, 75);
            dgvDanhSachkh.Margin = new Padding(2, 2, 2, 2);
            dgvDanhSachkh.Name = "dgvDanhSachkh";
            dgvDanhSachkh.RowHeadersWidth = 62;
            dgvDanhSachkh.RowTemplate.Height = 33;
            dgvDanhSachkh.Size = new Size(1037, 303);
            dgvDanhSachkh.TabIndex = 1;
            dgvDanhSachkh.CellClick += dgvDanhSachkh_CellClick;
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(txtTimKiemkh);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(2, 29);
            panel4.Margin = new Padding(2, 2, 2, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(1037, 46);
            panel4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.tk;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(710, 7);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 31);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // txtTimKiemkh
            // 
            txtTimKiemkh.Location = new Point(290, 5);
            txtTimKiemkh.Margin = new Padding(2, 2, 2, 2);
            txtTimKiemkh.Multiline = true;
            txtTimKiemkh.Name = "txtTimKiemkh";
            txtTimKiemkh.Size = new Size(455, 38);
            txtTimKiemkh.TabIndex = 2;
            txtTimKiemkh.TextChanged += txtTimKiemkh_TextChanged;
            // 
            // KhachHangg
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1041, 669);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "KhachHangg";
            Text = "KhachHang";
            Load += KhachHang_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachkh).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label5;
        private Panel panel2;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private RadioButton rdoNu;
        private RadioButton rdoNam;
        private TextBox txtDiaChi;
        private TextBox txtSĐT;
        private TextBox txtTenKh;
        private TextBox txtMaKH;
        private Button btnLammoi;
        private Button btnSua;
        private Button btnThem;
        private Panel panel3;
        private GroupBox groupBox1;
        private DataGridView dgvDanhSachkh;
        private Panel panel4;
        private PictureBox pictureBox1;
        private TextBox txtTimKiemkh;
    }
}