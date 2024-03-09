namespace ExaminationSystem
{
    partial class StudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            this.pStudentControl = new System.Windows.Forms.Panel();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStudentInfor = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.btnStudentExam = new System.Windows.Forms.Button();
            this.pStudentUI = new System.Windows.Forms.Panel();
            this.studentTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvStudentCourses = new System.Windows.Forms.DataGridView();
            this.dgvStudentExams = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.pStudentControl.SuspendLayout();
            this.pStudentUI.SuspendLayout();
            this.studentTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentExams)).BeginInit();
            this.SuspendLayout();
            // 
            // pStudentControl
            // 
            this.pStudentControl.Controls.Add(this.lblStudentName);
            this.pStudentControl.Controls.Add(this.label2);
            this.pStudentControl.Controls.Add(this.btnStudentInfor);
            this.pStudentControl.Controls.Add(this.btnResult);
            this.pStudentControl.Controls.Add(this.btnStudentExam);
            this.pStudentControl.Location = new System.Drawing.Point(0, 0);
            this.pStudentControl.Name = "pStudentControl";
            this.pStudentControl.Size = new System.Drawing.Size(358, 857);
            this.pStudentControl.TabIndex = 0;
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblStudentName.Location = new System.Drawing.Point(60, 76);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(167, 25);
            this.lblStudentName.TabIndex = 1;
            this.lblStudentName.Text = "[StudentName]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(60, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Xin chào,";
            // 
            // btnStudentInfor
            // 
            this.btnStudentInfor.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnStudentInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentInfor.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStudentInfor.Image = ((System.Drawing.Image)(resources.GetObject("btnStudentInfor.Image")));
            this.btnStudentInfor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudentInfor.Location = new System.Drawing.Point(65, 172);
            this.btnStudentInfor.Name = "btnStudentInfor";
            this.btnStudentInfor.Size = new System.Drawing.Size(201, 65);
            this.btnStudentInfor.TabIndex = 0;
            this.btnStudentInfor.Text = "Học viên";
            this.btnStudentInfor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStudentInfor.UseVisualStyleBackColor = false;
            this.btnStudentInfor.Click += new System.EventHandler(this.btnStudentInfor_Click);
            // 
            // btnResult
            // 
            this.btnResult.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResult.ForeColor = System.Drawing.SystemColors.Control;
            this.btnResult.Image = ((System.Drawing.Image)(resources.GetObject("btnResult.Image")));
            this.btnResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResult.Location = new System.Drawing.Point(65, 350);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(201, 65);
            this.btnResult.TabIndex = 0;
            this.btnResult.Text = "Kết quả";
            this.btnResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResult.UseVisualStyleBackColor = false;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // btnStudentExam
            // 
            this.btnStudentExam.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnStudentExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentExam.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStudentExam.Image = ((System.Drawing.Image)(resources.GetObject("btnStudentExam.Image")));
            this.btnStudentExam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudentExam.Location = new System.Drawing.Point(65, 261);
            this.btnStudentExam.Name = "btnStudentExam";
            this.btnStudentExam.Size = new System.Drawing.Size(201, 65);
            this.btnStudentExam.TabIndex = 0;
            this.btnStudentExam.Text = "Bài kiểm tra";
            this.btnStudentExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStudentExam.UseVisualStyleBackColor = false;
            this.btnStudentExam.Click += new System.EventHandler(this.btnStudentExam_Click);
            // 
            // pStudentUI
            // 
            this.pStudentUI.Controls.Add(this.studentTabControl);
            this.pStudentUI.Controls.Add(this.label1);
            this.pStudentUI.Location = new System.Drawing.Point(364, 3);
            this.pStudentUI.Name = "pStudentUI";
            this.pStudentUI.Size = new System.Drawing.Size(1078, 854);
            this.pStudentUI.TabIndex = 1;
            // 
            // studentTabControl
            // 
            this.studentTabControl.Controls.Add(this.tabPage1);
            this.studentTabControl.Controls.Add(this.tabPage2);
            this.studentTabControl.Location = new System.Drawing.Point(3, 3);
            this.studentTabControl.Name = "studentTabControl";
            this.studentTabControl.SelectedIndex = 0;
            this.studentTabControl.Size = new System.Drawing.Size(1075, 851);
            this.studentTabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvStudentCourses);
            this.tabPage1.Controls.Add(this.dgvStudentExams);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1067, 825);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvStudentCourses
            // 
            this.dgvStudentCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentCourses.Location = new System.Drawing.Point(56, 233);
            this.dgvStudentCourses.Name = "dgvStudentCourses";
            this.dgvStudentCourses.RowHeadersVisible = false;
            this.dgvStudentCourses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvStudentCourses.Size = new System.Drawing.Size(222, 269);
            this.dgvStudentCourses.TabIndex = 2;
            this.dgvStudentCourses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudentCourses_CellClick);
            // 
            // dgvStudentExams
            // 
            this.dgvStudentExams.AllowUserToAddRows = false;
            this.dgvStudentExams.AllowUserToDeleteRows = false;
            this.dgvStudentExams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudentExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentExams.Location = new System.Drawing.Point(354, 233);
            this.dgvStudentExams.MultiSelect = false;
            this.dgvStudentExams.Name = "dgvStudentExams";
            this.dgvStudentExams.ReadOnly = true;
            this.dgvStudentExams.RowHeadersVisible = false;
            this.dgvStudentExams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvStudentExams.Size = new System.Drawing.Size(683, 269);
            this.dgvStudentExams.TabIndex = 1;
            this.dgvStudentExams.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudentExams_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(62, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Các môn học của tôi";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1067, 825);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(367, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "HÃY CHỌN CÁC CHỨC NĂNG";
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.pStudentUI);
            this.Controls.Add(this.pStudentControl);
            this.Name = "StudentForm";
            this.Text = "StudentForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentForm_FormClosed);
            this.Load += new System.EventHandler(this.StudentForm_Load);
            this.pStudentControl.ResumeLayout(false);
            this.pStudentControl.PerformLayout();
            this.pStudentUI.ResumeLayout(false);
            this.pStudentUI.PerformLayout();
            this.studentTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentExams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pStudentControl;
        private System.Windows.Forms.Button btnStudentExam;
        private System.Windows.Forms.Panel pStudentUI;
        private System.Windows.Forms.TabControl studentTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStudentExams;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvStudentCourses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStudentInfor;
        private System.Windows.Forms.Button btnResult;
    }
}