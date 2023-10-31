using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class PositiveNegativePair
    {
        public void Pairs(int[] arr)
        {
            HashSet<int>dict=new HashSet<int>();
            List<int> result= new List<int>();

            foreach(int i in arr)
            {
                int a = i * -1;
                if (dict.Contains(a))
                {
                    result.Add(Math.Abs(a));
                }
                else
                {
                    dict.Add(i);
                }
            }

            foreach(int i in result)
            {
                Console.WriteLine(i);
            }
        }
    }
}
