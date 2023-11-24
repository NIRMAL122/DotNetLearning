using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class ReverseString
    {
        public  ReverseString(string str)
        {
            int len= str.Length;
            char[] charStr= str.ToCharArray();


            for(int i=0; i<len/2; i++)
            {
                char temp= str[i];
                charStr[i] = charStr[len-1 - i];
                charStr[len-1 - i]= temp;
            }

            string reversed= new string(charStr);
            Console.WriteLine(reversed);

        }
    }
}
