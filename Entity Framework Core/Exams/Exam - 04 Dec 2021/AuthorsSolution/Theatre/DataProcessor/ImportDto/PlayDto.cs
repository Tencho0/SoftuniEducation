﻿namespace Theatre.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Play")]
    public class PlayDto
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        [XmlElement("Title")]
        public string Title { get; set; }

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }

        [Required]
        [Range(0.00, 10.00)]
        [XmlElement("Raiting")]
        public float Rating { get; set; }


        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }

        [Required]
        [MaxLength(700)]
        [XmlElement("Description")]
        public string Description { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        [XmlElement("Screenwriter")]
        public string Screenwriter { get; set; }
    }
}
