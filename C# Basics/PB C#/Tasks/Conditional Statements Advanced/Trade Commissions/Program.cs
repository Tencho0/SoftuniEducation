using System;

namespace Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double trades = double.Parse(Console.ReadLine());

            double comission = 0;

            if (trades > 10000)
            {
                if (city == "Sofia")
                {
                    comission = 0.12;
                }
                else if (city == "Varna")
                {
                    comission = 0.13;
                }
                else if (city == "Plovdiv")
                {
                    comission = 0.145;
                }
            }

            else if (trades > 1000 && trades <= 10000)
            {
                if (city == "Sofia")
                {
                    comission = 0.08;
                }
                else if (city == "Varna")
                {
                    comission = 0.10;
                }
                else if (city == "Plovdiv")
                {
                    comission = 0.12;
                }
            }

            else if (trades > 500 && trades <= 1000)
            {
                if (city == "Sofia")
                {
                    comission = 0.07;
                }
                else if (city == "Varna")
                {
                    comission = 0.075;
                }
                else if (city == "Plovdiv")
                {
                    comission = 0.08;
                }
            }

            else if (trades >= 0 && trades <= 500)
            {
                if (city == "Sofia")
                {
                    comission = 0.05;
                }
                else if (city == "Varna")
                {
                    comission = 0.045;
                }
                else if (city == "Plovdiv")
                {
                    comission = 0.055;
                }
            }

            if (city != "Sofia" && city != "Plovdiv" && city != "Varna" || trades < 0)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine($"{comission * trades:F2}");
            }
        }
    }
}
