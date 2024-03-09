using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testtttt;

namespace ExaminationSystem
{
    public partial class StudentForm : Form
    {
        ExaminationSystemEntities eSystem = new ExaminationSystemEntities();
        private bool isClick = false;
        private Student currentStudent;
        public StudentForm(Student student)
        {
            InitializeComponent();
            lblStudentName.Text = student.StudentName;
            currentStudent = student;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            studentTabControl.Visible = false;
        }

        private void activeButton(Button btnEnable, Button btnDisable1, Button btnDisable2, int tabControlIndex)
        {
            isClick = !isClick;
            if (isClick)
            {
                studentTabControl.Visible = true;
                studentTabControl.SelectedIndex = tabControlIndex;
                btnEnable.BackColor = SystemColors.Control;
                btnEnable.ForeColor = Color.Black;
                btnDisable1.BackColor = SystemColors.Highlight;
                btnDisable1.ForeColor = SystemColors.Control;
                btnDisable2.BackColor = SystemColors.Highlight;
                btnDisable2.ForeColor = SystemColors.Control;
                isClick = !isClick;
            }

        }

        private void removeCourseColumns(DataGridView dataGridViewCourse)
        {
            dataGridViewCourse.Columns["ClassID"].Visible = false;
            dataGridViewCourse.Columns["Class"].Visible = false;
            dataGridViewCourse.Columns["Enrollments"].Visible = false;
            dataGridViewCourse.Columns["Topics"].Visible = false;
            dataGridViewCourse.Columns["CourseID"].Visible = false;
            int width = dataGridViewCourse.Width;
            dataGridViewCourse.Columns["CourseName"].Width = width;
        }

        private void btnStudentExam_Click(object sender, EventArgs e)
        {
            activeButton(btnStudentExam, btnStudentInfor, btnResult, 0);
            var courses = eSystem.Courses.Where(x => x.ClassID == currentStudent.ClassID).ToList();
            var enrolledCourses = courses.Where(course => eSystem.Enrollments
                                    .Any(enrollment => enrollment.CourseID == course.CourseID)).ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = enrolledCourses;
            dgvStudentCourses.DataSource = bindingSource;
            removeCourseColumns(dgvStudentCourses);
        }

        private void loadDataExams(DataGridView dgv, List<Exam> examList)
        {
            dgv.DataSource = null;
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = examList;
            dgv.DataSource = bindingSource;
            removeColumnsExams(dgvStudentExams);
        }

        private void removeColumnsExams(DataGridView dgv)
        {
            dgv.Columns["ExamID"].Width = 0;
            dgv.Columns["MarkPerQuestion"].Visible = false;
            dgv.Columns["ExamEnrollments"].Visible = false;
            dgv.Columns["QuestionInExams"].Visible = false;
            dgv.Columns["StudentRespones"].Visible = false;
        }

        private void dgvStudentCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStudentCourses.CurrentRow.Index >= dgvStudentCourses.Rows.Count - 1) return;
            int rowIndex = dgvStudentCourses.CurrentRow.Index;
            string courseID = dgvStudentCourses.Rows[rowIndex].Cells["CourseID"].Value.ToString();
            var findCourse = eSystem.Courses.Find(courseID);
            int databaseIndex = 0;

            if (findCourse != null)
            {
                databaseIndex = eSystem.Courses.Local.IndexOf(findCourse);
            }


            var examsForCourse = eSystem.Courses
                                .Where(course => course.CourseID == courseID)
                                .SelectMany(course => course.Topics)
                                .SelectMany(topic => topic.Questions)
                                .SelectMany(question => question.QuestionInExams)
                                .Select(qie => qie.Exam)
                                .Distinct()
                                .ToList();


            loadDataExams(dgvStudentExams, examsForCourse);
            if (!dgvStudentExams.Columns.Contains("Function"))
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.Name = "Function";
                //btnColumn.HeaderText = "Function";
                dgvStudentExams.Columns.Add(btnColumn);
            }
            foreach (DataGridViewRow row in dgvStudentExams.Rows)
            {

                string examID = row.Cells["ExamID"].Value.ToString();
                var isEnrollmentExam = eSystem.ExamEnrollments
                .Where(x => x.StudentUserName == currentStudent.StudentUserName && x.ExamID == examID).ToList();
                if (isEnrollmentExam.Count <= 0)
                {
                   row.Cells["Function"].Value = "Enroll";
                }else
                {
                    RemoveButtonFromCell(row.Cells["Function"]);
                    row.Cells["Function"].Value = "Done";
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.ForeColor = Color.Blue;
                    style.Font = new Font("Sans-Seriff", 10, FontStyle.Italic);
                    row.Cells["Function"].Style = style;
                }
            }
        }

        private void RemoveButtonFromCell(DataGridViewCell cell)
        {
            DataGridViewTextBoxCell textCell = new DataGridViewTextBoxCell();

            cell.OwningRow.Cells[cell.ColumnIndex] = textCell;
        }

        private void dgvStudentExams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && dgvStudentExams.Columns[e.ColumnIndex].Name == "Function")
            {
                string examID = dgvStudentExams.Rows[dgvStudentExams.CurrentRow.Index].Cells["ExamID"].Value.ToString();
                var findExam = eSystem.Exams.FirstOrDefault(x => x.ExamID == examID);
                var isEnrollment = eSystem.ExamEnrollments.FirstOrDefault(x => x.ExamID == examID);
                if (isEnrollment != null)
                {
                    return;
                }
                var result = MessageBox.Show("Bạn muốn làm bài kiểm tra?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                   
                    ExamForm examForm = new ExamForm(currentStudent, findExam);
                    examForm.Show();
                    examForm.FormClosed += ExamForm_FormClosed;
                }
                else
                {
                    return;
                }
            }
        }

        private void ExamForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Update the DataGridView after the ExamForm is closed
            if (dgvStudentCourses.CurrentRow.Index >= dgvStudentCourses.Rows.Count - 1) return;
            int rowIndex = dgvStudentCourses.CurrentRow.Index;
            string courseID = dgvStudentCourses.Rows[rowIndex].Cells["CourseID"].Value.ToString();
            var findCourse = eSystem.Courses.Find(courseID);
            int databaseIndex = 0;

            if (findCourse != null)
            {
                databaseIndex = eSystem.Courses.Local.IndexOf(findCourse);
            }


            var examsForCourse = eSystem.Courses
                                .Where(course => course.CourseID == courseID)
                                .SelectMany(course => course.Topics)
                                .SelectMany(topic => topic.Questions)
                                .SelectMany(question => question.QuestionInExams)
                                .Select(qie => qie.Exam)
                                .Distinct()
                                .ToList();
            dgvStudentExams.DataSource = null;
            loadDataExams(dgvStudentExams, examsForCourse);
            int rowIndex1 = dgvStudentCourses.CurrentRow.Index;
            int columnIndex1 = 0; 

            dgvStudentCourses_CellClick(dgvStudentCourses, new DataGridViewCellEventArgs(columnIndex1, rowIndex1));
        }

        private void btnStudentInfor_Click(object sender, EventArgs e)
        {
            activeButton(btnStudentInfor, btnStudentExam, btnResult, -1);
            StudentForm1 std1 = new StudentForm1(currentStudent);
            std1.Show();
        }


        private void btnResult_Click(object sender, EventArgs e)
        {
            activeButton(btnResult, btnStudentExam, btnStudentInfor, 1);
            DangKiDangNhap.ExamResult examResult = new DangKiDangNhap.ExamResult(currentStudent);
            examResult.Show();
        }

        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
