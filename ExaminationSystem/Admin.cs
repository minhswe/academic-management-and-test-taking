using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExaminationSystem
{
    public partial class Admin : Form
    {
        ExaminationSystemEntities eSystem = new ExaminationSystemEntities();
        public List<Class> classes = null;

        private List<Cours> courses = null;
        private bool isClick = false;
        public Admin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnClassMangement_Click(object sender, EventArgs e)
        {
            isClick = !isClick;
            if (isClick)
            {
                //currently
                tabControl1.Visible = true;
                tabControl1.SelectedIndex = 0;
                btnClassMangement.BackColor = SystemColors.Control;
                btnClassMangement.ForeColor = Color.Black;
                //currently
                btnTopics.BackColor = SystemColors.Highlight;
                btnQuestionManagement.BackColor = SystemColors.Highlight;
                btnExamManagement.BackColor = SystemColors.Highlight;

                btnTopics.ForeColor = Color.White;
                btnQuestionManagement.ForeColor = Color.White;
                btnExamManagement.ForeColor = Color.White;

                isClick = !isClick;
            }
        }
        private void btnTopics_Click(object sender, EventArgs e)
        {
            isClick = !isClick;
            if (isClick)
            {
                //currently
                tabControl1.Visible = true;
                tabControl1.SelectedIndex = 1;
                btnTopics.BackColor = SystemColors.Control;
                btnTopics.ForeColor = Color.Black;
                //currently
                btnClassMangement.BackColor = SystemColors.Highlight;
                btnQuestionManagement.BackColor = SystemColors.Highlight;
                btnExamManagement.BackColor = SystemColors.Highlight;

                btnClassMangement.ForeColor = Color.White;
                btnQuestionManagement.ForeColor = Color.White;
                btnExamManagement.ForeColor = Color.White;
                isClick = !isClick;
            }
        }

        private void btnQuestionManagement_Click(object sender, EventArgs e)
        {
            isClick = !isClick;
            if (isClick)
            {
                //currently
                tabControl1.Visible = true;
                tabControl1.SelectedIndex = 2;
                btnQuestionManagement.BackColor = SystemColors.Control;
                btnQuestionManagement.ForeColor = Color.Black;
                //currently
                btnClassMangement.BackColor = SystemColors.Highlight;
                btnTopics.BackColor = SystemColors.Highlight;
                btnExamManagement.BackColor = SystemColors.Highlight;

                btnClassMangement.ForeColor = Color.White;
                btnTopics.ForeColor = Color.White;
                btnExamManagement.ForeColor = Color.White;
                isClick = !isClick;
            }
        }

        private void btnExamManagement_Click(object sender, EventArgs e)
        {
            isClick = !isClick;
            if (isClick)
            {
                //currently
                tabControl1.Visible = true;
                tabControl1.SelectedIndex = 3;
                btnExamManagement.BackColor = SystemColors.Control;
                btnExamManagement.ForeColor = Color.Black;
                //currently
                btnClassMangement.BackColor = SystemColors.Highlight;
                btnTopics.BackColor = SystemColors.Highlight;
                btnQuestionManagement.BackColor = SystemColors.Highlight;

                btnClassMangement.ForeColor = Color.White;
                btnTopics.ForeColor = Color.White;
                btnQuestionManagement.ForeColor = Color.White;

                pCreateExamAuto.Visible = false;
                isClick = !isClick;
            }
        }


       private void CopyDataGridViewStyles(DataGridView sourceDGV)
{
    DataGridViewCellStyle defaultCellStyle = sourceDGV.DefaultCellStyle.Clone();
    DataGridViewCellStyle columnHeadersDefaultCellStyle = sourceDGV.ColumnHeadersDefaultCellStyle.Clone();
    DataGridViewCellStyle rowHeadersDefaultCellStyle = sourceDGV.RowHeadersDefaultCellStyle.Clone();

    foreach (Control control in this.Controls)
    {
        if (control is DataGridView dgv)
        {
            dgv.DefaultCellStyle = defaultCellStyle;
            dgv.ColumnHeadersDefaultCellStyle = columnHeadersDefaultCellStyle;
            dgv.RowHeadersDefaultCellStyle = rowHeadersDefaultCellStyle;

            // Copy other relevant style properties similarly...
            dgv.Font = sourceDGV.Font;
            dgv.BackgroundColor = sourceDGV.BackgroundColor;
            dgv.BorderStyle = sourceDGV.BorderStyle;
            // ... and so on

            dgv.Refresh();
        }
    }
}



        private void Admin_Load(object sender, EventArgs e)
        {
            CopyDataGridViewStyles(dgvClasses);
            //tab control unvisible
            tabControl1.Multiline = true;
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabStop = false;
            tabControl1.Visible = false;
            //load class
            classes = eSystem.Classes.ToList();
            if (classes.Count <= 0) return;
            loadDataClasses(dgvClasses, classes);
            loadDataClasses(dgvClasses_Topics, classes);
            removeClassColumns(dgvClasses_Topics);
            loadDataClasses(dgvClasses_Questions, classes);
            removeClassColumns(dgvClasses_Questions);
            loadDataClasses(dgvClasses_Exams, classes);
            removeClassColumns(dgvClasses_Exams);
            //load class

            //load course
            courses = eSystem.Courses.ToList();
            loadDataCourses(dgvCourses, classes[0].Courses.ToList());
            loadDataCourses(dgvCourses_Topics, classes[0].Courses.ToList());
            loadDataCourses(dgvCourses_Questions, classes[0].Courses.ToList());
            loadDataCourses(dgvCourses_Exams, classes[0].Courses.ToList());
            //load course

            //load topic
            //loadDataTopics(dgvTopics_Questions, courses[0].Topics.ToList());

            //panal create manually hidden
            pCreateExamManually.Visible = false;

            listViewExams.Columns.Add("Danh sách câu hỏi", 650);
            listViewExams.Columns.Add("ID", 0);
            listViewExams.View = View.Details;
        }

        private void removeClassColumns(DataGridView dataGridViewClass)
        {
            if (dataGridViewClass.Columns != null)
            {
                dataGridViewClass.Columns["Courses"].Visible = false;
                dataGridViewClass.Columns["Students"].Visible = false;
                //adjustment
                dataGridViewClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewClass.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewClass.Columns[0].FillWeight = 30;
            }
            else
            {
                return;
            }

        }
        public void loadDataClasses(DataGridView dataGridView, List<Class> classList)
        {
            dataGridView.DataSource = null;
            dataGridView.Update();
            dataGridView.Refresh();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = classList;
            dataGridView.DataSource = bindingSource;
            removeClassColumns(dgvClasses);
        }

        private void removeCourseColumns(DataGridView dataGridViewCourse)
        {
            dataGridViewCourse.Columns["ClassID"].Visible = false;
            dataGridViewCourse.Columns["Class"].Visible = false;
            dataGridViewCourse.Columns["Enrollments"].Visible = false;
            dataGridViewCourse.Columns["Topics"].Visible = false;

            dataGridViewCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCourse.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCourse.Columns[0].FillWeight = 30;
        }

        public void loadDataCourses(DataGridView dgvCourses, List<Cours> courseList)
        {
            dgvCourses.DataSource = null;
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = courseList;
            dgvCourses.DataSource = bindingSource;
            removeCourseColumns(dgvCourses);
        }

        private void removeTopicColumns(DataGridView dataGridViewTopic)
        {
            dataGridViewTopic.Columns["CourseID"].Visible = false;
            dataGridViewTopic.Columns["Cours"].Visible = false;
            dataGridViewTopic.Columns["Questions"].Visible = false;
            //adjustment
            dataGridViewTopic.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTopic.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTopic.Columns[0].FillWeight = 30;
        }
        private void loadDataTopics(DataGridView dgvTopics, List<Topic> topicList)
        {
            dgvTopics.DataSource = null;
            dgvTopics.Update();
            dgvTopics.Refresh();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = topicList;
            dgvTopics.DataSource = bindingSource;
            removeTopicColumns(dgvTopics);
        }

        private void classesCellClick(DataGridView dataGridViewClass, DataGridView dataGridViewCourse)
        {
            int rowIndex = dataGridViewClass.CurrentRow.Index;
            if (rowIndex >= dataGridViewClass.Rows.Count) return;

            string classID = dgvClasses.Rows[rowIndex].Cells["ClassID"].Value.ToString();
            var coursesForClass = eSystem.Courses
                                    .Where(course => course.ClassID == classID)
                                    .ToList();
            loadDataCourses(dataGridViewCourse, coursesForClass);
            txtClassID.Text = dataGridViewClass.Rows[rowIndex].Cells["ClassID"].Value.ToString();
            txtClassName.Text = dataGridViewClass.Rows[rowIndex].Cells["ClassName"].Value.ToString();  
        }

        
        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            classesCellClick(dgvClasses, dgvCourses);
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvCourses.CurrentRow.Index;
            if (index >= dgvCourses.Rows.Count) return;

            txtCourseID.Text = dgvCourses.Rows[index].Cells["CourseID"].Value.ToString();
            txtCourseName.Text = dgvCourses.Rows[index].Cells["CourseName"].Value.ToString();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            int dgvIndex = dgvClasses.CurrentRow.Index;
            string classID = txtClassID.Text.Trim();
            string className = txtClassName.Text.Trim();
            if (classID.Length > 10)
            {
                MessageBox.Show("Mã lớp chỉ cho phép tối đa 10 ký tự");
                return;
            }
            if (string.IsNullOrEmpty(classID) || string.IsNullOrWhiteSpace(classID))
            {
                MessageBox.Show("Mã lớp không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(className) || string.IsNullOrWhiteSpace(className))
            {
                MessageBox.Show("Tên lớp học không được để trống");
                return;
            }
            var checkDupCLassID = eSystem.Classes.Where(x => x.ClassID == classID);
            if (checkDupCLassID.Count() > 0)
            {
                MessageBox.Show("Mã lớp học đã tồn tại, hãy chọn mã khác");
                return;
            }
            var checkDupClassName = eSystem.Classes.Where(x => x.ClassName == className);
            if (checkDupClassName.Count() > 0)
            {
                MessageBox.Show("Tên môn học đã tồn tại, hãy chọn tên khác");
                return;
            }
            var addClass = new Class
            {
                ClassID = classID,
                ClassName = className
            };
            eSystem.Classes.Add(addClass);
            eSystem.SaveChanges();
            classes = eSystem.Classes.ToList();
            loadDataClasses(dgvClasses, classes);
            removeClassColumns(dgvClasses);
            loadDataClasses(dgvClasses_Topics, classes);
            removeClassColumns(dgvClasses_Topics);
            loadDataClasses(dgvClasses_Questions, classes);
            removeClassColumns(dgvClasses_Questions);
            loadDataClasses(dgvClasses_Exams, classes);
            removeClassColumns(dgvClasses_Exams);


            MessageBox.Show("Đã thêm lớp học thành công");
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {

            //string classID = txtClassID.Text.Trim();
            //int dgvIndex = dgvClasses.CurrentRow.Index;
                DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa {dgvClasses.SelectedRows.Count} lớp học này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvClasses.SelectedRows)
                    {
                    string classID = row.Cells["ClassID"].Value.ToString();
                    string className = row.Cells["ClassName"].Value.ToString();
                    int dgvIndex = row.Index;
                    var isCourses = eSystem.Courses.Where(x => x.ClassID == classID).Any();
                        if (isCourses)
                        {
                            MessageBox.Show($"Lớp {classID + "---" + className} có tồn tại các môn học, hãy xóa chúng trước");
                        continue;
                        }
                        eSystem.Classes.Remove(eSystem.Classes.Find(classID));
                        eSystem.SaveChanges();
                        dgvClasses.Rows.RemoveAt(dgvIndex);
                    }
                }
            classes = eSystem.Classes.ToList();
            loadDataClasses(dgvClasses, classes);
            loadDataClasses(dgvClasses_Topics, classes);
            loadDataClasses(dgvClasses_Questions, classes);
            loadDataClasses(dgvClasses_Exams, classes);
        } 

        private void btnUpdateClass_Click(object sender, EventArgs e)
        {
            string classID = txtClassID.Text.Trim();
            string className = txtClassName.Text.Trim();
            if (classID.Length > 10)
            {
                MessageBox.Show("Mã lớp chỉ cho phép tối đa 10 ký tự");
                return;
            }
            if (string.IsNullOrEmpty(classID) || string.IsNullOrWhiteSpace(classID)
                || string.IsNullOrEmpty(className) || string.IsNullOrWhiteSpace(className)) return;

            var findClass = eSystem.Classes.Find(classID);
            var findClass1 = eSystem.Classes.Find(className);
            if (findClass.ClassID == classID && findClass.ClassName == className)
            {
                MessageBox.Show("Thông tin bạn muốn cập nhật giống nhau");
                return;
            }
            if (findClass != null || findClass1 != null)
            {
                findClass.ClassID = classID;
                findClass.ClassName = className;
                eSystem.SaveChanges();
                MessageBox.Show("Đã cập nhật thành công");
                classes = eSystem.Classes.ToList();
                loadDataClasses(dgvClasses, classes);
                loadDataClasses(dgvClasses_Topics, classes);
                loadDataClasses(dgvClasses_Questions, classes);
                loadDataClasses(dgvClasses_Exams, classes);
            }
        }

        private void btnRefreshClass_Click(object sender, EventArgs e)
        {
            txtClassID.Text = null;
            txtClassName.Text = null;
            txtFindClass.Text = null;
            classes = eSystem.Classes.ToList();
            loadDataClasses(dgvClasses, classes);
        }

        private void txtFindClass_TextChanged(object sender, EventArgs e)
        {
            string findClass = txtFindClass.Text;
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = eSystem.Classes.Where(x => x.ClassName.Contains(findClass)).ToList();
            dgvClasses.DataSource = bindingSource;
           

            //string findClass = txtFindClass.Text;
            //var filteredClasses = eSystem.Classes
            //                            .Where(x => x.ClassName.Contains(findClass))
            //                            .ToList();

            //Adding an index column to the filtered data
            //var indexedClasses = filteredClasses
            //                        .Select((c, index) => new { OriginalIndex = index + 1, Class = c })
            //                        .ToList();

            //dgvClasses.DataSource = null;
            //dgvClasses.DataSource = indexedClasses.Select(ic => new { ic.OriginalIndex, ic.Class.ClassID, ic.Class.ClassName }).ToList();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            if (classes == null) return;
            int rowIndex = dgvClasses.CurrentRow.Index;
            string courseID = txtCourseID.Text.Trim();
            string courseName = txtCourseName.Text.Trim();

            if (courseID.Length > 10)
            {
                MessageBox.Show("Mã lớp chỉ cho phép tối đa 10 ký tự");
                return;
            }
            if (string.IsNullOrEmpty(courseID) || string.IsNullOrWhiteSpace(courseID)
                || string.IsNullOrEmpty(courseName) || string.IsNullOrWhiteSpace(courseName)) return;
            var checkDupCourseID = eSystem.Courses.Where(x => x.CourseID == courseID);
            if (checkDupCourseID.Count() > 0)
            {
                MessageBox.Show("Mã môn học đã tồn tại, hãy chọn mã khác");
                return;
            }
            var checkDupCourseName = eSystem.Courses.Where(x => x.CourseName == courseName);
            if (checkDupCourseName.Count() > 0)
            {
                MessageBox.Show("Tên lớp học đã tồn tại, hãy chọn tên khác");
                return;
            }
            string classID = dgvClasses.Rows[rowIndex].Cells["ClassID"].Value.ToString();
            var findClass = eSystem.Classes.Find(classID);
            int index = eSystem.Classes.Local.IndexOf(findClass);

            var addCourse = new Cours
            {
                CourseID = courseID,
                CourseName = courseName,
                Class = findClass
            };
            eSystem.Courses.Add(addCourse);
            eSystem.SaveChanges();
            classes = eSystem.Classes.ToList();
            courses = eSystem.Courses.ToList();
            loadDataCourses(dgvCourses, classes[index].Courses.ToList());
            loadDataCourses(dgvCourses_Topics, classes[index].Courses.ToList());
            loadDataCourses(dgvCourses_Questions, classes[index].Courses.ToList());
            loadDataCourses(dgvCourses_Exams, classes[index].Courses.ToList());
            dgvCourses.Update();
            dgvCourses.Refresh();
            dgvClasses_CellClick(dgvClasses, new DataGridViewCellEventArgs(0, 0));


            MessageBox.Show("Đã thêm môn học thành công");
        }

        private int classIndex(DataGridView dgvClasses)
        {
            int rowIndex = dgvClasses.CurrentRow.Index;
            string classID = dgvClasses.Rows[rowIndex].Cells["ClassID"].Value.ToString();
            var findClass = eSystem.Classes.Find(classID);
            var classIndex = eSystem.Classes.Local.IndexOf(findClass);
            return classIndex;
        }
        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            string courseID = txtCourseID.Text.Trim();
            int rowIndex = dgvClasses.CurrentRow.Index;
            var checkCourseID = eSystem.Courses.Where(x => x.CourseID == courseID);
            MessageBox.Show(checkCourseID.Count().ToString());
            string classID = dgvClasses.Rows[rowIndex].Cells["ClassID"].Value.ToString();
            var findClass = eSystem.Classes.Find(classID);
            var classIndex = eSystem.Classes.Local.IndexOf(findClass);

            var isTopics = eSystem.Topics.Where(x => x.CourseID == courseID).Any();
            if (isTopics)
            {
                MessageBox.Show("Môn học bạn muốn xòa có tồn tại các chương mục, hãy xóa chúng trước");
                return;
            }
            if (checkCourseID.Count() <= 0)
            {
                MessageBox.Show("Môn học bạn muốn xóa không tồn tại");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    eSystem.Courses.Remove(eSystem.Courses.Find(courseID));
                    eSystem.SaveChanges();
                    classes = eSystem.Classes.ToList();
                    loadDataCourses(dgvCourses, classes[classIndex].Courses.ToList());
                    loadDataCourses(dgvCourses_Topics, classes[classIndex].Courses.ToList());
                    MessageBox.Show("Đã xóa môn học thành công");
                }
                else
                {
                    return;
                }
            }
        }

        private void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            int cIndex = classIndex(dgvClasses);
            string courseID = txtCourseID.Text.Trim();
            string courseName = txtCourseName.Text.Trim();
            if (string.IsNullOrEmpty(courseID) || string.IsNullOrWhiteSpace(courseID)) return;
            if (string.IsNullOrEmpty(courseName) || string.IsNullOrWhiteSpace(courseName)) return;
            var findCourse = eSystem.Courses.Find(courseID);
            
            if (findCourse != null)
            {
                findCourse.CourseID = courseID;
                findCourse.CourseName = courseName;
                eSystem.SaveChanges();
                classes = eSystem.Classes.ToList();
                loadDataCourses(dgvCourses, classes[cIndex].Courses.ToList());
                loadDataCourses(dgvCourses_Topics, classes[cIndex].Courses.ToList());
                MessageBox.Show("Đã cập nhật môn học thành công");
            }
        }

        private void btnRefreshCourse_Click(object sender, EventArgs e)
        {
            txtCourseID.Text = null;
            txtCourseName.Text = null;
            int cIndex = classIndex(dgvClasses);
            classes = eSystem.Classes.ToList();
            loadDataCourses(dgvCourses, classes[cIndex].Courses.ToList());
        }

        private void txtFindCourse_TextChanged(object sender, EventArgs e)
        {
            string courseName = txtFindCourse.Text;
            string classID = null;
            var findCourse = eSystem.Courses.Where(x => x.CourseName.Contains(courseName));
            var takeClassID = eSystem.Courses.Where(x => x.CourseName.Contains(courseName)).Select(y => new { y.ClassID });
            foreach(var item in takeClassID)
            {
                classID = item.ClassID;
            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = findCourse.ToList();
            dgvCourses.DataSource = bindingSource;
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = eSystem.Classes.Where(x => x.ClassID.Contains(classID)).ToList();
            dgvClasses.DataSource = bindingSource1;
            removeCourseColumns(dgvCourses);
        }


        private void dgvCourses_Topics_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int courseIndex = dgvCourses_Topics.CurrentRow.Index;
            if (courseIndex >= dgvCourses_Topics.Rows.Count) return;
            string courseID = dgvCourses_Topics.Rows[courseIndex].Cells["CourseID"].Value.ToString();
            var topicForCourse = eSystem.Topics
                                   .Where(topic => topic.CourseID == courseID)
                                   .ToList();
            loadDataTopics(dgvTopics, topicForCourse);
        }

        private void btnAddTopic_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvCourses_Topics.CurrentRow.Index;
            string topicID = txtTopicID.Text.Trim();
            string topicName = txtTopicName.Text.Trim();

            if (topicID.Length > 10)
            {
                MessageBox.Show("Mã lớp chỉ cho phép tối đa 10 ký tự");
                return;
            }
            if (string.IsNullOrEmpty(topicID) || string.IsNullOrWhiteSpace(topicID)
                || string.IsNullOrEmpty(topicName) || string.IsNullOrWhiteSpace(topicName)) return;
            var checkDupCourseID = eSystem.Topics.Where(x => x.TopicID == topicID);
            if (checkDupCourseID.Count() > 0)
            {
                MessageBox.Show("Mã chương học đã tồn tại, hãy chọn mã khác");
                return;
            }
            var checkDupCourseName = eSystem.Topics.Where(x => x.TopicName == topicName);
            if (checkDupCourseName.Count() > 0)
            {
                MessageBox.Show("Tên chương học đã tồn tại, hãy chọn tên khác");
                return;
            }
            string courseID = dgvCourses_Topics.Rows[rowIndex].Cells["CourseID"].Value.ToString();
            var findCourse = eSystem.Courses.Find(courseID);
            int index = eSystem.Courses.Local.IndexOf(findCourse);

            var addTopic = new Topic
            {
                TopicID = topicID,
                TopicName = topicName,
                Cours = findCourse
            };
            eSystem.Topics.Add(addTopic);
            eSystem.SaveChanges();
            loadDataTopics(dgvTopics, courses[index].Topics.ToList());
            MessageBox.Show("Đã thêm môn học thành công");
        }

        private void btnDeleteTopic_Click(object sender, EventArgs e)
        {
            string topicID = txtTopicID.Text.Trim();
            int rowIndex = dgvCourses_Topics.CurrentRow.Index;
            var checkTopicID = eSystem.Topics.Where(x => x.TopicID == topicID);
            string courseID = dgvCourses_Topics.Rows[rowIndex].Cells["CourseID"].Value.ToString();
            var findCourse = eSystem.Courses.Find(courseID);
            int index = eSystem.Courses.Local.IndexOf(findCourse);
            var isQuestions = eSystem.Questions.Where(x => x.TopicID == topicID).Any();
            if (isQuestions)
            {
                MessageBox.Show("Chương mục bạn muốn xóa có tồn tại các câu hỏi, hãy xóa chúng trước");
                return;
            }
            if (checkTopicID.Count() <= 0)
            {
                MessageBox.Show("Lớp học bạn muốn xóa không tồn tại");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa chương học này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    eSystem.Topics.Remove(eSystem.Topics.Find(topicID));
                    eSystem.SaveChanges();
                    loadDataTopics(dgvCourses_Topics, courses[index].Topics.ToList());
                    MessageBox.Show("Đã xóa môn học thành công");
                }
            }
        }

        private void dgvTopics_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvCourses_Topics.CurrentRow.Index;
            if (index >= dgvCourses_Topics.Rows.Count) return;

            txtTopicID.Text = dgvTopics.Rows[index].Cells["TopicID"].Value.ToString();
            txtTopicName.Text = dgvTopics.Rows[index].Cells["TopicName"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvCourses_Topics.CurrentRow.Index;
            string courseID = dgvCourses_Topics.Rows[rowIndex].Cells["CourseID"].Value.ToString();
            
            var findCourse = eSystem.Courses.Find(courseID);
            int index = eSystem.Courses.Local.IndexOf(findCourse);

            string topicID = txtTopicID.Text.Trim();
            string topicName = txtTopicName.Text.Trim();
            if (string.IsNullOrEmpty(topicID) || string.IsNullOrWhiteSpace(topicID)) return;
            if (string.IsNullOrWhiteSpace(topicName) || string.IsNullOrWhiteSpace(topicName)) return;
            var findTopic = eSystem.Topics.Find(topicID);

            if (findTopic != null)
            {
                findTopic.TopicID = topicID;
                findTopic.TopicName = topicName;
                eSystem.SaveChanges();
                loadDataTopics(dgvCourses_Topics, courses[index].Topics.ToList());
                MessageBox.Show("Đã cập nhật môn học thành công");
            }
        }

        private void txtFindTopic_TextChanged(object sender, EventArgs e)
        {
            //findTopic
            string topicName = txtFindTopic.Text.Trim();
            var findTopic = eSystem.Topics.Where(x => x.TopicName.Contains(topicName));
            loadDataTopics(dgvCourses_Topics, findTopic.ToList());
            //findCourse
            var findCourse = eSystem.Topics.Where(x => x.TopicName.Contains(topicName)).Select(y => new { y.CourseID });
            string courseID = null;
            foreach(var item in findCourse)
            {
                courseID = item.CourseID;
            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = eSystem.Courses.FirstOrDefault(x => x.CourseID == courseID);
            dgvCourses_Topics.DataSource = bindingSource;
            if (bindingSource.Count <= 0) return;
            removeCourseColumns(dgvCourses_Topics);
            //findClass
            var findClass = eSystem.Courses.Where(x => x.CourseID == courseID).Select(y => new { y.ClassID });
            string classID = null;
            foreach (var item in findClass)
            {
                classID = item.ClassID;
            }
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = eSystem.Classes.FirstOrDefault(x => x.ClassID == classID);
            dgvClasses_Topics.DataSource = bindingSource1;
            if (bindingSource1.Count <= 0) return;
            removeClassColumns(dgvClasses_Topics);
        }



        private void txtFindCourse_Topics_TextChanged(object sender, EventArgs e)
        {
            string findCourse = txtFindCourse_Topics.Text;
            string classID = null;
            var test = eSystem.Courses.Where(x => x.CourseName.Contains(findCourse)).Select(y => new { y.CourseID, y.CourseName, y.ClassID });
            foreach (var item in test)
            {
                classID = item.ClassID;
            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = test.ToList();
            dgvCourses_Topics.DataSource = bindingSource;
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = eSystem.Classes.Where(x => x.ClassID.Contains(classID)).ToList();
            dgvClasses_Topics.DataSource = bindingSource1;
            removeCourseColumns(dgvCourses_Topics);
        }

        private void txtFindClass_Topics_TextChanged(object sender, EventArgs e)
        {
            string findClass = txtFindClass_Topics.Text;
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = eSystem.Classes.Where(x => x.ClassName.Contains(findClass)).ToList();
            dgvClasses_Topics.DataSource = bindingSource;
            removeClassColumns(dgvClasses_Topics);
        }

        //refresh topics
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtTopicID.Text = null;
            txtTopicName.Text = null;
            int cIndex = classIndex(dgvClasses_Topics);
            classes = eSystem.Classes.ToList();
            loadDataClasses(dgvClasses_Topics, classes);
            loadDataCourses(dgvCourses_Topics, classes[cIndex].Courses.ToList());
            loadDataTopics(dgvCourses_Topics, courses[0].Topics.ToList());
        }

        private void dgvClasses_Questions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            classesCellClick(dgvClasses_Questions, dgvCourses_Questions);
        }

        private void dgvCourses_Questions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int courseIndex = dgvCourses_Questions.CurrentRow.Index;
            //if (courseIndex >= dgvCourses_Questions.Rows.Count - 1) return;
            string courseID = dgvCourses_Questions.Rows[courseIndex].Cells["CourseID"].Value.ToString();
            var topicForCourse = eSystem.Topics
                                   .Where(topic => topic.CourseID == courseID)
                                   .ToList();
            loadDataTopics(dgvTopics_Questions, topicForCourse);
        }

        private void dgvTopics_Questions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Topic> topicList = eSystem.Topics.ToList();
            int topicIndex = dgvTopics_Questions.CurrentRow.Index;
            if (topicIndex >= dgvTopics_Questions.Rows.Count - 1) return;
            string topicID = dgvTopics_Questions.Rows[topicIndex].Cells["TopicID"].Value.ToString();
            var questionForTopic = eSystem.Questions
                                  .Where(question => question.TopicID == topicID)
                                  .ToList();


            txtNumberOfQuestion.Text = countQuestion(topicID).ToString();
            int currentNumber = countQuestion(topicID) + 1;
            txtQuestionID.Text = topicID + currentNumber;
            loaddataQuestions(dgvQuestions, questionForTopic);
        }

        private void nextQuestion()
        {
            txtQuestionContent.Text = null;
            txtOptionA.Text = null;
            txtOptionB.Text = null;
            txtOptionC.Text = null;
            txtOptionD.Text = null;
            txtOptionE.Text = null;
            txtCorrect1.Text = null;
            txtCorrect2.Text = null;
            txtCorrect3.Text = null;
            txtCorrect4.Text = null;

            string topicID = dgvTopics_Questions.CurrentRow.Cells["TopicID"].Value.ToString();
            int questionID = countQuestion(topicID) + 1;
            txtQuestionID.Text = topicID + questionID.ToString();
            txtNumberOfQuestion.Text = countQuestion(topicID).ToString();
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            nextQuestion();
        }

        private int countQuestion(string topicID)
        {
            var findTopic = eSystem.Topics.Where(x => x.TopicID == topicID).SelectMany(y => y.Questions);
            return findTopic.Count();        
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (dgvTopics_Questions.SelectedRows.Count < 0 || string.IsNullOrEmpty(txtQuestionID.Text))
            {
                MessageBox.Show("Hãy chọn chương mục cho câu hỏi");
                return;
            }
            string questionID = txtQuestionID.Text.Trim();
            string questionContent = txtQuestionContent.Text.Trim();
            string optionA = txtOptionA.Text.Trim();
            string optionB = txtOptionB.Text.Trim();
            string optionC = txtOptionC.Text.Trim();
            string optionD = txtOptionD.Text.Trim();
            string optionE = txtOptionE.Text.Trim();
            string correct1 = txtCorrect1.Text.Trim().ToUpper();
            string correct2 = txtCorrect2.Text.Trim().ToUpper();
            string correct3 = txtCorrect3.Text.Trim().ToUpper();
            string correct4 = txtCorrect4.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(questionContent) || string.IsNullOrWhiteSpace(questionContent)) return;

            string topicID = dgvTopics_Questions.CurrentRow.Cells["TopicID"].Value.ToString();
            List<Question> checkDuplicate = eSystem.Questions.Where(x => x.QuestionContent == questionContent).ToList();
            if (checkDuplicate.Count > 0)
            {
                MessageBox.Show("Nội dung dành cho câu hỏi này đã tồn tại, vui lòng chỉnh sửa");
                return;
            }
            
            var addQuestion = new Question
            {
                QuestionID = questionID,
                QuestionContent = questionContent,
                TopicID = topicID
            };


            int number = countQuestion(topicID) + 1;
            var addDisplayOrder = new QuestionDisplayOrder
            {
                QuestionID = questionID,
                DisplayOrder = number
            };
            if ((string.IsNullOrEmpty(optionA) && string.IsNullOrWhiteSpace(optionA) && (correct1 == "A" || correct2 == "A" || correct3 == "A" || correct4 == "A"))){
                MessageBox.Show("A không thể là đáp án vì không chứa câu trã lời");
                return;
            };
            if ((string.IsNullOrEmpty(optionB) && string.IsNullOrWhiteSpace(optionB) && (correct1 == "B" || correct2 == "B" || correct3 == "B" || correct4 == "B")))
            {
                MessageBox.Show("B không thể là đáp án vì không chứa câu trã lời");
                return;
            };
            if ((string.IsNullOrEmpty(optionC) && string.IsNullOrWhiteSpace(optionC) && (correct1 == "C" || correct2 == "C" || correct3 == "C" || correct4 == "C")))
            {
                MessageBox.Show("C không thể là đáp án vì không chứa câu trã lời");
                return;
            };
            if ((string.IsNullOrEmpty(optionD) && string.IsNullOrWhiteSpace(optionD) && (correct1 == "D" || correct2 == "D" || correct3 == "D" || correct4 == "D")))
            {
                MessageBox.Show("D không thể là đáp án vì không chứa câu trã lời");
                return;
            };
            if ((string.IsNullOrEmpty(optionE) && string.IsNullOrWhiteSpace(optionE) && (correct1 == "E" || correct2 == "E" || correct3 == "E" || correct4 == "E")))
            {
                MessageBox.Show("E không thể là đáp án vì không chứa câu trã lời");
                return;
            };

            eSystem.Questions.Add(addQuestion);
            eSystem.QuestionDisplayOrders.Add(addDisplayOrder);
            addQuestionChoice(questionID, optionA, "A");
            addQuestionChoice(questionID, optionB, "B");
            addQuestionChoice(questionID, optionC, "C");
            addQuestionChoice(questionID, optionD, "D");
            addQuestionChoice(questionID, optionE, "E");
            addCorrectAnswer(questionID, correct1);
            addCorrectAnswer(questionID, correct2);
            addCorrectAnswer(questionID, correct3);
            addCorrectAnswer(questionID, correct4);
            eSystem.SaveChanges();
            MessageBox.Show("Thêm câu hỏi thành công");
            List<Topic> topicList = eSystem.Topics.ToList();
            var findTopic = eSystem.Topics.Find(topicID);
            loaddataQuestions(dgvQuestions, topicList[eSystem.Topics.Local.IndexOf(findTopic)].Questions.ToList());
            nextQuestion();
        }

        private void addQuestionChoice(string questionID,string option, string label)
        {
            if (!(string.IsNullOrEmpty(option) && string.IsNullOrWhiteSpace(option)))
            {
                var addOption = new QuestionChoice
                {
                    QuestionID = questionID,
                    ChoiceLabel = label.ToUpper(),
                    ChoiceContent = option
                };
                eSystem.QuestionChoices.Add(addOption);
            }
        }
        private void removeQuestionColumns(DataGridView dgvQuestion)
        {
            dgvQuestion.Columns["QuestionID"].Visible = false;
            dgvQuestion.Columns["TopicID"].Visible = false;
            dgvQuestion.Columns["QuestionChoices"].Visible = false;
            dgvQuestion.Columns["QuestionCorrectAnswers"].Visible = false;
            dgvQuestion.Columns["QuestionDisplayOrder"].Visible = false;
            dgvQuestion.Columns["Topic"].Visible = false;
            dgvQuestion.Columns["StudentRespones"].Visible = false;
            dgvQuestion.Columns["QuestionInExams"].Visible = false;
            int width = dgvQuestion.Width;
            //int courseIDWidth = dgvQuestion.Columns["QuestionID"].Width;
            dgvQuestion.Columns["QuestionContent"].Width = width;
        }
        private void loaddataQuestions(DataGridView dgvQuestions, List<Question> questionList)
        {
            dgvQuestions.DataSource = null;
            dgvQuestions.Update();
            dgvQuestions.Refresh();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = questionList;
            dgvQuestions.DataSource = bindingSource;
            removeQuestionColumns(dgvQuestions);

        }

        private void questionAdded(string questionID, System.Windows.Forms.ListView listView)
        {
            listView.View = View.List;
            var question = from a in eSystem.QuestionChoices.Where(x => x.QuestionID == questionID)
                        join b in eSystem.QuestionCorrectAnswers on a.QuestionID equals b.QuestionID
                        join c in eSystem.QuestionDisplayOrders on a.QuestionID equals c.QuestionID
                        select new
                        {
                            a.QuestionID,
                            a.Question.QuestionContent,
                            a.ChoiceLabel,
                            a.ChoiceContent,
                            b.CorrectChoice,
                            c.DisplayOrder
                        };

            string questionContent = null;
            int displayOrder = 0;
            string correctAnswer = null;
            foreach(var item in question)
            {
                questionContent = item.QuestionContent;
                displayOrder = item.DisplayOrder.Value;
                correctAnswer = item.CorrectChoice.ToUpper();
            }
            listView.Items.Add(questionContent);
        }

        private void addCorrectAnswer(string questionID, string correctChoice)
        {
            if (!(string.IsNullOrEmpty(correctChoice) && string.IsNullOrWhiteSpace(correctChoice)))
            {
                var addCorrectChoice = new QuestionCorrectAnswer
                {
                    QuestionID = questionID,
                    CorrectChoice = correctChoice.ToUpper()
                };
                eSystem.QuestionCorrectAnswers.Add(addCorrectChoice);
            }
        }


        
        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            string questionID = null;
            string content = dgvQuestions.CurrentRow.Cells["QuestionContent"].Value.ToString();
            var findID = eSystem.Questions.Where(x => x.QuestionContent == content).Select(y => new {y.QuestionID, y.QuestionChoices, y.QuestionCorrectAnswers});
            foreach(var item in findID)
            {
                questionID = item.QuestionID;

            }

            var findQuestion = eSystem.Questions.Find(questionID);
            if (findQuestion != null)
            {
                findQuestion.QuestionContent = txtQuestionContent.Text;
            }

            var findChoices = eSystem.QuestionChoices.Where(x => x.QuestionID == questionID).ToList();
            var updateA = findChoices.Where(x => x.ChoiceLabel == "A").ToList();
            updateA.ForEach(x => x.ChoiceContent = txtOptionA.Text);
            var updateB = findChoices.Where(x => x.ChoiceLabel == "B").ToList();
            updateB.ForEach(x => x.ChoiceContent = txtOptionB.Text);
            var updateC = findChoices.Where(x => x.ChoiceLabel == "C").ToList();
            updateC.ForEach(x => x.ChoiceContent = txtOptionC.Text); 
            var updateD = findChoices.Where(x => x.ChoiceLabel == "D").ToList();
            updateD.ForEach(x => x.ChoiceContent = txtOptionD.Text);
            var updateE = findChoices.Where(x => x.ChoiceLabel == "E").ToList();
            updateE.ForEach(x => x.ChoiceContent = txtOptionE.Text);

            var findAnswerID = eSystem.QuestionCorrectAnswers.Where(x => x.QuestionID == questionID).Select(y => new { y.ID });
            foreach(var item in findAnswerID)
            {
                eSystem.QuestionCorrectAnswers.Remove(eSystem.QuestionCorrectAnswers.Find(item.ID));
            }
           
            addCorrectAnswer(questionID, txtCorrect1.Text.Trim());
            addCorrectAnswer(questionID, txtCorrect2.Text.Trim());
            addCorrectAnswer(questionID, txtCorrect3.Text.Trim());
            addCorrectAnswer(questionID, txtCorrect4.Text.Trim());
            eSystem.SaveChanges();
            MessageBox.Show("Đã cập nhật thành công");

            //var topicIndex = eSystem.Topics.Local.IndexOf(topicID);
            //loadQuestions(dgvQuestions, dgvTopics_Questions);
        }

        private void dgvQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int questionIndex = dgvQuestions.CurrentRow.Index;
            //if (questionIndex >= dgvQuestions.Rows.Count - 1) return;
            string content = dgvQuestions.Rows[questionIndex].Cells["QuestionContent"].Value.ToString();
            var query = eSystem.Questions.Where(x => x.QuestionContent == content).Select(y => new
            {
                y.QuestionID,
                y.QuestionChoices,
                y.QuestionCorrectAnswers,
            });
            txtQuestionContent.Text = content;
            foreach (var item in query)
            {
                foreach (var item1 in item.QuestionChoices)
                {
                    switch (item1.ChoiceLabel)
                    {
                        case "A":
                            txtOptionA.Text = item1.ChoiceContent;
                            break;
                        case "B":
                            txtOptionB.Text = item1.ChoiceContent;
                            break;
                        case "C":
                            txtOptionC.Text = item1.ChoiceContent;
                            break;
                        case "D":
                            txtOptionD.Text = item1.ChoiceContent;
                            break;
                        case "E":
                            txtOptionE.Text = item1.ChoiceContent;
                            break;
                    }
                }

                List<QuestionCorrectAnswer> answers = item.QuestionCorrectAnswers.ToList();

                switch (answers.Count)
                {
                    case 1:
                        txtCorrect1.Text = answers[0].CorrectChoice;
                        break;
                    case 2:
                        txtCorrect1.Text = answers[0].CorrectChoice;
                        txtCorrect2.Text = answers[1].CorrectChoice;
                        break;
                    case 3:
                        txtCorrect1.Text = answers[0].CorrectChoice;
                        txtCorrect2.Text = answers[1].CorrectChoice;
                        txtCorrect3.Text = answers[2].CorrectChoice;
                        break;
                    case 4:
                        txtCorrect1.Text = answers[0].CorrectChoice;
                        txtCorrect2.Text = answers[1].CorrectChoice;
                        txtCorrect3.Text = answers[2].CorrectChoice;
                        txtCorrect4.Text = answers[3].CorrectChoice;
                        break;
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<Topic> topicList = eSystem.Topics.ToList();
            string questionID = null;
            var question = eSystem.Questions.Where(x => x.QuestionContent == txtQuestionContent.Text).Select(y => new { y.QuestionID });
            foreach(var item in question)
            {
                questionID = item.QuestionID;
            }
            int rowIndex = dgvQuestions.CurrentRow.Index;
            var checkQuestionID = eSystem.Questions.Where(x => x.QuestionID == questionID);

            int rowTopic = dgvTopics_Questions.CurrentRow.Index;
            string topicID = dgvTopics_Questions.Rows[rowTopic].Cells["TopicID"].Value.ToString();
            var findTopic = eSystem.Topics.Find(topicID);
            int index = eSystem.Topics.Local.IndexOf(findTopic);
            var isExams = eSystem.QuestionInExams.Where(x => x.QuestionID == questionID).Any();
            if (isExams)
            {
                MessageBox.Show("Câu hỏi bạn muốn xóa đã có trong bài kiểm tra, hãy xóa bài kiểm tra đó trước");
                return;
            }
            if (checkQuestionID.Count() <= 0)
            {
                MessageBox.Show("Câu hỏi bạn muốn xóa không tồn tại");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa câu hỏi này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    eSystem.QuestionChoices.RemoveRange(eSystem.QuestionChoices.Where(x => x.QuestionID == questionID));
                    eSystem.QuestionCorrectAnswers.RemoveRange(eSystem.QuestionCorrectAnswers.Where(x => x.QuestionID == questionID));
                    eSystem.QuestionDisplayOrders.Remove(eSystem.QuestionDisplayOrders.Find(questionID));
                    eSystem.Questions.Remove(eSystem.Questions.Find(questionID));
                    eSystem.SaveChanges();
                    loaddataQuestions(dgvQuestions, topicList[index].Questions.ToList());
                    MessageBox.Show("Đã xóa câu hỏi thành công");
                    txtQuestionID.Text = null;
                    txtQuestionContent.Text = null;
                    txtOptionA.Text = null;
                    txtOptionB.Text = null;
                    txtOptionC.Text = null;
                    txtOptionD.Text = null;
                    txtOptionE.Text = null;
                    txtCorrect1.Text = null;
                    txtCorrect2.Text = null;
                    txtCorrect3.Text = null;
                    txtCorrect4.Text = null;
                }
            }
        }

        private void dgvClasses_Exams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            classesCellClick(dgvClasses_Exams, dgvCourses_Exams);
        }

        private List<Question> randomQuestionList (List<Question> questionList, int numberOfQuestion)
        {
            Random rnd = new Random();
            List<Question> shuffleQuestionList = questionList.OrderBy(x => rnd.Next()).ToList();

            return shuffleQuestionList.Take(numberOfQuestion).ToList(); 
        }

        private void loadDataExamInCourse(DataGridView dgv, List<Exam> examList)
        {
            dgv.DataSource = null;
            dgv.DataSource = examList;
            foreach(DataGridViewColumn column in dgv.Columns)
            {
                if (!(column.Name == "ExamTitle"))
                {
                    column.Visible = false;
                }
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[0].FillWeight = 100;

        }

        private void dgvCourses_Exams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            courses = eSystem.Courses.ToList();
            int courseIndex = dgvCourses_Exams.CurrentRow.Index;
            if (courseIndex >= dgvCourses_Exams.Rows.Count - 1) return;
            string courseID = dgvCourses_Exams.Rows[courseIndex].Cells["CourseID"].Value.ToString();

            var countExam = eSystem.Courses
           .Where(course => course.CourseID == courseID)
           .SelectMany(course => course.Topics)
           .SelectMany(topic => topic.Questions)
           .SelectMany(question => question.QuestionInExams)
           .Where(exam => exam != null) 
           .GroupBy(exam => exam.ExamID) 
           .Select(group => group.FirstOrDefault()) 
           .Count();

            int increaseExamID = (int)countExam + 1;
            txtExamID.Text = courseID + increaseExamID.ToString();

            var examInCourse = eSystem.Courses.Where(course => course.CourseID == courseID)
                .SelectMany(course => course.Topics)
                .SelectMany(topic => topic.Questions)
                .SelectMany(question => question.QuestionInExams)
                .Where(exam => exam != null)
                .Select(exam => exam.Exam).Distinct().ToList();

            loadDataExamInCourse(dgvExamInCourse, examInCourse);
                
            if (cBoxExamType.SelectedIndex == 1)
            {   
                listViewExams.Items.Clear();

                var questionList = eSystem.Topics.Where(x => x.CourseID == courseID).SelectMany(y => y.Questions).ToList();
                txtNumberOFCurrentQuestions.Text = questionList.Count().ToString();

            } else
            {
                listViewExams.Items.Clear();

                var question = eSystem.Topics.Where(x => x.CourseID == courseID).SelectMany(y => y.Questions);
                List<Question> questionList = null;

                questionList = question.ToList();
                loaddataQuestions(dgvQuestions_Exams, questionList);

                txtNumberOFCurrentQuestions.Text = questionList.Count.ToString();
            }
        }

        private void cBoxExamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxExamType.SelectedIndex == 0)
            {
                pCreateExamManually.Visible = true;
            } else
            {
                pCreateExamManually.Visible = false;
            }

            if (cBoxExamType.SelectedIndex == 1)
            {
                pCreateExamAuto.Visible = true;
            } else
            {
                pCreateExamAuto.Visible = false;
            }
        }

        private void btnCreateExam_Click(object sender, EventArgs e)
        {
            bool check = false;
            int numberOfQuestion = 0;
            if (cBoxExamType.SelectedIndex == 1)
            {
                if (string.IsNullOrEmpty(txtNumberOfQuestions.Text) || string.IsNullOrWhiteSpace(txtNumberOfQuestions.Text))
                {
                    MessageBox.Show("Bạn phải nhập số câu hỏi");
                    return;
                }
                if (listViewExams.Items.Count <= 0)
                {
                    MessageBox.Show("Bạn chưa chọn câu hỏi nào để thêm vào bài kiểm tra");
                    return;
                }
                check = int.TryParse(txtNumberOfQuestions.Text, out numberOfQuestion);
                if (!check)
                {
                    return;
                }
            }

            byte examTime = 0;
            check = byte.TryParse(txtExamTime.Text, out examTime);
            if (!check)
            {
                MessageBox.Show("Thời gian làm bài kiểm tra không hợp lệ");
                return;
            }
            var addExam = new Exam
            {
                ExamID = txtExamID.Text,
                ExamTitle = txtExamName.Text,
                ExamDate = DateTime.Now.Date,
                NumberOfQuestion = listViewExams.Items.Count,
                MarkPerQuestion = (double)(10 / (double)listViewExams.Items.Count),
                examTime = examTime
            };

            for (int i = 0; i < listViewExams.Items.Count; i++)
            {
                string questionID = listViewExams.Items[i].SubItems[1].Text;
                var questionInExam = new QuestionInExam
                {
                    ExamID = addExam.ExamID,
                    QuestionID = questionID
                };
                eSystem.QuestionInExams.Add(questionInExam);

            }
            eSystem.Exams.Add(addExam);
            eSystem.SaveChanges();
            MessageBox.Show("Tạo bài kiểm tra thành công");
            
        }

        private void btnAddQuestionExam_Click(object sender, EventArgs e)
        {
            if (dgvQuestions_Exams.Rows.Count <= 1) return;
            int rowIndex = dgvQuestions_Exams.CurrentRow.Index;
            string questionID = dgvQuestions_Exams.Rows[rowIndex].Cells["QuestionID"].Value.ToString();

            var question = eSystem.Questions.Where(x => x.QuestionID == questionID).ToList();
            foreach(var item in question)
            {
                var check = listViewExams.FindItemWithText(item.QuestionContent);
                if (check != null)
                {
                    MessageBox.Show("Bạn đã thêm câu hỏi này rồi");
                    return;
                }else
                {
                    //question.ForEach(x => listViewExams.Items.Add(x.QuestionContent));
                    question.ForEach(x => listViewExams.Items.Add(new ListViewItem(new[] { x.QuestionContent, x.QuestionID })));
                    
                }
              
            }

        }

        private void dgvQuestions_Exams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuestions_Exams.CurrentRow.Index > dgvQuestions_Exams.RowCount - 1) return;

        }


        private void btnImportClass_Click(object sender, EventArgs e)
        {
            ImportClass importClassForm = new ImportClass(this);
            importClassForm.ShowDialog();
            classes = eSystem.Classes.ToList();
            loadDataClasses(dgvClasses, classes);
            loadDataClasses(dgvClasses_Topics, classes);
            removeClassColumns(dgvClasses_Topics);
            loadDataClasses(dgvClasses_Questions, classes);
            removeClassColumns(dgvClasses_Questions);
            loadDataClasses(dgvClasses_Exams, classes);
            removeClassColumns(dgvClasses_Exams);
        }

        private void txtNumberOfQuestions_TextChanged(object sender, EventArgs e)
        {
            bool check = false;
            int expectedNumber = 0;
            int currentNumber = int.Parse(txtNumberOFCurrentQuestions.Text);
            check = int.TryParse(txtNumberOfQuestions.Text, out expectedNumber);
            if (expectedNumber > currentNumber)
            {
                MessageBox.Show("Số câu hỏi trong dữ liệu không đủ để đáp ứng");
                return;
            }
            listViewExams.Items.Clear();
            courses = eSystem.Courses.ToList();
            int courseIndex = dgvCourses_Exams.CurrentRow.Index;
            if (courseIndex >= dgvCourses_Exams.Rows.Count - 1) return;
            string courseID = dgvCourses_Exams.Rows[courseIndex].Cells["CourseID"].Value.ToString();
            var findCourse = eSystem.Courses.Find(courseID);
            int index = eSystem.Courses.Local.IndexOf(findCourse);

            var countExam = eSystem.Courses
            .Where(course => course.CourseID == courseID)
            .SelectMany(course => course.Topics)
            .SelectMany(topic => topic.Questions)
            .Count();
            var questionList = eSystem.Topics.Where(x => x.CourseID == courseID).SelectMany(y => y.Questions).ToList();
            txtNumberOFCurrentQuestions.Text = questionList.Count.ToString();

            int number = 0;
            check = int.TryParse(txtNumberOfQuestions.Text, out number);
            if (!check)
            {
                return;
            }
            //randomQuestionList(questionList, number).ForEach(x => listViewExams.Items.Add(x.QuestionContent));
            randomQuestionList(questionList, number).ForEach(x => listViewExams.Items.Add(new ListViewItem(new[] { x.QuestionContent, x.QuestionID })));
        }

        private void dgvClasses_Topics_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            classesCellClick(dgvClasses_Topics, dgvCourses_Topics);
        }

        private void dgvExamInCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgvExamInCourse.CurrentRow.Index;
            string examID = dgvExamInCourse.Rows[rowIndex].Cells["ExamID"].Value.ToString();
            var questions = eSystem.Questions.Where(q => q.QuestionInExams.Any(x => x.ExamID == examID))
                .Select(q => q.QuestionContent).ToList();
            
            foreach(var details in questions)
            {
                listViewExams.Items.Add(details);
            }
        }
    }
}