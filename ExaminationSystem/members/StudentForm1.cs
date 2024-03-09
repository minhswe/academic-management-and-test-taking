using ExaminationSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testtttt
{
    public partial class StudentForm1 : Form
    {
        ExaminationSystemEntities db = new ExaminationSystemEntities();
        Student currentStudent = null;
        private List<string> selectedCourseIDs = new List<string>();
        private List<Cours> allCourses = new List<Cours>();
        public StudentForm1(Student student)
        {
            InitializeComponent();
            currentStudent = student;
            loadData();
            LoadRegisteredCourses();
            UpdateStudentInfo(currentStudent);
        }
        void loadData()
        {
            allCourses = db.Courses.ToList();
            dataGridViewCourse.Columns.Clear();

            string studentClassID = currentStudent.ClassID;
            var availableCourses = db.Courses
                .Where(course => course.ClassID == studentClassID)
                .ToList();

            var enrolledCourseIDs = db.Enrollments
                .Where(enrollment => enrollment.StudentUserName == currentStudent.StudentUserName)
                .Select(enrollment => enrollment.CourseID)
                .ToList();

            availableCourses = availableCourses
                .Where(course => !enrolledCourseIDs.Contains(course.CourseID))
                .ToList();

            dataGridViewCourse.AutoGenerateColumns = false;
            dataGridViewCourse.Columns.Add("CourseID", "Mã Môn Học");
            dataGridViewCourse.Columns["CourseID"].DataPropertyName = "CourseID";
            dataGridViewCourse.Columns["CourseID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCourse.Columns.Add("CourseName", "Tên Môn Học");
            dataGridViewCourse.Columns["CourseName"].DataPropertyName = "CourseName";
            dataGridViewCourse.Columns["CourseName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Hiển thị danh sách môn học theo yêu cầu
            dataGridViewCourse.DataSource = availableCourses;
        }
        void LoadRegisteredCourses()
        {
            dataGridViewRegisteredCourses.Columns.Clear();

            var registeredCourses = db.Enrollments
                .Where(enrollment => enrollment.StudentUserName == currentStudent.StudentUserName)
                .Join(db.Courses,
                      enrollment => enrollment.CourseID,
                      course => course.CourseID,
                      (enrollment, course) => new { CourseID = course.CourseID, CourseName = course.CourseName })
                .ToList();

            dataGridViewRegisteredCourses.AutoGenerateColumns = false;
            dataGridViewRegisteredCourses.Columns.Add("CourseID", "Mã Môn Học");
            dataGridViewRegisteredCourses.Columns["CourseID"].DataPropertyName = "CourseID";
            dataGridViewRegisteredCourses.Columns["CourseID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRegisteredCourses.Columns.Add("CourseName", "Tên Môn Học");
            dataGridViewRegisteredCourses.Columns["CourseName"].DataPropertyName = "CourseName";
            dataGridViewRegisteredCourses.Columns["CourseName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewRegisteredCourses.DataSource = registeredCourses;
            //Controls.Add(dataGridViewRegisteredCourses);
            dataGridViewRegisteredCourses.Size = dataGridViewCourse.Size;
        }

        private void dataGridViewCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string selectedCourseID = dataGridViewCourse.Rows[e.RowIndex].Cells["CourseID"].Value.ToString();

                if (selectedCourseIDs.Contains(selectedCourseID))
                {
                    selectedCourseIDs.Remove(selectedCourseID);
                    dataGridViewCourse.Rows[e.RowIndex].Cells["CourseID"].Style.BackColor = Color.White;
                }
                else
                {
                    selectedCourseIDs.Add(selectedCourseID);
                    dataGridViewCourse.Rows[e.RowIndex].Cells["CourseID"].Style.BackColor = Color.Yellow;
                }
            }
        }

        private void dataGridViewRegisteredCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string selectedCourseID = dataGridViewRegisteredCourses.Rows[e.RowIndex].Cells["CourseID"].Value.ToString();

                if (selectedCourseIDs.Contains(selectedCourseID))
                {
                    selectedCourseIDs.Remove(selectedCourseID);
                    dataGridViewRegisteredCourses.Rows[e.RowIndex].Cells["CourseID"].Style.BackColor = Color.White;
                }
                else
                {
                    selectedCourseIDs.Add(selectedCourseID);
                    dataGridViewRegisteredCourses.Rows[e.RowIndex].Cells["CourseID"].Style.BackColor = Color.Yellow;
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (selectedCourseIDs.Count > 0)
            {
                foreach (string selectedCourseID in selectedCourseIDs)
                {
                    var existingEnrollment = db.Enrollments
                        .FirstOrDefault(enrollment => enrollment.StudentUserName == currentStudent.StudentUserName && enrollment.CourseID == selectedCourseID);

                    if (existingEnrollment != null)
                    {
                        MessageBox.Show("Bạn đã đăng ký khóa học này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newEnrollment = new Enrollment
                    {
                        CourseID = selectedCourseID,
                        StudentUserName = currentStudent.StudentUserName
                    };

                    db.Enrollments.Add(newEnrollment);
                }

                db.SaveChanges();

                MessageBox.Show("Đăng ký môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                LoadRegisteredCourses();

                selectedCourseIDs.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelCourse_Click(object sender, EventArgs e)
        {
            if (selectedCourseIDs.Count > 0)
            {
                foreach (string selectedCourseID in selectedCourseIDs)
                {
                    var existingEnrollment = db.Enrollments
                        .FirstOrDefault(enrollment => enrollment.StudentUserName == currentStudent.StudentUserName && enrollment.CourseID == selectedCourseID);

                    if (existingEnrollment == null)
                    {
                        MessageBox.Show("Môn học không tồn tại trong danh sách đã đăng ký.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var isAssessed = db.ExamEnrollments
                        .Any(examEnrollment => examEnrollment.StudentUserName == currentStudent.StudentUserName && examEnrollment.ExamID == selectedCourseID);

                    if (isAssessed)
                    {
                        MessageBox.Show("Môn học đã làm bài thi, không thể hủy đăng ký.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    db.Enrollments.Remove(existingEnrollment);
                }

                db.SaveChanges();

                MessageBox.Show("Hủy đăng ký môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                LoadRegisteredCourses();

                selectedCourseIDs.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học để hủy đăng ký.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UpdateStudentInfo(Student student)
        {
            if (student != null)
            {
                txtStudentName.ReadOnly = true;
                txtStudentClass.ReadOnly = true;
                txtStudentName.Text = student.StudentName;
                txtStudentClass.Text = student.ClassID;
            }
        }
        void SearchCourses(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                loadData();
                LoadRegisteredCourses();
            }
            else
            {
                var enrolledCourseIDs = db.Enrollments
                    .Where(enrollment => enrollment.StudentUserName == currentStudent.StudentUserName)
                    .Select(enrollment => enrollment.CourseID)
                    .ToList();

                var filteredCourses = allCourses
                    .Where(course => course.CourseName.ToLower().Contains(searchText.ToLower()) &&
                                     course.ClassID == currentStudent.ClassID &&
                                     !enrolledCourseIDs.Contains(course.CourseID))
                    .ToList();

                var registeredCourses = db.Enrollments
                    .Where(enrollment => enrollment.StudentUserName == currentStudent.StudentUserName)
                    .Join(db.Courses,
                          enrollment => enrollment.CourseID,
                          course => course.CourseID,
                          (enrollment, course) => new { CourseID = course.CourseID, CourseName = course.CourseName })
                    .ToList();

                dataGridViewCourse.DataSource = filteredCourses;
                dataGridViewRegisteredCourses.DataSource = registeredCourses;
                dataGridViewRegisteredCourses.Size = dataGridViewCourse.Size;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCourses(txtSearch.Text);
        }

        private void btnDangKyMon_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            currentStudent.StudentUserName = txtTenDangNhap.Text;
            currentStudent.StudentPassword = txtMatKhau.Text;
            currentStudent.StudentName = txtHoVaTen.Text;
            currentStudent.StudentAddress = txtDiaChi.Text;

            string newPassword = txtMatKhau.Text;

            string hashedPassword = HashPassword(newPassword);

            currentStudent.StudentPassword = hashedPassword;


            try
            {
                using (var db = new ExaminationSystemEntities())
                {
                    var userToUpdate = db.Students.FirstOrDefault(u => u.StudentUserName == currentStudent.StudentUserName);

                    if (userToUpdate != null)
                    {
                        if (txtMatKhau.Text != txtNhapLaiMatKhau.Text)
                        {
                            MessageBox.Show("Mật khẩu không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        userToUpdate.StudentPassword = hashedPassword;
                        userToUpdate.StudentName = currentStudent.StudentName;
                        userToUpdate.StudentAddress = currentStudent.StudentAddress;

                        db.SaveChanges();
                        MessageBox.Show("Thông tin đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy người dùng để cập nhật thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            gbDoiMatKhau.Visible = !gbDoiMatKhau.Visible;
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtMatKhau.Text))
            {
                txtNhapLaiMatKhau.Enabled = true;
                checkBoxShowXNPassword.Enabled = true;
                label7.Enabled = true;


            }
            else
            {
                txtNhapLaiMatKhau.Enabled = false;
                checkBoxShowXNPassword.Enabled = false;
                label7.Enabled = false;
                txtNhapLaiMatKhau.Text = string.Empty;
            }
        }

        private void checkBoxShowXNPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowXNPassword.Checked)
            {
                txtNhapLaiMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtNhapLaiMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = currentStudent.StudentUserName;
            txtHoVaTen.Text = currentStudent.StudentName;
            txtLop.Text = currentStudent.Class.ClassName;
            txtDiaChi.Text = currentStudent.StudentAddress;
            txtMatKhau.UseSystemPasswordChar = true;
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
            gbDoiMatKhau.Visible = false;
            txtNhapLaiMatKhau.Enabled = false;
            checkBoxShowXNPassword.Enabled = false;
            label7.Enabled = false;
        }
    }
}