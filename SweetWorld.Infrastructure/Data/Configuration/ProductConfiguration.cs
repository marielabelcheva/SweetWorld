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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.Property(product => product.Id).HasColumnName("id");
            builder.Property(product => product.Name).HasColumnName("name");
            builder.Property(product => product.Type).HasColumnName("type");
            builder.Property(product => product.Price).HasColumnName("price");
            builder.Property(product => product.ConfectionerId).HasColumnName("confectioner_id");
            builder.Ignore(product => product.PiecesCountShapeAndPrice);

            builder.HasData(CreateProducts());
        }

        private List<Product> CreateProducts()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product()
            {
            });

            return products;
        }
    }
}
