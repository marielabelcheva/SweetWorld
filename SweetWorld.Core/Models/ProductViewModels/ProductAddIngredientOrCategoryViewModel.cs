using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.ProductViewModels
{
    public class ProductAddIngredientOrCategoryViewModel
    {
        public Guid? ProductId { get; set; }

        public Guid? ItemId { get; set; }
    }
}
