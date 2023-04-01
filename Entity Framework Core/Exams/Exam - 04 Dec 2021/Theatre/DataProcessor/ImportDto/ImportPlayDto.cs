namespace Theatre.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    [XmlType("Play")]
    public class ImportPlayDto
    {
        [XmlElement("Title")]
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string Title { get; set; } = null!;

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [Required]
        [Range(0.00, 10.00)]
        [XmlElement("Raiting")]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [Required]
        [MaxLength(700)]
        public string Description { get; set; } = null!;

        [XmlElement("Screenwriter")]
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string Screenwriter { get; set; } = null!;
    }
}