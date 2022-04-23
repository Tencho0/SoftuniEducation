namespace T04.BorderControl.Models
{
    public class Robot : PartOfSociety
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; set; }
    }
}
