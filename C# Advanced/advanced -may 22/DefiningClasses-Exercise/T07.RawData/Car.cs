namespace T07.RawData
{
    public class Car
    {
        private string model;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; } = new Tire[4];
    }
}
