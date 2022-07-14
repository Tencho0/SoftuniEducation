﻿namespace T04.WildFarm.Model.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }
        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
