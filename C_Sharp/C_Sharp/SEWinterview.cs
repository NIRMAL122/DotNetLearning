using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class SEWinterview
    {
        
    }
    public class Parent
    {
        public void print()
        {
            Console.WriteLine("parent");

            


        }

        
    }

    public class Child:Parent
    {
        public void print()
        {
            Console.WriteLine("Child");
        }
    }


}
