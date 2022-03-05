using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = "a";
            double money = 0;

            if(budget <= 100)
            {
                place = "Somewhere in Bulgaria";
                    switch(season)
                {
                    case "summer":
                        money = budget * 0.3;
                        break;
                    case "winter":
                        money = budget * 0.7;
                        break;
                }
            }
            else if (budget <= 1000)
            {
                place = "Somewhere in Balkans";
                switch (season)
                {
                    case "summer":
                        money = budget * 0.4;
                        break;
                    case "winter":
                        money = budget * 0.8;
                        break;
                }
            }
            else if (budget > 1000)
            {
                place = "Somewhere in Europe";
                       switch (season)
                {
                    case "summer":
                    case "winter":
                        money = budget * 0.9;
                        break;
                }
            }    
            string room = "b";
            if (budget > 1000 || season == "winter")
            {
                room = "Hotel";
            }
            else
            {
                room = "Camp";
            }
            Console.WriteLine(place);
            Console.WriteLine($"{room} - {money:F2}");
        }
    }
}
