namespace ExaminationSystem
{
    partial class StudentRegisterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkBoxShowPassword1 = new System.Windows.Forms.CheckBox();
            this.chkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.btnRegisterNewStudent = new System.Windows.Forms.Button();
            this.cBoxClassRegister = new System.Windows.Forms.ComboBox();
            this.txtStudentAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStudentFullName = new System.Windows.Forms.TextBox();
            this.txtPasswordCheck = new System.Windows.Forms.TextBox();
            this.txtStudentPassword = new System.Windows.Forms.TextBox();
            this.txtStudentUserName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Học viên đăng ký tài khoản";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.chkBoxShowPassword1);
            this.panel1.Controls.Add(this.chkBoxShowPassword);
            this.panel1.Controls.Add(this.btnRegisterNewStudent);
            this.panel1.Controls.Add(this.cBoxClassRegister);
            this.panel1.Controls.Add(this.txtStudentAddress);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtStudentFullName);
            this.panel1.Controls.Add(this.txtPasswordCheck);
            this.panel1.Controls.Add(this.txtStudentPassword);
            this.panel1.Controls.Add(this.txtStudentUserName);
            this.panel1.Location = new System.Drawing.Point(216, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 517);
            this.panel1.TabIndex = 1;
            // 
            // chkBoxShowPassword1
            // 
            this.chkBoxShowPassword1.AutoSize = true;
            this.chkBoxShowPassword1.Location = new System.Drawing.Point(31, 234);
            this.chkBoxShowPassword1.Name = "chkBoxShowPassword1";
            this.chkBoxShowPassword1.Size = new System.Drawing.Size(95, 17);
            this.chkBoxShowPassword1.TabIndex = 6;
            this.chkBoxShowPassword1.Text = "Hiện mật khẩu";
            this.chkBoxShowPassword1.UseVisualStyleBackColor = true;
            this.chkBoxShowPassword1.CheckedChanged += new System.EventHandler(this.chkBoxShowPassword1_CheckedChanged);
            // 
            // chkBoxShowPassword
            // 
            this.chkBoxShowPassword.AutoSize = true;
            this.chkBoxShowPassword.Location = new System.Drawing.Point(31, 149);
            this.chkBoxShowPassword.Name = "chkBoxShowPassword";
            this.chkBoxShowPassword.Size = new System.Drawing.Size(95, 17);
            this.chkBoxShowPassword.TabIndex = 6;
            this.chkBoxShowPassword.Text = "Hiện mật khẩu";
            this.chkBoxShowPassword.UseVisualStyleBackColor = true;
            this.chkBoxShowPassword.CheckedChanged += new System.EventHandler(this.chkBoxShowPassword_CheckedChanged);
            // 
            // btnRegisterNewStudent
            // 
            this.btnRegisterNewStudent.Location = new System.Drawing.Point(195, 459);
            this.btnRegisterNewStudent.Name = "btnRegisterNewStudent";
            this.btnRegisterNewStudent.Size = new System.Drawing.Size(119, 41);
            this.btnRegisterNewStudent.TabIndex = 2;
            this.btnRegisterNewStudent.Text = "Đăng ký";
            this.btnRegisterNewStudent.UseVisualStyleBackColor = true;
            this.btnRegisterNewStudent.Click += new System.EventHandler(this.btnRegisterNewStudent_Click);
            // 
            // cBoxClassRegister
            // 
            this.cBoxClassRegister.FormattingEnabled = true;
            this.cBoxClassRegister.Location = new System.Drawing.Point(31, 415);
            this.cBoxClassRegister.Name = "cBoxClassRegister";
            this.cBoxClassRegister.Size = new System.Drawing.Size(283, 21);
            this.cBoxClassRegister.TabIndex = 4;
            // 
            // txtStudentAddress
            // 
            this.txtStudentAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentAddress.Location = new System.Drawing.Point(31, 345);
            this.txtStudentAddress.Name = "txtStudentAddress";
            this.txtStudentAddress.Size = new System.Drawing.Size(283, 22);
            this.txtStudentAddress.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Chọn lớp *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Địa chỉ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "* Các trường không được để trống";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Họ và tên";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Nhập lại mật khẩu *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên đăng nhập *";
            // 
            // txtStudentFullName
            // 
            this.txtStudentFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentFullName.Location = new System.Drawing.Point(31, 284);
            this.txtStudentFullName.Name = "txtStudentFullName";
            this.txtStudentFullName.Size = new System.Drawing.Size(283, 22);
            this.txtStudentFullName.TabIndex = 2;
            // 
            // txtPasswordCheck
            // 
            this.txtPasswordCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordCheck.Location = new System.Drawing.Point(31, 206);
            this.txtPasswordCheck.Name = "txtPasswordCheck";
            this.txtPasswordCheck.PasswordChar = '*';
            this.txtPasswordCheck.Size = new System.Drawing.Size(283, 22);
            this.txtPasswordCheck.TabIndex = 2;
            // 
            // txtStudentPassword
            // 
            this.txtStudentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentPassword.Location = new System.Drawing.Point(31, 121);
            this.txtStudentPassword.Name = "txtStudentPassword";
            this.txtStudentPassword.Size = new System.Drawing.Size(283, 22);
            this.txtStudentPassword.TabIndex = 2;
            // 
            // txtStudentUserName
            // 
            this.txtStudentUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentUserName.Location = new System.Drawing.Point(31, 58);
            this.txtStudentUserName.Name = "txtStudentUserName";
            this.txtStudentUserName.Size = new System.Drawing.Size(283, 22);
            this.txtStudentUserName.TabIndex = 2;
            // 
            // StudentRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(838, 629);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "StudentRegisterForm";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.StudentRegisterForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStudentAddress;
        private System.Windows.Forms.TextBox txtStudentFullName;
        private System.Windows.Forms.TextBox txtStudentPassword;
        private System.Windows.Forms.TextBox txtStudentUserName;
        private System.Windows.Forms.ComboBox cBoxClassRegister;
        private System.Windows.Forms.Button btnRegisterNewStudent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkBoxShowPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPasswordCheck;
        private System.Windows.Forms.CheckBox chkBoxShowPassword1;
    }
}