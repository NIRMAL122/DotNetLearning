namespace SingletonDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Parallel.Invoke(
                ()=>PersonOne(),
                ()=>PersonTwo()
                );


            //with the help of nested drived class we can create new object
            //of singleton class. which is not good. thats why we use "SEALED" keyword 
            //to avoid inheritance
            //Singleton.b obj3 = new  Singleton.b();
            //obj3.Print("Annalise");


            //Singleton objj = Singleton.getInstance();
            //objj.Print("eh");
            //Singleton objjj = Singleton.getInstance();
            //objj.Print("ho");

            
        }

        private static void PersonOne()
        {
            ThreadSafeSingleton obj = ThreadSafeSingleton.getInstance();
            obj.Print("Charlie");
        }

        private static void PersonTwo()
        {
            ThreadSafeSingleton obj1 = ThreadSafeSingleton.getInstance();
            obj1.Print("Laurel");
        }
    }
}