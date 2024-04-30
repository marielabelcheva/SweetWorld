using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Infrastructure.Data.Models
{
    public class PiecesCount
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int? Count { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        [Required]
        public Product? Product { get; set; }
    }
}
