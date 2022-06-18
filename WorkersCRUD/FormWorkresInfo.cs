using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkersCRUD
{
    public partial class FormWorkersInfo : Form
    {
        FormWorker form;
        WorkerService workerService = new WorkerService();
       
        public FormWorkersInfo()
        {
            InitializeComponent();
            form = new FormWorker(this);

        }

        public void Display()
        {
             MySQLDatabaseRepository.DisplayAndSearchWorker("SELECT * FROM worker_table", dataGridView);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MySQLDatabaseRepository.DisplayAndSearchWorker("SELECT * FROM worker_table WHERE lastName LIKE '%" + txtSearch.Text + "%'", dataGridView);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.ShowDialog();
        }

        private void FormWorkersInfo_Shown(object sender, EventArgs e)
        {
            Display();
        }


        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.firstName = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.lastName = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.position = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.salary = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
              
                form.UpdateInfo();
                form.ShowDialog();
                
                return;
            }
            if(e.ColumnIndex == 1)
            {
               if(MessageBox.Show("Czy chcesz usunąć tego pracownika?", "Informacja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)== DialogResult.Yes)
                {
                  
                    workerService.DeleteWorker(new WorkerModel(
                        dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString(),
                        dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString(),
                        dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString()), dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    
                    Display();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
         

            const string fileName = "fileDB.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);

     
                using (StreamWriter sw = File.AppendText(path))
                {
                   sw.Write("");
                }


            StreamReader stream = new StreamReader(path);

            dataGridView.Visible = false;
                richTextBox1.Visible = true;
                string filedata = stream.ReadToEnd();
                richTextBox1.Text = "imie;nazwisko;stanowisko;wypłata \n"+filedata.ToString();
                
            stream.Close();

        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            dataGridView.Visible = false;
            richTextBox1.Visible = true;

            const string fileName = "jsonDB.json";
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);

            StreamReader stream = new StreamReader(path);

            dataGridView.Visible = false;
            richTextBox1.Visible = true;
            string filedata = stream.ReadToEnd();

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var jsonElement = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(filedata);

            richTextBox1.Text = System.Text.Json.JsonSerializer.Serialize(jsonElement, options);
            stream.Close();

        }

        private void btnDb_Click(object sender, EventArgs e)
        {
            dataGridView.Visible = true;
            richTextBox1.Visible = false;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
        }
    }
}
