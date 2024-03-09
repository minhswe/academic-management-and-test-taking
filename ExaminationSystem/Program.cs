
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testtttt;

namespace ExaminationSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());
            Application.Run(new Admin());

            // Input to test
            //ExaminationSystemEntities eSystem = new ExaminationSystemEntities();
            //var student = eSystem.Students.FirstOrDefault(x => x.StudentUserName == "quangminh");
            //var exam = eSystem.Exams.FirstOrDefault(x => x.ExamID == "23CSM111");

            //input to test
            //Application.Run(new StudentForm(student));
            //Application.Run(new StudentForm1(student));
            //Application.Run(new ExamForm(student, exam));

            //methodTest test = new methodTest(); 
            //test.calculateScore1("23CSM1C16");

            //Application.Run(new DangKiDangNhap.ExamResult(student));
        }
    }
}
