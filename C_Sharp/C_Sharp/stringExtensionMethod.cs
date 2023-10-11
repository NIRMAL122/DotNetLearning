
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public static class stringExtensionMethod
    {
        public static int wordCount(this string str)
        {
            string s=str.Replace(" ", "");
            return s.Length;
        }
    }
}
