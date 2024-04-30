using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Models.UserViewModels
{
    public class UserViewModel
    {
        public string? Id {  get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string? FirstName {  get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? Role {  get; set; }

        public string? ProfilePictureURL {  get; set; }

        public IFormFile? ProfilePicture {  get; set; }
    }
}
