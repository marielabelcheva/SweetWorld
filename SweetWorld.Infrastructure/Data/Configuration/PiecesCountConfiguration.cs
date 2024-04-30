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
    public class PiecesCountConfiguration : IEntityTypeConfiguration<PiecesCount>
    {
        public void Configure(EntityTypeBuilder<PiecesCount> builder)
        {
            builder.ToTable("pieces_count");
            builder.Property(count => count.Id).HasColumnName("id");
            builder.Property(count => count.ProductId).HasColumnName("product_id");
            builder.Property(count => count.Price).HasColumnName("price").HasPrecision(10, 3);
            builder.Property(count => count.Count).HasColumnName("count");

            builder.HasData(GetPices());
        }

        private List<PiecesCount> GetPices()
        {
            List<PiecesCount> pieces = new List<PiecesCount>();

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 1,
                Price = 4.79m,
                ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 16,
                Price = 70.49m,
                ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 28,
                Price = 94.49m,
                ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 1,
                Price = 6.29m,
                ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 8,
                Price = 52.49m,
                ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 14,
                Price = 82.49m,
                ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 21,
                Price = 115.49m,
                ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 28,
                Price = 127.49m,
                ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 1,
                Price = 4.49m,
                ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 8,
                Price = 37.49m,
                ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 14,
                Price = 59.99m,
                ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 16,
                Price = 67.49m,
                ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 21,
                Price = 85.49m,
                ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 28,
                Price = 97.49m,
                ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 1,
                Price = 5.29m,
                ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 14,
                Price = 67.49m,
                ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 25,
                Price = 103.49m,
                ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 28,
                Price = 107.99m,
                ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 1,
                Price = 5.69m,
                ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 14,
                Price = 74.99m,
                ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 21,
                Price = 94.49m,
                ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 1,
                Price = 3.29m,
                ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 8,
                Price = 29.99m,
                ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 16,
                Price = 52.49m,
                ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 25,
                Price = 77.99m,
                ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 28,
                Price = 82.49m,
                ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 1,
                Price = 4.79m,
                ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 8,
                Price = 37.49m,
                ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 16,
                Price = 67.49m,
                ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 28,
                Price = 94.49m,
                ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 36,
                Price = 137.99m,
                ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 1,
                Price = 5.99m,
                ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 8,
                Price = 49.49m,
                ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 14,
                Price = 77.99m,
                ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 21,
                Price = 112.49m,
                ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2")
            });

            pieces.Add(new PiecesCount()
            {
                Id = Guid.NewGuid(),
                Count = 28,
                Price = 119.99m,
                ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2")
            });

            return pieces;
        }
    }
}
