using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var sb = new StringBuilder();
            CoachDto[] coaches;
            XmlSerializer serializer = new XmlSerializer(typeof(CoachDto[]), new XmlRootAttribute("Coaches"));
            using (TextReader reader = new StringReader(xmlString))
            {
                coaches = (CoachDto[])serializer.Deserialize(reader);
            }

            var coachEntities = new HashSet<Coach>();
            foreach (var coachDto in coaches)
            {
                var coachEntity = new Coach();
                coachEntity.Name = coachDto.Name ?? "";
                coachEntity.Nationality = coachDto.Nationality ?? "";

                if (!IsValid(coachEntities))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                coachEntities.Add(coachEntity);

                foreach (var footballer in coachDto.Footballers)
                {
                    Footballer footballerEntity = new Footballer();

                    try
                    {
                        footballerEntity.Name = footballer.Name ?? "";
                        footballerEntity.PositionType = (PositionType)footballer.PositionType;
                        footballerEntity.ContractStartDate =
                            DateTime.ParseExact(footballer.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        footballerEntity.ContractEndDate =
                            DateTime.ParseExact(footballer.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        footballerEntity.BestSkillType = (BestSkillType)footballer.BestSkillType;

                        if (!IsValid(footballerEntity) || footballerEntity.ContractEndDate < footballerEntity.ContractStartDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                    catch (Exception e)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    coachEntity.Footballers.Add(footballerEntity);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coachEntity.Name, coachEntity.Footballers.Count));
            }

            context.Coaches.AddRange(coachEntities);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teams = JsonConvert.DeserializeObject<TeamDto[]>(jsonString);
            var sb = new StringBuilder();
            var teamEntities = new HashSet<Team>();

            foreach (var team in teams)
            {
                Team teamEntity = new Team();
                teamEntity.Name = team.Name ?? "";
                teamEntity.Nationality = team.Nationality ?? "";

                if (!int.TryParse(team.Trophies, out var trophiesCount) || trophiesCount <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                teamEntity.Trophies = trophiesCount;

                if (!IsValid(teamEntities))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var footballer in team.Footballers.Distinct())
                {
                    Footballer? footballerEntity = context.Footballers.Find(footballer);

                    if (footballerEntity == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    teamEntity.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Footballer = footballerEntity,
                        FootballerId = footballer
                    });
                }

                teamEntities.Add(teamEntity);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, teamEntity.Name, teamEntity.TeamsFootballers.Count()));
            }

            context.Teams.AddRange(teamEntities);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
