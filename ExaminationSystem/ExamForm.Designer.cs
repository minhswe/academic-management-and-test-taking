namespace ExaminationSystem
{
    partial class ExamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartExam = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pExamMainScreen = new System.Windows.Forms.Panel();
            this.lblExamTime = new System.Windows.Forms.Label();
            this.lblExamTitle = new System.Windows.Forms.Label();
            this.lblNumberOfQuestion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pExam = new System.Windows.Forms.Panel();
            this.btnSubmitExam = new System.Windows.Forms.Button();
            this.lblNumberInExam = new System.Windows.Forms.Label();
            this.btnQuestionPrevious = new System.Windows.Forms.Button();
            this.pExamSection = new System.Windows.Forms.Panel();
            this.flowPanelButton = new System.Windows.Forms.FlowLayoutPanel();
            this.pResult = new System.Windows.Forms.Panel();
            this.lblYourScore = new System.Windows.Forms.Label();
            this.lblYourScoreText = new System.Windows.Forms.Label();
            this.txtTimeLeft = new System.Windows.Forms.TextBox();
            this.groupBoxSingleChoice = new System.Windows.Forms.GroupBox();
            this.radioBtnA = new System.Windows.Forms.RadioButton();
            this.radioBtnB = new System.Windows.Forms.RadioButton();
            this.radioBtnC = new System.Windows.Forms.RadioButton();
            this.radioBtnE = new System.Windows.Forms.RadioButton();
            this.radioBtnD = new System.Windows.Forms.RadioButton();
            this.rtBoxQuestion = new System.Windows.Forms.RichTextBox();
            this.groupBoxMultipleChoice = new System.Windows.Forms.GroupBox();
            this.checkBoxA = new System.Windows.Forms.CheckBox();
            this.checkBoxB = new System.Windows.Forms.CheckBox();
            this.checkBoxE = new System.Windows.Forms.CheckBox();
            this.checkBoxD = new System.Windows.Forms.CheckBox();
            this.checkBoxC = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnQuestionNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pExamMainScreen.SuspendLayout();
            this.pExam.SuspendLayout();
            this.pExamSection.SuspendLayout();
            this.pResult.SuspendLayout();
            this.groupBoxSingleChoice.SuspendLayout();
            this.groupBoxMultipleChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(181, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(462, 518);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(735, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chúc bạn đạt được kết quả tốt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(808, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhấn nút để bắt đầu làm bài";
            // 
            // btnStartExam
            // 
            this.btnStartExam.Location = new System.Drawing.Point(862, 336);
            this.btnStartExam.Name = "btnStartExam";
            this.btnStartExam.Size = new System.Drawing.Size(133, 64);
            this.btnStartExam.TabIndex = 2;
            this.btnStartExam.Text = "Bắt đầu";
            this.btnStartExam.UseVisualStyleBackColor = true;
            this.btnStartExam.Click += new System.EventHandler(this.btnStartExam_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(726, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "Thông tin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(726, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "- Số câu hỏi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(726, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 31);
            this.label5.TabIndex = 1;
            this.label5.Text = "- Thời gian:";
            // 
            // pExamMainScreen
            // 
            this.pExamMainScreen.BackColor = System.Drawing.SystemColors.Control;
            this.pExamMainScreen.Controls.Add(this.pictureBox1);
            this.pExamMainScreen.Controls.Add(this.btnStartExam);
            this.pExamMainScreen.Controls.Add(this.lblExamTime);
            this.pExamMainScreen.Controls.Add(this.lblExamTitle);
            this.pExamMainScreen.Controls.Add(this.lblNumberOfQuestion);
            this.pExamMainScreen.Controls.Add(this.label3);
            this.pExamMainScreen.Controls.Add(this.label2);
            this.pExamMainScreen.Controls.Add(this.label6);
            this.pExamMainScreen.Controls.Add(this.label4);
            this.pExamMainScreen.Controls.Add(this.label1);
            this.pExamMainScreen.Controls.Add(this.label5);
            this.pExamMainScreen.Location = new System.Drawing.Point(12, 131);
            this.pExamMainScreen.Name = "pExamMainScreen";
            this.pExamMainScreen.Size = new System.Drawing.Size(1335, 505);
            this.pExamMainScreen.TabIndex = 3;
            // 
            // lblExamTime
            // 
            this.lblExamTime.AutoSize = true;
            this.lblExamTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamTime.Location = new System.Drawing.Point(910, 166);
            this.lblExamTime.Name = "lblExamTime";
            this.lblExamTime.Size = new System.Drawing.Size(62, 31);
            this.lblExamTime.TabIndex = 1;
            this.lblExamTime.Text = "text";
            // 
            // lblExamTitle
            // 
            this.lblExamTitle.AutoSize = true;
            this.lblExamTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamTitle.Location = new System.Drawing.Point(910, 74);
            this.lblExamTitle.Name = "lblExamTitle";
            this.lblExamTitle.Size = new System.Drawing.Size(62, 31);
            this.lblExamTitle.TabIndex = 1;
            this.lblExamTitle.Text = "text";
            // 
            // lblNumberOfQuestion
            // 
            this.lblNumberOfQuestion.AutoSize = true;
            this.lblNumberOfQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfQuestion.Location = new System.Drawing.Point(910, 120);
            this.lblNumberOfQuestion.Name = "lblNumberOfQuestion";
            this.lblNumberOfQuestion.Size = new System.Drawing.Size(62, 31);
            this.lblNumberOfQuestion.TabIndex = 1;
            this.lblNumberOfQuestion.Text = "text";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(726, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 31);
            this.label6.TabIndex = 1;
            this.label6.Text = "- Tên bài:";
            // 
            // pExam
            // 
            this.pExam.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pExam.Controls.Add(this.btnSubmitExam);
            this.pExam.Controls.Add(this.lblNumberInExam);
            this.pExam.Controls.Add(this.btnQuestionPrevious);
            this.pExam.Controls.Add(this.pExamSection);
            this.pExam.Controls.Add(this.btnQuestionNext);
            this.pExam.Location = new System.Drawing.Point(15, 120);
            this.pExam.Name = "pExam";
            this.pExam.Size = new System.Drawing.Size(1366, 692);
            this.pExam.TabIndex = 4;
            // 
            // btnSubmitExam
            // 
            this.btnSubmitExam.Location = new System.Drawing.Point(1116, 572);
            this.btnSubmitExam.Name = "btnSubmitExam";
            this.btnSubmitExam.Size = new System.Drawing.Size(151, 62);
            this.btnSubmitExam.TabIndex = 5;
            this.btnSubmitExam.Text = "Nộp bài";
            this.btnSubmitExam.UseVisualStyleBackColor = true;
            this.btnSubmitExam.Click += new System.EventHandler(this.btnSubmitExam_Click);
            // 
            // lblNumberInExam
            // 
            this.lblNumberInExam.AutoSize = true;
            this.lblNumberInExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberInExam.Location = new System.Drawing.Point(614, 582);
            this.lblNumberInExam.Name = "lblNumberInExam";
            this.lblNumberInExam.Size = new System.Drawing.Size(94, 31);
            this.lblNumberInExam.TabIndex = 5;
            this.lblNumberInExam.Text = "số câu";
            // 
            // btnQuestionPrevious
            // 
            this.btnQuestionPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnQuestionPrevious.Image")));
            this.btnQuestionPrevious.Location = new System.Drawing.Point(440, 562);
            this.btnQuestionPrevious.Name = "btnQuestionPrevious";
            this.btnQuestionPrevious.Size = new System.Drawing.Size(71, 62);
            this.btnQuestionPrevious.TabIndex = 5;
            this.btnQuestionPrevious.UseVisualStyleBackColor = true;
            this.btnQuestionPrevious.Click += new System.EventHandler(this.btnQuestionPrevious_Click);
            // 
            // pExamSection
            // 
            this.pExamSection.Controls.Add(this.flowPanelButton);
            this.pExamSection.Controls.Add(this.pResult);
            this.pExamSection.Controls.Add(this.txtTimeLeft);
            this.pExamSection.Controls.Add(this.groupBoxSingleChoice);
            this.pExamSection.Controls.Add(this.rtBoxQuestion);
            this.pExamSection.Controls.Add(this.groupBoxMultipleChoice);
            this.pExamSection.Controls.Add(this.label7);
            this.pExamSection.Location = new System.Drawing.Point(40, 38);
            this.pExamSection.Name = "pExamSection";
            this.pExamSection.Size = new System.Drawing.Size(1323, 493);
            this.pExamSection.TabIndex = 6;
            // 
            // flowPanelButton
            // 
            this.flowPanelButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowPanelButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowPanelButton.Location = new System.Drawing.Point(1043, 108);
            this.flowPanelButton.Name = "flowPanelButton";
            this.flowPanelButton.Size = new System.Drawing.Size(265, 367);
            this.flowPanelButton.TabIndex = 7;
            // 
            // pResult
            // 
            this.pResult.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pResult.Controls.Add(this.lblYourScore);
            this.pResult.Controls.Add(this.lblYourScoreText);
            this.pResult.ForeColor = System.Drawing.SystemColors.Control;
            this.pResult.Location = new System.Drawing.Point(388, 144);
            this.pResult.Name = "pResult";
            this.pResult.Size = new System.Drawing.Size(495, 258);
            this.pResult.TabIndex = 1;
            // 
            // lblYourScore
            // 
            this.lblYourScore.AutoSize = true;
            this.lblYourScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourScore.Location = new System.Drawing.Point(197, 98);
            this.lblYourScore.Name = "lblYourScore";
            this.lblYourScore.Size = new System.Drawing.Size(101, 108);
            this.lblYourScore.TabIndex = 1;
            this.lblYourScore.Text = "[]";
            // 
            // lblYourScoreText
            // 
            this.lblYourScoreText.AutoSize = true;
            this.lblYourScoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourScoreText.Location = new System.Drawing.Point(152, 60);
            this.lblYourScoreText.Name = "lblYourScoreText";
            this.lblYourScoreText.Size = new System.Drawing.Size(192, 31);
            this.lblYourScoreText.TabIndex = 0;
            this.lblYourScoreText.Text = "Điểm của bạn";
            // 
            // txtTimeLeft
            // 
            this.txtTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeLeft.Location = new System.Drawing.Point(913, 34);
            this.txtTimeLeft.Name = "txtTimeLeft";
            this.txtTimeLeft.Size = new System.Drawing.Size(114, 38);
            this.txtTimeLeft.TabIndex = 6;
            // 
            // groupBoxSingleChoice
            // 
            this.groupBoxSingleChoice.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxSingleChoice.Controls.Add(this.radioBtnA);
            this.groupBoxSingleChoice.Controls.Add(this.radioBtnB);
            this.groupBoxSingleChoice.Controls.Add(this.radioBtnC);
            this.groupBoxSingleChoice.Controls.Add(this.radioBtnE);
            this.groupBoxSingleChoice.Controls.Add(this.radioBtnD);
            this.groupBoxSingleChoice.Location = new System.Drawing.Point(38, 238);
            this.groupBoxSingleChoice.Name = "groupBoxSingleChoice";
            this.groupBoxSingleChoice.Size = new System.Drawing.Size(974, 234);
            this.groupBoxSingleChoice.TabIndex = 3;
            this.groupBoxSingleChoice.TabStop = false;
            // 
            // radioBtnA
            // 
            this.radioBtnA.AutoSize = true;
            this.radioBtnA.Location = new System.Drawing.Point(6, 23);
            this.radioBtnA.Name = "radioBtnA";
            this.radioBtnA.Size = new System.Drawing.Size(32, 17);
            this.radioBtnA.TabIndex = 0;
            this.radioBtnA.TabStop = true;
            this.radioBtnA.Text = "A";
            this.radioBtnA.UseVisualStyleBackColor = true;
            this.radioBtnA.Click += new System.EventHandler(this.radioBtnA_Click);
            // 
            // radioBtnB
            // 
            this.radioBtnB.AutoSize = true;
            this.radioBtnB.Location = new System.Drawing.Point(6, 66);
            this.radioBtnB.Name = "radioBtnB";
            this.radioBtnB.Size = new System.Drawing.Size(32, 17);
            this.radioBtnB.TabIndex = 1;
            this.radioBtnB.TabStop = true;
            this.radioBtnB.Text = "B";
            this.radioBtnB.UseVisualStyleBackColor = true;
            this.radioBtnB.Click += new System.EventHandler(this.radioBtnB_Click);
            // 
            // radioBtnC
            // 
            this.radioBtnC.AutoSize = true;
            this.radioBtnC.Location = new System.Drawing.Point(7, 103);
            this.radioBtnC.Name = "radioBtnC";
            this.radioBtnC.Size = new System.Drawing.Size(32, 17);
            this.radioBtnC.TabIndex = 1;
            this.radioBtnC.TabStop = true;
            this.radioBtnC.Text = "C";
            this.radioBtnC.UseVisualStyleBackColor = true;
            this.radioBtnC.Click += new System.EventHandler(this.radioBtnC_Click);
            // 
            // radioBtnE
            // 
            this.radioBtnE.AutoSize = true;
            this.radioBtnE.Location = new System.Drawing.Point(6, 194);
            this.radioBtnE.Name = "radioBtnE";
            this.radioBtnE.Size = new System.Drawing.Size(32, 17);
            this.radioBtnE.TabIndex = 1;
            this.radioBtnE.TabStop = true;
            this.radioBtnE.Text = "E";
            this.radioBtnE.UseVisualStyleBackColor = true;
            this.radioBtnE.Click += new System.EventHandler(this.radioBtnE_Click);
            // 
            // radioBtnD
            // 
            this.radioBtnD.AutoSize = true;
            this.radioBtnD.Location = new System.Drawing.Point(6, 147);
            this.radioBtnD.Name = "radioBtnD";
            this.radioBtnD.Size = new System.Drawing.Size(33, 17);
            this.radioBtnD.TabIndex = 1;
            this.radioBtnD.TabStop = true;
            this.radioBtnD.Text = "D";
            this.radioBtnD.UseVisualStyleBackColor = true;
            this.radioBtnD.Click += new System.EventHandler(this.radioBtnD_Click);
            // 
            // rtBoxQuestion
            // 
            this.rtBoxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtBoxQuestion.Location = new System.Drawing.Point(38, 108);
            this.rtBoxQuestion.Name = "rtBoxQuestion";
            this.rtBoxQuestion.Size = new System.Drawing.Size(989, 96);
            this.rtBoxQuestion.TabIndex = 3;
            this.rtBoxQuestion.Text = "";
            // 
            // groupBoxMultipleChoice
            // 
            this.groupBoxMultipleChoice.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxMultipleChoice.Controls.Add(this.checkBoxA);
            this.groupBoxMultipleChoice.Controls.Add(this.checkBoxB);
            this.groupBoxMultipleChoice.Controls.Add(this.checkBoxE);
            this.groupBoxMultipleChoice.Controls.Add(this.checkBoxD);
            this.groupBoxMultipleChoice.Controls.Add(this.checkBoxC);
            this.groupBoxMultipleChoice.Location = new System.Drawing.Point(38, 238);
            this.groupBoxMultipleChoice.Name = "groupBoxMultipleChoice";
            this.groupBoxMultipleChoice.Size = new System.Drawing.Size(989, 234);
            this.groupBoxMultipleChoice.TabIndex = 4;
            this.groupBoxMultipleChoice.TabStop = false;
            // 
            // checkBoxA
            // 
            this.checkBoxA.AutoSize = true;
            this.checkBoxA.Location = new System.Drawing.Point(7, 19);
            this.checkBoxA.Name = "checkBoxA";
            this.checkBoxA.Size = new System.Drawing.Size(33, 17);
            this.checkBoxA.TabIndex = 2;
            this.checkBoxA.Text = "A";
            this.checkBoxA.UseVisualStyleBackColor = true;
            this.checkBoxA.Click += new System.EventHandler(this.checkBoxA_Click);
            // 
            // checkBoxB
            // 
            this.checkBoxB.AutoSize = true;
            this.checkBoxB.Location = new System.Drawing.Point(7, 66);
            this.checkBoxB.Name = "checkBoxB";
            this.checkBoxB.Size = new System.Drawing.Size(33, 17);
            this.checkBoxB.TabIndex = 2;
            this.checkBoxB.Text = "B";
            this.checkBoxB.UseVisualStyleBackColor = true;
            this.checkBoxB.Click += new System.EventHandler(this.checkBoxB_Click);
            // 
            // checkBoxE
            // 
            this.checkBoxE.AutoSize = true;
            this.checkBoxE.Location = new System.Drawing.Point(7, 194);
            this.checkBoxE.Name = "checkBoxE";
            this.checkBoxE.Size = new System.Drawing.Size(33, 17);
            this.checkBoxE.TabIndex = 2;
            this.checkBoxE.Text = "E";
            this.checkBoxE.UseVisualStyleBackColor = true;
            this.checkBoxE.Click += new System.EventHandler(this.checkBoxE_Click);
            // 
            // checkBoxD
            // 
            this.checkBoxD.AutoSize = true;
            this.checkBoxD.Location = new System.Drawing.Point(7, 147);
            this.checkBoxD.Name = "checkBoxD";
            this.checkBoxD.Size = new System.Drawing.Size(34, 17);
            this.checkBoxD.TabIndex = 2;
            this.checkBoxD.Text = "D";
            this.checkBoxD.UseVisualStyleBackColor = true;
            this.checkBoxD.Click += new System.EventHandler(this.checkBoxD_Click);
            // 
            // checkBoxC
            // 
            this.checkBoxC.AutoSize = true;
            this.checkBoxC.Location = new System.Drawing.Point(7, 103);
            this.checkBoxC.Name = "checkBoxC";
            this.checkBoxC.Size = new System.Drawing.Size(33, 17);
            this.checkBoxC.TabIndex = 2;
            this.checkBoxC.Text = "C";
            this.checkBoxC.UseVisualStyleBackColor = true;
            this.checkBoxC.Click += new System.EventHandler(this.checkBoxC_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(669, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(214, 29);
            this.label7.TabIndex = 5;
            this.label7.Text = "Thời gian còn lại:";
            // 
            // btnQuestionNext
            // 
            this.btnQuestionNext.Image = ((System.Drawing.Image)(resources.GetObject("btnQuestionNext.Image")));
            this.btnQuestionNext.Location = new System.Drawing.Point(809, 562);
            this.btnQuestionNext.Name = "btnQuestionNext";
            this.btnQuestionNext.Size = new System.Drawing.Size(71, 62);
            this.btnQuestionNext.TabIndex = 5;
            this.btnQuestionNext.UseVisualStyleBackColor = true;
            this.btnQuestionNext.Click += new System.EventHandler(this.btnQuestionNext_Click);
            // 
            // ExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.pExam);
            this.Controls.Add(this.pExamMainScreen);
            this.Name = "ExamForm";
            this.Text = "ExamForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExamForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExamForm_FormClosed);
            this.Load += new System.EventHandler(this.ExamForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pExamMainScreen.ResumeLayout(false);
            this.pExamMainScreen.PerformLayout();
            this.pExam.ResumeLayout(false);
            this.pExam.PerformLayout();
            this.pExamSection.ResumeLayout(false);
            this.pExamSection.PerformLayout();
            this.pResult.ResumeLayout(false);
            this.pResult.PerformLayout();
            this.groupBoxSingleChoice.ResumeLayout(false);
            this.groupBoxSingleChoice.PerformLayout();
            this.groupBoxMultipleChoice.ResumeLayout(false);
            this.groupBoxMultipleChoice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartExam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pExamMainScreen;
        private System.Windows.Forms.Panel pExam;
        private System.Windows.Forms.Label lblExamTime;
        private System.Windows.Forms.Label lblNumberOfQuestion;
        private System.Windows.Forms.Label lblExamTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnQuestionNext;
        private System.Windows.Forms.Button btnQuestionPrevious;
        private System.Windows.Forms.Panel pExamSection;
        private System.Windows.Forms.RadioButton radioBtnD;
        private System.Windows.Forms.RadioButton radioBtnC;
        private System.Windows.Forms.RadioButton radioBtnB;
        private System.Windows.Forms.RadioButton radioBtnA;
        private System.Windows.Forms.CheckBox checkBoxD;
        private System.Windows.Forms.CheckBox checkBoxC;
        private System.Windows.Forms.CheckBox checkBoxB;
        private System.Windows.Forms.CheckBox checkBoxA;
        private System.Windows.Forms.GroupBox groupBoxMultipleChoice;
        private System.Windows.Forms.GroupBox groupBoxSingleChoice;
        private System.Windows.Forms.RichTextBox rtBoxQuestion;
        private System.Windows.Forms.RadioButton radioBtnE;
        private System.Windows.Forms.CheckBox checkBoxE;
        private System.Windows.Forms.Label lblNumberInExam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTimeLeft;
        private System.Windows.Forms.Button btnSubmitExam;
        private System.Windows.Forms.Panel pResult;
        private System.Windows.Forms.Label lblYourScoreText;
        private System.Windows.Forms.Label lblYourScore;
        private System.Windows.Forms.FlowLayoutPanel flowPanelButton;
    }
}