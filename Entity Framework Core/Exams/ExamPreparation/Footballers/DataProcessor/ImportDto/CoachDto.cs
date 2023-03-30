using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    [XmlType("Coach")]
    public class CoachDto
    {
        [XmlElement("Name")]
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string? Name { get; set; }

        [XmlElement("Nationality")]
        [Required]
        public string? Nationality { get; set; }

        [XmlArray("Footballers")]
        [XmlArrayItem("Footballer")]
        public virtual FootballerDto[] Footballers { get; set; }
    }
}