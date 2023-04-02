using Boardgames.Data.Models.Enums;

namespace Boardgames.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    [XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        [Required]
        [XmlElement("Name")]
        [MaxLength(20)]
        [MinLength(10)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("Rating")]
        [Range(1, 10.00)]
        public double Rating { get; set; }

        [Required]
        [XmlElement("YearPublished")]
        [Range(2018, 2023)]
        public int YearPublished { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        [Range(0, 4)]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
    }
}