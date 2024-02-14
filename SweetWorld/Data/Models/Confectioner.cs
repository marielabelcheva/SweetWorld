using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Data.Models
{
    public class Confectioner
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public ICollection<Request> Requests { get; set; } = new HashSet<Request>();
    }
}
