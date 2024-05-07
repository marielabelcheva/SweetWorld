using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.OrderViewModels
{
    public class CartOrderViewModel
    {
        public Guid? Id { get; set; }

        public string? Type {  get; set; }

        [Required]
        public int? Amount { get; set; }

        public string? AdditionalInformation { get; set; } = null!;

        public decimal? Price {  get; set; }

        public SelectList? Sizes { get; set; }
    }
}
