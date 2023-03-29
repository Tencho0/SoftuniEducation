namespace Trucks.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using Common;
    using Enums;

    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(ValidationConstants.RegistrationNumberLength)]
        public string? RegistrationNumber { get; set; }

        [Required]
        [MaxLength(ValidationConstants.VinNumberLength)]
        public string VinNumber { get; set; } = null!;

        public int TankCapacity { get; set; }

        public int CargoCapacity { get; set; }

        public CategoryType CategoryType { get; set; }

        public MakeType MakeType { get; set; }

        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId { get; set; }
        public virtual Despatcher Despatcher { get; set; } = null;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}