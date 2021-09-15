using finalproject.BUS;
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

namespace finalproject
{
    public partial class FRegister : Form
    {
        BUS_Login busLogin;
        public FRegister()
        {
            busLogin = new BUS_Login();
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLogin f = new FLogin();
            f.ShowDialog();
        }

        private void reset()
        {
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            txtConfirmPassword.Text = "";
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Enter an email.");
                txtEmail.Focus();
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Enter a valid email.");
                txtEmail.Select(0, txtEmail.Text.Length);
                txtEmail.Focus();
            }
            else
            {
                string firstname = txtFirstName.Text;
                string lastname = txtLastName.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                if (txtPassword.Text.Length == 0)
                {
                    txtPassword.Text = "Enter password.";
                    txtPassword.Focus();
                }
                else if (txtUsername.Text.Length == 0 && txtUsername.Text.Length < 0 || txtUsername.Text.Length > 10)
                {
                    MessageBox.Show("Enter Valid Username.");
                    txtPassword.Focus();
                }
                else if (txtConfirmPassword.Text.Length == 0)
                {
                    MessageBox.Show("Enter Confirm password.");
                    txtConfirmPassword.Focus();
                }
                else if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Confirm password must be same as password");
                    txtPassword.Focus();
                }
                else
                {
                    User user = new User();
                    user.FirstName = txtFirstName.Text;
                    user.LastName = txtLastName.Text;
                    user.Username = txtUsername.Text;
                    user.Password = txtPassword.Text;
                    user.Email = txtEmail.Text;
                    if (busLogin.Resgister(user))
                    {
                        MessageBox.Show("You have Registered successfully", "Chúc mừng");
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("You have Registered badly", "Thất bại");
                    }

                    
                }
            }
        }
    }
}
