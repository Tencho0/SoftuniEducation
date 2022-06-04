using System.Text;

namespace T08.CarSalesman
{
    public class Car
    {
        private string model;

        public Car()
        {
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }

        // public override string ToString()
        // {
        //     StringBuilder sb = new StringBuilder();
        //
        //     sb.AppendLine($"{this.Model}:");
        //     sb.AppendLine($"{this.Engine.Model}:");
        //     sb.AppendLine($"Power: {this.Engine.Power}");
        //     sb.AppendLine($"Displacement: {this.Engine.Displacement}");
        //     sb.AppendLine($"Efficiency: {this.Engine.Efficiency}");
        //     sb.AppendLine($"Weight: {this.Weight}");
        //     sb.AppendLine($"Color: {this.Color}");
        //
        //
        //     return sb.ToString();
        // }
    }
}
