using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02
{
    public partial class QLThongTinSV : Form
    {
        public QLThongTinSV()
        {
            InitializeComponent();
        }

        private void QLThongTinSV_Load(object sender, EventArgs e)
        {
            cmbChuyenNganh.SelectedIndex = 0;
            rdoNam.Checked = true;
        }

        public int TimDongChuaSV(string maSV)
        {
            for (int i = 0; i < drgSinhVien.Rows.Count; i++)
            {
                if (drgSinhVien.Rows[i].Cells[0].Value.ToString() == maSV)
                {
                    return i; //dòng nhân viên tìm thấy
                }
            }
            return -1; //Không tìm thấy nhân viên
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text;
            string ten = txtHoTen.Text;
            string gioitinh = rdoNam.Checked ? "Nam" : "Nữ";
            string dtb = txtDTB.Text;
            string chuyennganh = cmbChuyenNganh.Text;
            int dongSV = TimDongChuaSV(maSV);
            if (dongSV == -1)
            {
                drgSinhVien.Rows.Add(maSV, ten, gioitinh, dtb, chuyennganh);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn sửa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    drgSinhVien.Rows[dongSV].Cells[1].Value = ten;
                    drgSinhVien.Rows[dongSV].Cells[2].Value = gioitinh;
                    drgSinhVien.Rows[dongSV].Cells[3].Value = dtb;
                    drgSinhVien.Rows[dongSV].Cells[4].Value = chuyennganh;
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            CountNamNu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text;
            string ten = txtHoTen.Text;
            string gioitinh = rdoNam.Checked ? "Nam" : "Nữ";
            string dtb = txtDTB.Text;
            string chuyennganh = cmbChuyenNganh.Text;
            int dongSV = TimDongChuaSV(maSV);
            try
            {
                if (maSV == "" || ten == "" || dtb == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin sinh viên!!");
                }

                if (dongSV != -1)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn sửa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        drgSinhVien.Rows.RemoveAt(dongSV);
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Nhân viên đã tồn tại", "Lỗi!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CountNamNu();
        }

        void Reset()
        {
            txtHoTen.ResetText();
            txtMaSV.ResetText();
            rdoNam.Checked = true;
            txtDTB.ResetText();
        }

        private void drgSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = drgSinhVien.Rows[e.RowIndex];
            txtMaSV.Text = Convert.ToString(row.Cells[0].Value);
            txtHoTen.Text = Convert.ToString(row.Cells[1].Value);
            rdoNam.Text = Convert.ToString(row.Cells[2].Value);
            txtDTB.Text = Convert.ToString(row.Cells[3].Value);
            cmbChuyenNganh.Text = Convert.ToString(row.Cells[4].Value);
        }

        private void CountNamNu()
        {
            int countNam = 0;
            int countNu = 0;
            for (int i = 0; i < drgSinhVien.Rows.Count; i++)
            {
                var countGt = drgSinhVien.Rows[i].Cells[2].Value;
                if (countGt != null && countGt.ToString() == "Nam")
                    countNam++;
                else if (countGt != null && countGt.ToString() == "Nữ")
                    countNu++;
            }
            txtCountNam.Text = countNam.ToString();
            txtCountNu.Text = countNu.ToString();
        }
    }
}
