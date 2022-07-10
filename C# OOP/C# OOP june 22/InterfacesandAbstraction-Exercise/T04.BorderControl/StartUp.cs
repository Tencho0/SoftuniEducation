namespace T04.BorderControl
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, PartOfSociety> partsOfSociety = new Dictionary<string, PartOfSociety>();

            PartOfSociety partOfSociety = null;
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);


                string id = string.Empty;
                if (givenCmd.Length == 3)
                {
                    string name = givenCmd[0];
                    int age = int.Parse(givenCmd[1]);
                    id = givenCmd[2];

                    partOfSociety = new Citizen(name, age, id);
                }
                else if (givenCmd.Length == 2)
                {
                    string model = givenCmd[0];
                    id = givenCmd[1];
                    partOfSociety = new Robot(model, id);
                }
                partsOfSociety[id] = partOfSociety;

                command = Console.ReadLine();
            }
            string fakeIdNums = Console.ReadLine();
            foreach (var (currId, currPartOfSociety) in partsOfSociety)
            {
                if (currId.EndsWith(fakeIdNums))
                    Console.WriteLine(currId);
            }
        }
    }
}
