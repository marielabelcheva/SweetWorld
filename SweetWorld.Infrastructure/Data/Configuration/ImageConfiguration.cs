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
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("images");
            builder.Property(image => image.Id).HasColumnName("id");
            builder.Property(image => image.URL).HasColumnName("url");
            builder.Property(image => image.ProductId).HasColumnName("product_id");
        }
    }
}
