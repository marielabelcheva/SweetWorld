using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Infrastructure.Data.Models
{
    public class Product
    {
        [Key]
        public Guid? Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        [StringLength(60,MinimumLength = 2)]
        public string? Type { get; set; }

        public decimal? Price { get; set; } 

        [ForeignKey(nameof(Confectioner))]
        public Guid? ConfectionerId { get; set; }
        [Required]
        public Confectioner? Confectioner { get; set; }

        [Required]
        public string? Thumbnail {  get; set; }

        public ICollection<ProductsIngredients> Ingredients { get; set; } = new HashSet<ProductsIngredients>();

        public ICollection<ProductsCategories> Categories { get; set; } = new HashSet<ProductsCategories>();

        public ICollection<KeyValuePair<int, decimal>> PiecesCountAndPrice { get; set; } = new HashSet<KeyValuePair<int, decimal>>();

        public ICollection<Image> Images { get; set; } = new HashSet<Image>();

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public ICollection<FavouriteProduct> FavoriteProducts { get; set;} = new HashSet<FavouriteProduct>();
    }
}
