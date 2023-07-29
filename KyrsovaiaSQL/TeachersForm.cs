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
    public partial class TeachersForm : Form
    {
        public TeachersForm()
        {
            InitializeComponent();
        }

        DataBase dataBase = new DataBase();


        private void TeachersForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolMagazineDataSet1.Teacher". При необходимости она может быть перемещена или удалена.
            this.teacherTableAdapter.Fill(this.schoolMagazineDataSet1.Teacher);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableUpdate();

        }

        private void TableUpdate()
        {
            dataGridView2.Rows.Clear();
            dataBase.openConnection();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Teacher",
                dataBase.GetConnection());
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string id = reader[0].ToString();
                    object fio = reader[1];
                    dataGridView2.Rows.Add(id, fio);
                }
                dataBase.closeConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                AddTeacher();
                TableUpdate();
            }
            
        }

        private void AddTeacher()
        {
            dataBase.openConnection();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Teacher (fio) VALUES ('" + textBox1.Text + "')",
                dataBase.GetConnection());
            sqlCommand.ExecuteNonQuery();
            dataBase.closeConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteTeacher();
            TableUpdate();
        }

        private void DeleteTeacher()
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
            //id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            // SelectedRows работает когда все ячейки строки выделены , и это неудобно
            dataBase.openConnection();
            SqlCommand sqlCommand =
                new SqlCommand("DELETE FROM Teacher WHERE Id = " + id,
                dataBase.GetConnection());
            sqlCommand.ExecuteNonQuery();
            dataBase.closeConnection();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
