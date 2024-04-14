using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Infrastructure.Data.Configuration
{
    public class ProductsCategoriesConfiguration : IEntityTypeConfiguration<ProductsCategories>
    {
        public void Configure(EntityTypeBuilder<ProductsCategories> builder)
        {
            builder.ToTable("products_categories");
            builder.HasKey(product => new { product.CategoryId, product.ProductId });
            builder.Property(product => product.ProductId).HasColumnName("product_id");
            builder.Property(product => product.CategoryId).HasColumnName("category_id");

            builder.HasData(CreateProductsCategories());
        }

        private List<ProductsCategories> CreateProductsCategories()
        {
            List<ProductsCategories> productsCategories = new List<ProductsCategories>();

            productsCategories.AddRange(new List<ProductsCategories>()
            {
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    CategoryId = Guid.Parse("46371267-0d7c-4e7a-a64f-8716972f0f54")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    CategoryId = Guid.Parse("46371267-0d7c-4e7a-a64f-8716972f0f54")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa"),
                    CategoryId = Guid.Parse("46371267-0d7c-4e7a-a64f-8716972f0f54")
                }
            });

            productsCategories.AddRange(new List<ProductsCategories>()
            {
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                    CategoryId = Guid.Parse("bd6b7990-7394-4c6e-af12-981ac6e2d28b")
                }
            });

            productsCategories.AddRange(new List<ProductsCategories>()
            {
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("4b856ddb-c40f-404e-9b06-164ebb3755cf"),
                    CategoryId = Guid.Parse("a313707e-4307-4e0e-91b9-5ecd4399931f")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                    CategoryId = Guid.Parse("a313707e-4307-4e0e-91b9-5ecd4399931f")
                }
            });

            productsCategories.AddRange(new List<ProductsCategories>()
            {
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    CategoryId = Guid.Parse("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    CategoryId = Guid.Parse("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    CategoryId = Guid.Parse("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    CategoryId = Guid.Parse("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa"),
                    CategoryId = Guid.Parse("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5"),
                    CategoryId = Guid.Parse("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"),
                    CategoryId = Guid.Parse("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    CategoryId = Guid.Parse("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc")
                }
            });

            productsCategories.AddRange(new List<ProductsCategories>()
            {
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("8d23fc0e-42c7-4a64-8100-63d6cf061421"),
                    CategoryId = Guid.Parse("85901598-c0eb-49ac-93d7-8e680de25a68")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("3b4feead-b9a6-41e4-b96a-42a50609603d"),
                    CategoryId = Guid.Parse("85901598-c0eb-49ac-93d7-8e680de25a68")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("e4dfb73d-8426-4c5e-bade-452c6d43bc3b"),
                    CategoryId = Guid.Parse("85901598-c0eb-49ac-93d7-8e680de25a68")
                },
                new ProductsCategories()
                {
                    ProductId = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                    CategoryId = Guid.Parse("85901598-c0eb-49ac-93d7-8e680de25a68")
                }
            });

            return productsCategories;
        }
    }
}
