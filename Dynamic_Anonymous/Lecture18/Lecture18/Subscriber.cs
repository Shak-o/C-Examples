using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture18
{
    public class Subscriber
    {
        public void EventHandler(string message)
        {
            Console.WriteLine(message);
        }
    }
}
