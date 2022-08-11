namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, 65, 7.5)
        {
        }
        public override void Drive()
        {
            base.Drive();
            this.HorsePower = (int)(this.HorsePower * 0.97);
        }
    }
}
