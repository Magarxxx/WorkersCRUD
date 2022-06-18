using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkersCRUD
{
    public partial class FormWorker : Form
    {
        private readonly FormWorkersInfo _parent;
        public string id, firstName, lastName, position, salary;
        WorkerModel oldWorker = new WorkerModel("", "", "", "");

        WorkerService workerService = new WorkerService();
       

        public FormWorker(FormWorkersInfo parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void SaveInfo()
        {
            Clear();
            lbltext.Text = "Zapisz pracownika";
            btnSave.Text = "Zapisz";
        }

        public void UpdateInfo()
        {
            lbltext.Text = "Edytuj pracownika";
            btnSave.Text = "Edytuj";
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtPosition.Text = position;
            txtSalary.Text = salary;

            oldWorker.FirstName = firstName;
            oldWorker.LastName = lastName;
            oldWorker.Position = position;
            oldWorker.Salary = salary;
        }

        public void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtPosition.Text = txtSalary.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtPosition.Text) || string.IsNullOrEmpty(txtSalary.Text))
            {
                MessageBox.Show("Wszystkie pola muszą być uzupełnione!");
                return;
            }

            if(btnSave.Text == "Zapisz")
            {
                WorkerModel newWorker = new WorkerModel(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtPosition.Text.Trim(), txtSalary.Text.Trim());
                workerService.CreateWorker(newWorker);
                Clear();
            }
            if(btnSave.Text == "Edytuj")
            {
                WorkerModel worker = new  WorkerModel(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtPosition.Text.Trim(), txtSalary.Text.Trim());
             
                workerService.UpdateWorker(oldWorker, worker, id);
                this.Close();
            }
            _parent.Display();
        }

        
    }
}
