using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Tests
{
    public static class UnitTestFunctionTest
    {
        //Test func naming convention- className_MethodName_ExpectedResult
        public static void UnitTestFunction_ReturnNameIfZero_ReturnString()
        {
            try
            {
                //Arrange
                int num = 0;
                UnitTestFunction UTF = new UnitTestFunction();

                //Act
                string result=UTF.ReturnNameIfZero(num);

                //Assert
                if (result == "Nirmal")
                {
                    Console.WriteLine("Passed");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
