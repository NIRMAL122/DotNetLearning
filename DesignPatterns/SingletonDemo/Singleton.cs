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

        public static Singleton getInstance()
        {

            
            if (instance == null)
            {
               instance = new Singleton();
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

//While a private constructor prevents external instantiation, it is still
//possible for a developer to create a subclass that inherits from the Singleton
//class and introduces a second instance of the class. By marking the class
//as sealed, you explicitly disallow any inheritance, ensuring that no subclass
//can create its own instance.
