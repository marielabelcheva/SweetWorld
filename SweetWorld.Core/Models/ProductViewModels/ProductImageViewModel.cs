using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.ProductViewModels
{
    public class ProductImageViewModel
    {
        public Guid? ProductId {  get; set; }
        public IFormFile? Picture { get; set; }
    }
}
