using System;

namespace Area_Of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            double result = 0;
           
            if (figure =="square")
            {
                double a = double.Parse(Console.ReadLine());
                result = a * a;
            }

            else if (figure == "rectangle") 
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                result = a * b;
            }

            else if (figure == "circle") 
            {
                double r = double.Parse(Console.ReadLine());
                result = r * r * Math.PI;
            }

            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());
                result = a * ha / 2;
            }
            Console.WriteLine($"{result:F3}");

        }
    }
}
