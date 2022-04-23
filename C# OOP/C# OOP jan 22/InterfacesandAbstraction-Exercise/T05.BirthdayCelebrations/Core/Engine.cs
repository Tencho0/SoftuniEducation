namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private IList<IBirthdate> repository;
        public Engine()
        {
            this.repository = new List<IBirthdate>();
        }
        public void Run()
        {
            AddInSociety();
            string specificYear = Console.ReadLine();
            string[] sameDates = this.repository
                .Where(x => x.Birthdate.EndsWith(specificYear))
                .Select(x => x.Birthdate)
                .ToArray();
            sameDates.ToList().ForEach(x => Console.WriteLine(x));
        }
        private void AddInSociety()
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                AddBirthdable(givenCmd);
                command = Console.ReadLine();
            }
        }

        private void AddBirthdable(string[] givenCmd)
        {
            string type = givenCmd[0];
            string name = givenCmd[1];

            IBirthdate ibirthdate = null;
            if (type == "Citizen")
            {
                int age = int.Parse(givenCmd[2]);
                string id = givenCmd[3];
                string birthdate = givenCmd[4];
                ibirthdate = new Citizen(name, age, id, birthdate);
            }
            else if (type == "Pet")
            {
                string birthdate = givenCmd[2];
                ibirthdate = new Pet(name, birthdate);
            }
            if (ibirthdate != null)
            {
                this.repository.Add(ibirthdate);
            }
        }
    }
}
