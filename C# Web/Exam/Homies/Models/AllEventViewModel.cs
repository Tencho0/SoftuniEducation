namespace Homies.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AllEventViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
        public DateTime Start { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public string Organiser { get; set; } = null!;
    }
}
