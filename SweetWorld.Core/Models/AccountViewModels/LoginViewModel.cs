﻿using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Core.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
