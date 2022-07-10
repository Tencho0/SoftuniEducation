namespace T05.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static int boughtFood = 0;
        static Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
        static void Main(string[] args)
        {
            AddBuyers();
            string command = Console.ReadLine();
            while (command != "End")
            {
                if (buyers.ContainsKey(command))
                    boughtFood += buyers[command].BuyFood();

                command = Console.ReadLine();
            }
            Console.WriteLine(boughtFood);
        }

        private static void AddBuyers()
        {
            IBuyer buyer = null;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = givenCmd[0];
                int age = int.Parse(givenCmd[1]);

                if (givenCmd.Length == 4)
                {
                    string id = givenCmd[2];
                    string birthdate = givenCmd[3];
                    buyer = new Citizen(name, age, id, birthdate);
                }
                else if (givenCmd.Length == 3)
                {
                    string group = givenCmd[2];
                    buyer = new Rebel(name, age, group);
                }
                buyers[name] = buyer;
            }
        }
    }
}
