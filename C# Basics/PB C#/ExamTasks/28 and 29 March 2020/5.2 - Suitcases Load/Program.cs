using System;

namespace _5._2___Suitcases_Load
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double suitcase = 0;
            int counter = 0;
            while (input != "End")
            {
                suitcase = double.Parse(input);
                if (counter % 3 == 0 && counter != 0)
                {
                    suitcase *= 1.1;
                }
                if (capacity <= suitcase)
                {
                    break;
                }
                capacity -= suitcase;
                counter++;
                input = Console.ReadLine();
            }
            if (input == "End")
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");
            }
            else if (capacity <= suitcase)
            {

                Console.WriteLine($"No more space!");
            }
            else if(counter == 0)
            {
                counter -= 1;
                Console.WriteLine($"No more space!");
            }
            Console.WriteLine($"Statistic: {counter} suitcases loaded.");
        }
    }
}
 