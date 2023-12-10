using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class UnitTestFunction
    {
        public string ReturnNameIfZero(int num)
        {
            if (num == 0)
            {
                return "Nirmal";
            }
            else
            {
                return "Nothing";
            }
        }
    }
}
