using FastFood.Common.EntityConfiguration;

namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        [MaxLength(EntitiesValidation.GuidMaxLength)]
        public string Id { get; set; }

        [Required]
        public string Customer { get; set; } = null!;

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public OrderType Type { get; set; }

        [NotMapped]
        public decimal TotalPrice { get; set; }
        
        [ForeignKey(nameof(Employee))]
        public string EmployeeId { get; set; } = null!;

        [Required]
        public virtual Employee Employee { get; set; } = null!;

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}