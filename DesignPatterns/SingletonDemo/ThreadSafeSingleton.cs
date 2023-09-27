using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class ThreadSafeSingleton
    {
        private static int counter = 0;
        private static ThreadSafeSingleton instance = null;

        //for Lock
        private static readonly object obj = new object();
        public static ThreadSafeSingleton getInstance()
        {

            if (instance == null)
            {
                //using lock to avoid the creation of multiple object in multithread
                //environment
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new ThreadSafeSingleton();
                    }
                }
            }
            return instance;


        }
        private ThreadSafeSingleton()
        {
            counter++;
            Console.WriteLine("object {0}", counter);
        }



        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
