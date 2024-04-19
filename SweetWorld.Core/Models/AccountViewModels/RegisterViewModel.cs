using System.ComponentModel.DataAnnotations;

namespace SweetWorld.Core.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string? UserName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength = 10)]
        public string? Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 4)]
        public string? IsConfectioner { get; set; }
    }
}
