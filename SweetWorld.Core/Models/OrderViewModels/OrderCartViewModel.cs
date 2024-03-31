using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.OrderViewModels
{
    public class OrderCartViewModel
    {
        [Required]
        public Guid? ProductId { get; set; }

        [Required]
        public string? ProductName { get; set; }

        public string? ProductThumb { get; set; }

        [Required]
        public string? ProductType { get; set; }

        [Required]
        public int? Amount { get; set; }

        [Required]
        public decimal? UnitPrice { get; set; }

        public string? AdditionalInformation { get; set; } = null!;
    }
}
