namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;

    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {
        }
        public bool SonarMode { get; set; } = false;

        public void ToggleSonarMode()
        {
            if (!this.SonarMode)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + " *Sonar mode: " + (this.SonarMode ? "ON" : "OFF");
        }
    }
}
