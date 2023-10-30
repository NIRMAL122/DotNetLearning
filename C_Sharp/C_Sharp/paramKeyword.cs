using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class paramKeyword
    {
        public static void paramMethod(params int[] nums)
        {
            Console.WriteLine("there are {0} elements", nums.Length);
            foreach(int i in nums)
            {
                Console.WriteLine(i);
            }
        }
    }
}
