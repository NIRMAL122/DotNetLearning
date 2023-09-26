namespace SingletonDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton obj= Singleton.getInstance;
            obj.Print("Charlie");

            Singleton obj1 = Singleton.getInstance;
            obj1.Print("Laurel");
            
            Singleton obj2 = Singleton.getInstance;
            obj1.Print("BonBon");
        }
    }
}