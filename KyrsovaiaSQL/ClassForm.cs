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
        private string[] ages =
        {
            "20","21","22"
        };

        public ClassForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolMagazineClassDataSet.Class". При необходимости она может быть перемещена или удалена.
            this.classTableAdapter.Fill(this.schoolMagazineClassDataSet.Class);

            /*dataGridView2.Rows.Add(row0);
            dataGridView2.Rows.Add("1",true,"21");*/
            TestAppend();


        }

        private void TestAppend()
        {
            Random rnd = new Random();


            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                int id = rnd.Next(1, 1000);
                bool name = Convert.ToBoolean(rnd.Next(0, 2));
                string age = ages[rnd.Next(0, 3)];
                dataGridView2.Rows.Add(id.ToString(), name, age);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }
    }
}
