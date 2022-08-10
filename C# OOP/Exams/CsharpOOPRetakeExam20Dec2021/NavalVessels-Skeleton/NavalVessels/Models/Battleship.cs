namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;

    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode = false;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {
        }
        public bool SonarMode => sonarMode;

        public void ToggleSonarMode()
        {
            if (this.SonarMode)
            {
                this.sonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
            else
            {
                this.sonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
        }
        public override void RepairVessel()
        {
            this.ArmorThickness = 300;
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + " *Sonar mode: " + (this.SonarMode ? "ON" : "OFF");
        }
    }
}
