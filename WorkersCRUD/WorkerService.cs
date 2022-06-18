using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersCRUD
{
    internal class WorkerService
    {
        TxtFileDatabaseRepository fileDatabaseRepository = new TxtFileDatabaseRepository();
        JsonFileDatabaseRepository jsonFileDatabaseRepository = new JsonFileDatabaseRepository();
        MySQLDatabaseRepository mySQLDatabaseRepository = new MySQLDatabaseRepository();


        public void DeleteWorker(WorkerModel workerToDelete, string id)
        {
            fileDatabaseRepository.Delete(workerToDelete);
            mySQLDatabaseRepository.DeleteWorker(id);
            jsonFileDatabaseRepository.ConvertToJson();
        }

        public void UpdateWorker(WorkerModel oldWorker, WorkerModel updatedWorker, string id)
        {
            mySQLDatabaseRepository.UpdateWorker(updatedWorker, id);
            fileDatabaseRepository.Update(oldWorker, updatedWorker);
            jsonFileDatabaseRepository.ConvertToJson();
        }

        public void CreateWorker(WorkerModel worker )
        {
            mySQLDatabaseRepository.AddWorker(worker);
            fileDatabaseRepository.Write(worker);
            jsonFileDatabaseRepository.ConvertToJson();
        }
    }
}
