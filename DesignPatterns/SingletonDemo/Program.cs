namespace SingletonDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton obj= Singleton.getInstance();
            obj.Print("Charlie");

            Singleton obj1 = Singleton.getInstance();
            obj1.Print("Laurel");
            
            Singleton obj2 = Singleton.getInstance();
            obj1.Print("BonBon");

            //with the help of nested drived class we can create new object
            //of singleton class. which is not good. thats why we use "SEALED" keyword 
            //to avoid inheritance
            //Singleton.b obj3 = new  Singleton.b();
            //obj3.Print("Annalise");
        }
    }
}