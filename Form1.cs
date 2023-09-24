using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DialogResult dr;

        private void Form1_Load(object sender, EventArgs e)
        {
            radCong.Checked = true; //đầu tiên chọn phép cộng
            radCong.Checked = true;

            txtSo1.Text = txtSo2.Text = "0";

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
    
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        /*các sửa code
        cal3 = tăng kiểu dữ liệu = cal15 = cal29 
        cal5 = try - catch cho dấu mủ --------X
        cal14 = Try - catch nhập E --------X
        cal9 = thông bảo lỗi nhập = cal17 = cal23 --------X
        cal20 = chia cho 0 báo lỗi --------X
        cal28 = focus -> select all --------X
        */

        // Main function for calculate
        private void btnTinh_Click(object sender, EventArgs e)
        {
            if(txtSo1.Text.Length == 0 || txtSo2.Text.Length == 0)
            {
                if(txtSo1.Text.Length == 0)
                {
                    dr = MessageBox.Show("Số thứ nhất không được bỏ trống, vui lòng nhập lại",
                                        "Thông báo", MessageBoxButtons.OK);

                    txtSo1.Focus();
                }

                if(txtSo2.Text.Length == 0)
                {
                    dr = MessageBox.Show("Số thứ hai không được bỏ trống, vui lòng nhập lại",
                                        "Thông báo", MessageBoxButtons.OK);

                    txtSo2.Focus();

                }
            }

            else
            {
                try
                {
                    double so1, so2, kq = 0;
                    string txt1, txt2;
                    txt1 = txtSo1.Text;
                    txt2 = txtSo2.Text;


                    // check length of text
                    if (txt1.Length <= 9 && txt2.Length <= 9)
                    {
                        so1 = double.Parse(txtSo1.Text);
                        so2 = double.Parse(txtSo2.Text);
                        //Thực hiện phép tính dựa vào phép toán được chọn

                        if (radCong.Checked) kq = so1 + so2;
                        else if (radTru.Checked) kq = so1 - so2;
                        else if (radNhan.Checked) kq = so1 * so2;
                        else if (radChia.Checked)
                        {
                            if (so2 == 0)
                            {
                                txtSo2.Focus();

                                dr = MessageBox.Show("Không chia được cho 0. Vui lòng nhập lại!",
                                         "Thông báo", MessageBoxButtons.OK);
                            }
                            else
                            {
                                kq = so1 / so2;

                            }
                        }
                        //Hiển thị kết quả lên trên ô kết quả
                        txtKq.Text = kq.ToString();
                    }

                    /*else if (txt1.Length == 0 || txt2.Length == 0)
                    {
                        if (txt1.Length == 0)
                        {
                            txtSo1.Focus();

                        }
                    }*/
                }
                catch
                {

                    dr = MessageBox.Show("Error",
                                         "Thông báo", MessageBoxButtons.OK);

                }
            }
          
            
        }


        private void txtSo2_Click(object sender, EventArgs e)
        {
            txtSo2.SelectAll();
        }

        private void txtSo1_KeyPress(object sender, KeyPressEventArgs e)
        {

            // If Key is Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                if(txtSo1.Text.Length > 0)
                {
                    txtSo2.SelectAll();
                    txtSo2.Focus();
                }
            }
            else 
            {
                e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || (e.KeyChar == '.'));

                if (e.Handled == true)
                {
                    dr = MessageBox.Show("Kí tự không hợp lệ, vui lòng nhập lại",
                                        "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void txtSo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If Key is Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtSo2.Text.Length > 0)
                {
                    this.btnTinh_Click(sender,e);
                }
            }
            else
            {
                e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || (e.KeyChar == '.'));

                if (e.Handled == true)
                {
                    dr = MessageBox.Show("Kí tự không hợp lệ, vui lòng nhập lại",
                                        "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void txtSo1_Click(object sender, EventArgs e)
        {
            txtSo1.SelectAll();

        }
    }
}
