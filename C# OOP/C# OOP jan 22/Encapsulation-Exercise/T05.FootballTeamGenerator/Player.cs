using System;
using System.Collections.Generic;
using System.Text;

namespace T05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            if (endurance < 0 || endurance > 100)  throw new ArgumentException($"Endurance should be between 0 and 100.");
            if (sprint < 0 || sprint > 100)  throw new ArgumentException($"Sprint should be between 0 and 100.");
            if (dribble < 0 || dribble > 100)  throw new ArgumentException($"Dribble should be between 0 and 100.");
            if (passing < 0 || passing > 100)  throw new ArgumentException($"Passing should be between 0 and 100.");
            if (shooting < 0 || shooting > 100)  throw new ArgumentException($"Shooting should be between 0 and 100.");

            this.Name = name;
            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int SkillLevel =>
            (int)Math.Round((this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0);

        private void isInvalidStat(int stat)
        {
            if (stat < 0 || stat > 100)
            {
                throw new ArgumentException($"{stat} should be between 0 and 100.");
            }
        }
    }
}
