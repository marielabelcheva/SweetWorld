using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.OrderViewModels
{
    public class OrderClientViewModel
    {
        [Required]
        public Guid? OrderId {  get; set; }

        [Required]
        public string? ProductName {  get; set; }

        public string? ProductThumb {  get; set; }

        public string? ProductType { get; set; }

        [Required]
        public DateTime? CreationDate { get; set; }

        public int? Amount { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? Status { get; set; }

        public string? AdditionalInformation {  get; set; }
    }
}
