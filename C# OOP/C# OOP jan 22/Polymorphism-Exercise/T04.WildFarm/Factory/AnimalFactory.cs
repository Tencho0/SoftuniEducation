using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public static class AnimalFactory
    {
        public static IAnimal CreateAnimal(string[] animalData)
        {
            IAnimal animal = null;
            string givenType = animalData[0];
            string animalName = animalData[1];
            double weight = double.Parse(animalData[2]);

            if (givenType == "Cat" || givenType == "Tiger")
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];
                if (givenType == "Cat")
                {
                    animal = new Cat(animalName, weight, livingRegion, breed);
                }
                else
                {
                    animal = new Tiger(animalName, weight, livingRegion, breed);
                }
            }
            else if (givenType == "Owl" || givenType == "Hen")
            {
                double wingSize = double.Parse(animalData[3]);
                if (givenType == "Owl")
                {
                    animal = new Owl(animalName, weight, wingSize);
                }
                else
                {
                    animal = new Hen(animalName, weight, wingSize);
                }
            }
            else if (givenType == "Mouse" || givenType == "Dog")
            {
                string livingRegion = animalData[3];
                if (givenType == "Mouse")
                {
                    animal = new Mouse(animalName, weight, livingRegion);
                }
                else
                {
                    animal = new Dog(animalName, weight, livingRegion);
                }
            }

            return animal;
        }
    }
}
