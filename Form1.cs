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

        int number = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            radCong.Checked = true; //đầu tiên chọn phép cộng
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
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

        private void btnTinh_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            try
            {
                double so1, so2, kq = 0;
                string txt1, txt2;
                txt1 = txtSo1.Text;
                txt2 = txtSo2.Text;


                // check length of text
                if(txt1.Length <= 9 && txt2.Length <= 9)
                {
                    so1 = double.Parse(txtSo1.Text);
                    so2 = double.Parse(txtSo2.Text);
                    //Thực hiện phép tính dựa vào phép toán được chọn

                    if (radCong.Checked) kq = so1 + so2;
                    else if (radTru.Checked) kq = so1 - so2;
                    else if (radNhan.Checked) kq = so1 * so2;
                    else if (radChia.Checked)
                    {
                        if(so2 == 0)
                        {
                            txtSo2.Focus();

                            dr = MessageBox.Show("Số không chính xác! Vui lòng nhập lai",
                                     "Thông báo", MessageBoxButtons.OK);
                        } else
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
            catch {
                DialogResult dd;
                dd = MessageBox.Show("Error",
                                     "Thông báo", MessageBoxButtons.OK);
                
            }
        }

        // Check focus when it empty and check character is number
        private void txtSo2_TextChanged(object sender, EventArgs e)
        {
            DialogResult dr;

            Regex RgxUrl = new Regex("^[0-9]");


            if (txtSo2.Text.Length == 0)
            {
                dr = MessageBox.Show("Không được phép để trống",
                                    "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                 
                if (!RgxUrl.IsMatch(txtSo2.Text))
                {
                    dr = MessageBox.Show("Kí tự không hợp lệ, vui lòng nhập lai",
                                    "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void txtSo1_TextChanged_1(object sender, EventArgs e)
        {
            DialogResult dr;


            Regex RgxUrl = new Regex("^[0-9]");

            if (txtSo1.Text.Length == 0)
            {
                if (number != 0)
                    dr = MessageBox.Show("Không được phép để trống",
                                    "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                number++;
                if (!RgxUrl.IsMatch(txtSo1.Text))
                {
                    dr = MessageBox.Show("Kí tự không hợp lệ, vui lòng nhập lai",
                                    "Thông báo", MessageBoxButtons.OK);

                }
            }
        }
    }
}
