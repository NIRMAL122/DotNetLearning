using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
     sealed class Class1
    {
        public Class1()
        {
            Console.WriteLine("object created");
        }
        public void hello()
        {
            Console.WriteLine("hello"); 
        }

        public static void hi()
        {
            Console.WriteLine("hi");
        }
    }
}
