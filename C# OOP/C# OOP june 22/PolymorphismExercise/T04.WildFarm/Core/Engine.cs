namespace T04.WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Engine : IEngine
    {
        public Engine()
        {}

        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] animalInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] foodInfo= Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                if (type == "")
                {

                }

                command = Console.ReadLine();
            }
        }
    }
}
