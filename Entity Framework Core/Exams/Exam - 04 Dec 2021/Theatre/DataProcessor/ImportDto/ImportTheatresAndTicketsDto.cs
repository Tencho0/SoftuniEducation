namespace Theatre.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportTheatresAndTicketsDto
    {
        [Required]
        [JsonProperty("Name")]
        [MaxLength(30)]
        [MinLength(4)]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("NumberOfHalls")]
        [Range(1, 10)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [JsonProperty("Director")]
        [MaxLength(30)]
        [MinLength(4)]
        public string Director { get; set; } = null!;

        [JsonProperty("Tickets")]
        public ImportTicketDto[] Tickets { get; set; }
    }
}