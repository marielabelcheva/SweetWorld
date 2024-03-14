﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Infrastructure.Data.Models
{
    public class Order
    {
        [ForeignKey(nameof(Client))]
        public Guid? ClientId { get; set; }
        [Required]
        public Client? Client { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        [Required]
        public Product? Product { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public decimal? TotalPrice { get; set; }

        public string? AdditionalInformation { get; set; } = null!;

        [Required]
        public string? DeliveryAddress;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Status { get; set; }
    }
}
