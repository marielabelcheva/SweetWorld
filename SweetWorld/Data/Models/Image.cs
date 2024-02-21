using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Data.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? URL { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        [Required]
        public Product? Product { get; set; }

    }
}
