namespace T05.BirthdayCelebrations
{
    public class Robot : PartOfSociety
    {
        public Robot(string model, string id)
            :base(id)
        {
            Model = model;
        }

        public string Model { get; set; }
    }
}
