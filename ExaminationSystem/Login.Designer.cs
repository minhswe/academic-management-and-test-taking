namespace ExaminationSystem
{
    partial class LoginForm
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
            this.PanelSelectRole = new System.Windows.Forms.Panel();
            this.cBoxRoleSelect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelAdminLogin = new System.Windows.Forms.Panel();
            this.chkBoxAdminShowPassword = new System.Windows.Forms.CheckBox();
            this.btnAdminLogin = new System.Windows.Forms.Button();
            this.txtAdminPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdminUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelStudentLogin = new System.Windows.Forms.Panel();
            this.chkBoxLoginShowPassword = new System.Windows.Forms.CheckBox();
            this.btnStudentRegister = new System.Windows.Forms.Button();
            this.btnStudentLogin = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLoginPasswordStudent = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLoginStudentUserName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PanelSelectRole.SuspendLayout();
            this.PanelAdminLogin.SuspendLayout();
            this.panelStudentLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(453, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(437, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ỨNG DỤNG THI TRẮC NGHIỆM";
            // 
            // PanelSelectRole
            // 
            this.PanelSelectRole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PanelSelectRole.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PanelSelectRole.Controls.Add(this.cBoxRoleSelect);
            this.PanelSelectRole.Controls.Add(this.label3);
            this.PanelSelectRole.Controls.Add(this.label2);
            this.PanelSelectRole.Location = new System.Drawing.Point(541, 140);
            this.PanelSelectRole.Name = "PanelSelectRole";
            this.PanelSelectRole.Size = new System.Drawing.Size(228, 100);
            this.PanelSelectRole.TabIndex = 1;
            // 
            // cBoxRoleSelect
            // 
            this.cBoxRoleSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cBoxRoleSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxRoleSelect.FormattingEnabled = true;
            this.cBoxRoleSelect.Items.AddRange(new object[] {
            "Người quản trị (Admin)",
            "Học viên (Student)"});
            this.cBoxRoleSelect.Location = new System.Drawing.Point(3, 65);
            this.cBoxRoleSelect.Name = "cBoxRoleSelect";
            this.cBoxRoleSelect.Size = new System.Drawing.Size(222, 24);
            this.cBoxRoleSelect.TabIndex = 2;
            this.cBoxRoleSelect.SelectedIndexChanged += new System.EventHandler(this.cBoxRoleSelect_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "(Vui lòng chọn)";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Xin chào, bạn là...";
            // 
            // PanelAdminLogin
            // 
            this.PanelAdminLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PanelAdminLogin.BackColor = System.Drawing.SystemColors.Control;
            this.PanelAdminLogin.Controls.Add(this.chkBoxAdminShowPassword);
            this.PanelAdminLogin.Controls.Add(this.btnAdminLogin);
            this.PanelAdminLogin.Controls.Add(this.txtAdminPassword);
            this.PanelAdminLogin.Controls.Add(this.label6);
            this.PanelAdminLogin.Controls.Add(this.label5);
            this.PanelAdminLogin.Controls.Add(this.txtAdminUserName);
            this.PanelAdminLogin.Controls.Add(this.label4);
            this.PanelAdminLogin.Location = new System.Drawing.Point(393, 267);
            this.PanelAdminLogin.Name = "PanelAdminLogin";
            this.PanelAdminLogin.Size = new System.Drawing.Size(497, 314);
            this.PanelAdminLogin.TabIndex = 2;
            // 
            // chkBoxAdminShowPassword
            // 
            this.chkBoxAdminShowPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkBoxAdminShowPassword.AutoSize = true;
            this.chkBoxAdminShowPassword.Location = new System.Drawing.Point(74, 202);
            this.chkBoxAdminShowPassword.Name = "chkBoxAdminShowPassword";
            this.chkBoxAdminShowPassword.Size = new System.Drawing.Size(95, 17);
            this.chkBoxAdminShowPassword.TabIndex = 4;
            this.chkBoxAdminShowPassword.Text = "Hiện mật khẩu";
            this.chkBoxAdminShowPassword.UseVisualStyleBackColor = true;
            this.chkBoxAdminShowPassword.CheckedChanged += new System.EventHandler(this.chkBoxAdminShowPassword_CheckedChanged);
            // 
            // btnAdminLogin
            // 
            this.btnAdminLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdminLogin.Location = new System.Drawing.Point(71, 235);
            this.btnAdminLogin.Name = "btnAdminLogin";
            this.btnAdminLogin.Size = new System.Drawing.Size(117, 42);
            this.btnAdminLogin.TabIndex = 3;
            this.btnAdminLogin.Text = "Đăng nhập";
            this.btnAdminLogin.UseVisualStyleBackColor = true;
            this.btnAdminLogin.Click += new System.EventHandler(this.btnAdminLogin_Click);
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAdminPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminPassword.Location = new System.Drawing.Point(74, 174);
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.Size = new System.Drawing.Size(270, 22);
            this.txtAdminPassword.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(71, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mật khẩu";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(71, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên tài khoản";
            // 
            // txtAdminUserName
            // 
            this.txtAdminUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAdminUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminUserName.Location = new System.Drawing.Point(74, 108);
            this.txtAdminUserName.Name = "txtAdminUserName";
            this.txtAdminUserName.Size = new System.Drawing.Size(270, 22);
            this.txtAdminUserName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Người quản trị đăng nhập";
            // 
            // panelStudentLogin
            // 
            this.panelStudentLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelStudentLogin.BackColor = System.Drawing.SystemColors.Control;
            this.panelStudentLogin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelStudentLogin.Controls.Add(this.chkBoxLoginShowPassword);
            this.panelStudentLogin.Controls.Add(this.btnStudentRegister);
            this.panelStudentLogin.Controls.Add(this.btnStudentLogin);
            this.panelStudentLogin.Controls.Add(this.label10);
            this.panelStudentLogin.Controls.Add(this.txtLoginPasswordStudent);
            this.panelStudentLogin.Controls.Add(this.label7);
            this.panelStudentLogin.Controls.Add(this.label8);
            this.panelStudentLogin.Controls.Add(this.txtLoginStudentUserName);
            this.panelStudentLogin.Controls.Add(this.label9);
            this.panelStudentLogin.Location = new System.Drawing.Point(393, 267);
            this.panelStudentLogin.Name = "panelStudentLogin";
            this.panelStudentLogin.Size = new System.Drawing.Size(497, 314);
            this.panelStudentLogin.TabIndex = 2;
            // 
            // chkBoxLoginShowPassword
            // 
            this.chkBoxLoginShowPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkBoxLoginShowPassword.AutoSize = true;
            this.chkBoxLoginShowPassword.Location = new System.Drawing.Point(74, 192);
            this.chkBoxLoginShowPassword.Name = "chkBoxLoginShowPassword";
            this.chkBoxLoginShowPassword.Size = new System.Drawing.Size(95, 17);
            this.chkBoxLoginShowPassword.TabIndex = 4;
            this.chkBoxLoginShowPassword.Text = "Hiện mật khẩu";
            this.chkBoxLoginShowPassword.UseVisualStyleBackColor = true;
            this.chkBoxLoginShowPassword.CheckedChanged += new System.EventHandler(this.chkBoxLoginShowPassword_CheckedChanged);
            // 
            // btnStudentRegister
            // 
            this.btnStudentRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStudentRegister.Location = new System.Drawing.Point(357, 248);
            this.btnStudentRegister.Name = "btnStudentRegister";
            this.btnStudentRegister.Size = new System.Drawing.Size(117, 42);
            this.btnStudentRegister.TabIndex = 3;
            this.btnStudentRegister.Text = "Đăng ký";
            this.btnStudentRegister.UseVisualStyleBackColor = true;
            this.btnStudentRegister.Click += new System.EventHandler(this.btnStudentRegister_Click);
            // 
            // btnStudentLogin
            // 
            this.btnStudentLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStudentLogin.Location = new System.Drawing.Point(74, 248);
            this.btnStudentLogin.Name = "btnStudentLogin";
            this.btnStudentLogin.Size = new System.Drawing.Size(117, 42);
            this.btnStudentLogin.TabIndex = 3;
            this.btnStudentLogin.Text = "Đăng nhập";
            this.btnStudentLogin.UseVisualStyleBackColor = true;
            this.btnStudentLogin.Click += new System.EventHandler(this.btnStudentLogin_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(354, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Chưa có tài khoản?";
            // 
            // txtLoginPasswordStudent
            // 
            this.txtLoginPasswordStudent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLoginPasswordStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPasswordStudent.Location = new System.Drawing.Point(74, 164);
            this.txtLoginPasswordStudent.Name = "txtLoginPasswordStudent";
            this.txtLoginPasswordStudent.Size = new System.Drawing.Size(270, 22);
            this.txtLoginPasswordStudent.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(71, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mật khẩu";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(71, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tên tài khoản";
            // 
            // txtLoginStudentUserName
            // 
            this.txtLoginStudentUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLoginStudentUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginStudentUserName.Location = new System.Drawing.Point(74, 108);
            this.txtLoginStudentUserName.Name = "txtLoginStudentUserName";
            this.txtLoginStudentUserName.Size = new System.Drawing.Size(270, 22);
            this.txtLoginStudentUserName.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(89, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(222, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Học viên đăng nhập";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1333, 842);
            this.Controls.Add(this.panelStudentLogin);
            this.Controls.Add(this.PanelAdminLogin);
            this.Controls.Add(this.PanelSelectRole);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.PanelSelectRole.ResumeLayout(false);
            this.PanelSelectRole.PerformLayout();
            this.PanelAdminLogin.ResumeLayout(false);
            this.PanelAdminLogin.PerformLayout();
            this.panelStudentLogin.ResumeLayout(false);
            this.panelStudentLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelSelectRole;
        private System.Windows.Forms.ComboBox cBoxRoleSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelAdminLogin;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAdminUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdminLogin;
        private System.Windows.Forms.Panel panelStudentLogin;
        private System.Windows.Forms.Button btnStudentRegister;
        private System.Windows.Forms.Button btnStudentLogin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLoginPasswordStudent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLoginStudentUserName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkBoxLoginShowPassword;
        private System.Windows.Forms.CheckBox chkBoxAdminShowPassword;
    }
}

