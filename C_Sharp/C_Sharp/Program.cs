using System.Collections;

namespace C_Sharp
{
    public class Program
    {
        static void Main(string[] args)
        {

            //TwoInterfacesWithSameMethod obj= new TwoInterfacesWithSameMethod();
            //((A)obj).print();

            //string name = "100AB";

            //int num = 0;
            //int.TryParse(name,out num);

            //Console.WriteLine(num);


            //ImpetusInterview p= new ImpetusInterview();
            //p.print();

            //ImpetusInterview p1= new child();
            //p1.print();

            //child c = new child();
            //c.print();



            //var a = 5;
            //a = "hello";


            //dynamic d = 5;
            //d="hello";

            //VarDynamic obj = new VarDynamic();
            //Console.WriteLine(obj.method2("hi", 2));

            //asyncAwait obj=new asyncAwait();
            //obj.asyncAwaitFun();

            //CountOccurances obj= new CountOccurances();
            //obj.Count("occurrences");


            //CoffeeShopUsingSwitch obj = new CoffeeShopUsingSwitch();
            //obj.Coffee();

            //doWhileLoop.fun();

            //Abstraction obj= new Abstraction();
            //obj.calculate(10, 2);

            //int i = 0;
            //PassByValueReference.PassByValue(i);
            //PassByValueReference.PassByReference(ref i);
            //Console.WriteLine(i);

            //int sum = 0;
            //int product = 0;
            //OutKeyword.calculate(10, 20, out sum, out product);
            //Console.WriteLine("sum={0} and Product={1}",sum,product);

            //int[] numbers = { 1, 2, 3, 4, 5 };

            //paramKeyword.paramMethod();
            //paramKeyword.paramMethod(numbers);
            //paramKeyword.paramMethod(10,20,30);


            string input1 = "AAB";
            string input2 = "AZZ";

            NextSequence obj= new NextSequence();
            Console.WriteLine(obj.GetNextValue(input1));
            Console.WriteLine(obj.GetNextValue(input2));





        }
    }

}