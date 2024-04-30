using SweetWorld.Core.Models.CategoryViewModels;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.ProductViewModels
{
    public class ProductDataViewModel
    {
        [Required]
        public Guid? Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string? Type { get; set; }

        public decimal? Price { get; set; } = 0;

        [Required]
        public string? ConfectionerName {  get; set; }

        [Required]
        public string? Thumbnail { get; set; }

        public ICollection<PiecesCount>? PiecesCountAndPrice { get; set; } = new HashSet<PiecesCount>();

        public ICollection<Image>? Images { get; set; } = new HashSet<Image>();

        public IEnumerable<string?> Ingredients { get; set; } = new HashSet<string?>();

        public IEnumerable<CategoryViewModel?> Categories { get; set; } = new HashSet<CategoryViewModel>();

        public int? Amount { get; set; } = 0;

        public string? AdditionalInformation { get; set; } = null!;

        public IEnumerable<ProductViewModel> Related { get; set; } = new HashSet<ProductViewModel>();
    }
}
