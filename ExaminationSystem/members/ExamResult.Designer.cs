namespace DangKiDangNhap
{
    partial class ExamResult
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
            System.Windows.Forms.Label Xem;
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtagridviewCauHoi = new System.Windows.Forms.DataGridView();
            this.dtagridviewExam = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            Xem = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtagridviewCauHoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtagridviewExam)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(79, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1298, 408);
            this.panel1.TabIndex = 2;
            // 
            // dtagridviewCauHoi
            // 
            this.dtagridviewCauHoi.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtagridviewCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtagridviewCauHoi.Location = new System.Drawing.Point(18, 29);
            this.dtagridviewCauHoi.Name = "dtagridviewCauHoi";
            this.dtagridviewCauHoi.RowHeadersWidth = 51;
            this.dtagridviewCauHoi.RowTemplate.Height = 24;
            this.dtagridviewCauHoi.Size = new System.Drawing.Size(759, 300);
            this.dtagridviewCauHoi.TabIndex = 0;
            // 
            // dtagridviewExam
            // 
            this.dtagridviewExam.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtagridviewExam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtagridviewExam.Location = new System.Drawing.Point(15, 29);
            this.dtagridviewExam.Name = "dtagridviewExam";
            this.dtagridviewExam.RowHeadersWidth = 51;
            this.dtagridviewExam.RowTemplate.Height = 24;
            this.dtagridviewExam.Size = new System.Drawing.Size(335, 300);
            this.dtagridviewExam.TabIndex = 0;
            this.dtagridviewExam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtagridviewExam_CellClick);
            // 
            // Xem
            // 
            Xem.AutoSize = true;
            Xem.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Xem.Location = new System.Drawing.Point(556, 44);
            Xem.Name = "Xem";
            Xem.Size = new System.Drawing.Size(444, 39);
            Xem.TabIndex = 1;
            Xem.Text = "XEM LẠI BÀI THI CỦA BẠN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtagridviewExam);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(78, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 344);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bài thi bạn đã làm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtagridviewCauHoi);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(449, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(795, 344);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Câu hỏi và đáp án của bài thi";
            // 
            // hienThiKetQua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1469, 560);
            this.Controls.Add(Xem);
            this.Controls.Add(this.panel1);
            this.Name = "hienThiKetQua";
            this.Text = "hienThiKetQua";
            this.Load += new System.EventHandler(this.hienThiKetQua_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtagridviewCauHoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtagridviewExam)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtagridviewCauHoi;
        private System.Windows.Forms.DataGridView dtagridviewExam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}