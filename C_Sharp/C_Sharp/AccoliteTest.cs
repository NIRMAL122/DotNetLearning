using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    class x
    {
        public virtual void print() { Console.WriteLine("x"); }
    }
    class y:x
    {
        public new void print() { Console.WriteLine("y"); }
        public new void print1() { Console.WriteLine("print1"); }
    }
    
}
