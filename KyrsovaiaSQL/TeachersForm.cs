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
        DataBaseTableEditor tableEditor = new DataBaseTableEditor("Teacher");


        private void TeachersForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "teacherDataSet.Teacher". При необходимости она может быть перемещена или удалена.
            this.teacherTableAdapter2.Fill(this.teacherDataSet.Teacher);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolMagazineTeacherDataSet.Teacher". При необходимости она может быть перемещена или удалена.
            //this.teacherTableAdapter1.Fill(this.schoolMagazineTeacherDataSet.Teacher);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolMagazineDataSet1.Teacher". При необходимости она может быть перемещена или удалена.
            //this.teacherTableAdapter.Fill(this.schoolMagazineDataSet1.Teacher);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableUpdate();
            this.teacherTableAdapter2.Fill(teacherDataSet.Teacher);
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
            string name = textBox1.Text;
            tableEditor.InsertRow(name);
            TableUpdate();
        }

        /*private void AddTeacher()
        {
            dataBase.openConnection();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Teacher (fio) VALUES ('" + textBox1.Text + "')",
                dataBase.GetConnection());
            sqlCommand.ExecuteNonQuery();
            dataBase.closeConnection();
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
            tableEditor.DeleteRow(id);
            TableUpdate();
        }

       

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            int index = dataGridView2.CurrentCell.RowIndex;
            string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
            tableEditor.UpdateRow(name,id);
            TableUpdate();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = tableEditor.GetCellValue((DataGridView)sender,1);
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string id = tableEditor.GetCellValue((DataGridView)sender, 0);
            tableEditor.DeleteRow(id);
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            string name = e.Row.Cells[1].Value?.ToString();
            //tableEditor.InsertRow(name);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //MessageBox.Show(((DataGridView)sender).RowCount.ToString()); 
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string id = tableEditor.GetCellValue((DataGridView)sender, 0);
            string name = tableEditor.GetCellValue((DataGridView)sender, 1);
            if(int.Parse(id) < 0)
            {
                // выполняем добавление
                tableEditor.InsertRow(name);
            }
            else
            {
                // обновление 
                tableEditor.UpdateRow(name,id);
            }
            //dataGridView1.DataBindings.Control.Update();
            //dataGridView1.DataBindings.Control.Refresh();
            //dataGridView1.Update();
            //dataGridView1.Refresh();
        }
    }
    }

