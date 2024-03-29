﻿using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.ProductViewModels
{
    public class EditProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string? Type { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public string? Thumbnail { get; set; }

        //public ICollection<string> PiecesCountShapeAndPrice { get; set; } = new HashSet<string>();
    }
}
