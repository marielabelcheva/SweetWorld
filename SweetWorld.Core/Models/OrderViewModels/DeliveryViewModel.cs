using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.OrderViewModels
{
    public class DeliveryViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? City {  get; set; }

        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string? ZipCode {  get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Address {  get; set; }
    }
}
