using finalproject.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalproject
{
    public partial class FLogin : Form
    {
        BUS_Login busLogin;
        public FLogin()
        {
            busLogin = new BUS_Login();
            InitializeComponent();
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String userName = txtTaiKhoan.Text;
            String password = txtMatKhau.Text;
            
            if (userName.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tài khoản", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaiKhoan.Focus();
            }
            else if(password.Length == 0 ) {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
            }
            else
            {
                if (busLogin.Login(userName, password) == true)
                {
                    this.Hide();
                    MessageBox.Show("Bạn đã đăng nhập thành công", "Congratulation", MessageBoxButtons.OK);
                    FQuanli f = new FQuanli();
                }
                else
                {
                    MessageBox.Show("Bạn đã đăng nhập thất bại hoặc không hợp lệ !!", "Warning", MessageBoxButtons.OK);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình hay không ??", "Đóng chương trình", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }   
                
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRegister f = new FRegister();
            f.ShowDialog();
        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
