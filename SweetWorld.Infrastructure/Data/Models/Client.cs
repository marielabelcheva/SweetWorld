using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Infrastructure.Data.Models
{
    public class Client
    {
        [Key]
        public Guid? Id { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        [Required]
        public User? User { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public ICollection<CartOrder> Cart { get; set; } = new HashSet<CartOrder>();

        public ICollection<FavouriteProduct> FavouriteProducts { get; set; } = new HashSet<FavouriteProduct>();
    }
}
