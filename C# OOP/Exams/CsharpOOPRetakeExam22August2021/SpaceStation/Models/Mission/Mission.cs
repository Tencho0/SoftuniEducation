namespace SpaceStation.Models.Mission
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts.Where(x => x.Oxygen > 0))
            {
                while (planet.Items.Count > 0)
                {
                    var item = planet.Items.First();
                    astronaut.Bag.Items.Add(item);
                    astronaut.Breath();
                    planet.Items.Remove(item);
                    if (!astronaut.CanBreath)
                        break;
                }
            }
        }
    }
}
