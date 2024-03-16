using Microsoft.AspNetCore.Identity;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.UserViewModels;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly IImageService imageService;

        public UserService(UserManager<User> userManager, IImageService imageService) 
        { 
            this.userManager = userManager;
            this.imageService = imageService;
        }

        public async Task DeleteUserAsync(string id)
        {
            User user = await this.userManager.FindByIdAsync(id);

            if (user != null) { await this.userManager.DeleteAsync(user); }

            throw new NullReferenceException();
        }

        public async Task<UserViewModel> GetUserByIdAsync(string id)
        {
            User user = await this.userManager.FindByIdAsync(id);

            if (user != null)
            {
                return new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    ProfilePictureURL = user.ProfilePictureUrl
                };
            }

            throw new NullReferenceException();
        }


        public async Task UpdateUserAsync(UserViewModel viewModel)
        {
            User user = await this.userManager.FindByIdAsync(viewModel.Id);

            if (user != null) 
            {
                user.Email = viewModel.Email;
                user.PhoneNumber = viewModel.Phone;
                user.ProfilePictureUrl = await this.imageService.UploadImageAsync(viewModel.ProfilePicture, "users", user);

                await this.userManager.UpdateAsync(user);
            }

            throw new NullReferenceException();
        }
    }
}
