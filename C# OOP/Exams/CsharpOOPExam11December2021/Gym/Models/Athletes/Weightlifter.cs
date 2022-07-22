namespace Gym.Models.Athletes
{
    using System;
    using Gym.Utilities.Messages;

    public class Weightlifter : Athlete
    {
        public Weightlifter(string name, string motivation, int numberOfMedals) 
            : base(name, motivation, numberOfMedals, 50)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 10;
            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
