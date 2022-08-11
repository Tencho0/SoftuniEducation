namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private PlanetRepository planets;
        private AstronautRepository astronauts;
        private int exploredPlanetsCount = 0;

        public Controller()
        {
            planets = new PlanetRepository();
            astronauts = new AstronautRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == nameof(Biologist))
                astronaut = new Biologist(astronautName);
            else if (type == nameof(Geodesist))
                astronaut = new Geodesist(astronautName);
            else if (type == nameof(Meteorologist))
                astronaut = new Meteorologist(astronautName);
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);

            this.astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
                planet.Items.Add(item);

            this.planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            if (!this.astronauts.Models.Any(x => x.Oxygen <= 60))
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);

            IMission mission = new Mission();
            IPlanet planet = this.planets.FindByName(planetName);
            mission.Explore(planet, this.astronauts.Models.Where(x => x.Oxygen > 60).ToArray());
            exploredPlanetsCount++;

            return string.Format(OutputMessages.PlanetExplored, planetName, this.astronauts.Models.Count(x => !x.CanBreath));
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var astronaut in this.astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: " + (astronaut.Bag.Items.Count > 0 ? string.Join(", ", astronaut.Bag.Items) : "none"));
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronauts.FindByName(astronautName);
            if (astronaut == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));

            this.astronauts.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
