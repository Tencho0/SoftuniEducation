namespace AquaShop.Core
{
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
                aquarium = new FreshwaterAquarium(aquariumName);
            else if (aquariumType == "SaltwaterAquarium")
                aquarium = new SaltwaterAquarium(aquariumName);
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);

            this.aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == "Ornament")
                decoration = new Ornament();
            else if (decorationType == "Plant")
                decoration = new Plant();
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);

            this.decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.First(x => x.Name == aquariumName);
            IFish fish;

            if (fishType == "FreshwaterFish")
            {
                if (aquarium.GetType().Name == "FreshwaterAquarium")
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                else
                    return OutputMessages.UnsuitableWater;
            }
            else if (fishType == "SaltwaterFish")
            {
                if (aquarium.GetType().Name == "SaltwaterAquarium")
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                else
                    return OutputMessages.UnsuitableWater;
            }
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);

            aquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal price = aquarium.Fish.Sum(x => x.Price)
                          + aquarium.Decorations.Sum(x => x.Price);
            return string.Format(OutputMessages.AquariumValue, aquariumName, price);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            int fishCount = aquarium.Fish.Count;

            return string.Format(OutputMessages.FishFed, fishCount);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);
            if (decoration == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));

            this.aquariums.First(x => x.Name == aquariumName).AddDecoration(decoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            aquariums.ToList().ForEach(x => sb.AppendLine(x.GetInfo()));
            // foreach (var currAquarium in aquariums)
            //    sb.AppendLine(currAquarium.GetInfo());

            return sb.ToString().TrimEnd();
        }
    }
}
