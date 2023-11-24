using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class CountOccurance
    {
        public void count(string str)
        {
            string[] s= str.Split(',');
            Dictionary<string,int>dict= new Dictionary<string,int>();
            foreach(string st in s)
            {
                if (dict.ContainsKey(st))
                {
                    dict[st]++;
                }
                else
                {
                    dict.Add(st, 1);
                }
            }

            foreach(KeyValuePair<string,int> kvp in dict)
            {
                Console.WriteLine("{0} : {1}", kvp.Key,kvp.Value);
            }
        }
    }
}
