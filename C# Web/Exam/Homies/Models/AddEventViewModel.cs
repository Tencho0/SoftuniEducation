namespace Homies.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Please enter the name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 20 characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Please enter the description")]
        [StringLength(150, MinimumLength = 15, ErrorMessage = "Description must be between 15 and 150 characters")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Please enter the start time")]
        [Display(Name = "Start")]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Please enter the end time")]
        [Display(Name = "End")]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }

        [Required(ErrorMessage = "Please select the type of event")]
        [Display(Name = "Type of event")]
        [Range(1, int.MaxValue)]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
