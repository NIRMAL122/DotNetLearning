using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class EagerLoadingSingleton
    {
        private static int counter = 0;
        private static readonly EagerLoadingSingleton obj = new EagerLoadingSingleton();
        private EagerLoadingSingleton()
        {
            counter++;
            Console.WriteLine("object Created {0}", counter);
        }

        public static EagerLoadingSingleton getInstance()
        {
            return obj;
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}


//1) The Singleton class EagerLoadingSingleton has a private static instance
//variable(obj) that is created and initialized when the class is loaded.
//This ensures that the instance is created eagerly when the application starts.

//2) The constructor of the Singleton is private to prevent external
//instantiation, ensuring that no other instances of the class can be created.

//3) The public method getInstance provides access to the single instance,
//allowing you to retrieve it wherever needed.
