using DataBaseConnectionTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyrsovaiaSQL
{
    public partial class StudentsForms : Form
    {

        DataBase dataBase = new DataBase();

        public StudentsForms()
        {
            InitializeComponent();
        }

        DataBaseTableEditor tableEditor = new DataBaseTableEditor("Student");

        private void StudentForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolMagazineDataSet3.Student". При необходимости она может быть перемещена или удалена.
            this.studentTableAdapter2.Fill(this.schoolMagazineDataSet3.Student);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolMagazineStudentData.Student". При необходимости она может быть перемещена или удалена.
            this.studentTableAdapter1.Fill(this.schoolMagazineStudentData.Student);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolMagazineDataSet.Student". При необходимости она может быть перемещена или удалена.
            this.studentTableAdapter.Fill(this.schoolMagazineDataSet.Student);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateBase();
        }

        private void UpdateBase()
        {
            dataGridView2.Rows.Clear();
            dataBase.openConnection();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Student", dataBase.GetConnection());
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string id = reader[0].ToString();
                    string name = reader[1].ToString();
                    dataGridView2.Rows.Add(id, name);
                }
                dataBase.closeConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            tableEditor.InsertRow(name);
            UpdateBase();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
            tableEditor.DeleteRow(id);
            UpdateBase();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            int index = dataGridView2.CurrentCell.RowIndex;
            string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
            tableEditor.UpdateRow(name, id);
            UpdateBase();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            textBox2.Text = tableEditor.GetCellValue(dataGridView,1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string id = tableEditor.GetCellValue((DataGridView)sender, 0);
            tableEditor.DeleteRow(id);
        }
    }
    }

