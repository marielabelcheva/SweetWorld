﻿using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Core.Models.CategoryViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Name { get; set; }
    }
}
