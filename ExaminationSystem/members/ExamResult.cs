using ExaminationSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DangKiDangNhap
{
    public partial class ExamResult : Form
    {
        
        private ExaminationSystemEntities db = new ExaminationSystemEntities();
        private Student currentUser;

        public ExamResult(Student user)
        {
            InitializeComponent();
            currentUser = user;

        }

        private void dtagridviewExam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedExamID = dtagridviewExam.Rows[e.RowIndex].Cells["ExamID"].Value.ToString();

                var questionsAndAnswers = db.StudentRespones
                    .Where(sr => sr.StudentUserName == currentUser.StudentUserName && sr.ExamID == selectedExamID)
                    .Select(sr => new
                    {
                        QuestionContent = sr.Question.QuestionContent,
                        StudentAnswer = sr.ResponeChoice,
                        CorrectAnswers = sr.Question.QuestionCorrectAnswers.Select(qca => qca.CorrectChoice)
                    })
                    .AsEnumerable()
                    .Select(sr => new
                    {
                        sr.QuestionContent,
                        sr.StudentAnswer,
                        CorrectAnswer = string.Join(",", sr.CorrectAnswers)
                    })
                    .ToList();


                dtagridviewCauHoi.DataSource = questionsAndAnswers;

                foreach (DataGridViewRow row in dtagridviewCauHoi.Rows)
                {
                    string studentAnswer = row.Cells["StudentAnswer"].Value.ToString();
                    string correctAnswer = row.Cells["CorrectAnswer"].Value.ToString();

                    if (studentAnswer == correctAnswer)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                }

                dtagridviewCauHoi.Columns["QuestionContent"].HeaderText = "Câu Hỏi";
                dtagridviewCauHoi.Columns["StudentAnswer"].HeaderText = "Đáp Án Sinh Viên";
                dtagridviewCauHoi.Columns["CorrectAnswer"].HeaderText = "Đáp Án Đúng";

                int width = dtagridviewCauHoi.Width;
                dtagridviewCauHoi.Columns[0].Width = 65 * width / 100;
                dtagridviewCauHoi.Columns[1].Width = 15 * width / 100;
                dtagridviewCauHoi.Columns[2].Width = 15 * width / 100;

            }
        }

        private void hienThiKetQua_Load(object sender, EventArgs e)
        {
            var studentExams = db.StudentRespones
            .Where(sr => sr.StudentUserName == currentUser.StudentUserName)
            .Select(sr => new
            {
                ExamID = sr.ExamID,
                ExamTitle = sr.Exam.ExamTitle,
            })
            .Distinct()
            .ToList();

            dtagridviewExam.DataSource = studentExams;

            dtagridviewExam.Columns["ExamID"].HeaderText = "Mã Đề Thi";
            dtagridviewExam.Columns["ExamTitle"].HeaderText = "Tên Đề Thi";


        }
    }
}
