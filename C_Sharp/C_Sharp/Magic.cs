using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class Magic
    {
        public void MagicFun()
        {
            Console.Write("Think of any name: ");
            string name = Console.ReadLine();

            int durationInSeconds = 5;
            DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);

            Console.Write("Reading your Mind");
            while (DateTime.Now < endTime)
            {
                Console.Write(".");
                Thread.Sleep(1000); // Sleep for 1 second (1000 milliseconds)
            }

            Console.WriteLine();

            Console.WriteLine("you are thinking about {0}", name);
        }
    }
}
