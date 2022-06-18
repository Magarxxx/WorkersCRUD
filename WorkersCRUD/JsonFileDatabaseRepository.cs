using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorkersCRUD
{
    internal class JsonFileDatabaseRepository
    {
        const string fileNametxt = "fileDB.txt";
        const string fileNamejson = "jsonDB.json";
        string pathtxt = Path.Combine(Environment.CurrentDirectory, @"Data\", fileNametxt);
        string pathjson = Path.Combine(Environment.CurrentDirectory, @"Data\", fileNamejson);

        public void ConvertToJson()
        {
            List<string> lines = new List<string>();
            List<WorkerModel> workers = new List<WorkerModel>();
            if (File.Exists(pathtxt))
                lines = File.ReadAllLines(pathtxt).ToList();

            foreach (string line in lines)
            {
                string[] items = line.Split(';');
                WorkerModel w = new WorkerModel(items[0], items[1], items[2], items[3]);
                    workers.Add(w);

            }

            var json = JsonConvert.SerializeObject(workers);

            File.WriteAllText(pathjson, json);
        }

   
    }
}
