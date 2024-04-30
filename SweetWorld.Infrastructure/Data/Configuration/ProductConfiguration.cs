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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.Property(product => product.Id).HasColumnName("id");
            builder.Property(product => product.Name).HasColumnName("name");
            builder.Property(product => product.Type).HasColumnName("type");
            builder.Property(product => product.Price).HasColumnName("price").HasPrecision(10, 3);
            builder.Property(product => product.ConfectionerId).HasColumnName("confectioner_id");
            builder.Property(product => product.Thumbnail).HasColumnName("thumbnail");

            builder.HasData(CreateProducts());
        }

        private List<Product> CreateProducts()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product()
            {
                Id = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                Name = "French village cake",
                Type = "Ordinary",
                ConfectionerId = Guid.Parse("cec94c18-629d-4491-8b26-dee405de2cfd"),
                Thumbnail = "https://parmy.bg/media/cache/48/a6/thumb7_IMG_9075.jpg"
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                Name = "Eclair cake",
                Type = "Ordinary",
                ConfectionerId = Guid.Parse("0c10b01e-1b74-48fb-ab1f-7577c7c837de"),
                Thumbnail = "https://local.deweys.com/uploads/1/3/0/7/130725445/s190270156824480679_p237_i3_w1200.png"
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                Name = "Red velvet cake",
                Type = "Ordinary",
                ConfectionerId = Guid.Parse("e2b8a345-064a-4381-ab50-70724003fcbd"),
                Thumbnail = "https://pabalefoodandbeverage.in/wp-content/uploads/2024/03/Red-Velvet-Cake.jpg"
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                Name = "Red velvet cake with strawberries",
                Type = "Ordinary",
                ConfectionerId = Guid.Parse("cec94c18-629d-4491-8b26-dee405de2cfd"),
                Thumbnail = "https://tiffanysbakeryphilly.com/media/catalog/category/RedVelvetStrawberryShortcake_2_1.jpg"
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa"),
                Name = "Napoleon cake",
                Type = "Ordinary",
                ConfectionerId = Guid.Parse("0c10b01e-1b74-48fb-ab1f-7577c7c837de"),
                Thumbnail = "https://i.ytimg.com/vi/Q78skleBhp4/maxresdefault.jpg"
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5"),
                Name = "Vanilla cake",
                Type = "Ordinary",
                ConfectionerId = Guid.Parse("e2b8a345-064a-4381-ab50-70724003fcbd"),
                Thumbnail = "https://www.gratefulbites.org/wp-content/uploads/2018/02/VanillaVanillaCake.jpg"
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"),
                Name = "Chocolate cake",
                Type = "Ordinary",
                ConfectionerId = Guid.Parse("cec94c18-629d-4491-8b26-dee405de2cfd"),
                Thumbnail = "https://womenfitnessmag.com/wp-content/uploads/2020/07/Delight-Your-Mood-with-Thes.jpg"
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                Name = "Fruit cake",
                Type = "Ordinary",
                ConfectionerId = Guid.Parse("0c10b01e-1b74-48fb-ab1f-7577c7c837de"),
                Thumbnail = "https://www.bakinglikeachef.com/wp-content/uploads/fresh-fruit-cake.jpg"
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("8d23fc0e-42c7-4a64-8100-63d6cf061421"),
                Name = "Oat honey cookies / 100g",
                Type = "Vegan",
                ConfectionerId = Guid.Parse("e2b8a345-064a-4381-ab50-70724003fcbd"),
                Thumbnail = "https://www.1001recepti.com/images/photos/recipes/size_5/burzi-i-lesni-hrupkavi-vegan-oveseni-medeni-biskviti-6226b8a32b975ab20669e6628c9141ff-[111258].jpg",
                Price = 4.79m
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("4b856ddb-c40f-404e-9b06-164ebb3755cf"),
                Name = "Muffin with cocoa and banana",
                Type = "Vegan",
                ConfectionerId = Guid.Parse("cec94c18-629d-4491-8b26-dee405de2cfd"),
                Thumbnail = "https://www.1001recepti.com/images/photos/recipes/size_5/postni-vegan-mufini-s-kakao-i-banani-bez-iaica-i-bez-mliako-s-voda-1b5449a4c452597988873d251670172f-[108361].jpg",
                Price = 2.99m
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("3b4feead-b9a6-41e4-b96a-42a50609603d"),
                Name = "Vegan cookies / 100g",
                Type = "Vegan",
                ConfectionerId = Guid.Parse("0c10b01e-1b74-48fb-ab1f-7577c7c837de"),
                Thumbnail = "https://www.1001recepti.com/images/photos/recipes/size_5/vegan-biskviti-cookies-s-nahut-fustucheno-maslo-i-parchenca-shokolad-79104bbe112c4a8f3bc6c4283ef76bf9-[111257].jpg",
                Price = 5.99m
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("e4dfb73d-8426-4c5e-bade-452c6d43bc3b"),
                Name = "Chocolate chip cookies / 100g",
                Type = "Gluten-free",
                ConfectionerId = Guid.Parse("e2b8a345-064a-4381-ab50-70724003fcbd"),
                Thumbnail = "https://images.aws.nestle.recipes/resized/5b069c3ed2feea79377014f6766fcd49_Original_NTH_Chocolate_Chip_Cookie_1080_850.jpg",
                Price = 4.99m
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                Name = "Cantuccini with almonds / 100g",
                Type = "Gluten-free",
                ConfectionerId = Guid.Parse("cec94c18-629d-4491-8b26-dee405de2cfd"),
                Thumbnail = "https://po-krasivi.net/wp-content/uploads/2019/03/kantuchini-recepta-300x201.jpg",
                Price = 5.19m
            });

            products.Add(new Product()
            {
                Id = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                Name = "Muffin with avocado",
                Type = "Diabetic",
                ConfectionerId = Guid.Parse("0c10b01e-1b74-48fb-ab1f-7577c7c837de"),
                Thumbnail = "https://www.milkandhoneynutrition.com/wp-content/uploads/2020/07/Chocolate-Avocado-Muffins-3.jpg",
                Price = 3.19m
            });

            return products;
        }
    }
}
