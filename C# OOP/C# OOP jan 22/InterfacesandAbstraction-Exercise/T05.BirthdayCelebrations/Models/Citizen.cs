namespace BirthdayCelebrations
{
    public class Citizen : IIdentifiable, IBirthdate
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public string Id { get; set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Birthdate { get; set; }
    }
}
