namespace T07.MilitaryElite.Core
{
    using System;
    public class Engine
    {
        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                int id = int.Parse(givenCmd[1]);
                string firstName = givenCmd[2];
                string secondName = givenCmd[3];

                if (action == "Private")
                {

                }
                else if (action == "LeutenantGeneral")
                {

                }
                else if (action == "Engineer")
                {

                }
                else if (action == "Commando")
                {

                }
                else if (action == "Spy")
                {

                }

                command = Console.ReadLine();
            }
        }
    }
}
