using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab02_3
{
    public partial class QLChieuPhim : Form
    {
        private List<Button> chonGhe = new List<Button>();
        private double tongTien = 0;

        public QLChieuPhim()
        {
            InitializeComponent();
            foreach (Control control in grpChieuPhim.Controls)
            {
                if (control is Button button)
                {
                    button.Click += Button_Click;
                    button.BackColor = Color.White;
                }
            }
            btnChon.Click += btnChon_Click;
            btnHuy.Click += btnHuy_Click;
            btnKetThuc.Click += btnKetThuc_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button ghe = (Button)sender;
            int soGhe = Convert.ToInt32(ghe.Text);

            if (ghe.BackColor == Color.Yellow)
            {
                MessageBox.Show($"Ghế số {soGhe} đã được bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (ghe.BackColor == Color.Green)
            {
                ghe.BackColor = Color.White; 
                chonGhe.Remove(ghe); 
            }
            else
            {
                ghe.BackColor = Color.Green; 
                chonGhe.Add(ghe);
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            tongTien = 0;

            foreach (var seat in chonGhe)
            {
                seat.BackColor = Color.Yellow; // Đổi màu ghế đã chọn thành màu vàng
                tongTien += TinhTien(Convert.ToInt32(seat.Text));
            }

            chonGhe.Clear();
            txtTien.Text = $"{tongTien}đ"; // Hiển thị tổng tiền
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            foreach (var seat in chonGhe)
            {
                seat.BackColor = Color.White; // Đổi màu các ghế trở lại màu trắng
            }

            chonGhe.Clear();
            txtTien.Text = "0đ"; // Đặt lại tổng tiền là 0
        }

        private int TinhTien(int seatNumber)
        {
            if (seatNumber >= 1 && seatNumber <= 5) 
                return 30000;
            if (seatNumber >= 6 && seatNumber <= 10)
                return 40000;
            if (seatNumber >= 11 && seatNumber <= 15)
                return 50000;
            return 80000; // seatNumber từ 16 - 20
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
