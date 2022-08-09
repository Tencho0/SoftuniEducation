namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;

    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 200)
        {
        }

        public bool SubmergeMode { get; set; } = false;

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
            else
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + " *Submerge  mode: " + (this.SubmergeMode ? "ON" : "OFF");
        }
    }
}
