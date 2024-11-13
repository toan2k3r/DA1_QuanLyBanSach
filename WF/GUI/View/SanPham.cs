using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WF.BLL.Service;
using WF.DAL.Models;
using WF.GUI.View;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }
        dynamic imgLoad;
        string pathimg;
        NhaXBService Nxbsv;
        SachService sachsv;
        SachCtService sachctsv;
        int idwhenClick = new int();
        private void SanPham_Load(object sender, EventArgs e)
        {
            Nxbsv = new NhaXBService();
            sachsv = new SachService();
            sachctsv = new SachCtService();
            LoadNhaXuatBan();
            LoadSach();
            LoadttSachct();
        }

        public void LoadNhaXuatBan()
        {
            int STT = 1;
            dgvDsNhaXuatBan.ColumnCount = 8;
            dgvDsNhaXuatBan.Rows.Clear();
            dgvDsNhaXuatBan.Columns[0].Name = "ID";
            dgvDsNhaXuatBan.Columns[1].Name = "STT";
            dgvDsNhaXuatBan.Columns[2].Name = "Mã NXB";
            dgvDsNhaXuatBan.Columns[3].Name = "Tên NXB";
            dgvDsNhaXuatBan.Columns[4].Name = "Địa chỉ";
            dgvDsNhaXuatBan.Columns[5].Name = "Số điện thoại";
            dgvDsNhaXuatBan.Columns[6].Name = "Năm xuất bản";
            dgvDsNhaXuatBan.Columns[7].Name = "Trạng thái";
            dgvDsNhaXuatBan.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

            dgvDsNhaXuatBan.Columns[0].Visible = false;

            foreach (var item in Nxbsv.GetAllNXBsv())
            {
                if (item.TrangThai != "Ngừng Hoạt Động")
                {
                    dgvDsNhaXuatBan.Rows.Add(item.Id, STT++, item.MaNxb, item.TenNxb, item.DiaChi, item.Sđt, item.NamXb, item.TrangThai);
                }
            }
        }
        private void btnThemnxb_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaNXB.Text) || string.IsNullOrEmpty(txtTenNXB.Text) || string.IsNullOrEmpty(txtDiaChi.Text) ||
                    string.IsNullOrEmpty(txtSĐT.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra MaNxb không được lớn hơn 10 ký tự và chỉ chứa cả chữ và số
                if (txtMaNXB.Text.Length > 10 || !Regex.IsMatch(txtMaNXB.Text, @"[a-zA-Z]") || !Regex.IsMatch(txtMaNXB.Text, @"[0-9]"))
                {
                    errors.Add("Mã nhà xuất bản không được trống, không quá 10 ký tự và chứa cả chữ và số.");
                }

                // Kiểm tra TenNxb không được vượt quá 100 ký tự
                if (txtTenNXB.Text.Length > 100)
                {
                    errors.Add("Tên nhà xuất bản không được vượt quá 100 ký tự.");
                }

                // Kiểm tra Sđt chỉ chứa 10 số
                if (txtSĐT.Text.Length != 10 || !Regex.IsMatch(txtSĐT.Text, @"^[0-9]+$"))
                {
                    errors.Add("Số điện thoại phải có đúng 10 ký tự và chỉ chứa số.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra mã nhà xuất bản đã tồn tại
                bool check = Nxbsv.GetAllNXBsv().Any(x => string.Equals(x.MaNxb, txtMaNXB.Text, StringComparison.OrdinalIgnoreCase));
                if (check)
                {
                    MessageBox.Show("Mã đã tồn tại");
                    return;
                }

                // Thêm nhà xuất bản nếu không có lỗi
                NhaXuatBan nxb = new NhaXuatBan();
                nxb.MaNxb = txtMaNXB.Text;
                nxb.TenNxb = txtTenNXB.Text;
                nxb.DiaChi = txtDiaChi.Text;
                nxb.Sđt = txtSĐT.Text;
                nxb.NamXb = DateTime.ParseExact(dtpNanXB.Text.Trim(), "dd-MM-yyyy", null);
                nxb.TrangThai = rdoHoatDong.Checked ? "Hoạt Động" : "Ngừng Hoạt Động";
                MessageBox.Show(Nxbsv.Them(nxb));
                LoadNhaXuatBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSuanxb_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaNXB.Text) || string.IsNullOrEmpty(txtTenNXB.Text) || string.IsNullOrEmpty(txtDiaChi.Text) ||
                    string.IsNullOrEmpty(txtSĐT.Text))
                {
                    MessageBox.Show("Vui lòng chọn NXB cần sửa và  điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra MaNxb không được lớn hơn 10 ký tự và chỉ chứa cả chữ và số
                if (txtMaNXB.Text.Length > 10 || !Regex.IsMatch(txtMaNXB.Text, @"[a-zA-Z]") || !Regex.IsMatch(txtMaNXB.Text, @"[0-9]"))
                {
                    errors.Add("Mã nhà xuất bản không được trống, không quá 10 ký tự và chứa cả chữ và số.");
                }

                // Kiểm tra TenNxb không được vượt quá 100 ký tự
                if (txtTenNXB.Text.Length > 100)
                {
                    errors.Add("Tên nhà xuất bản không được vượt quá 100 ký tự.");
                }

                // Kiểm tra Sđt chỉ chứa 10 số
                if (txtSĐT.Text.Length != 10 || !Regex.IsMatch(txtSĐT.Text, @"^[0-9]+$"))
                {
                    errors.Add("Số điện thoại phải có đúng 10 ký tự và chỉ chứa số.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                NhaXuatBan nxb = new NhaXuatBan();
                nxb.MaNxb = txtMaNXB.Text;
                nxb.TenNxb = txtTenNXB.Text;
                nxb.DiaChi = txtDiaChi.Text;
                nxb.Sđt = txtSĐT.Text;
                nxb.NamXb = DateTime.ParseExact(dtpNanXB.Text.Trim(), "dd-MM-yyyy", null);
                if (rdoHoatDong.Checked)
                {
                    nxb.TrangThai = "Hoạt Động";
                }
                else
                {
                    nxb.TrangThai = "Ngừng Hoạt Động";
                }
                MessageBox.Show(Nxbsv.sua(nxb, idwhenClick));
                LoadNhaXuatBan();
            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi rồi");
            }
        }

        private void dgvDsNhaXuatBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDsNhaXuatBan.CurrentRow != null && dgvDsNhaXuatBan.CurrentRow.Cells[0].Value != null)
            {
                txtMaNXB.ReadOnly = true;

                // Ensure cell 0 (Id) contains valid data
                if (dgvDsNhaXuatBan.CurrentRow.Cells[0].Value != null)
                {
                    idwhenClick = int.Parse(dgvDsNhaXuatBan.CurrentRow.Cells[0].Value.ToString());
                }

                // Check and assign data to the textboxes if the corresponding cells contain valid data
                txtMaNXB.Text = dgvDsNhaXuatBan.CurrentRow.Cells[2].Value?.ToString() ?? string.Empty;
                txtTenNXB.Text = dgvDsNhaXuatBan.CurrentRow.Cells[3].Value?.ToString() ?? string.Empty;
                txtDiaChi.Text = dgvDsNhaXuatBan.CurrentRow.Cells[4].Value?.ToString() ?? string.Empty;
                txtSĐT.Text = dgvDsNhaXuatBan.CurrentRow.Cells[5].Value?.ToString() ?? string.Empty;

                // Ensure the date cell is valid before setting the date picker value
                if (dgvDsNhaXuatBan.CurrentRow.Cells[6].Value != null && DateTime.TryParse(dgvDsNhaXuatBan.CurrentRow.Cells[6].Value.ToString(), out DateTime date))
                {
                    dtpNanXB.Value = date;
                }
                else
                {
                    dtpNanXB.Value = DateTime.Now;
                }

                // Check the status and set the radio buttons accordingly
                if (dgvDsNhaXuatBan.CurrentRow.Cells[7].Value != null && dgvDsNhaXuatBan.CurrentRow.Cells[7].Value.ToString().Equals("Hoạt Động", StringComparison.OrdinalIgnoreCase))
                {
                    rdoHoatDong.Checked = true;
                }
                else
                {
                    rdoDungHoatDong.Checked = true;
                }
            }
            else
            {
                // Nếu không có dòng hoặc dữ liệu không hợp lệ, bạn có thể xóa các trường dữ liệu
                txtMaNXB.Text = string.Empty;
                txtTenNXB.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtSĐT.Text = string.Empty;
                dtpNanXB.Value = DateTime.Now;
                rdoHoatDong.Checked = false;
                rdoDungHoatDong.Checked = false;
            }
        }

        private void btnLamMoinxb_Click(object sender, EventArgs e)
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtDiaChi.Text = "";
            dtpNanXB.Text = "";
            rdoHoatDong.Checked = false;
            rdoDungHoatDong.Checked = false;
            txtSĐT.Text = "";
            txtMaNXB.ReadOnly = false;
            txtTimKiemnxb.Text = "";
            LoadNhaXuatBan();
        }
        public void LoadNhaXuatBan(string name)
        {
            int STT = 1;
            dgvDsNhaXuatBan.ColumnCount = 8;
            dgvDsNhaXuatBan.Rows.Clear();
            dgvDsNhaXuatBan.Columns[0].Name = "ID";
            dgvDsNhaXuatBan.Columns[1].Name = "STT";
            dgvDsNhaXuatBan.Columns[2].Name = "Mã NXB";
            dgvDsNhaXuatBan.Columns[3].Name = "Tên NXB";
            dgvDsNhaXuatBan.Columns[4].Name = "Địa chỉ";
            dgvDsNhaXuatBan.Columns[5].Name = "Số điện thoại";
            dgvDsNhaXuatBan.Columns[6].Name = "Năm xuất bản";
            dgvDsNhaXuatBan.Columns[7].Name = "Trạng thái";

            dgvDsNhaXuatBan.Columns[0].Visible = false;

            foreach (var item in Nxbsv.FindName(name))
            {
                dgvDsNhaXuatBan.Rows.Add(item.Id, STT++, item.MaNxb, item.TenNxb, item.DiaChi, item.Sđt, item.NamXb, item.TrangThai);
            }
        }

        private void txtTimKiemnxb_TextChanged(object sender, EventArgs e)
        {
            LoadNhaXuatBan(txtTimKiemnxb.Text);
        }
        public void LoadSach()
        {
            int STT = 1;
            dgvDanhSachSach.ColumnCount = 8;
            dgvDanhSachSach.Rows.Clear();
            dgvDanhSachSach.Columns[0].Name = "ID";
            dgvDanhSachSach.Columns[1].Name = "STT";
            dgvDanhSachSach.Columns[2].Name = "Mã Sách";
            dgvDanhSachSach.Columns[3].Name = "Tên sách";
            dgvDanhSachSach.Columns[4].Name = "Tác giả";
            dgvDanhSachSach.Columns[5].Name = "Ngôn ngữ";
            dgvDanhSachSach.Columns[6].Name = "Mô tả";
            dgvDanhSachSach.Columns[7].Name = "Trạng thái";

            dgvDanhSachSach.Columns[0].Visible = false;

            foreach (var item in sachsv.GetAllSachsv())
            {
                dgvDanhSachSach.Rows.Add(item.Id, STT++, item.MaSach, item.TieuDe, item.TacGia, item.NgonNgu, item.MoTa, item.TrangThai);
            }
        }
        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imagebytes = ms.ToArray();
                return imagebytes;
            }
        }

        public Image Base64ToImage(byte[] imagebytes)
        {
            MemoryStream ms = new MemoryStream(imagebytes, 0, imagebytes.Length);
            ms.Write(imagebytes, 0, imagebytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg; *.jpeg; *.png; *.gif";
            openFileDialog.Title = "Chọn ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    Image image = Image.FromFile(openFileDialog.FileName);


                    pictureSach.Image = image;

                    pathimg = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                }
            }
        }
        private void btnThemsach_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaSachs.Text) || string.IsNullOrEmpty(txtTieudes.Text) || string.IsNullOrEmpty(txtNgonngus.Text) || string.IsNullOrEmpty(txttacgias.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra MaSach không được lớn hơn 10 ký tự và chỉ chứa cả chữ và số
                if (txtMaSachs.Text.Length > 10 || !Regex.IsMatch(txtMaSachs.Text, @"[a-zA-Z]") || !Regex.IsMatch(txtMaSachs.Text, @"[0-9]"))
                {
                    errors.Add("Mã sách không được trống, không quá 10 ký tự và chứa cả chữ và số.");
                }

                // Kiểm tra Tiêu đề không được quá 200 ký tự
                if (txtTieudes.Text.Length > 200)
                {
                    errors.Add("Tiêu đề sách không được vượt quá 200 ký tự.");
                }

                // Kiểm tra NgonNgu chỉ chứa chữ và không quá 50 ký tự
                if (!Regex.IsMatch(txtNgonngus.Text, @"[a-zA-Z]") || txtNgonngus.Text.Length > 50)
                {
                    errors.Add("Ngôn ngữ sách chỉ được chứa chữ và không vượt quá 50 ký tự.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra mã sách đã tồn tại
                bool check = sachsv.GetAllSachsv().Any(x => string.Equals(x.MaSach, txtMaSachs.Text, StringComparison.OrdinalIgnoreCase));

                if (check)
                {
                    MessageBox.Show("Mã đã tồn tại");
                }
                else
                {
                    Sach sach = new Sach();
                    sach.MaSach = txtMaSachs.Text;
                    sach.TieuDe = txtTieudes.Text;
                    sach.TacGia = txttacgias.Text;
                    sach.NgonNgu = txtNgonngus.Text;
                    sach.MoTa = txtMoTas.Text;
                    sach.TrangThai = rdoConhang.Checked ? "Còn hàng" : "Hết hàng";
                    MessageBox.Show(sachsv.Them(sach));
                    LoadSach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btncapnhatsach_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaSachs.Text) || string.IsNullOrEmpty(txtTieudes.Text) || string.IsNullOrEmpty(txtNgonngus.Text) || string.IsNullOrEmpty(txttacgias.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }
                // Kiểm tra Tiêu đề không được quá 200 ký tự
                if (txtTieudes.Text.Length > 200)
                {
                    errors.Add("Tiêu đề sách không được vượt quá 200 ký tự.");
                }

                // Kiểm tra NgonNgu chỉ chứa chữ và không quá 50 ký tự
                if (!Regex.IsMatch(txtNgonngus.Text, @"[a-zA-Z]") || txtNgonngus.Text.Length > 50)
                {
                    errors.Add("Ngôn ngữ sách chỉ được chứa chữ và không vượt quá 50 ký tự.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Sach sach = new Sach();
                sach.MaSach = txtMaSachs.Text;
                sach.TieuDe = txtTieudes.Text;
                sach.TacGia = txttacgias.Text;
                sach.MoTa = txtMoTas.Text;
                sach.TrangThai = rdoConhang.Checked ? "Còn hàng" : "Hết hàng";
                sach.NgonNgu = txtNgonngus.Text;
                MessageBox.Show(sachsv.sua(sach, idwhenClick));
                LoadSach();
            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi rồi");
            }
        }

        private void dgvDanhSachSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the row index is valid and the selected row is not null
            if (e.RowIndex >= 0 && dgvDanhSachSach.CurrentRow != null)
            {
                txtMaSachs.ReadOnly = true;

                // Ensure cell 0 (Id) contains valid data
                if (dgvDanhSachSach.CurrentRow.Cells[0].Value != null)
                {
                    idwhenClick = int.Parse(dgvDanhSachSach.CurrentRow.Cells[0].Value.ToString());
                }

                // Check and assign data to the textboxes if the corresponding cells contain valid data
                txtMaSachs.Text = dgvDanhSachSach.CurrentRow.Cells[2].Value?.ToString() ?? string.Empty;
                txtTieudes.Text = dgvDanhSachSach.CurrentRow.Cells[3].Value?.ToString() ?? string.Empty;
                txttacgias.Text = dgvDanhSachSach.CurrentRow.Cells[4].Value?.ToString() ?? string.Empty;
                txtNgonngus.Text = dgvDanhSachSach.CurrentRow.Cells[5].Value?.ToString() ?? string.Empty;
                txtMoTas.Text = dgvDanhSachSach.CurrentRow.Cells[6].Value?.ToString() ?? string.Empty;

                // Check the availability status and set the radio buttons accordingly
                if (dgvDanhSachSach.CurrentRow.Cells[7].Value != null && dgvDanhSachSach.CurrentRow.Cells[7].Value.ToString().Equals("Còn hàng"))
                {
                    rdoConhang.Checked = true;
                }
                else
                {
                    rdohethang.Checked = true;
                }
            }
            else
            {
                // If the selected row is invalid or contains no data, clear all the textboxes and radio buttons
                txtMaSachs.Clear();
                txtTieudes.Clear();
                txttacgias.Clear();
                txtNgonngus.Clear();
                txtMoTas.Clear();
                rdoConhang.Checked = false;
                rdohethang.Checked = false;
            }
        }

        private void btnlammoisach_Click(object sender, EventArgs e)
        {
            txtMaSachs.Text = "";
            txtTieudes.Text = "";
            txttacgias.Text = "";
            txtNgonngus.Text = "";
            txtMoTas.Text = "";
            rdoConhang.Checked = false;
            rdohethang.Checked = false;
            txtMaSachs.ReadOnly = false;
        }
        public void LoadSach(string name)
        {
            int STT = 1;
            dgvDanhSachSach.ColumnCount = 8;
            dgvDanhSachSach.Rows.Clear();
            dgvDanhSachSach.Columns[0].Name = "ID";
            dgvDanhSachSach.Columns[1].Name = "STT";
            dgvDanhSachSach.Columns[2].Name = "Mã Sách";
            dgvDanhSachSach.Columns[3].Name = "Tên sách";
            dgvDanhSachSach.Columns[4].Name = "Tác giả";
            dgvDanhSachSach.Columns[5].Name = "Ngôn ngữ";
            dgvDanhSachSach.Columns[6].Name = "Mô tả";
            dgvDanhSachSach.Columns[7].Name = "Trạng thái";

            dgvDanhSachSach.Columns[0].Visible = false;

            foreach (var item in sachsv.FindName(name))
            {
                dgvDanhSachSach.Rows.Add(item.Id, STT++, item.MaSach, item.TieuDe, item.TacGia, item.NgonNgu, item.MoTa, item.TrangThai);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadSach(txtTimkiemS.Text);
        }

        public void LoadttSachct()
        {
            int index = 0;
            var result = from sct in sachctsv.GetAllSachctsv()
                         join nxb in Nxbsv.GetAllNXBsv() on sct.Idnxb equals nxb.Id
                         join s in sachsv.GetAllSachsv() on sct.Idsach equals s.Id
                         select new
                         {
                             sct.Id,
                             STT = ++index,
                             sct.MaSachCt,
                             s.TieuDe,
                             sct.HinhAnh,
                             sct.SoLuong,
                             sct.Tap,
                             sct.SoTrang,
                             sct.GiaBan,
                             nxb.TenNxb,
                             sct.TenTheLoai,
                         };

            dgvDanhSachct.DataSource = result.ToList();
            dgvDanhSachct.Columns[0].Visible = false;
            dgvDanhSachct.Columns[1].HeaderText = "STT";
            dgvDanhSachct.Columns[2].HeaderText = "Mã sách";
            dgvDanhSachct.Columns[3].HeaderText = "Tiêu đề";
            dgvDanhSachct.Columns[4].HeaderText = "Hình ảnh";
            dgvDanhSachct.Columns[5].HeaderText = "Số lượng";
            dgvDanhSachct.Columns[6].HeaderText = "Tập";
            dgvDanhSachct.Columns[7].HeaderText = "Số trang";
            dgvDanhSachct.Columns[8].HeaderText = "Giá bán";
            dgvDanhSachct.Columns[9].HeaderText = "Tên nhà XB";
            dgvDanhSachct.Columns[10].HeaderText = "Tên thể loại";

            var loadnxb = Nxbsv.GetAllNXBsv().ToList();
            cboNxb.DataSource = loadnxb;
            cboNxb.DisplayMember = "TenNxb";
            cboNxb.ValueMember = "Id";

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvDanhSachct.Columns[4];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(pathimg) || string.IsNullOrEmpty(txtMaSach.Text) || string.IsNullOrEmpty(txtSoLuong.Text) ||
                    string.IsNullOrEmpty(txtSotrang.Text) || string.IsNullOrEmpty(txtGia.Text) ||
                    cboNxb.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra MaSachCt không được lớn hơn 10 ký tự và chỉ chứa cả chữ và số
                if (txtMaSach.Text.Length > 10 || !Regex.IsMatch(txtMaSach.Text, @"[a-zA-Z]") || !Regex.IsMatch(txtMaSach.Text, @"[0-9]"))
                {
                    errors.Add("Mã sách chi tiết không được trống, không quá 10 ký tự chứa cả chữ và số.");
                }

                // Kiểm tra SoLuong chỉ chứa số và không vượt quá 10000
                int soLuong;
                if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong >= 10000)
                {
                    errors.Add("Số lượng sách phải là một số và không được vượt quá 10000.");
                }

                // Kiểm tra SoTrang chỉ chứa số và không vượt quá 1000
                int soTrang;
                if (!int.TryParse(txtSotrang.Text, out soTrang) || soTrang >= 1000)
                {
                    errors.Add("Số trang sách phải là một số và không được vượt quá 1000.");
                }

                // Kiểm tra GiaBan chỉ chứa số và không vượt quá 1000000
                int giaBan;
                if (!int.TryParse(txtGia.Text, out giaBan) || giaBan >= 1000000)
                {
                    errors.Add("Giá bán sách phải là một số và không được vượt quá 1000000.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool check = sachctsv.GetAllSachctsv().Any(x => string.Equals(x.MaSachCt, txtMaSach.Text, StringComparison.OrdinalIgnoreCase));
                if (check)
                {
                    MessageBox.Show("Mã đã tồn tại");
                    return;
                }
                // Thêm sách chi tiết nếu không có lỗi
                SachChiTiet sachct = new SachChiTiet();
                byte[] imageBytes = File.ReadAllBytes(pathimg);
                sachct.HinhAnh = imageBytes;
                sachct.MaSachCt = txtMaSach.Text;
                sachct.SoLuong = soLuong;
                sachct.Tap = txtTap.Text;
                sachct.SoTrang = soTrang;
                sachct.GiaBan = giaBan;
                sachct.Idnxb = int.Parse(cboNxb.SelectedValue.ToString());
                sachct.Idsach = int.Parse(textBoxID.Text);
                sachct.TenTheLoai = txtTheloai.Text;
                MessageBox.Show(sachctsv.Them(sachct));
                LoadttSachct();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaSach.Text))
            {
                var sach = sachsv.GetAllSachsv().FirstOrDefault(s => s.MaSach == txtMaSach.Text);

                if (sach != null)
                {
                    txtTieude.Text = sach.TieuDe;
                    textBoxID.Text = sach.Id.ToString();
                }
                else
                {
                    txtTieude.Text = "Not found";
                    textBoxID.Text = "";
                }
            }
            else
            {
                txtTieude.Text = "";
                textBoxID.Text = "";
            }
        }

        private void dgvDanhSachct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idwhenClick = int.Parse(dgvDanhSachct.CurrentRow.Cells[0].Value.ToString());
            txtMaSach.Text = dgvDanhSachct.CurrentRow.Cells[2].Value.ToString();
            txtTieude.Text = dgvDanhSachct.CurrentRow.Cells[3].Value.ToString();
            txtSoLuong.Text = dgvDanhSachct.CurrentRow.Cells[5].Value.ToString();
            txtTap.Text = dgvDanhSachct.CurrentRow.Cells[6].Value.ToString();
            txtSotrang.Text = dgvDanhSachct.CurrentRow.Cells[7].Value.ToString();
            txtGia.Text = dgvDanhSachct.CurrentRow.Cells[8].Value.ToString();
            cboNxb.Text = dgvDanhSachct.CurrentRow.Cells[9].Value.ToString();
            txtTheloai.Text = dgvDanhSachct.CurrentRow.Cells[10].Value.ToString();
            txtMaSach.ReadOnly = true;

            var s = sachctsv.Findid(idwhenClick);
            if (s != null && s.HinhAnh != null)
            {
                byte[] imageData = s.HinhAnh;
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureSach.Image = Image.FromStream(ms);
                    imgLoad = s.HinhAnh;
                }
            }
            else
            {
                pictureSach.Image = null;
                imgLoad = null;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaSach.Text) || string.IsNullOrEmpty(txtSoLuong.Text) ||
                    string.IsNullOrEmpty(txtSotrang.Text) || string.IsNullOrEmpty(txtGia.Text) ||
                    cboNxb.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra MaSachCt không được lớn hơn 10 ký tự và chỉ chứa cả chữ và số
                if (txtMaSach.Text.Length > 10 || !Regex.IsMatch(txtMaSach.Text, @"[a-zA-Z]") || !Regex.IsMatch(txtMaSach.Text, @"[0-9]"))
                {
                    errors.Add("Mã sách chi tiết không được trống, không quá 10 ký tự chứa cả chữ và số.");
                }

                // Kiểm tra SoLuong chỉ chứa số và không vượt quá 10000
                int soLuong;
                if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong >= 10000)
                {
                    errors.Add("Số lượng sách phải là một số và không được vượt quá 10000.");
                }

                // Kiểm tra SoTrang chỉ chứa số và không vượt quá 500
                int soTrang;
                if (!int.TryParse(txtSotrang.Text, out soTrang) || soTrang >= 500)
                {
                    errors.Add("Số trang sách phải là một số và không được vượt quá 500.");
                }

                // Kiểm tra GiaBan chỉ chứa số và không vượt quá 1000000
                int giaBan;
                if (!int.TryParse(txtGia.Text, out giaBan) || giaBan >= 1000000)
                {
                    errors.Add("Giá bán sách phải là một số và không được vượt quá 1000000.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SachChiTiet sachct = new SachChiTiet();
                if (pathimg != null)
                {
                    byte[] imageBytes = File.ReadAllBytes(pathimg);
                    sachct.HinhAnh = imageBytes;
                }
                else
                    sachct.HinhAnh = imgLoad;
                sachct.MaSachCt = txtMaSach.Text;
                sachct.SoLuong = int.Parse(txtSoLuong.Text);
                sachct.Tap = txtTap.Text;
                sachct.SoTrang = int.Parse(txtSotrang.Text);
                sachct.GiaBan = int.Parse(txtGia.Text);
                sachct.Idnxb = int.Parse(cboNxb.SelectedValue.ToString());
                sachct.Idsach = int.Parse(textBoxID.Text);
                sachct.TenTheLoai = txtTheloai.Text;
                MessageBox.Show(sachctsv.Sua(sachct, idwhenClick));

                LoadttSachct();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";
            txtTieude.Text = "";
            txtSoLuong.Text = "";
            txtTap.Text = "";
            txtSotrang.Text = "";
            txtGia.Text = "";
            cboNxb.SelectedIndex = -1;
            pictureSach.Image = null;
            txtMaSach.ReadOnly = false;
            txtTheloai.Text = "";
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenernator = new QRCodeGenerator();
            QRCodeData qrCodedata = qrGenernator.CreateQrCode(txtMaSach.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qrCodedata);
            Bitmap qrcodeImg = qrcode.GetGraphic(20);
            pictureSach.Image = qrcodeImg;
        }

        private void btnLuuQr_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog savefliedialog = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                if (savefliedialog.ShowDialog() == DialogResult.OK)
                {
                    pictureSach.Image.Save(savefliedialog.FileName);
                    MessageBox.Show("Tệp đã lưu");
                }
            }
        }
        public void LoadttSachct(string name)
        {
            int index = 0;
            var result = from sct in sachctsv.GetAllSachctsv()
                         join nxb in Nxbsv.GetAllNXBsv() on sct.Idnxb equals nxb.Id
                         join s in sachsv.FindName(name) on sct.Idsach equals s.Id
                         select new
                         {
                             sct.Id,
                             STT = ++index,
                             sct.MaSachCt,
                             s.TieuDe,
                             sct.HinhAnh,
                             sct.SoLuong,
                             sct.Tap,
                             sct.SoTrang,
                             sct.GiaBan,
                             nxb.TenNxb,
                             sct.TenTheLoai,
                         };

            dgvDanhSachct.DataSource = result.ToList();
            dgvDanhSachct.Columns[0].Visible = false;
            dgvDanhSachct.Columns[1].HeaderText = "STT";
            dgvDanhSachct.Columns[2].HeaderText = "Mã sách";
            dgvDanhSachct.Columns[3].HeaderText = "Tiêu đề";
            dgvDanhSachct.Columns[4].HeaderText = "Hình ảnh";
            dgvDanhSachct.Columns[5].HeaderText = "Số lượng";
            dgvDanhSachct.Columns[6].HeaderText = "Tập";
            dgvDanhSachct.Columns[7].HeaderText = "Số trang";
            dgvDanhSachct.Columns[8].HeaderText = "Giá bán";
            dgvDanhSachct.Columns[9].HeaderText = "Tên nhà XB";
            dgvDanhSachct.Columns[10].HeaderText = "Tên thể loại";




            var loadnxb = Nxbsv.GetAllNXBsv().ToList();
            cboNxb.DataSource = loadnxb;
            cboNxb.DisplayMember = "TenNxb";
            cboNxb.ValueMember = "Id";

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvDanhSachct.Columns[4];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        private void txtTimKiemkh_TextChanged(object sender, EventArgs e)
        {
            LoadttSachct(txtTimKiemkh.Text);
        }
        private void SanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgvDanhSachSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvDanhSachSach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                // Lấy giá trị của cell được double-click
                string cellValue = dgvDanhSachSach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // Hiển thị giá trị của cell lên TextBox trên TabControl2
                txtMaSach.Text = cellValue;

                // Chuyển sang TabControl2
                tabControl1.SelectedIndex = 1; // Giả sử TabControl2 có index là 1
            }
        }
    }
}
