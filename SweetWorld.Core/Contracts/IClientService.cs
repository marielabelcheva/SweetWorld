using SweetWorld.Core.Models.UserViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IClientService
    {
        //all clients - pagination, delete - without post (client sends request for deleting and
        //after aproving from admin - admin sends email to client to inform him that his profile has been removed)

        public Task AddClientAsync(string userId);

        public Task<IEnumerable<UserViewModel>> GetAllClientsAsync();
    }
}
