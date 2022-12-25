using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.ISP.Interfaces;

namespace Solid.ISP.Models
{
    public class ExternalEmployee : IEmployee
    {
        public ExternalEmployee(string name, string position)
        {
            Name = name;
            Position = position;
            Salary = ContractedSalary + Bonus;
        }

        public int Id { get; set; }
        public int ContractedSalary { get; set; }
        public int Bonus { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
    }
}
