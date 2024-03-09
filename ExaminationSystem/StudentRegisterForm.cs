using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ExaminationSystem
{
    public partial class StudentRegisterForm : Form
    {
        public static ExaminationSystemEntities eSystem = new ExaminationSystemEntities();
        List<Class> classList = new List<Class>();

        public StudentRegisterForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void StudentRegisterForm_Load(object sender, EventArgs e)
        {
            cBoxClassRegister.DataSource = eSystem.Classes.ToList();
            cBoxClassRegister.DisplayMember = "ClassName";
            txtStudentPassword.PasswordChar = '\u25CF';
            txtPasswordCheck.PasswordChar = '\u25CF';
            
        }

        private void btnRegisterNewStudent_Click(object sender, EventArgs e)
        {
            if (cBoxClassRegister.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn lớp học");
                return;
            }
            try
            {
                string userName = txtStudentUserName.Text.ToLower();
                string password = txtStudentPassword.Text;
                string passwordCheck = txtPasswordCheck.Text;
                string studentName = txtStudentFullName.Text;
                string studentAddress = txtStudentAddress.Text;
                string className = cBoxClassRegister.Text;
                string classID = null;
               
                var selectClassID = eSystem.Classes.Where(x => x.ClassName == className).Select(y => new { classID = y.ClassID });
                    foreach (var item in selectClassID)
                    {
                        classID = item.classID;
                    }
                if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName)
                    || string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password)
                    || string.IsNullOrEmpty(passwordCheck) || string.IsNullOrWhiteSpace(passwordCheck)
    )
                {
                    MessageBox.Show("Không được để trống thông tin ở các trường bắt buộc");
                    return;
                }
                if (password != passwordCheck)
                {
                    MessageBox.Show("Mật khẩu không trùng nhau, hãy kiểm tra lại");
                    return;
                }
            List<Student> selectDuplicate = eSystem.Students.Where(x => x.StudentUserName == userName).ToList();
            if (selectDuplicate.Count() > 0)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại, vui lòng chọn tên khác");
                    return;
                }
            
                byte[] salt = new byte[128/8]; // divide by 8 to convert bits to bytes
                string hashPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password : password,
                    salt : salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 1000,
                    numBytesRequested: (256/8)
                    ));

                var student = new Student
                {
                    StudentUserName = userName.ToLower(),
                    StudentPassword = hashPassword,
                    StudentName = studentName,
                    StudentAddress = studentAddress,
                    ClassID = classID
                };

                    eSystem.Students.Add(student);
                    int check = eSystem.SaveChanges();
                    if (check > 0)
                    {
                        var result = MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK);
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký không thành công, hãy thử lại");
                    }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, hãy thử lại\n" + ex.Message);
                
            }
}

        private void chkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxShowPassword.Checked)
            {
                txtStudentPassword.PasswordChar = '\0';
            }
            else
            {
                txtStudentPassword.PasswordChar = '\u25CF';
            }
        }

        private void chkBoxShowPassword1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxShowPassword1.Checked)
            {
                txtPasswordCheck.PasswordChar = '\0';
            }
            else
            {
                txtPasswordCheck.PasswordChar = '\u25CF';
            }
        }
    }
}
