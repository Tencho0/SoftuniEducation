using Newtonsoft.Json;

namespace Theatre.DataProcessor
{
    using System.Text;
    using System.Globalization;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        private static XmlHelper xmlHelper;

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            xmlHelper = new XmlHelper();
            var sb = new StringBuilder();
            var minimumTime = new TimeSpan(1, 0, 0);
            var validGenres = new string[] { "Drama", "Comedy", "Romance", "Musical" };

            var playDtos = xmlHelper.Deserialize<ImportPlayDto[]>(xmlString, "Plays");
            var validPlays = new HashSet<Play>();

            foreach (var playDto in playDtos)
            {
                var currentTime = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture);

                if (!IsValid(playDto)
                    || !validGenres.Contains(playDto.Genre)
                    || (currentTime < minimumTime))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture),
                    Rating = playDto.Rating,
                    Genre = (Genre)Enum.Parse(typeof(Genre), playDto.Genre),
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                validPlays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, playDto.Title, playDto.Genre, playDto.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            xmlHelper = new XmlHelper();
            var sb = new StringBuilder();

            var castsDtos = xmlHelper.Deserialize<ImportCastDto[]>(xmlString, "Casts");
            var validCasts = new HashSet<Cast>();

            foreach (var castDto in castsDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                var IsMainCharacter = cast.IsMainCharacter ? "main" : "lesser";
                validCasts.Add(cast);
                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, IsMainCharacter));
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            xmlHelper = new XmlHelper();
            var sb = new StringBuilder();

            var theatreDtos = JsonConvert.DeserializeObject<ImportTheatresAndTicketsDto[]>(jsonString);
            var validTheatres = new HashSet<Theatre>();

            foreach (var theatresAndTicketsDto in theatreDtos)
            {
                if (!IsValid(theatresAndTicketsDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Name = theatresAndTicketsDto.Name,
                    NumberOfHalls = theatresAndTicketsDto.NumberOfHalls,
                    Director = theatresAndTicketsDto.Director
                };

                var validTickets = new HashSet<Ticket>();
                foreach (var ticketDto in theatresAndTicketsDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };
                    validTickets.Add(ticket);
                }
                theatre.Tickets = validTickets;

                validTheatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
