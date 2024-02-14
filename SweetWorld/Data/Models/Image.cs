using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Data.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        public string URL { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
