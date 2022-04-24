using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engine : IEngine
    {
        private Dictionary<int, ISoldier> soldiers;
        public Engine()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }
        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                try
                {
                    string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string result = this.Read(givenCmd);
                    Console.WriteLine(result);
                }
                catch (Exception) { }
                command = Console.ReadLine();
            }
        }

        private string Read(string[] givenCmd)
        {
            string type = givenCmd[0];
            int id = int.Parse(givenCmd[1]);
            string firstName = givenCmd[2];
            string lastName = givenCmd[3];

            ISoldier soldier = null;

            if (type == "Private")
            {
                decimal salary = decimal.Parse(givenCmd[4]);
                soldier = new Private(id, firstName, lastName, salary);
            }
            else if (type == "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(givenCmd[4]);
                Dictionary<int, IPrivate> privates = new Dictionary<int, IPrivate>();
                for (int i = 5; i < givenCmd.Length; i++)
                {
                    int currID = int.Parse(givenCmd[i]);
                    IPrivate currPrivate = (IPrivate)soldiers[currID];
                    privates.Add(currID, currPrivate);
                }
                soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
            }
            else if (type == "Engineer")
            {
                decimal salary = decimal.Parse(givenCmd[4]);
                bool isValid = Enum.TryParse(givenCmd[5], out Corps corps);

                if (!isValid)
                {
                    throw new Exception();
                }

                ICollection<IRepairs> repairs = new List<IRepairs>();

                for (int i = 6; i < givenCmd.Length; i += 2)
                {
                    string repairPart = givenCmd[i];
                    int repairWorkHours = int.Parse(givenCmd[i + 1]);
                    Repairs repair = new Repairs(repairPart, repairWorkHours);
                    repairs.Add(repair);
                }

                soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
            }
            else if (type == "Commando")
            {
                decimal salary = decimal.Parse(givenCmd[4]);
                bool isValid = Enum.TryParse(givenCmd[5], out Corps corps);

                if (!isValid)
                {
                    throw new Exception();
                }

                ICollection<IMission> missions = new List<IMission>();

                for (int i = 6; i < givenCmd.Length; i += 2)
                {
                    string missionCodeName = givenCmd[i];
                    bool isMissionValid = Enum.TryParse(givenCmd[i + 1], out State state);
                    if (!isMissionValid)
                    {
                        continue;
                    }
                    Mission mission = new Mission(missionCodeName, state);
                    missions.Add(mission);
                }

                soldier = new Commando(id, firstName, lastName, salary, corps, missions);
            }
            else if (type == "Spy")
            {
                int codeNumber = int.Parse(givenCmd[4]);
                soldier = new Spy(id, firstName, lastName, codeNumber);
            }

            this.soldiers.Add(id, soldier);

            return soldier.ToString();
        }
    }
}
