using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    static class OutKeyword
    {
        public static void calculate(int x,int y, out int sum, out int product)
        {
            sum = x + y;
            product = x * y;
        }
    }
}
