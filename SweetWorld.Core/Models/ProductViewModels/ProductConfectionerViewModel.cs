﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.ProductViewModels
{
    public class ProductConfectionerViewModel
    {
        public Guid Id {  get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public string? Thumbnail { get; set; }
    }
}
