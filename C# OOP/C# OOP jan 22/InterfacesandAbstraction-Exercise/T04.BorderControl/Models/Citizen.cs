namespace T04.BorderControl.Models
{
    public class Citizen : PartOfSociety
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
