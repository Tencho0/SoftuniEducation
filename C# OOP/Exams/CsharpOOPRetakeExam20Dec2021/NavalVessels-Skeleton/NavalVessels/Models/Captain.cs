namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;

    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            FullName = fullName;
            CombatExperience = 0;
            this.vessels = new List<IVessel>();
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);

                fullName = value;
            }
        }

        public int CombatExperience
        {
            get { return combatExperience; }
            private set { combatExperience = value; }
        }

        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);

            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
