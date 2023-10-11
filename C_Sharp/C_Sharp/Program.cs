namespace C_Sharp
{
    public class Program
    {
        static void Main(string[] args)
        {

            TwoInterfacesWithSameMethod obj= new TwoInterfacesWithSameMethod();
            ((A)obj).print();


            string name = "nirmal singh";
            Console.WriteLine(name.wordCount());
        }
    }

}