using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseConnectionTool
{
    public class DataBaseTableEditor // создание класса DataBaseTableEditor
    {

        private string tableName = "";
        private string parametr1 = "";
        

        private DataBase dataBase = new DataBase();


        public DataBaseTableEditor(string tableName) // создание конструктора класса DataBaseTableEditor ,
            // где  tableName присваиваем значение одного из четырёх вариантов каждого класса
        {
            this.tableName = tableName;
            
            switch (tableName)
            {
                case "Teacher":
                    parametr1 = "fio";
                    break;

                default:
                    parametr1 = "Name";
                    break;
            }
            
               
        }

        public void InsertRow(string name)
        {
            if (name!=null && name.Length > 0)
            {
                dataBase.openConnection();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO " + tableName + " (" + parametr1 + ") VALUES ('" + name + "')",
                    dataBase.GetConnection());
                sqlCommand.ExecuteNonQuery();
                dataBase.closeConnection();

            }
        }
        public void DeleteRow(string id)
        {
            if (id.Length > 0)
            {
                dataBase.openConnection();
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM " + tableName + " WHERE Id = " + id,
                    dataBase.GetConnection());
                sqlCommand.ExecuteNonQuery();
                dataBase.closeConnection();
            }
           
        }
        public void UpdateRow(string name,string id)
        {
            if (name.Length > 0)
            {
                dataBase.openConnection();
                SqlCommand sqlCommand = new SqlCommand("UPDATE " + tableName + " SET " + parametr1 + " = ('" + name + "') WHERE Id = ('" + id + "')",
                    dataBase.GetConnection());
                sqlCommand.ExecuteNonQuery();
                dataBase.closeConnection();
            }
        }
        public string GetCellValue(DataGridView dataGridView, int cellIndex)
        {
            
            int index = -1;
            if(dataGridView.CurrentCell != null)
            {
                index = dataGridView.CurrentCell.RowIndex;
            }
            else if(dataGridView.CurrentRow != null)
            {
                index = dataGridView.CurrentRow.Index;
            }
            else
            {
                return "";
            }
            
            string name = "";
            if (dataGridView.Rows[index].Cells[cellIndex].Value != null)
            {
                name = dataGridView.Rows[index].Cells[cellIndex].Value.ToString();
            }
            return name;
        }
    }
}


