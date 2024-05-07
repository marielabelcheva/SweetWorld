using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.HomeViewModels
{
    public class ContactUsViewModel
    {
        [Required]
        public string SenderName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string From { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(10, MinimumLength = 9)]
        public string? PhoneNumber { get; set; }

        [Required]
        public string Body { get; set; } = null!;
    }
}
