namespace Gym.Models.Athletes
{
    using System;
    using Gym.Models.Athletes.Contracts;
    using Gym.Utilities.Messages;

    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;

        protected Athlete(string name, string motivation, int numberOfMedals, int stamina)
        {
            FullName = name;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }
                fullName = value;
            }
        }
        public string Motivation
        {
            get { return motivation; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }
                motivation = value;
            }
        }
        public int Stamina
        {
            get { return stamina; }
            protected set { stamina = value; }
        }
        public int NumberOfMedals
        {
            get { return numberOfMedals; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}
