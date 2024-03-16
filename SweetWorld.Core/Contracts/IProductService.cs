using SweetWorld.Core.Models.ProductViewModels;

namespace SweetWorld.Core.Contracts
{
    public interface IProductService
    {
        //Add, Edit, Delete - without post, All - pagination, PoductsFromType - pagination, ProductData

        public Task<IEnumerable<ProductViewModel>> AllProductsAsync();

        public Task AddProductAsync(AddProductViewModel viewModel);

        public Task<EditProductViewModel> EditProductAsync(Guid id);

        public Task EditProductAsync(EditProductViewModel viewModel);

        public Task DeleteProductAsync(Guid id);
    }
}
