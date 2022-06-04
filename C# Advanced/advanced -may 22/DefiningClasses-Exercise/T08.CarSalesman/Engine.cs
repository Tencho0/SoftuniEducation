namespace T08.CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine()
        {
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int? Displacement { get; set; }
        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

    }
}
