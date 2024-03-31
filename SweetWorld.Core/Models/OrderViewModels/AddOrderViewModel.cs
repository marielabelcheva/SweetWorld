using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.OrderViewModels
{
    public class AddOrderViewModel
    {
        [Required]
        public Guid? ClientId { get; set; }

        [Required]
        public Guid? ProductId { get; set; }

        [Required]
        public int? Amount { get; set; }

        [Required]
        public decimal? TotalPrice { get; set; }

        public string? AdditionalInformation { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? DeliveryAddress;
    }
}
