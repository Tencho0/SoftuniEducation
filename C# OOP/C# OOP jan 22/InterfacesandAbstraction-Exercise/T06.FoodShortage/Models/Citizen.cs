namespace FoodShortage
{
    public class Citizen : IIdentifiable, IBirthdate, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }
        public string Id { get; set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }

        public int BuyFood()
        {
            Food += 10;
            return 10;
        }
    }
}
