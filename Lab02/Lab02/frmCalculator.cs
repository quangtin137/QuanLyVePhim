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
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            try
            {
                var number1 = double.Parse(txtNumber1.Text);
                var number2 = double.Parse(txtNumber2.Text);
                double result = number1 + number2;
                txtResult.Text = result.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            try
            {
                var number1 = double.Parse(txtNumber1.Text);
                var number2 = double.Parse(txtNumber2.Text);
                double result = number1 - number2;
                txtResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            try
            {
                var number1 = double.Parse(txtNumber1.Text);
                var number2 = double.Parse(txtNumber2.Text);
                double result = number1 * number2;
                txtResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            try
            {
                var number1 = double.Parse(txtNumber1.Text);
                var number2 = double.Parse(txtNumber2.Text);
                double result = Math.Round((double) number1 / number2, 2);
                txtResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
