using SweetWorld.Core.Models.ProductViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IProductService
    {
        //Add, Edit, Delete, All - pagination, PoductsFromType - pagination, ProductData

        public Task AddProductAsync(AddProductViewModel viewModel);
    }
}
