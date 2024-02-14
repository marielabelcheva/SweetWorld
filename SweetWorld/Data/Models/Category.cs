using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Data.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductsCategories> ProductsCategories { get; set; } = new HashSet<ProductsCategories>();
    }
}
