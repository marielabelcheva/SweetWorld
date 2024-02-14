using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Data.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } // kompiziten PK or leave it that way

        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; }
    }
}
