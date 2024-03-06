using SweetWorld.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Core.Models.ProductViewModels
{
    public class AddProductViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string? Type { get; set; }

        [Required]
        public decimal? Price { get; set; }

        
        public Confectioner? Confectioner { get; set; }
    }
}
