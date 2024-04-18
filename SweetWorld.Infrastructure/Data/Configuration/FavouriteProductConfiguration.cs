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
    public class FavouriteProductConfiguration : IEntityTypeConfiguration<FavouriteProduct>
    {
        public void Configure(EntityTypeBuilder<FavouriteProduct> builder)
        {
            builder.ToTable("favourite_products");
            builder.HasKey(product => new { product.ProductId, product.ClientId });
            builder.Property(product => product.ProductId).HasColumnName("product_id");
            builder.Property(product => product.ClientId).HasColumnName("client_id");
        }
    }
}
