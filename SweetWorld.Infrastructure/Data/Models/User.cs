using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }

        public string? ProfilePictureUrl {  get; set; }
    }
}
