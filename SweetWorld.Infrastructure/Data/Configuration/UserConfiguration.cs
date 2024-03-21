using Microsoft.AspNetCore.Identity;
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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.UserName).HasMaxLength(20);
            builder.Property(user => user.Email).HasMaxLength(60).IsRequired();
            builder.Property(user => user.PhoneNumber).HasMaxLength(10).IsRequired();

            builder.HasData(CreateUsers());

        }

        private List<User> CreateUsers()
        {
            List<User> users = new List<User>();
            PasswordHasher<User> hasher = new PasswordHasher<User>();

            User user = new User()
            {
                Id = "7376f12c-855e-40ba-a5d5-d6a993022bf3",
                FirstName = "Geri",
                LastName = "Tsaneva",
                UserName = "geri88",
                NormalizedUserName = "GERI88",
                Email = "geritsaneva@gmail.com",
                NormalizedEmail = "GERITSANEVA@GMAIL.COM",
                PhoneNumber = "0893052673"
            };

            user.PasswordHash = hasher.HashPassword(user, "Geri88@");
            users.Add(user);

            user = new User()
            {
                Id = "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f",
                FirstName = "Kaly",
                LastName = "Malchinikolova",
                UserName = "kaly79",
                NormalizedUserName = "KALY79",
                Email = "kalypo3@gmail.com",
                NormalizedEmail = "kalypo3@GMAIL.COM",
                PhoneNumber = "0888752419"
            };

            user.PasswordHash = hasher.HashPassword(user, "Kaly79@");
            users.Add(user);

            user = new User()
            {
                Id = "06f7430b-dfbf-42ed-9618-20f2cfd24875",
                FirstName = "Meri",
                LastName = "Belcheva",
                UserName = "meri05",
                NormalizedUserName = "MERI05",
                Email = "meribelcheva@gmail.com",
                NormalizedEmail = "MERIBELCHEVA@GMAIL.COM",
                PhoneNumber = "0898508050"
            };

            user.PasswordHash = hasher.HashPassword(user, "Meri05@");
            users.Add(user);

            user = new User()
            {
                Id = "a501c64b-74f7-46b7-a938-bda911a77b81",
                FirstName = "Hrisi",
                LastName = "Miteva",
                UserName = "hrisi05",
                NormalizedUserName = "HRISI05",
                Email = "hrisimiteva@gmail.com",
                NormalizedEmail = "HRISIMITEVA@GMAIL.COM",
                PhoneNumber = "0895719337"
            };

            user.PasswordHash = hasher.HashPassword(user, "Hrisi05@");
            users.Add(user);

            user = new User()
            {
                Id = "ca99e01c-6a19-45a2-9ac2-89f17f79dd08",
                FirstName = "Ognyan",
                LastName = "Kirilov",
                UserName = "ognyan06",
                NormalizedUserName = "OGNYAN06",
                Email = "ognyankirilov@gmail.com",
                NormalizedEmail = "OGNYANKIRILOV@GMAIL.COM",
                PhoneNumber = "0897373378"
            };

            user.PasswordHash = hasher.HashPassword(user, "Ognyan06@");
            users.Add(user);

            user = new User()
            {
                Id = "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75",
                FirstName = "Elitsa",
                LastName = "Georgieva",
                UserName = "elitsa89",
                NormalizedUserName = "ELITSA89",
                Email = "elitsageorgieva@gmail.com",
                NormalizedEmail = "ELITSAGEORGIEVA@GMAIL.COM",
                PhoneNumber = "0896999728"
            };

            user.PasswordHash = hasher.HashPassword(user, "Elitsa89@");
            users.Add(user);

            return users;
        }
    }
}
