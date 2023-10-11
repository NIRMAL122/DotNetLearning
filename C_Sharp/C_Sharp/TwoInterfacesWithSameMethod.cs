

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class TwoInterfacesWithSameMethod : A,B
    {
         void A.print()
        {

            Console.WriteLine("A");
        }
         void B.print()
        {
            Console.WriteLine("B");
        }
    }


    

    interface A
    {
        public void print();
    }

    interface B
    {
        public void print();
    }

}

