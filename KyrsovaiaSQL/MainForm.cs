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
        StudentsForm studentsForm = new StudentsForm();

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
                studentsForm = new StudentsForm();
            }
            studentsForm.Show();
        }
    }
}
