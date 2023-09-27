using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class LazyLoadingSingleton
    {
        private static int counter = 0;
        private static readonly Lazy<LazyLoadingSingleton> obj=
                new Lazy<LazyLoadingSingleton>(()=>new LazyLoadingSingleton());
        private LazyLoadingSingleton()
        {
            counter++;
            Console.WriteLine("object created {0}", counter);
        }

        public static LazyLoadingSingleton getInstance()
        {
            return obj.Value;
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}

//1) The Singleton class LazyLoadedSingleton uses the Lazy<T> type to
//achieve lazy loading. The Lazy<T> type allows you to specify how the instance
//should be created when it is first accessed.

//2) The lazyInstance field is a private static field that holds the
//Lazy<LazyLoadedSingleton> instance, which will be responsible for creating and
//holding the Singleton instance when needed.

//3) The constructor of the Singleton is private to prevent external instantiation,
//ensuring that no other instances of the class can be created.

//4) The public property Instance provides access to the single instance.
//When Instance is accessed for the first time, the Value property of the Lazy
//instance is used to create and return the Singleton instance. Subsequent calls
//to Instance return the same instance without recreating it.
