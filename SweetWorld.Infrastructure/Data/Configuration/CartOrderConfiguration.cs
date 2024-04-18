using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Infrastructure.Data.Configuration
{
    public class CartOrderConfiguration : IEntityTypeConfiguration<CartOrder>
    {
        public void Configure(EntityTypeBuilder<CartOrder> builder)
        {
            builder.ToTable("carts");
            builder.Property(cart => cart.Id).HasColumnName("id");
            builder.Property(cart => cart.ProductId).HasColumnName("product_id");
            builder.Property(cart => cart.ClientId).HasColumnName("client_id");
            builder.Property(cart => cart.ProductName).HasColumnName("product_name");
            builder.Property(cart => cart.ProductThumb).HasColumnName("product_thumbnail");
            builder.Property(cart => cart.ProductType).HasColumnName("product_type");
            builder.Property(cart => cart.Amount).HasColumnName("product_amount");
            builder.Property(cart => cart.UnitPrice).HasColumnName("unit_price").HasPrecision(10, 3);
            builder.Property(cart => cart.AdditionalInformation).HasColumnName("additional_information");
        }
    }
}
