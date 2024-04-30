﻿using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SweetWorld.Core.Contracts
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewModel>> AllProductsAsync();

        public Task AddProductAsync(AddProductViewModel viewModel, Guid? confectionerId);

        public Task<EditProductViewModel> EditProductAsync(Guid? id);

        public Task EditProductAsync(EditProductViewModel viewModel);

        public Task DeleteProductAsync(Guid? id);

        public Task<ProductDataViewModel> ProductDataAsync(Guid? id);

        public Task<IEnumerable<ProductViewModel>> GetProductsFromTypeAsync(string type);

        public Task<IEnumerable<ProductViewModel>> GetProductsFromCategoryAsync(string? categoryName);

        public Task<IEnumerable<ProductViewModel>> GetProductsByPriceAsync(decimal price = 0.0m);

        public Task LikeProductAsync(Guid? id, Guid? clientId);

        public Task<IEnumerable<ProductViewModel>> WishListAsync(Guid? clientId);

        public Task AddPiecesCountAndPrice(PiecesCountAndPriceViewModel viewModel, Guid? productId);

        public Task DeleteFromWishListAsync(Guid? productId, Guid? clientId);

        public Task<SelectList> GetPiecesCountOfAProductAsync(Guid? productId);

        public Task<IEnumerable<string?>> GetAllTypesAsync();

        public Task<IEnumerable<string?>> GetAllCategoriesAsync();
    }
}
