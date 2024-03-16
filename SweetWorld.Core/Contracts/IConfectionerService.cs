using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Core.Models.UserViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IConfectionerService
    {
        //all - pagination

        public Task AddConfectionerAsync(string userId);

        public Task<IEnumerable<UserViewModel>> GetAllConfectionersAsync();

        public Task<IEnumerable<ProductConfectionerViewModel>> AllProductsOfAConfectioner(Guid confectionerId);
    }
}
