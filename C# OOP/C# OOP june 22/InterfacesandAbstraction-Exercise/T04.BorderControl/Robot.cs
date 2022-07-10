namespace T04.BorderControl
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
