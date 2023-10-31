using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class PaytmInterview
    {
        public  void print()
        {
            Console.WriteLine("PaytmInterview");
        }
    }
    public class PaytmInterviewChild : PaytmInterview 
    {
        public  void print2()
        {
            Console.WriteLine("B");
        }
    }

    public class C
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        //public string Add(int a,int b)
        //{
        //    return (a + b).ToString();
        //}  -> not possible because Class C already have method with same name and same parameters
    }


    interface IInterview
    {
        public void print();
    }
    interface IInterview1
    {
        public void print();
    }
    class interview : IInterview, IInterview1
    {
            public void print()
            {
                Console.WriteLine("Paytm");
            }
        
    }

}
