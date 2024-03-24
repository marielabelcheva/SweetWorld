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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clients");
            builder.Property(client => client.Id).HasColumnName("id");
            builder.Property(client => client.UserId).HasColumnName("user_id");

            builder.HasData(CreateClients());
        }

        private List<Client> CreateClients()
        {
            List<Client> clients = new List<Client>();

            clients.Add(new Client()
            {
                Id = Guid.Parse("fa6c6780-40d5-4c7e-9e48-fd82d03190b5"),
                UserId = "7376f12c-855e-40ba-a5d5-d6a993022bf3"
            });

            clients.Add(new Client()
            {
                Id = Guid.Parse("c96d52c3-571e-4381-a724-b88c58492caa"),
                UserId = "a501c64b-74f7-46b7-a938-bda911a77b81"
            });

            return clients;
        }
    }
}
