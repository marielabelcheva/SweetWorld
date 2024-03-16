using Microsoft.EntityFrameworkCore;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;

        public ProductService(ApplicationDbContext dbContext) { this.dbContext =  dbContext; }

        public async Task AddProductAsync(AddProductViewModel viewModel)
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                Type = viewModel.Type,
                Price = viewModel.Price,
                Thumbnail = viewModel.Thumbnail,
                Confectioner = viewModel.Confectioner
            };

            await this.dbContext.Products.AddAsync(product);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> AllProductsAsync()
        {
            return await this.dbContext.Products.Include(product => product.Confectioner)
                                       .ThenInclude(confectioner => confectioner.User)
                                       .Select(product => new ProductViewModel()
                                       {
                                           Id = product.Id,
                                           Name = product.Name,
                                           Type = product.Type,
                                           Price = product.Price,
                                           Thumbnail = product.Thumbnail,
                                           ConfectionerName = $"{product.Confectioner.User.FirstName} {product.Confectioner.User.LastName}"
                                       }).ToListAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            Product? product = await this.dbContext.Products.FirstOrDefaultAsync(product => product.Id == id);

            if (product != null)
            {
                this.dbContext.Products.Remove(product);
                await this.dbContext.SaveChangesAsync();
            }

            throw new NullReferenceException();
        }

        public Task<EditProductViewModel> EditProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task EditProductAsync(EditProductViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
