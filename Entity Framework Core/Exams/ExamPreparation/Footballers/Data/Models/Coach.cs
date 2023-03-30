namespace Footballers.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Coach
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Name { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string Nationality { get; set; } = null!;

        public virtual ICollection<Footballer> Footballers { get; set; } = new HashSet<Footballer>();
    }
}