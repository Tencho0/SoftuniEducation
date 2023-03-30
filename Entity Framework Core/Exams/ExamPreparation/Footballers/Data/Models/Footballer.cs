namespace Footballers.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Footballer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime ContractStartDate { get; set; }

        [Required]
        public DateTime ContractEndDate { get; set; }

        [Required]
        public PositionType PositionType { get; set; }

        [Required]
        public BestSkillType BestSkillType { get; set; }

        [Required]
        public int CoachId { get; set; }

        [ForeignKey(nameof(CoachId))]
        public virtual Coach Coach { get; set; } = null!;

        [Required]
        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; } = new HashSet<TeamFootballer>();
    }
}