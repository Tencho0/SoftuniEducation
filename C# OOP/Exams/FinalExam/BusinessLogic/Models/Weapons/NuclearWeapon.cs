namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Utilities.Messages;
    using System;

    public class NuclearWeapon : Weapon
    {

        public NuclearWeapon(int destructionLevel)
            : base(15, destructionLevel)
        {
        }
    }
}
