namespace T07.MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using Model;
    using Contracts;
    using Enums;

    public class Engine : IEngine
    {
        private Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();
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
                    Soldier soldier = ReturnSoldier(givenCmd);
                    PrintCurrentSoldier(soldier);
                }
                catch (Exception e)
                {
                }
                command = Console.ReadLine();
            }
        }

        private void PrintCurrentSoldier(Soldier soldier)
        {
            Console.WriteLine(soldier);
        }

        private Soldier ReturnSoldier(string[] givenCmd)
        {
            string action = givenCmd[0];
            int id = int.Parse(givenCmd[1]);
            string firstName = givenCmd[2];
            string secondName = givenCmd[3];
            Soldier soldier = null;

            if (action == "Private")
            {
                decimal salary = decimal.Parse(givenCmd[4]);
                soldier = new Private(id, firstName, secondName, salary);
            }
            else if (action == "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(givenCmd[4]);
                Dictionary<int, IPrivate> privates = ReadPrivates(givenCmd);
                soldier = new LieutenantGeneral(id, firstName, secondName, salary, privates);
            }
            else if (action == "Engineer")
            {
                decimal salary = decimal.Parse(givenCmd[4]);
                bool isValid = Enum.TryParse(givenCmd[5], out Corps corps);

                if (!isValid)
                    throw new Exception();

                ICollection<IRepairs> repairs = ReadRepairs(givenCmd);
                soldier = new Engineer(id, firstName, secondName, salary, corps, repairs);
            }
            else if (action == "Commando")
            {
                decimal salary = decimal.Parse(givenCmd[4]);
                bool isValid = Enum.TryParse(givenCmd[5], out Corps corps);

                if (!isValid)
                    throw new Exception();

                ICollection<IMission> missions = ReadMissions(givenCmd);
                soldier = new Commando(id, firstName, secondName, salary, corps, missions);
            }
            else if (action == "Spy")
            {
                int codeNumber = int.Parse(givenCmd[4]);
                soldier = new Spy(id, firstName, secondName, codeNumber);
            }
            soldiers[id] = soldier;

            return soldier;
        }

        private ICollection<IMission> ReadMissions(string[] givenCmd)
        {
            ICollection<IMission> missions = new List<IMission>();

            for (int i = 6; i < givenCmd.Length; i += 2)
            {
                string missionCodeName = givenCmd[i];
                bool isMissionValid = Enum.TryParse(givenCmd[i + 1], out State state);
                if (!isMissionValid)
                    continue;

                Mission mission = new Mission(missionCodeName, state);
                missions.Add(mission);
            }

            return missions;
        }

        private ICollection<IRepairs> ReadRepairs(string[] givenCmd)
        {
            ICollection<IRepairs> repairs = new List<IRepairs>();

            for (int i = 6; i < givenCmd.Length; i += 2)
            {
                string repairPart = givenCmd[i];
                int repairWorkHours = int.Parse(givenCmd[i + 1]);
                Repairs repair = new Repairs(repairPart, repairWorkHours);
                repairs.Add(repair);
            }
            return repairs;
        }

        private Dictionary<int, IPrivate> ReadPrivates(string[] givenCmd)
        {
            Dictionary<int, IPrivate> privates = new Dictionary<int, IPrivate>();
            for (int i = 5; i < givenCmd.Length; i++)
            {
                int currID = int.Parse(givenCmd[i]);
                IPrivate currPrivate = (IPrivate)soldiers[currID];
                privates.Add(currID, currPrivate);
            }

            return privates;
        }
    }
}
