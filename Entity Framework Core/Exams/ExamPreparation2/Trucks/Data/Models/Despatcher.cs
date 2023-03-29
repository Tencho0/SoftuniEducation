namespace Trucks.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class Despatcher
    {
        public Despatcher()
        {
            this.Trucks = new HashSet<Truck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.DespatcherNameMaxLength)]
        public string Name { get; set; } = null!;

        public string? Position { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }
    }
}

//Despatcher
//    •	Id – integer, Primary Key
//    •	Name – text with length [2, 40] (required)
//    •	Position – text
//    •	Trucks – collection of type Truck
