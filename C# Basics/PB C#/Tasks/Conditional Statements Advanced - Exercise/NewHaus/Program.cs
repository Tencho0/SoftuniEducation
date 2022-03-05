using System;

namespace NewHaus
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            const double rosesPricePer1 = 5;
            const double dahliasPricePer1 = 3.8;
            const double tulipsPricePer1 = 2.8;
            const double nnarcissusPricePer1 = 3;
            const double gladiolusPricePer1 = 2.5;
            double discount = 0;
            double price = 0;
            if(flower == "Roses")
            {
                if (num >= 80)
                {
                    price = rosesPricePer1 * num;
                    discount = 0.1;
                }
                else
                {
                    price = num * rosesPricePer1 
                }


            }





            price = num * rosesPricePer1


        }
    }
}
