using Microsoft.AspNetCore.Identity;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.UserViewModels;
using SweetWorld.Infrastructure.Data;
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
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext) 
        { 
            this.dbContext = dbContext;
        }

        public async Task DeleteUserAsync(string? id)
        {
            User? user = await this.dbContext.Users.FindAsync(id);

            if (user != null) 
            { 
                this.dbContext.Users.Remove(user);
                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }

        public async Task<UserViewModel> GetUserByIdAsync(string? id)
        {
            User? user = await this.dbContext.Users.FindAsync(id);

            if (user != null)
            {
                return new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    ProfilePictureURL = user.ProfilePictureUrl
                };
            }

            throw new NullReferenceException();
        }


        public async Task UpdateUserAsync(UserViewModel viewModel)
        {
            User? user = await this.dbContext.Users.FindAsync(viewModel.Id);

            if (user != null) 
            {
                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;
                user.Email = viewModel.Email;

                await this.dbContext.SaveChangesAsync();
            }

            else throw new NullReferenceException();
        }
    }
}
