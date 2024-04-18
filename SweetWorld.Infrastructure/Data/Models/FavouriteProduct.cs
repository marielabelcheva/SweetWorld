using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Infrastructure.Data.Models
{
    public class FavouriteProduct
    {
        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        [Required]
        public Product? Product { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid? ClientId { get; set; }
        [Required]
        public Client? Client { get; set; }
    }
}
