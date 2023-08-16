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
using System.Xml.Linq;

namespace KyrsovaiaSQL
{
    public partial class SubjectsForm : Form
    {
        public SubjectsForm()
        {
            InitializeComponent();
        }

        DataBase dataBase = new DataBase();
        DataBaseTableEditor tableEditor = new DataBaseTableEditor("Subject");
        

        private void SubjectsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolMagazineSubjectData.Subject". При необходимости она может быть перемещена или удалена.
            this.subjectTableAdapter1.Fill(this.schoolMagazineSubjectData.Subject);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolMagazineDataSet2.Subject". При необходимости она может быть перемещена или удалена.
            this.subjectTableAdapter.Fill(this.schoolMagazineDataSet2.Subject);

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //name = dataGridView2.Rows[index].Cells[1].Value?.ToString() ?? ""; // Value? останавливает дальнейшиq вызов ToString, ?? - если слева от этого символа null, то вернётся значение указанное справа 
            textBox2.Text = tableEditor.GetCellValue(dataGridView2, 1);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void RefreshTable()
        {
            dataGridView2.Rows.Clear();
            dataBase.openConnection();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Subject", dataBase.GetConnection());
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string id = reader[0].ToString();
                    object name = reader[1];
                    dataGridView2.Rows.Add(id, name);
                }
                dataBase.closeConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            tableEditor.InsertRow(name);
            RefreshTable();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            string id = tableEditor.GetCellValue((DataGridView)sender,0);
            tableEditor.DeleteRow(id);
            RefreshTable();

        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            int index = dataGridView2.CurrentCell.RowIndex;
            string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
            tableEditor.UpdateRow(name, id);
            RefreshTable();
        }

       

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            textBox2.Text = tableEditor.GetCellValue(dataGridView, 1);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string id = tableEditor.GetCellValue((DataGridView)sender, 0);
            tableEditor.DeleteRow(id);
        }
    }
}
