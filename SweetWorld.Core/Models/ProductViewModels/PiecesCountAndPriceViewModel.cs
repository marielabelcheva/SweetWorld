using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.ProductViewModels
{
    public class PiecesCountAndPriceViewModel
    {
        public Guid? ProductId {  get; set; }

        [Required]
        public int PiecesCount { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
