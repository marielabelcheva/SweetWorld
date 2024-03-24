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
    public class UsersRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder) { builder.HasData(GiveUsersRoles()); }

        private List<IdentityUserRole<string>> GiveUsersRoles()
        {
            var users = new List<IdentityUserRole<string>>();

            users.Add(new IdentityUserRole<string>()
            {
                RoleId = "1dcab376-7fa5-4514-8528-c0bc09e12627",
                UserId = "06f7430b-dfbf-42ed-9618-20f2cfd24875"
            });

            users.Add(new IdentityUserRole<string>()
            {
                RoleId = "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6",
                UserId = "7376f12c-855e-40ba-a5d5-d6a993022bf3"
            });

            users.Add(new IdentityUserRole<string>()
            {
                RoleId = "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6",
                UserId = "a501c64b-74f7-46b7-a938-bda911a77b81"
            });

            users.Add(new IdentityUserRole<string>()
            {
                RoleId = "bde985f1-7ae2-4da7-a2b3-afc16ad1c528",
                UserId = "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f"
            });

            users.Add(new IdentityUserRole<string>()
            {
                RoleId = "bde985f1-7ae2-4da7-a2b3-afc16ad1c528",
                UserId = "ca99e01c-6a19-45a2-9ac2-89f17f79dd08"
            });

            users.Add(new IdentityUserRole<string>()
            {
                RoleId = "bde985f1-7ae2-4da7-a2b3-afc16ad1c528",
                UserId = "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75"
            });

            return users;
        }
    }
}
