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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");
            builder.Property(order => order.Id).HasColumnName("id");
            builder.Property(order => order.ClientId).HasColumnName("client_id");
            builder.Property(order => order.ProductId).HasColumnName("product_id");
            builder.Property(order => order.Amount).HasColumnName("product_amount");
            builder.Property(order => order.CreationDate).HasColumnName("date_of_creating");
            builder.Property(order => order.ToDate).HasColumnName("to_date");
            builder.Property(order => order.TotalPrice).HasColumnName("total_price");
            builder.Property(order => order.AdditionalInformation).HasColumnName("additional_information");
            builder.Property(order => order.DeliveryAddress).HasColumnName("delivery_address");
            builder.Property(order => order.Status).HasColumnName("status");
        }
    }
}
