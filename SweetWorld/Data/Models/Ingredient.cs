using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Data.Models
{
    public class Ingredient
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductsIngredients> ProductsIngredients { get; set; } = new HashSet<ProductsIngredients>();
    }
}
