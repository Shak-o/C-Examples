using Solid.ISP.Interfaces;

namespace Solid.ISP.Models
{
    public class NormalEmployee : IEmployee
    {
        public NormalEmployee(string name, string position)
        {
            Name = name;
            Position = position;
            Salary = WorkedHours * HourlyRate;
        }

        public int Id { get; set; }
        public int WorkedHours { get; set; }
        public int HourlyRate { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
    }
}
