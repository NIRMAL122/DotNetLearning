using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class CoffeeShopUsingSwitch
    {
        public void Coffee()
        {
            int totalCoffeeCost = 0;

            start:
            Console.WriteLine("1- Small\n2- Medium\n3- Large");
            Console.WriteLine("Choose Size of Coffee");
            int userChoice= int.Parse(Console.ReadLine());

            switch(userChoice)
            {
                case 1:
                    totalCoffeeCost += 1;
                    break;
                case 2:
                    totalCoffeeCost += 2;
                    break;

                case 3:
                    totalCoffeeCost += 3;
                    break;
                default:
                    Console.WriteLine("invalid choice {0}", userChoice);
                    goto start;
            }
            decissionLocation:
            Console.WriteLine("Do you want to buy another coffee - Yes or No?");
            string decission= Console.ReadLine();

            switch (decission.ToUpper())
            {
                case "YES":
                    goto start;
                case "NO":
                    break;
                default:
                    Console.WriteLine("Invalid choice {0}", decission);
                    goto decissionLocation;
            }

            Console.WriteLine("Thank you for shopping with us");
            Console.WriteLine("Bill Amount is {0}", totalCoffeeCost);
        }
    }
}

//break:- if break statement is used inside a switch statement, the control will leave
//switch statement.

//goto Statement:- you can either jump to another case statement, or to a specfic label


