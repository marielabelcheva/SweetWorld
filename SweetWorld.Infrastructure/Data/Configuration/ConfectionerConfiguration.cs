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
    public class ConfectionerConfiguration : IEntityTypeConfiguration<Confectioner>
    {
        public void Configure(EntityTypeBuilder<Confectioner> builder)
        {
            builder.ToTable("confectioners");
            builder.Property(confectioner => confectioner.Id).HasColumnName("id");
            builder.Property(confectioner => confectioner.UserId).HasColumnName("user_id");

            builder.HasData(CreateConfectioners());
        }

        private List<Confectioner> CreateConfectioners()
        {
            List<Confectioner> confectioners = new List<Confectioner>();

            Confectioner confectioner = new Confectioner()
            {
                Id = Guid.Parse("e2b8a345-064a-4381-ab50-70724003fcbd"),
                UserId = "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f"
            };

            confectioners.Add(confectioner);

            confectioner = new Confectioner()
            {
                Id = Guid.Parse("0c10b01e-1b74-48fb-ab1f-7577c7c837de"),
                UserId = "ca99e01c-6a19-45a2-9ac2-89f17f79dd08"
            };

            confectioners.Add(confectioner);

            confectioner = new Confectioner()
            {
                Id = Guid.Parse("cec94c18-629d-4491-8b26-dee405de2cfd"),
                UserId = "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75"
            };

            confectioners.Add(confectioner);

            return confectioners;
        }
    }
}
