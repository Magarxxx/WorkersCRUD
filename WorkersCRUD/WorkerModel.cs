using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersCRUD
{
    internal class WorkerModel
    {
      

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }

        public WorkerModel(string firstName, string lastName, string position, string salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            Salary = salary;
        }
    }
}
