using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_4
{
    public partial class QLThongTinTK : Form
    {
        public QLThongTinTK()
        {
            InitializeComponent();
        }

        public int TimDongChuaNV(string maNV)
        {
            if (ltvTaiKhoan != null && ltvTaiKhoan.Items.Count > 0)
            {
                for (int i = 0; i < ltvTaiKhoan.Items.Count; i++)
                {
                    if (ltvTaiKhoan.Items[i].SubItems[0].Text == maNV)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            string maSTK = txtSTK.Text;
            string ten = txtTenKH.Text;
            string diaChi = txtDiaChi.Text;
            string sotien = txtSoTien.Text;
            int dongNV = TimDongChuaNV(maSTK);

            if (string.IsNullOrWhiteSpace(maSTK) || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(sotien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dongNV == -1) // Nếu không tìm thấy thì thêm mới
            {
                foreach (ListViewItem item in ltvTaiKhoan.Items)
                {
                    if (item.SubItems[1].Text == maSTK) // Cột 1 là MaSTK
                    {
                        MessageBox.Show("Mã STK đã tồn tại, vui lòng nhập mã khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                ListViewItem newitem = new ListViewItem((ltvTaiKhoan.Items.Count + 1).ToString()); // STT
                newitem.SubItems.Add(maSTK);
                newitem.SubItems.Add(ten);
                newitem.SubItems.Add(diaChi);
                newitem.SubItems.Add(sotien);

                ltvTaiKhoan.Items.Add(newitem); // lstSinhVien là tên của ListView
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TongTien();
                Reset();
            }
            else // Nếu tìm thấy thì sửa
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn sửa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ListViewItem item = ltvTaiKhoan.Items[dongNV];
                    item.SubItems[1].Text = maSTK;
                    item.SubItems[2].Text = ten;
                    item.SubItems[3].Text = diaChi;
                    item.SubItems[4].Text = sotien;

                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TongTien();
                    Reset();
                }
            }
            for (int i = 0; i < ltvTaiKhoan.Items.Count; i++)
            {
                ltvTaiKhoan.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSTK = txtSTK.Text;
            string ten = txtTenKH.Text;
            string diaChi = txtDiaChi.Text;
            string sotien = txtSoTien.Text;
            int dongNV = TimDongChuaNV(maSTK);

            

            // Tìm mục có mã sinh viên
            ListViewItem itemToRemove = null;
            foreach (ListViewItem item in ltvTaiKhoan.Items)
            {
                if (item.SubItems[1].Text == maSTK) // Giả sử cột 1 là Mã SV
                {
                    itemToRemove = item;
                    break;
                }
            }

            if (itemToRemove != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ltvTaiKhoan.Items.Remove(itemToRemove);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TongTien();

                    // Cập nhật lại STT cho tất cả các mục trong ListView
                    for (int i = 0; i < ltvTaiKhoan.Items.Count; i++)
                    {
                        ltvTaiKhoan.Items[i].SubItems[0].Text = (i + 1).ToString(); // Cập nhật STT
                    }
                }
            }
            else
            {
                MessageBox.Show("Sinh viên không tồn tại", "Lỗi!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Reset();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Reset()
        {
            txtSTK.ResetText();
            txtTenKH.ResetText();
            txtDiaChi.ResetText();
            txtSoTien.ResetText();
        }

        private void ltvTaiKhoan_Click(object sender, EventArgs e)
        {
            if (ltvTaiKhoan.SelectedItems.Count > 0)
            {
                ListViewItem item = ltvTaiKhoan.SelectedItems[0];
                txtSTK.Text = item.SubItems[1].Text;
                txtTenKH.Text = item.SubItems[2].Text;
                txtDiaChi.Text = item.SubItems[3].Text;
                txtSoTien.Text = item.SubItems[4].Text;
            }
        }

        private void TongTien()
        {
            decimal tongTien = 0;

            foreach (ListViewItem item in ltvTaiKhoan.Items)
            {
                if (decimal.TryParse(item.SubItems[4].Text, out decimal soTien)) // Giả sử cột 4 là Số tiền
                {
                    tongTien += soTien;
                }
            }

            // Hiển thị tổng tiền trong TextBox
            txtTongTien.Text = tongTien.ToString("N0"); // Hiển thị theo định dạng số
        }

    }
}
