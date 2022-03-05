using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal currBalance = decimal.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            decimal totalPriceForGames = 0;
            while (command != "Game Time")
            {
                decimal priceForCurrGame = 0;
                if (currBalance == 0)
                {
                    break;
                }
                if (command == "OutFall 4")
                {
                    priceForCurrGame = 39.99M;
                    if (priceForCurrGame > currBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        priceForCurrGame = 0;
                    }
                    else
                    {
                        currBalance -= priceForCurrGame;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else if (command == "CS: OG")
                {
                    priceForCurrGame = 15.99M;
                    if (priceForCurrGame > currBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        priceForCurrGame = 0;
                    }
                    else
                    {
                        currBalance -= priceForCurrGame;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else if (command == "Zplinter Zell")
                {
                    priceForCurrGame = 19.99M;
                    if (priceForCurrGame > currBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        priceForCurrGame = 0;
                    }
                    else
                    {
                        currBalance -= priceForCurrGame;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else if (command == "Honored 2")
                {
                    priceForCurrGame = 59.99M;
                    if (priceForCurrGame > currBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        priceForCurrGame = 0;
                    }
                    else
                    {
                        currBalance -= priceForCurrGame;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else if (command == "RoverWatch")
                {
                    priceForCurrGame = 29.99M;
                    if (priceForCurrGame > currBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        priceForCurrGame = 0;
                    }
                    else
                    {
                        currBalance -= priceForCurrGame;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    priceForCurrGame = 39.99M;
                    if (priceForCurrGame > currBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        priceForCurrGame = 0;
                    }
                    else
                    {
                        currBalance -= priceForCurrGame;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                totalPriceForGames += priceForCurrGame;
                command = Console.ReadLine();
            }
            if (currBalance <= 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${totalPriceForGames:F2}. Remaining: ${currBalance:f2}");
            }
        }
    }
}
