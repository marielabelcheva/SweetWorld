using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Infrastructure.Data.Models
{
    public class Ingredient
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }

        public ICollection<ProductsIngredients> ProductsIngredients { get; set; } = new HashSet<ProductsIngredients>();
    }
}
