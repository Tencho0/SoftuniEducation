namespace FoodShortage
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private int totalFood;
        private Dictionary<string, IBuyer> repository;

        public Engine()
        {
            this.repository = new Dictionary<string, IBuyer>();
        }
        public void Run()
        {
            AddInSociety();
            BuyFood();
            Console.WriteLine(totalFood);
        }

        private void BuyFood()
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                if (repository.ContainsKey(command))
                {
                    totalFood += repository[command].BuyFood();
                }
                command = Console.ReadLine();
            }
        }

        private void AddInSociety()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = givenCmd[0];
                int age = int.Parse(givenCmd[1]);
                IBuyer buyer = null;

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
                if (buyer != null)
                {
                    repository.Add(name, buyer);
                }
            }
        }
    }
}
