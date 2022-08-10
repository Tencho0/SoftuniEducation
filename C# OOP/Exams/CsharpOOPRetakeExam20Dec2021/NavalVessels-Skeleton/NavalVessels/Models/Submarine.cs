namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Text;

    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode = false;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 200)
        {
        }

        public bool SubmergeMode => submergeMode;

        public override void RepairVessel()
        {
            this.ArmorThickness = 200;
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {
                this.submergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
            else
            {
                this.submergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string switchable = this.SubmergeMode ? "ON" : "OFF";
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {switchable}");

            return sb.ToString().TrimEnd();
        }
    }
}
