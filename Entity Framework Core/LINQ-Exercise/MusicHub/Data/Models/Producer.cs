﻿using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(ValidationConstants.ProducerNameMaxLength)]
        public string Name { get; set; }

        public string? Pseudonym { get; set; } = null!;

        public string? PhoneNumber { get; set; } = null!;

        public virtual ICollection<Album> Albums { get; set; }
    }
}
