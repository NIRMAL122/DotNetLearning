using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed  class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;

        //for Lock
        private static readonly object obj = new object();
        public static Singleton getInstance()
        {

            if (instance == null)
            {
                //using lock to avoid the creation of multiple object in multithread
                //environment
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
            
            
        }
        private Singleton()
        {
            counter++;
            Console.WriteLine("object {0}", counter);
        }



        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        //nested derived class
        //public class b: Singleton
        //{

        //}
    }
}
