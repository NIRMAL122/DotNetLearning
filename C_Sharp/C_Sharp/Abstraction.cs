using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class Abstraction
    {
        public  void calculate(int x, int y)
        {
            int s = sum(x, y);
            int m = minus(x, y);
            int mul = multiply(x, y);

            Console.WriteLine("Sum= {0}", s);
            Console.WriteLine("Minus= {0}",m);
            Console.WriteLine("Multiply= {0}",mul);
        }

        private int sum(int x, int y)
        {
            return x+ y;
        }
        private int minus(int x, int y)
        {
            return x - y;
        }
        private int multiply(int x, int y)
        {
            return x * y;
        }
    }
}
