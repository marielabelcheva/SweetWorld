using SweetWorld.Core.Models.UserViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IUserService
    {
        public Task DeleteUserAsync(string id);

        public Task<UserViewModel> GetUserByIdAsync(string id);

        public Task UpdateUserAsync(UserViewModel viewModel);
    }
}
