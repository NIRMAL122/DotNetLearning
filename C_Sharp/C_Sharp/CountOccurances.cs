using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class CountOccurances
    {

        public void Count(string str)
        {
            Dictionary<char,int>dict= new Dictionary<char,int>();

            foreach (char c in str)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            foreach(KeyValuePair<char,int>kvp in dict) 
            {
                Console.Write("{0}{1}",kvp.Key,kvp.Value);
            }
        }
    }
}
