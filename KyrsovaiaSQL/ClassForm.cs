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
    public partial class ClassForm : Form
    {
        public ClassForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolMagazineClassDataSet.Class". При необходимости она может быть перемещена или удалена.
            this.classTableAdapter.Fill(this.schoolMagazineClassDataSet.Class);
            //dataGridView2.
            string[] row0 = { "11/22/1968","true","21"};
            

            dataGridView2.Rows.Add(row0);
            dataGridView2.Rows.Add("1",true,"21");

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
