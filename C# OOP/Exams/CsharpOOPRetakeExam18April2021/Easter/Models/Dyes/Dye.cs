﻿namespace Easter.Models.Dyes
{
    using Easter.Models.Dyes.Contracts;
    using System;

    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get => power;
            private set
            {
                if (value < 0)
                    value = 0;

                power = value;
            }
        }

        public bool IsFinished() => this.Power == 0;

        public void Use()
        {
            this.Power -= 10;
        }
    }
}
