namespace T05.BirthdayCelebrations
{
    using Contracts;

    public class Pet : IBirthdable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}