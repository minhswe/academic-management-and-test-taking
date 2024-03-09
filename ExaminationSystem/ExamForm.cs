using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ExaminationSystem
{
    public partial class ExamForm : Form
    {
        ExaminationSystemEntities eSystem = new ExaminationSystemEntities();

        private Student currentStudent;
        private Exam currentExam;

        private int currentQuestion = -1;
        private double studentScore = 0;

        private List<Question> questionList;

        private Dictionary<string, List<string>> selectedOptions = new Dictionary<string, List<string>>();

        private TimeSpan remainingTime;
        private System.Timers.Timer countdownTimer;

        private bool isSaveResult = false;


        public ExamForm(Student student, Exam exam)
        {
            InitializeComponent();
            currentStudent = student;
            currentExam = exam;
            this.CenterToScreen();
        }

        private void ExamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn thoát? Nếu bạn chưa nộp bài, tiến trình có thể sẽ không được lưu lại", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //StringBuilder message = new StringBuilder();
                //foreach (var pair in selectedOptions)
                //{
                //    message.AppendLine($"Question ID: {pair.Key}");
                //    message.AppendLine("Selected Options:");
                //    foreach (var option in pair.Value)
                //    {
                //        message.AppendLine(option);
                //    }
                //    message.AppendLine();
                //}

                //MessageBox.Show(message.ToString(), "Selected Options");

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnStartExam_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn đã sẵn sàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var addExamEnrollment = new ExamEnrollment()
                {
                    ExamID = currentExam.ExamID,
                    AttendDate = DateTime.Now.Date,
                    StudentUserName = currentStudent.StudentUserName
                };
                eSystem.ExamEnrollments.Add(addExamEnrollment);
                eSystem.SaveChanges();

                pExamMainScreen.SendToBack();
                pExamMainScreen.Visible = false;
                pExam.BringToFront();

                int examTimeInMinutes = (int)currentExam.examTime;
                remainingTime = TimeSpan.FromMinutes(examTimeInMinutes);
                countdownTimer = new System.Timers.Timer();
                countdownTimer.Interval = 1000;
                countdownTimer.Elapsed += CountdownTimer_Tick;
                countdownTimer.Start();

                for(int i = 0; i < questionList.Count(); i++)
                {
                    System.Windows.Forms.Button button = new System.Windows.Forms.Button();
                    button.Tag = i;
                    button.Text = (i + 1).ToString();
                    button.Height = 30;
                    button.Width = 30;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 1;
                    button.BackColor = SystemColors.Control;
                    button.Click += new EventHandler(buttonNavigation);
                    button.Name = "btnQuestion" + i;
                    flowPanelButton.Controls.Add(button);
                }


                pExam.Visible = true;
                btnQuestionNext.PerformClick();
            }
            else
            {
                return;
            }
        }

        private void buttonNavigation(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            int buttonIndex = int.Parse(button.Text);
            currentQuestion = buttonIndex - 1;
            
            string questionID = questionList[currentQuestion].QuestionID;

            List<string> selectedOptions = GetSelectedOptionForQuestion(questionID);
            unCheck();
            if (selectedOptions != null && selectedOptions.Any())
            {
                displaySelectedOption(questionID, selectedOptions);
            }
            else
            {
                displayCurrentQuestion();
                displayCurrentAnswer();
            }

        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (txtTimeLeft.InvokeRequired)
            { 
                txtTimeLeft.Invoke(new MethodInvoker(delegate
                {
                    UpdateTimerDisplay();
                }));
            }
            else
            {
                UpdateTimerDisplay();
            }
        }

        private void UpdateTimerDisplay()
        {
            remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));

            if (remainingTime.TotalMinutes <= 1)
            {
                txtTimeLeft.ForeColor = Color.Red;
            }

            if (remainingTime.TotalSeconds < 0)
            {
                countdownTimer.Stop();
                pResult.Visible = true;
                pResult.BringToFront();

                foreach (Control control in this.Controls)
                {
                    control.Enabled = false;
                }
                if (isSaveResult == false)
                {
                    foreach (var pair in selectedOptions)
                    {
                        calculateScore(pair.Key);
                    }
                    lblYourScore.Text = studentScore.ToString();
                    var updateMark = eSystem.ExamEnrollments.FirstOrDefault(x => x.ExamID == currentExam.ExamID);
                    if (updateMark != null)
                    {
                        updateMark.Mark = studentScore;
                    }
                    eSystem.SaveChanges();
                    isSaveResult = true;
                }
            }
            else
            {
                txtTimeLeft.Text = remainingTime.ToString(@"mm\:ss");
            }
        }

        private List<Question> shuffleQuestion(List<Question> questionList)
        {
            Random random = new Random();
            int n = questionList.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Question value = questionList[k];
                questionList[k] = questionList[n];
                questionList[n] = value;
            }
            return questionList;
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            pExamMainScreen.Visible = true;
            pExam.Visible = false;
            lblNumberOfQuestion.Text = currentExam.NumberOfQuestion.ToString() + " câu hỏi";
            lblExamTime.Text = currentExam.examTime.ToString() + " phút";
            lblExamTitle.Text = currentExam.ExamTitle;
            questionList = shuffleQuestion(questionForExam());


            radioBtnA.Visible = false;
            radioBtnB.Visible = false;
            radioBtnC.Visible = false;
            radioBtnD.Visible = false;
            radioBtnE.Visible = false;

            checkBoxA.Visible = false;
            checkBoxB.Visible = false;
            checkBoxC.Visible = false;
            checkBoxD.Visible = false;
            checkBoxE.Visible = false;

            pResult.Visible = false;

            lblYourScore.ForeColor = Color.White;
            lblYourScoreText.ForeColor = Color.White;
        }

        private List<Question> questionForExam()
        {
            var questionsForExam = eSystem.QuestionInExams
               .Where(qie => qie.ExamID == currentExam.ExamID) // Filtering by the current exam ID
               .Select(q => q.Question) // Selecting questions related to the exam
               .ToList();
            return questionsForExam;
        }

        private void displayCurrentQuestion()
        {
            rtBoxQuestion.Text = questionList[currentQuestion].QuestionContent;
        }

        private void displayOrNot(string questionID, string label)
        {
            var choices = eSystem.QuestionChoices.Where(x => x.QuestionID == questionID).ToList();
            var isMultiple = eSystem.QuestionCorrectAnswers.Where(x => x.QuestionID == questionID);

            if (choices.Any())
            {
                foreach (var item in choices)
                {
                    if (item.ChoiceLabel == label)
                    {
                        switch (item.ChoiceLabel)
                        {
                            case "A":
                                checkBoxA.Visible = true;
                                if (isMultiple.Count() > 1)
                                {
                                    checkBoxA.Text = "A. " + item.ChoiceContent;
                                }
                                else
                                {
                                    radioBtnA.Visible = true;
                                    radioBtnA.Text = "A. " + item.ChoiceContent;
                                }
                                break;
                            case "B":
                                if (isMultiple.Count() > 1)
                                {
                                    checkBoxB.Visible = true;
                                    checkBoxB.Text = "B. " + item.ChoiceContent;
                                }
                                else
                                {
                                    radioBtnB.Visible = true;
                                    radioBtnB.Text = "B. " + item.ChoiceContent;
                                }
                                break;
                            case "C":
                                if (isMultiple.Count() > 1)
                                {
                                    checkBoxC.Visible = true;
                                    checkBoxC.Text = "C. " + item.ChoiceContent;
                                }
                                else
                                {
                                    radioBtnC.Visible = true;
                                    radioBtnC.Text = "C. " + item.ChoiceContent;
                                }
                                break;
                            case "D":
                                if (isMultiple.Count() > 1)
                                {
                                    checkBoxD.Visible = true;
                                    checkBoxD.Text = "D. " + item.ChoiceContent;
                                }
                                else
                                {
                                    radioBtnD.Visible = true;
                                    radioBtnD.Text = "D. " + item.ChoiceContent;
                                }
                                break;
                            case "E":
                                if (isMultiple.Count() > 1)
                                {
                                    checkBoxE.Visible = true;
                                    checkBoxE.Text = "E. " + item.ChoiceContent;
                                }
                                else
                                {
                                    radioBtnE.Visible = true;
                                    radioBtnE.Text = "E. " + item.ChoiceContent;
                                }
                                break;
                        }
                    }
                }
            }
        }


        private void displayCurrentAnswer()
        {
            lblNumberInExam.Text = ((currentQuestion + 1) + "/" + questionList.Count).ToString();
            string questionID = questionList[currentQuestion].QuestionID;
            var isMultiple = eSystem.QuestionCorrectAnswers.Where(x => x.QuestionID == questionID);
            if (isMultiple.Count() > 1)
            {
                groupBoxSingleChoice.SendToBack();
                groupBoxSingleChoice.Visible = false;
                groupBoxMultipleChoice.Visible = true;
                groupBoxMultipleChoice.BringToFront();
            }
            else
            {
                groupBoxSingleChoice.Visible = true;
                groupBoxSingleChoice.BringToFront();
                groupBoxMultipleChoice.SendToBack();
                groupBoxMultipleChoice.Visible = false;
            }
            displayOrNot(questionID, "A");
            displayOrNot(questionID, "B");
            displayOrNot(questionID, "C");
            displayOrNot(questionID, "D");
            displayOrNot(questionID, "E");
        }

        private void btnQuestionNext_Click(object sender, EventArgs e)
        {
            if (currentQuestion >= questionList.Count - 1)
                return; // Ensure we're not exceeding the question list

            currentQuestion++;
            string questionID = questionList[currentQuestion].QuestionID;

            // Retrieve the selected options for the current question
            List<string> selectedOptions = GetSelectedOptionForQuestion(questionID);

            // Clear selections and display based on whether options were previously selected or not
            unCheck();
            if (selectedOptions != null && selectedOptions.Any())
            {
                displaySelectedOption(questionID, selectedOptions);
            }
            else
            {
                displayCurrentQuestion();
                displayCurrentAnswer();
            }
        }

        private void btnQuestionPrevious_Click(object sender, EventArgs e)
        {
            if (currentQuestion <= 0)
                return; // Ensure we're not going before the first question

            currentQuestion--;
            string questionID = questionList[currentQuestion].QuestionID;

            List<string> selectedOptions = GetSelectedOptionForQuestion(questionID);

            unCheck();
            if (selectedOptions != null && selectedOptions.Any())
            {
                displaySelectedOption(questionID, selectedOptions);
            }
            else
            {
                displayCurrentQuestion();
                displayCurrentAnswer();
            }
        }

        private void userSelected(string label)
        {
            string questionID = questionList[currentQuestion].QuestionID;
            if (!selectedOptions.ContainsKey(questionID))
            {
                selectedOptions.Add(questionID, new List<string>() { label });
                saveAnswer(questionID, selectedOptions[questionID]);
            }
            else
            {
                if (selectedOptions[questionID].Contains(label))
                {
                    selectedOptions[questionID].Remove(label);
                    removeAnser(questionID);
                    saveAnswer(questionID, selectedOptions[questionID]);
                }
                else
                {
                    selectedOptions[questionID].Add(label);
                    saveAnswer(questionID, selectedOptions[questionID]);
                }
            }
        }

        private void userSelectedForRadio(string label)
        {
            string questionID = questionList[currentQuestion].QuestionID;
            if (!selectedOptions.ContainsKey(questionID))
            {
                selectedOptions.Add(questionID, new List<string>() { label });
                saveAnswer(questionID, selectedOptions[questionID]);
            }
            else
            {
                selectedOptions[questionID].Clear();
                selectedOptions[questionID].Add(label);
                removeAnser(questionID);
                saveAnswer(questionID, selectedOptions[questionID]);
            }
        }




        private void unCheck()
        {
            radioBtnA.Checked = false;
            radioBtnB.Checked = false;
            radioBtnC.Checked = false;
            radioBtnD.Checked = false;
            radioBtnE.Checked = false;
            checkBoxA.Checked = false;
            checkBoxB.Checked = false;
            checkBoxC.Checked = false;
            checkBoxD.Checked = false;
            checkBoxE.Checked = false;
        }

        private List<string> GetSelectedOptionForQuestion(string questionID)
        {
            if (selectedOptions.ContainsKey(questionID))
            {
                return selectedOptions[questionID];
            }
            return null;
        }

        //private void displaySelectedOption(string questionID, List<string> labels)
        //{
        //    displayCurrentQuestion();
        //    displayCurrentAnswer();

        //    if (labels != null)
        //    {
        //        var isMultiple = eSystem.QuestionCorrectAnswers.FirstOrDefault(x => x.QuestionID == questionID);

        //        Dictionary<string, Control> controlMap = new Dictionary<string, Control>
        //{
        //    { "A", checkBoxA },
        //    { "B", checkBoxB },
        //    { "C", checkBoxC },
        //    { "D", checkBoxD },
        //    { "E", checkBoxE }
        //};

        //        if (isMultiple != null)
        //        {
        //            foreach (string label in labels)
        //            {
        //                if (controlMap.TryGetValue(label, out Control control))
        //                {
        //                    if (control is CheckBox checkBox)
        //                    {
        //                        checkBox.Checked = true;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (string label in labels)
        //            {
        //                if (controlMap.TryGetValue(label, out Control control))
        //                {
        //                    if (control is RadioButton radioButton)
        //                    {
        //                        radioButton.Checked = true;
        //                        Assuming you only have radio buttons and checkboxes
        //                         If there are other control types, you might need additional handling
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        private void displaySelectedOption(string questionID, List<string> labels)
        {
            displayCurrentQuestion();
            displayCurrentAnswer();
            if (labels != null)
            {
                var isMultiple = eSystem.QuestionCorrectAnswers.Where(x => x.QuestionID == questionID);
                if (isMultiple.Count() <= 1)
                {
                    foreach (string label in labels)
                    {
                        switch (label)
                        {
                            case "A":
                                radioBtnA.Checked = true;
                                break;
                            case "B":
                                radioBtnB.Checked = true;
                                break;
                            case "C":
                                radioBtnC.Checked = true;
                                break;
                            case "D":
                                radioBtnD.Checked = true;
                                break;
                            case "E":
                                radioBtnE.Checked = true;
                                break;
                        }
                    }
                }
                else if (isMultiple.Count() > 1)
                {
                    foreach (string label in labels.ToList())
                    {
                        switch (label)
                        {
                            case "A":
                                checkBoxA.Checked = true;
                                break;
                            case "B":
                                checkBoxB.Checked = true;
                                break;
                            case "C":
                                checkBoxC.Checked = true;
                                break;
                            case "D":
                                checkBoxD.Checked = true;
                                break;
                            case "E":
                                checkBoxE.Checked = true;
                                break;
                        }
                    }
                }
            }

        }

        //private void saveAnswer(string questionID, List<string> selectedOptions)
        //{
        //    var userAnswer = eSystem.StudentRespones
        //        .FirstOrDefault(x => x.StudentUserName == currentStudent.StudentUserName && x.QuestionID == questionID);

        //    if (userAnswer == null)
        //    {
        //        userAnswer = new StudentRespone
        //        {
        //            QuestionID = questionID,
        //            StudentUserName = currentStudent.StudentUserName,
        //            ExamID = currentExam.ExamID,
        //            ResponeChoice = string.Join(",", selectedOptions)
        //        };
        //        eSystem.StudentRespones.Add(userAnswer);
        //    }
        //    else
        //    {
        //        var existingChoices = userAnswer.ResponeChoice.Split(',').ToList();
        //        foreach (var option in selectedOptions)
        //        {
        //            if (!existingChoices.Contains(option))
        //            {
        //                existingChoices.Add(option);
        //            }
        //        }
        //        userAnswer.ResponeChoice = string.Join(",", existingChoices);
        //    }
        //    eSystem.SaveChanges();
        //}

        private void saveAnswer(string questionID, List<string> selectedOptions)
        {
            var userAnswer = eSystem.StudentRespones
                .FirstOrDefault(x => x.StudentUserName == currentStudent.StudentUserName && x.QuestionID == questionID);

            if (userAnswer == null)
            {
                foreach (var option in selectedOptions)
                {
                    var newAnswer = new StudentRespone
                    {
                        QuestionID = questionID,
                        StudentUserName = currentStudent.StudentUserName,
                        ExamID = currentExam.ExamID,
                        ResponeChoice = option // Assign each option separately
                    };
                    eSystem.StudentRespones.Add(newAnswer);
                }
            }
            else
            {
                foreach (var option in selectedOptions)
                {
                    if (!userAnswer.ResponeChoice.Contains(option))
                    {
                        userAnswer.ResponeChoice += "," + option; // Append each new option
                    }
                }
            }
            eSystem.SaveChanges();
        }




        private void removeAnser(string questionID)
        {
            var responsesToRemove = eSystem.StudentRespones.Where(x => x.QuestionID == questionID).ToList();

            if (responsesToRemove.Count > 0)
            {
                foreach (var response in responsesToRemove)
                {
                    eSystem.StudentRespones.Remove(response);
                }

                eSystem.SaveChanges();
            }
            return;

        }



        private void btnSubmitExam_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn nộp bài?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                countdownTimer.Stop();
                pResult.Visible = true;
                pResult.BringToFront();

                foreach (Control control in this.Controls)
                {
                    control.Enabled = false;
                }

                if (isSaveResult == false)
                {
                    foreach (var pair in selectedOptions)
                    {
                        calculateScore(pair.Key);
                    }
                    lblYourScore.Text = studentScore.ToString();
                    var updateMark = eSystem.ExamEnrollments.FirstOrDefault(x => x.ExamID == currentExam.ExamID);
                    if (updateMark != null)
                    {
                        updateMark.Mark = studentScore;
                    }
                    eSystem.SaveChanges();
                    isSaveResult = true;
                }
            }else
            {
                return;
            }
            
 
        }

 


        private void isFillSelectionCheckBox(System.Windows.Forms.CheckBox checkBox)
        {
            string questionID = questionList[currentQuestion].QuestionID;
            checkBox.Tag = currentQuestion;
            int buttonIndex = Convert.ToInt32(checkBox.Tag);
            System.Windows.Forms.Button btn = flowPanelButton.Controls.Find("btnQuestion" + (buttonIndex), true).FirstOrDefault() as System.Windows.Forms.Button;
            if (selectedOptions.ContainsKey(questionID))
            {
                foreach (var pair in selectedOptions)
                {
                    if (pair.Value.Count > 0)
                    {
                        btn.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        btn.BackColor = SystemColors.Control;
                    }
                }
            }
        }

        private void isFillSelectionRadio(System.Windows.Forms.RadioButton radioButton)
        {
            string questionID = questionList[currentQuestion].QuestionID;
            radioButton.Tag = currentQuestion;
            int buttonIndex = Convert.ToInt32(radioButton.Tag);
            System.Windows.Forms.Button btn = flowPanelButton.Controls.Find("btnQuestion" + (buttonIndex), true).FirstOrDefault() as System.Windows.Forms.Button;
            if (selectedOptions.ContainsKey(questionID))
            {
                foreach (var pair in selectedOptions)
                {
                    if (pair.Value.Count > 0)
                    {
                        btn.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        btn.BackColor = SystemColors.Control;
                    }
                }
            }
        }

        private void checkBoxA_Click(object sender, EventArgs e)
        {
            userSelected("A");
            isFillSelectionCheckBox(checkBoxA);
               
        }

        private void checkBoxB_Click(object sender, EventArgs e)
        {
            userSelected("B");
            isFillSelectionCheckBox(checkBoxB);
        }

        private void checkBoxC_Click(object sender, EventArgs e)
        {
            userSelected("C");
            isFillSelectionCheckBox(checkBoxC);
        }

        private void checkBoxD_Click(object sender, EventArgs e)
        {
            userSelected("D");
            isFillSelectionCheckBox(checkBoxD);
        }

        private void checkBoxE_Click(object sender, EventArgs e)
        {
            userSelected("E");
            isFillSelectionCheckBox(checkBoxE);
        }

        private void radioBtnA_Click(object sender, EventArgs e)
        {
            userSelectedForRadio("A");
            isFillSelectionRadio(radioBtnA);
        }

        private void radioBtnB_Click(object sender, EventArgs e)
        {
            userSelectedForRadio("B");
            isFillSelectionRadio(radioBtnB);
        }

        private void radioBtnC_Click(object sender, EventArgs e)
        {
            userSelectedForRadio("C");
            isFillSelectionRadio(radioBtnC);
        }

        private void radioBtnD_Click(object sender, EventArgs e)
        {
            userSelectedForRadio("D");
            isFillSelectionRadio(radioBtnD);
        }

        private void radioBtnE_Click(object sender, EventArgs e)
        {
            userSelectedForRadio("E");
            isFillSelectionRadio(radioBtnE);
        }

        private void calculateScore(string questionID)
        {

            var mark = eSystem.Exams.Where(x => x.ExamID == currentExam.ExamID).Select(y => y.MarkPerQuestion).ToList();
            double scorePerQuestion = 0;
            mark.ForEach(x => scorePerQuestion = x.Value);
            var correctChoices = eSystem.QuestionCorrectAnswers.Where(x => x.QuestionID == questionID).Select(y => y.CorrectChoice);

            List<string> a = new List<string>();
            foreach (var item in correctChoices)
            {
                a.Add(item.ToUpper().Replace(" ", "")); // Convert to uppercase and remove spaces
            }

            a.Sort(); // Sort list 'a'

            var studentChoice = eSystem.StudentRespones.Where(x => x.QuestionID == questionID).Select(y => y.ResponeChoice);
            List<string> b = new List<string>();

            foreach (var item in studentChoice)
            {
                string[] splitChoices = item.Split(','); // Splitting by comma
                foreach (var choice in splitChoices)
                {
                    b.Add(choice.Trim().ToUpper().Replace(" ", "")); // Trim, convert to uppercase, and remove spaces
                }
            }

            b.Sort(); // Sort list 'b'

            // Remove spaces and trim whitespace from elements for comparison
            List<string> trimmedA = a.Select(choice => choice.Trim()).ToList();
            List<string> trimmedB = b.Select(choice => choice.Trim()).ToList();

            var differences = trimmedA.Except(trimmedB).Union(trimmedB.Except(trimmedA));

            //foreach (var item in differences)
            //{
            //    MessageBox.Show("Difference: " + item);
            //}

            bool listsAreEqual = trimmedA.SequenceEqual(trimmedB);

            if (listsAreEqual)
            {
                studentScore = studentScore + scorePerQuestion;
                //MessageBox.Show(studentScore.ToString());
            }
        }

        private void ExamForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isSaveResult == false)
            {
                var updateMark = eSystem.ExamEnrollments.FirstOrDefault(x => x.ExamID == currentExam.ExamID);
                if (updateMark != null)
                {
                    updateMark.Mark = studentScore;
                }
                eSystem.SaveChanges();
                isSaveResult = true;
            }
        }
    }
}
