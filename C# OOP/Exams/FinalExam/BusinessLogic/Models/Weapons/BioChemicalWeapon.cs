namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Utilities.Messages;
    using System;

    public class BioChemicalWeapon : Weapon
    {
        public BioChemicalWeapon(int destructionLevel)
            : base(destructionLevel, 3.2)
        {
        }
    }
}
