namespace Boardgames.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportSellerDto
    {
        [Required]
        [JsonProperty("Name")]
        [MaxLength(20)]
        [MinLength(5)]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("Address")]
        [MaxLength(30)]
        [MinLength(2)]
        public string Address { get; set; } = null!;

        [Required]
        [JsonProperty("Country")]
        public string Country { get; set; } = null!;

        [Required]
        [JsonProperty("Website")]
        [RegularExpression(@"^www\.[a-zA-Z0-9\-]+\.com$")]
        public string Website { get; set; } = null!;

        [Required]
        public int[] Boardgames { get; set; }
    }
}