using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Data.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Name { get; set; }

        public ICollection<ProductsCategories> ProductsCategories { get; set; } = new HashSet<ProductsCategories>();
    }
}
