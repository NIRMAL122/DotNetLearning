
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class asyncAwait
    {
        /// <summary>
        /// this class for testing the working of async and await
        /// </summary>
        /// <returns></returns>
        private async Task<int> CountChar()
        {
            int count = 0;
            using(StreamReader reader= new StreamReader("C:\\Users\\asus\\Desktop\\Notepad++\\asynAwait.txt"))
            {
                string content= reader.ReadToEnd();
                count= content.Length;
                Thread.Sleep(5000);
            }

            return count;
        }

        public async void asyncAwaitFun()
        {
            Console.WriteLine("Start");

            int count= await CountChar();
            Console.WriteLine(count);

            Console.WriteLine("counting");
            Console.WriteLine("End");
        }

    }
}
