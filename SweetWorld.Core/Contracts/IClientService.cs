using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.UserViewModels;
using SweetWorld.Infrastructure.Data.Models;

namespace SweetWorld.Core.Contracts
{
    public interface IClientService
    {
        public Task AddClientAsync(string userId);

        public Task<IEnumerable<UserViewModel>> GetAllClientsAsync();

        public Task<IEnumerable<OrderClientViewModel>> AllOrdersOfAClientAsync(Guid clientId);

        public Task<Client?> GetClientByUserIdAsync(string userId);
    }
}
