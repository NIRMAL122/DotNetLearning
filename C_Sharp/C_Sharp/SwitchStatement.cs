using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class SwitchStatement
    {
        public void SwitchFun()
        {
            Console.WriteLine("Enter Number: ");
            int num= int.Parse(Console.ReadLine());

            switch (num)
            {
                case 10:
                case 20:
                case 30:
                    Console.WriteLine("you entered {0}", num);
                    break;
                default:
                    Console.WriteLine("hehe");
                    break;
            }
        }
    }
}


//Case statements, with no code in-between, creates a single case for multiple values.
// A case without any code will automatically fall through to the next case. In this 
//example, case 10 and case 20 will fall through and execute code for case 30.
