namespace Gym.Core
{
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Gyms.Contracts;
    using Gym.Repositories;
    using Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name == "BoxingGym")
                    gym.AddAthlete(athlete);
                else
                    return OutputMessages.InappropriateGym;
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name == "WeightliftingGym")
                    gym.AddAthlete(athlete);
                else
                    return OutputMessages.InappropriateGym;
            }
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            Equipment givenEquipment;

            if (equipmentType == "BoxingGloves")
                givenEquipment = new BoxingGloves();
            else
                givenEquipment = new Kettlebell();

            equipment.Add(givenEquipment);
            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            IGym gym;

            if (gymType == "BoxingGym")
                gym = new BoxingGym(gymName);
            else
                gym = new WeightliftingGym(gymName);

            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var currValue = this.gyms.First(x => x.Name == gymName).EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, currValue);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment currEquipment = this.equipment.FindByType(equipmentType);
            if (currEquipment == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));

            this.gyms.FirstOrDefault(x => x.Name == gymName).AddEquipment(currEquipment); //.Equipment.Add(currEquipment);
            this.equipment.Remove(currEquipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
            // return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
             //  sb.AppendLine($"{gym.Name} is a {gym.GetType().Name}:");
             //      
             //  if (gym.Athletes.Count == 0)
             //      sb.AppendLine("No athletes");
             //  else
             //      sb.AppendLine($"Athletes: {string.Join(", ", gym.Athletes.Select(x => x.FullName))}");
             //
             //  sb.AppendLine($"Equipment total count: {gym.Equipment.Count}");
             //  sb.AppendLine($"Equipment total weight: {gym.EquipmentWeight} grams");
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            int count = this.gyms.First(x => x.Name == gymName).Athletes.Count;

            foreach (var currAthlete in this.gyms.First(x => x.Name == gymName).Athletes)
                currAthlete.Exercise();

            return string.Format(OutputMessages.AthleteExercise, count);
        }
    }
}
