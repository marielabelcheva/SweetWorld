using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.UserViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IClientService
    {
        //all clients - pagination

        public Task AddClientAsync(string userId);

        public Task<IEnumerable<UserViewModel>> GetAllClientsAsync();

        public Task<IEnumerable<OrderClientViewModel>> AllOrdersOfAClientAsync(Guid clientId);
    }
}
