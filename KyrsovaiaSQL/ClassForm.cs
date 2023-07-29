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
using DataBaseConnectionTool;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KyrsovaiaSQL
{
    public partial class ClassForm : Form
    {
        private string[] ages =
        {
            "20","21","22"
        };

        DataBase dataBase = new DataBase();

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

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateBase();
        }

        private void UpdateBase()
        {
            dataGridView3.Rows.Clear();
            dataBase.openConnection();// открываем связь с базой данных
            SqlCommand command = new SqlCommand("SELECT *  FROM Class",//создаём заготовку запроса к базе данных 
                dataBase.GetConnection());// передаём данные для соединения
            using (SqlDataReader reader = command.ExecuteReader())// формируем экземпляр для чтения данных команды 
            {
                while (reader.Read())// считывает данные следующей строки(табицы / запросов)
                {
                    string id = reader[0].ToString();
                    object name = reader[1];//object это обёртка для типа string, может быть обёрткой для любого типа
                    dataGridView3.Rows.Add(id, name);
                }
            }
            dataBase.closeConnection();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                dataBase.openConnection();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Class (Name) VALUES ('" + textBox1.Text + "')",
                     dataBase.GetConnection());
                sqlCommand.ExecuteNonQuery();
                dataBase.closeConnection();
            }
            UpdateBase();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView3.CurrentCell.RowIndex;
            string id = dataGridView3.Rows[index].Cells[0].Value.ToString();
            dataBase.openConnection();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Class WHERE Id = " + id,
                dataBase.GetConnection());
            sqlCommand.ExecuteNonQuery();
            dataBase.closeConnection();
            UpdateBase();
        }
    }
   // SqlCommand command = new SqlCommand("SELECT *  FROM Class", dataBase.GetConnection());
}
