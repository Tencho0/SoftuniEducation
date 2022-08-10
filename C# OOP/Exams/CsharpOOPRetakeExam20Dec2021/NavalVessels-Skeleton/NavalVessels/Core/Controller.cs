namespace NavalVessels.Core
{
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using NavalVessels.Utilities.Messages;
    using System.Collections.Generic;
    using System.Linq;

    public class Controller : IController
    {
        private VesselRepository vessels;
        private ICollection<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            IVessel vessel = this.vessels.FindByName(selectedVesselName);

            if (captain == null)
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);

            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);

            if (vessel.Captain != null)
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);

            captains.Add(captain);
            captain.AddVessel(vessel);
            vessel.Captain = captain;
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attacker = this.vessels.FindByName(attackingVesselName);
            var deffender = this.vessels.FindByName(defendingVesselName);

            if (attacker == null)
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);

            if (deffender == null)
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);

            if (attacker.ArmorThickness == 0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);

            if (deffender.ArmorThickness == 0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            attacker.Attack(deffender);
            attacker.Captain.IncreaseCombatExperience();
            deffender.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, deffender.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            return this.captains.FirstOrDefault(x => x.FullName == captainFullName).Report();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captains.Any(x => x.FullName == fullName))
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);

            ICaptain captain = new Captain(fullName);
            this.captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) != null)
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);

            IVessel vessel;
            if (vesselType == nameof(Battleship))
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            else if (vesselType == nameof(Submarine))
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            else
                return OutputMessages.InvalidVesselType;

            this.vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);
            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, vesselName);

            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel is Battleship)
            {
                (vessel as Battleship).ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else if (vessel is Submarine)
            {
                (vessel as Submarine).ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }

            return string.Format(OutputMessages.VesselNotFound, vesselName);

            //  if (vessel == null)
            //      return string.Format(OutputMessages.VesselNotFound, vesselName);
            //
            //  if (vessel.GetType().Name == nameof(Submarine))
            //  {
            //      Submarine submarine = (Submarine)vessel;
            //      submarine.ToggleSubmergeMode();
            //      return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            //  }
            //  else
            //  {
            //      Battleship submarine = (Battleship)vessel;
            //      submarine.ToggleSonarMode();
            //      return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            //  }
        }

        public string VesselReport(string vesselName)
        {
            return this.vessels.FindByName(vesselName).ToString();
        }
    }
}
