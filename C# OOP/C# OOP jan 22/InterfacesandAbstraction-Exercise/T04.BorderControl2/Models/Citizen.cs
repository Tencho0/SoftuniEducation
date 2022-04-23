namespace BorderControl2
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Id { get; set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
    }
}
