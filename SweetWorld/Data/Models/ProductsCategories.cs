using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SweetWorld.Data.Models
{
    public class ProductsCategories
    {
        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        [Required]
        public Product? Product { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid? CategoryId { get; set; }
        [Required]
        public Category? Category { get; set; }
    }
}
