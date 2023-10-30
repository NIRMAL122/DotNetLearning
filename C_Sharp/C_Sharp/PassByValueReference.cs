using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    static class PassByValueReference
    {
        public static void PassByValue(int j)
        {
            j = 100;
        }

        public static void PassByReference(ref int j)
        {
            j = 100; 
        }
    }
}
