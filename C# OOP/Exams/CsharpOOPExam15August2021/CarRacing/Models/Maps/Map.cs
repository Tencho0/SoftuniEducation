namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerOne.IsAvailable())
                return OutputMessages.RaceCannotBeCompleted;

            if (!racerOne.IsAvailable())
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);

            if (!racerTwo.IsAvailable())
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);

            racerOne.Race();
            racerTwo.Race();

            var firstRacerchanceOfWinning = racerOne.Car.HorsePower
                * racerOne.DrivingExperience
                * (racerOne.RacingBehavior == "strict" ? racerOne.RacingBehavior == "aggressive" ? 1.2 : 1.1 : 0);
            var secondRacerchanceOfWinning = racerTwo.Car.HorsePower
                * racerTwo.DrivingExperience
                * (racerTwo.RacingBehavior == "strict" ? racerTwo.RacingBehavior == "aggressive" ? 1.2 : 1.1 : 0);

            string winner = firstRacerchanceOfWinning > secondRacerchanceOfWinning ? racerOne.Username : racerTwo.Username;
            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner);
        }
    }
}
