using System;
using System.Collections.Generic;
using T04.BorderControl.Models;

namespace T04.BorderControl.Core
{
    public class Engine
    {
        private IList<PartOfSociety> society;
        public Engine()
        {
            this.society = new List<PartOfSociety>();
        }
        public void Run()
        {
            AddInSociety();
            string fakeId = Console.ReadLine();
            CheckEveryOne(fakeId);
        }

        private void CheckEveryOne(string fakeId)
        {
            foreach (var item in society)
            {
                if (item.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }

        private void AddInSociety()
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (givenCmd.Length == 3)
                {
                    AddCitizen(givenCmd);
                }
                else
                {
                    AddRobot(givenCmd);
                }
                command = Console.ReadLine();
            }
        }

        private void AddRobot(string[] givenCmd)
        {
            string model = givenCmd[0];
            string id = givenCmd[1];
            Robot robot = new Robot(model, id);
            this.society.Add(robot);
        }

        private void AddCitizen(string[] givenCmd)
        {
            string name = givenCmd[0];
            int age = int.Parse(givenCmd[1]);
            string id = givenCmd[2];
            Citizen citizen = new Citizen(name, age, id);
            this.society.Add(citizen);
        }
    }
}
