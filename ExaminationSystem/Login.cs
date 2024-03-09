using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSystem
{
    public partial class LoginForm : Form
    {
        ExaminationSystemEntities eSystem = new ExaminationSystemEntities();
        public LoginForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void cBoxRoleSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxRoleSelect.SelectedIndex == 0)
            {
                panelStudentLogin.Visible = false;
                PanelAdminLogin.Visible = true;
            }else
            {
                panelStudentLogin.Visible = true;
                PanelAdminLogin.Visible = false;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            panelStudentLogin.Visible = false;
            PanelAdminLogin.Visible = false;
            txtLoginPasswordStudent.PasswordChar = '\u25CF';
            txtAdminPassword.PasswordChar = '\u25CF';
        }

        private void btnStudentRegister_Click(object sender, EventArgs e)
        {
            StudentRegisterForm stdRegisterForm = new StudentRegisterForm();
            stdRegisterForm.ShowDialog();
        }

        private void chkBoxLoginShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxLoginShowPassword.Checked)
            {
                txtLoginPasswordStudent.PasswordChar = '\0';
            } else
            {
                txtLoginPasswordStudent.PasswordChar = '\u25CF';
            }
        }

        private void btnStudentLogin_Click(object sender, EventArgs e)
        {
            string studentUserName = txtLoginStudentUserName.Text.ToLower();
            string studentPassword = txtLoginPasswordStudent.Text;
            byte[] salt = new byte[128 / 8];
            string hashPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: studentPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 1000,
                numBytesRequested: (256 / 8)
                )) ;
            var isStudent= eSystem.Students.FirstOrDefault(x => x.StudentUserName == studentUserName && x.StudentPassword == hashPassword);
            if (isStudent == null)
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng");
                return; 
            }
            MessageBox.Show("Đăng nhập thành công");
            StudentForm stdForm = new StudentForm(isStudent);
            stdForm.Show();
            this.Hide();

        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            string adminUserName = txtAdminUserName.Text;
            string adminPassWord = txtAdminPassword.Text;

            if (string.IsNullOrEmpty(adminUserName) || string.IsNullOrWhiteSpace(adminUserName)
                || string.IsNullOrEmpty(adminPassWord) || string.IsNullOrWhiteSpace(adminPassWord))
            {
                MessageBox.Show("Thông tin đăng nhập không được để trống");
            }

            var isAdmin = eSystem.Administrators.FirstOrDefault(x => x.AdminUserName == adminUserName && x.AdminPassword == adminPassWord);
            if (isAdmin == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, hãy thử lại");
                return;
            } else
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                Admin adminForm = new Admin();
                adminForm.Show();
            }

        }

        private void chkBoxAdminShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxAdminShowPassword.Checked)
            {
                txtAdminPassword.PasswordChar = '\0';
            } else
            {
                txtAdminPassword.PasswordChar = '\u25CF';
            }
        }
    }
}
