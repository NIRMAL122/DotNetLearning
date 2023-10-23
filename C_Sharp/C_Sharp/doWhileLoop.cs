using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    static class doWhileLoop
    {

        public static void fun()
        {
            string userChoice = "";
            do
            {
                Console.WriteLine("Enter your target: ");
                int num = int.Parse(Console.ReadLine());

                int i = 0;
                while (i <= num)
                {
                    Console.WriteLine(i);
                    i = i + 2;
                }


                do
                {
                    Console.WriteLine("Do you want to Continue - Yes or No");
                    userChoice = Console.ReadLine().ToUpper();
                    if (userChoice != "YES" && userChoice != "NO")
                    {
                        Console.WriteLine("Invalid choice, Please say YES or NO");
                    }
                }
                while (userChoice != "YES" && userChoice != "NO");

            }
            while (userChoice != "NO");
        } 
    }
}
