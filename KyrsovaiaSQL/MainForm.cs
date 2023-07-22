using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyrsovaiaSQL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        ClassForm classForm = new ClassForm();
        StudentsForms studentsForm = new StudentsForms();
        TeachersForm teachersForm = new TeachersForm();
        SubjectsForm subjectsForm = new SubjectsForm();

        private void ClassButtonClick(object sender, EventArgs e)
        {
            if(classForm == null)
            {
                classForm = new ClassForm();
            }
            classForm.Show();
        }

        private void StudentsButtonClick(object sender, EventArgs e)
        {
            if (studentsForm == null)
            {
                studentsForm = new StudentsForms();
            }
            studentsForm.Show();
        }

        private void TeachersButtonClick(object sender, EventArgs e)
        {
            if (teachersForm == null)
            {
                teachersForm = new TeachersForm();
            }
            teachersForm.Show();
        }

        private void SubjectsButtonClick(object sender, EventArgs e)
        {
            if (subjectsForm == null)
            {
                subjectsForm = new SubjectsForm();
            }
            subjectsForm.Show();
        }
    }
}
