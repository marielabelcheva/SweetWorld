using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Infrastructure.Data.Models
{
    public class CartOrder
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid? ClientId { get; set; }
        [Required]
        public Client? Client { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Required]
        public string? ProductThumb { get; set; }

        [Required]
        public string? ProductType { get; set; }

        [Required]
        public int? Amount { get; set; }

        public decimal? UnitPrice { get; set; }

        public string? AdditionalInformation { get; set; } = null!;
    }
}
