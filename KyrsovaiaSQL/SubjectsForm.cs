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
    public partial class SubjectsForm : Form
    {
        public SubjectsForm()
        {
            InitializeComponent();
        }

        DataBase dataBase = new DataBase();



        private void SubjectsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolMagazineDataSet2.Subject". При необходимости она может быть перемещена или удалена.
            this.subjectTableAdapter.Fill(this.schoolMagazineDataSet2.Subject);

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
            if(textBox1.Text.Length > 0)
            {
                dataBase.openConnection();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Subject (Name) VALUES ('" + textBox1.Text + "')",
                    dataBase.GetConnection());
                sqlCommand.ExecuteNonQuery();
                dataBase.closeConnection();
                UpdateBase();
            }
            UpdateBase();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
            dataBase.openConnection();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Subject WHERE Id = " + id,
                dataBase.GetConnection());
            sqlCommand.ExecuteNonQuery();
            dataBase.closeConnection();
            UpdateBase();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            if (name.Length > 0)
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
                dataBase.openConnection();
                SqlCommand sqlCommand = new SqlCommand("UPDATE Subject SET Name = ('" + name + "') WHERE Id = ('" + id + "')",
                    dataBase.GetConnection());
                sqlCommand.ExecuteNonQuery();
                dataBase.closeConnection();
                UpdateBase();
            }
        }
    }
}
