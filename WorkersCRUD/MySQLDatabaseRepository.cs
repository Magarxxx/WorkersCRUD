using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkersCRUD
{
     class MySQLDatabaseRepository
    {

      public static MySqlConnection GetConnection()
        {
            string DatabaseProperties = "datasource=localhost;port=3306;username=root;password=admin;database=workerschema";

            MySqlConnection con = new MySqlConnection(DatabaseProperties);

            try
            {
                con.Open();
            } 
            catch(MySqlException e)
            {
                MessageBox.Show("Połączenie z bazą danych \n" + e.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return con;
        }

        public void AddWorker(WorkerModel worker)
        {
 
            string sql = "INSERT INTO worker_table VALUES (NULL, @WorkerFirstName,@WorkerLastName,@WorkerPosition,@WorkerSalary)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@WorkerFirstName", MySqlDbType.VarChar).Value = worker.FirstName;
            cmd.Parameters.Add("@WorkerLastName", MySqlDbType.VarChar).Value = worker.LastName;
            cmd.Parameters.Add("@WorkerPosition", MySqlDbType.VarChar).Value = worker.Position;
            cmd.Parameters.Add("@WorkerSalary", MySqlDbType.VarChar).Value = worker.Salary;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Pracownik dodany pomyślnie", "infomracja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(MySqlException e)
            {
                MessageBox.Show("Pracownik nie został zapisany \n" + e.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
 
        }

        public void UpdateWorker(WorkerModel worker, string id)
        {
            string sql = "UPDATE worker_table SET firstName = @WorkerFirstName, lastName = @WorkerLastName, position = @WorkerPosition, salary=@WorkerSalary WHERE id = @WorkerId";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@WorkerId", MySqlDbType.Int64).Value = id;
            cmd.Parameters.Add("@WorkerFirstName", MySqlDbType.VarChar).Value = worker.FirstName;
            cmd.Parameters.Add("@WorkerLastName", MySqlDbType.VarChar).Value = worker.LastName;
            cmd.Parameters.Add("@WorkerPosition", MySqlDbType.VarChar).Value = worker.Position;
            cmd.Parameters.Add("@WorkerSalary", MySqlDbType.Int32).Value = worker.Salary;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Pracownik edytowany pomyślnie", "infomracja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Pracownik nie został edytowany \n" + e.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }

        public  void DeleteWorker(string id)
        {
            string sql = "DELETE FROM worker_table WHERE id = @WorkerId";

            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@WorkerId", MySqlDbType.Int32).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Pracownik usunięty pomyślnie", "infomracja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Pracownik nie został usunięty \n" + e.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }

        public static void DisplayAndSearchWorker(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgv.DataSource = table;
            con.Close();
        }

    }
}
