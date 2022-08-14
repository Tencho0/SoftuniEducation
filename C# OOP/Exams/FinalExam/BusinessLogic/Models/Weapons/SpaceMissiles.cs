namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Utilities.Messages;
    using System;

    public class SpaceMissiles : Weapon
    {

        public SpaceMissiles(int destructionLevel) 
            : base(destructionLevel, 8.75)
        {
        }
    }
}
