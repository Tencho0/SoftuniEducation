namespace Homies.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Name { get; set; } = null!;
    }
}
