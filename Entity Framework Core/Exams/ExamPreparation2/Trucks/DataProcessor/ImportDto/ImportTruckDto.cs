namespace Trucks.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Common;

    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [MinLength(ValidationConstants.RegistrationNumberLength)]
        [MaxLength(ValidationConstants.RegistrationNumberLength)]
        [RegularExpression(ValidationConstants.RegistrationNumberRegEx)]
        public string? RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [Required]
        [MinLength(ValidationConstants.VinNumberLength)]
        [MaxLength(ValidationConstants.VinNumberLength)]
        public string VinNumber { get; set; } = null!;

        [XmlElement("TankCapacity")]
        [Range(ValidationConstants.TruckTankCapacityMinValue,
            ValidationConstants.TruckTankCapacityMaxValue)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(ValidationConstants.TruckCargoCapacityMinValue,
            ValidationConstants.TruckCargoCapacityMaxValue)]
        public int CargoCapacity { get; set; }

        [XmlElement("CategoryType")]
        [Range(ValidationConstants.TruckCategoryTypeMinValue,
            ValidationConstants.TruckCategoryTypeMaxValue)]
        public int CategoryType { get; set; }

        [XmlElement("MakeType")]
        [Range(ValidationConstants.TruckMakeTypeMinValue,
            ValidationConstants.TruckMakeTypeMaxValue)]
        public int MakeType { get; set; }
    }
}