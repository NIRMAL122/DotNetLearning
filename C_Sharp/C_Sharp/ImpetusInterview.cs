
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class ImpetusInterview
    {
        public virtual void print()
        {
            Console.WriteLine("Parent Class");
        }
    }


    public class child : ImpetusInterview
    {
        public override void print()
        {
            Console.WriteLine("Child Class");
        }
    }

}
