using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Data.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        //
        public bool InStock { get; set; }
        //

        public decimal Price { get; set; } 

        [ForeignKey(nameof(Confectioner))]
        public Guid ConfectionerId { get; set; }
        public Confectioner Confectioner { get; set; }

        public ICollection<ProductsIngredients> Ingredients { get; set; } = new HashSet<ProductsIngredients>();

        public ICollection<ProductsCategories> Categories { get; set; } = new HashSet<ProductsCategories>();

        //
        public ICollection<string> PiecesCountShapeAndPrice { get; set; } = new HashSet<string>();

        //public string PiecesCountAndShape {  get; set; } and use the Price prop //"24d" or "16x"

        public ICollection<Image> Images = new HashSet<Image>();

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
