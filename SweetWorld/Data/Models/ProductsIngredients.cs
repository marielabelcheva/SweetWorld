using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SweetWorld.Data.Models
{
    public class ProductsIngredients
    {
        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        [Required]
        public Product? Product { get; set; }

        [ForeignKey(nameof(Ingredient))]
        public Guid? IngredientId { get; set; }
        [Required]
        public Ingredient? Ingredient { get; set; }
    }
}
