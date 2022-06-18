using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WorkersCRUD
{

   

    internal class TxtFileDatabaseRepository
    {
        const string fileName = "fileDB.txt";
        string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);

        public void Write(WorkerModel worker)
        {
                if(Regex.IsMatch(worker.Salary, "^[0-9]+$"))
                {
                      using (StreamWriter sw = File.AppendText(path))
                      {
                           sw.WriteLine(worker.FirstName + ";" + worker.LastName + ";" + worker.Position + ";" + worker.Salary + ";");
                      }
                }
        }

        public void Delete(WorkerModel workerModel)
        {

            List<string> lines = new List<string>();
            List<WorkerModel> workers = new List<WorkerModel>();
            if(File.Exists(path))
             lines = File.ReadAllLines(path).ToList();

            foreach(string line in lines)
            {
                string[] items = line.Split(';');
                WorkerModel w = new WorkerModel(items[0], items[1], items[2], items[3]);
                if (!string.Equals(w.FirstName, workerModel.FirstName) && !string.Equals(w.LastName, workerModel.LastName))
                    workers.Add(w);
                
                    
            }

            File.Delete(path);

            foreach(WorkerModel worker in workers)
            {
                Write(worker);
            }

        }

        public void Update(WorkerModel oldWorker, WorkerModel updatedWorker)
        {
            List<string> lines = new List<string>();
            List<WorkerModel> workers = new List<WorkerModel>();

            lines = File.ReadAllLines(path).ToList();

            foreach (string line in lines)
            {
                string[] items = line.Split(';');
                WorkerModel w = new WorkerModel(items[0], items[1], items[2], items[3]);
                if (string.Equals(w.FirstName, oldWorker.FirstName)&&string.Equals(w.LastName,oldWorker.LastName))
                {
                    w.FirstName = updatedWorker.FirstName;
                    w.LastName = updatedWorker.LastName;
                    w.Position = updatedWorker.Position;
                    w.Salary = updatedWorker.Salary;
                }
                    workers.Add(w);
            }
            File.Delete(path);
            foreach (WorkerModel worker in workers)
            {
                Write(worker);
            }
        }




    }
}
