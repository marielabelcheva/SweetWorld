using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Infrastructure.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder) { builder.HasData(CreateRoles()); }

        private List<IdentityRole> CreateRoles()
        {
            List<IdentityRole> roles = new List<IdentityRole>();

            roles.Add(new IdentityRole()
            {
                Id = "1dcab376-7fa5-4514-8528-c0bc09e12627",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });

            roles.Add(new IdentityRole()
            {
                Id = "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6",
                Name = "Client",
                NormalizedName = "CLIENT"
            });

            roles.Add(new IdentityRole()
            {
                Id = "bde985f1-7ae2-4da7-a2b3-afc16ad1c528",
                Name = "Confectioner",
                NormalizedName = "CONFECTIONER"
            });

            return roles;
        }
    }
}
