using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double pricePerLightsabers = double.Parse(Console.ReadLine());
            double pricePerRobe = double.Parse(Console.ReadLine());
            double pricePerBelt = double.Parse(Console.ReadLine());
            int freeBelts = countOfStudents / 6;
            double peopleLightsabers = 0;
            if (countOfStudents % 10 != 0)
            {
                 peopleLightsabers =countOfStudents / 10 + 1;
            }
            else
            {
                peopleLightsabers = countOfStudents / 10;
            }
            double priceForLightsabers = (countOfStudents * pricePerLightsabers) + (peopleLightsabers * pricePerLightsabers);
            double priceForRobes = countOfStudents * pricePerRobe;
            double priceForBelts = pricePerBelt * (countOfStudents - freeBelts);
            double totalPrice = priceForLightsabers + priceForRobes + priceForBelts;
            if (totalPrice <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                double neededMoney = totalPrice - money;
                Console.WriteLine($"John will need {neededMoney:f2}lv more.");
            }
        }
    }
}
