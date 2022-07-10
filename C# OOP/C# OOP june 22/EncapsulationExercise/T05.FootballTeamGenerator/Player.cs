namespace T05.FootballTeamGenerator
{
    using System;
    
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
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int SkillLevel =>
            (int)Math.Round((this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0);
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"A name should not be empty.");
                }
                name = value;
            }
        }
        public int Endurance
        {
            get { return endurance; }
            private set
            {
                CheckIsValid("Endurance", value);
                endurance = value;
            }
        }
        public int Sprint
        {
            get { return sprint; }
            private set
            {
                CheckIsValid("Sprint", value);
                sprint = value;
            }
        }
        public int Dribble
        {
            get { return dribble; }
            private set
            {
                CheckIsValid("Dribble", value);
                dribble = value;
            }
        }
        public int Passing
        {
            get { return passing; }
            private set
            {
                CheckIsValid("Passing", value);
                passing = value;
            }
        }
        public int Shooting
        {
            get { return shooting; }
            private set
            {
                CheckIsValid("Shooting", value);
                shooting = value;
            }
        }
        private void CheckIsValid(string skill, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new Exception($"{skill} should be between 0 and 100.");
            }
        }
    }
}
