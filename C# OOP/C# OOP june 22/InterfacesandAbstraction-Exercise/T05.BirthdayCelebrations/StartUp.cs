namespace T05.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthdable> partsOfSociety = new List<IBirthdable>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                IBirthdable partOfSociety = null;
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = givenCmd[0];
                string birthdate = string.Empty;
                string name = givenCmd[1];

                if (type == "Citizen")
                {
                    int age = int.Parse(givenCmd[2]);
                    string id = givenCmd[3];
                    birthdate = givenCmd[4];

                    partOfSociety = new Citizen(name, age, id, birthdate);
                }
                else if (type == "Pet")
                {
                    birthdate = givenCmd[2];
                    partOfSociety = new Pet(name, birthdate);
                }
                if (partOfSociety != null)
                    partsOfSociety.Add(partOfSociety);

                command = Console.ReadLine();
            }
            string fakeBirthdateNums = Console.ReadLine();
            string[] sameDates = partsOfSociety
                 .Where(x => x.Birthdate.EndsWith(fakeBirthdateNums))
                 .Select(x => x.Birthdate)
                 .ToArray();
            sameDates.ToList().ForEach(x => Console.WriteLine(x));
            //foreach (var (currBirthdate, currPartOfSociety) in partsOfSociety)
            //{
            //    if (currBirthdate.EndsWith(fakeBirthdateNums))
            //        Console.WriteLine(currBirthdate);
            //}
        }
    }
}
