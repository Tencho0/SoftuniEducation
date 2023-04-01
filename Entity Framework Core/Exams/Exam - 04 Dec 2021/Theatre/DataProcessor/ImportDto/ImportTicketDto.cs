namespace Theatre.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportTicketDto
    {
        [Required]
        [JsonProperty("Price")]
        [Range(1.00, 100.00)]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty("RowNumber")]
        [Range(1, 10)]
        public sbyte RowNumber { get; set; }

        [Required]
        [JsonProperty("PlayId")]
        public int PlayId { get; set; }
    }
}