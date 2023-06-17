namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class EventParticipant
    {
        [Key]
        public string HelperId { get; set; } = null!;

        [Required]
        public IdentityUser Helper { get; set; } = null!;

        [Key]
        public int EventId { get; set; }

        [Required]
        public Event Event { get; set; } = null!;
    }
}
