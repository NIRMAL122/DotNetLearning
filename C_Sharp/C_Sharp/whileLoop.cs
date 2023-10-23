using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    static class whileLoop
    {

        public static void fun()
        {
            Console.WriteLine("Enter your target: ");
            int num= int.Parse(Console.ReadLine());

            int i = 0;
            while(i<=num)
            {
                Console.WriteLine(i);
                i = i + 2;
            }
        } 
    }
}
