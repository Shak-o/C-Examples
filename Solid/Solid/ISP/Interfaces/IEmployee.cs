using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.ISP.Interfaces
{
    public interface IEmployee : IBaseModel
    {
        public string Position { get; set; }
        public int Salary { get; set; }

    }
}
