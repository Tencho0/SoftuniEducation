using System;

namespace Conditional_Statements
{
    class Program
    {
        static void Main(string[] args)
        {


            int age = 15;

            bool isOfAge = age >= 18;

            if (isOfAge == true)
            {
                Console.WriteLine("You can drive a car!");
            }
            else
            {
                Console.WriteLine("You cant drive a car");

            }

        }
    }
}
