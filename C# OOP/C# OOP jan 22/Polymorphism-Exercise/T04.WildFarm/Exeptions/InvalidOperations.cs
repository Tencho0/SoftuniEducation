using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public static class InvalidOperations
    {
        public static void ExeptionForInvalidFood(string animalType, string foodtype)
        {
            throw new ArgumentException($"{animalType} does not eat {foodtype}!");
        }
    }
}
