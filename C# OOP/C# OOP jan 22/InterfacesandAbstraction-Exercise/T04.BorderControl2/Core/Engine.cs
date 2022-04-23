namespace BorderControl2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private IList<IIdentifiable> repository;
        public Engine()
        {
            this.repository = new List<IIdentifiable>();
        }
        public void Run()
        {
            AddInSociety();
            string fakeId = Console.ReadLine();
            // CheckEveryOne(fakeId);
            string[] fakeIds = this.repository
                .Where(x => x.Id.EndsWith(fakeId))
                .Select(x => x.Id)
                .ToArray();
            fakeIds.ToList().ForEach(x => Console.WriteLine(x));
        }

        //private void CheckEveryOne(string fakeId)
        //{
        //    foreach (var item in repository)
        //    {
        //        if (item.Id.EndsWith(fakeId))
        //        {
        //            Console.WriteLine(item.Id);
        //        }
        //    }
        //}

        private void AddInSociety()
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                AddIdentifiable(givenCmd);
                command = Console.ReadLine();
            }
        }

        private void AddIdentifiable(string[] givenCmd)
        {
            IIdentifiable identifiable;
            if (givenCmd.Length == 3)
            {
                string name = givenCmd[0];
                int age = int.Parse(givenCmd[1]);
                string id = givenCmd[2];
                identifiable = new Citizen(name, age, id);
            }
            else
            {
                string model = givenCmd[0];
                string id = givenCmd[1];
                identifiable = new Robot(model, id);
            }
            this.repository.Add(identifiable);
        }
    }
}
