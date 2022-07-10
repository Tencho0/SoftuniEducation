namespace T05.BirthdayCelebrations
{
    using Contracts;

    public class Citizen : PartOfSociety, IBirthdable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
            : base(id)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
            Food = 0;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }

        public int BuyFood()
        {
            Food += 10;
            return 10;
        }
    }
}
