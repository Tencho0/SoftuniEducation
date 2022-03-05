using System;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double result = 0;

            
            if(figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double result = a * a;
                
            }
            else if(figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double  = a * b;
            }

            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double d = r * r;
                double  = d * Math.PI;
            }

           else if (figure == "triangle") ;
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());

                double  = a * h * 0.5;
            }

            Console.WriteLine($"{:F3}");
        }
    }
}
