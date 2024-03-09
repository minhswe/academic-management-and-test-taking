using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSystem
{
    public partial class ImportClass : Form
    {
        ExaminationSystemEntities eSystem = new ExaminationSystemEntities();
        Admin admin = new Admin();
        public ImportClass(Admin admin)
        {
            InitializeComponent();
        }

        private void btnImportClass_Click(object sender, EventArgs e)
        {
            admin.classes = eSystem.Classes.ToList();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                ArrayList dupList = new ArrayList();
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] values = line.Split(',');
                    Class addClass = new Class();
                    for (int j = 0; j < values.Length; j++)
                    {
                        addClass.ClassID = values[0];
                        addClass.ClassName = values[1];
                    }
                    var checkDup = eSystem.Classes.Where(x => x.ClassID == addClass.ClassID || x.ClassName == addClass.ClassName).ToList();
                    if (checkDup.Count <= 0)
                    {
                            addClass.ClassID = values[0];
                            addClass.ClassName = values[1];
                            eSystem.Classes.Add(addClass);
                            admin.classes.Add(addClass);
                            eSystem.SaveChanges();
                    }
                    else
                    {
                    dupList.Add(values);
                    }

                }

                if (dupList.Count > 0)
                {
                    StringBuilder s = new StringBuilder();
                    MessageBox.Show("Đã loại bỏ các thông tin trùng lặp");
                    foreach (string[] a in dupList)
                    {
                            MessageBox.Show(a[0] + " --- " + a[1]);
                    }
                }
                MessageBox.Show("Đã thêm thành công\n" + "Đóng cửa sổ này để cập nhật dữ liệu");
            }
        }
    }
}
