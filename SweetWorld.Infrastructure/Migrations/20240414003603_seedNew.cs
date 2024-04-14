using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetWorld.Infrastructure.Data.Migrations
{
    public partial class seedNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "products",
                newName: "thumbnail");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "products",
                type: "decimal(10,3)",
                precision: 10,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "total_price",
                table: "orders",
                type: "decimal(10,3)",
                precision: 10,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "delivery_address",
                table: "orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "product_amount",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dcab376-7fa5-4514-8528-c0bc09e12627", "7544cea2-9750-4770-8cc4-66e26942199a", "Administrator", "ADMINISTRATOR" },
                    { "bde985f1-7ae2-4da7-a2b3-afc16ad1c528", "e7c98515-ec85-4ea8-af49-b55870338d69", "Confectioner", "CONFECTIONER" },
                    { "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6", "d0a0f126-2c35-4c7e-b3f6-a07803e2dfb8", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06f7430b-dfbf-42ed-9618-20f2cfd24875", 0, "db2f0e02-ebd2-4e5b-a47d-beb3fc4bc50a", "meribelcheva@gmail.com", false, "Meri", "Belcheva", false, null, "MERIBELCHEVA@GMAIL.COM", "MERI05", "AQAAAAEAACcQAAAAEOgGJSxo5zGha8ncZtoEWMuDy73OGKwLELbAjIDTj0Gk7x8ksO4hjlC6pUC5aB6R5w==", "0898508050", false, null, "44bf2474-b8a4-475c-991f-6f89ccd43019", false, "meri05" },
                    { "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75", 0, "69293a71-2ffd-4396-850a-4b68cc43239c", "elitsageorgieva@gmail.com", false, "Elitsa", "Georgieva", false, null, "ELITSAGEORGIEVA@GMAIL.COM", "ELITSA89", "AQAAAAEAACcQAAAAENUb324lx03wxKu4bUcxtLzDLJyrNl98UeQa+WN4iviBJGB5w4RQHodXy8vRMSoVLg==", "0896999728", false, null, "6b1629fe-319b-4e8a-b0e0-2275157fb4a3", false, "elitsa89" },
                    { "7376f12c-855e-40ba-a5d5-d6a993022bf3", 0, "eef3d6b9-3c76-4bdb-8cb6-9bd98a24796c", "geritsaneva@gmail.com", false, "Geri", "Tsaneva", false, null, "GERITSANEVA@GMAIL.COM", "GERI88", "AQAAAAEAACcQAAAAEERWeuG6PoYK+xYtFV0HL+8zUwOvOtprVa9UIplLd2KhDlprLbT19m60RLsmb/cKxQ==", "0893052673", false, null, "924a7544-cbac-4138-a6e9-c17a1fb03b51", false, "geri88" },
                    { "a501c64b-74f7-46b7-a938-bda911a77b81", 0, "4e23ab02-8f65-4192-a4ff-7f5ef6201532", "hrisimiteva@gmail.com", false, "Hrisi", "Miteva", false, null, "HRISIMITEVA@GMAIL.COM", "HRISI05", "AQAAAAEAACcQAAAAEHa3v5PkNcuK5fgeyQtj5YIsg/i4hM6AFftTXjXVdOxSvDmvBEEA866Mbb6BXqVUAQ==", "0895719337", false, null, "dfff5f02-68b7-4fc4-a020-9291498a786d", false, "hrisi05" },
                    { "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f", 0, "8b0cb05d-3bb4-465f-beb9-51c1915b4c8b", "kalypo3@gmail.com", false, "Kaly", "Malchinikolova", false, null, "kalypo3@GMAIL.COM", "KALY79", "AQAAAAEAACcQAAAAEMuiPBN3//0u+azPCZq+Kmcs+ncbZEbZFAwQD5OKBS/LpZYp/eRUtrDJ3bsLqXHg7w==", "0888752419", false, null, "72b7a7da-7b20-484b-ac35-00707a637d47", false, "kaly79" },
                    { "ca99e01c-6a19-45a2-9ac2-89f17f79dd08", 0, "53f0a675-c514-4537-810a-f6304ecaa4e6", "ognyankirilov@gmail.com", false, "Ognyan", "Kirilov", false, null, "OGNYANKIRILOV@GMAIL.COM", "OGNYAN06", "AQAAAAEAACcQAAAAEKCYyxwnQxd6X5RPrN9WYnXpIB/7SFHZFO9q+oQeZmcS1n9YvT++vBIlia4FCWW2RQ==", "0897373378", false, null, "195b1c40-30d3-41e9-956a-42aec07cc6ce", false, "ognyan06" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("46371267-0d7c-4e7a-a64f-8716972f0f54"), "French pastries" },
                    { new Guid("85901598-c0eb-49ac-93d7-8e680de25a68"), "Cookies" },
                    { new Guid("a313707e-4307-4e0e-91b9-5ecd4399931f"), "Muffins" },
                    { new Guid("bd6b7990-7394-4c6e-af12-981ac6e2d28b"), "Italian pastries" },
                    { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), "Cakes" }
                });

            migrationBuilder.InsertData(
                table: "ingredients",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("05810086-be70-48b4-a40c-0330ebea7f7e"), "grape seed oil" },
                    { new Guid("0955c74b-8e3c-4ad6-97fc-bdc72c4a70f2"), "chickpeas" },
                    { new Guid("16fe2f69-513c-4277-af3d-52b641fe9487"), "water" },
                    { new Guid("1776e340-9db2-453a-b29f-947b732796cc"), "lemon juice" },
                    { new Guid("19c410e1-f574-4e2e-b235-51906d01c727"), "white chocolate" },
                    { new Guid("1c73c664-4242-467f-a13f-5816ed222b97"), "carob flour" },
                    { new Guid("25464223-7321-45e1-a377-e3d3bc9a1a70"), "avocado" },
                    { new Guid("26e2241b-5ef0-4998-bf81-3be8b5c5dd64"), "almond flour" },
                    { new Guid("287e7803-b225-4131-b7f4-e3b57de672af"), "red food coloring" },
                    { new Guid("2d8b869c-ef64-44d9-807a-1221ff08e3b9"), "stevia" },
                    { new Guid("59a4a752-8e59-4cc9-a5f2-5b52f5e998ca"), "corn flour" },
                    { new Guid("5a35c906-4373-43ef-a4c5-316058e22536"), "brown sugar" },
                    { new Guid("5df10646-eaea-4040-b50c-393cf49ca75e"), "seasonal fruit" },
                    { new Guid("5f89b69f-ee79-488e-bd01-9527b101493a"), "spelt flour" },
                    { new Guid("65009db2-6a67-470e-951b-b9dfd68109f8"), "rice flour" },
                    { new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"), "sunflower oil" },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), "eggs" },
                    { new Guid("6ad109c5-e8e7-4f40-8c0e-434f272db285"), "cinnamon" },
                    { new Guid("701c2a97-48ac-4781-8a08-c60c6aa3f040"), "oat flakes" },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), "vanilla" },
                    { new Guid("775e23ed-1fb6-4125-b23c-c43cb98fe1b6"), "honey" },
                    { new Guid("7d52d73e-b4e5-45f6-999e-9e7bd42e8a93"), "strawberries" },
                    { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), "flour" },
                    { new Guid("8e394b57-2c7a-42a1-b700-263d57f8cc5e"), "jam" },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), "baking powder" },
                    { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), "sugar" },
                    { new Guid("ac3d8343-895b-4805-aaeb-3b0d2f9de96a"), "banana" },
                    { new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"), "dark chocolate" }
                });

            migrationBuilder.InsertData(
                table: "ingredients",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("ad8bddfd-a20d-4f5b-b53b-86e008dc3fc1"), "peanut butter" },
                    { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), "cocoa" },
                    { new Guid("be3ebdea-a67c-4a28-b83e-c238cb85c09d"), "coconut oil" },
                    { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), "butter" },
                    { new Guid("c067592d-7db2-476b-8216-da94a089b269"), "puff pastry" },
                    { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), "milk" },
                    { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), "wipping cream" },
                    { new Guid("d8acfa7d-2e90-4fc3-a2a0-89441d7866c2"), "orange essential oil" },
                    { new Guid("d90013c0-3372-4dce-8376-9d50e1952a0d"), "apple" },
                    { new Guid("e880c006-3af2-4d28-b8a4-7684cb986185"), "walnuts" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1dcab376-7fa5-4514-8528-c0bc09e12627", "06f7430b-dfbf-42ed-9618-20f2cfd24875" },
                    { "bde985f1-7ae2-4da7-a2b3-afc16ad1c528", "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75" },
                    { "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6", "7376f12c-855e-40ba-a5d5-d6a993022bf3" },
                    { "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6", "a501c64b-74f7-46b7-a938-bda911a77b81" },
                    { "bde985f1-7ae2-4da7-a2b3-afc16ad1c528", "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f" },
                    { "bde985f1-7ae2-4da7-a2b3-afc16ad1c528", "ca99e01c-6a19-45a2-9ac2-89f17f79dd08" }
                });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "id", "user_id" },
                values: new object[,]
                {
                    { new Guid("c96d52c3-571e-4381-a724-b88c58492caa"), "a501c64b-74f7-46b7-a938-bda911a77b81" },
                    { new Guid("fa6c6780-40d5-4c7e-9e48-fd82d03190b5"), "7376f12c-855e-40ba-a5d5-d6a993022bf3" }
                });

            migrationBuilder.InsertData(
                table: "confectioners",
                columns: new[] { "id", "user_id" },
                values: new object[,]
                {
                    { new Guid("0c10b01e-1b74-48fb-ab1f-7577c7c837de"), "ca99e01c-6a19-45a2-9ac2-89f17f79dd08" },
                    { new Guid("cec94c18-629d-4491-8b26-dee405de2cfd"), "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75" },
                    { new Guid("e2b8a345-064a-4381-ab50-70724003fcbd"), "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "confectioner_id", "name", "price", "thumbnail", "type" },
                values: new object[,]
                {
                    { new Guid("1824a2d5-1519-4173-b628-6ccee98019b2"), new Guid("0c10b01e-1b74-48fb-ab1f-7577c7c837de"), "Fruit cake", null, "https://www.bakinglikeachef.com/wp-content/uploads/fresh-fruit-cake.jpg", "Ordinary" },
                    { new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d"), new Guid("0c10b01e-1b74-48fb-ab1f-7577c7c837de"), "Vegan cookies / 100g", 5.99m, "https://www.1001recepti.com/images/photos/recipes/size_5/vegan-biskviti-cookies-s-nahut-fustucheno-maslo-i-parchenca-shokolad-79104bbe112c4a8f3bc6c4283ef76bf9-[111257].jpg", "Vegan" },
                    { new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf"), new Guid("cec94c18-629d-4491-8b26-dee405de2cfd"), "Muffin with cocoa and banana", 2.99m, "https://www.1001recepti.com/images/photos/recipes/size_5/postni-vegan-mufini-s-kakao-i-banani-bez-iaica-i-bez-mliako-s-voda-1b5449a4c452597988873d251670172f-[108361].jpg", "Vegan" },
                    { new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"), new Guid("cec94c18-629d-4491-8b26-dee405de2cfd"), "Red velvet cake with strawberries", null, "https://tiffanysbakeryphilly.com/media/catalog/category/RedVelvetStrawberryShortcake_2_1.jpg", "Ordinary" },
                    { new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa"), new Guid("0c10b01e-1b74-48fb-ab1f-7577c7c837de"), "Napoleon cake", null, "https://i.ytimg.com/vi/Q78skleBhp4/maxresdefault.jpg", "Ordinary" },
                    { new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"), new Guid("cec94c18-629d-4491-8b26-dee405de2cfd"), "Chocolate cake", null, "https://womenfitnessmag.com/wp-content/uploads/2020/07/Delight-Your-Mood-with-Thes.jpg", "Ordinary" },
                    { new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421"), new Guid("e2b8a345-064a-4381-ab50-70724003fcbd"), "Oat honey cookies / 100g", 4.79m, "https://www.1001recepti.com/images/photos/recipes/size_5/burzi-i-lesni-hrupkavi-vegan-oveseni-medeni-biskviti-6226b8a32b975ab20669e6628c9141ff-[111258].jpg", "Vegan" },
                    { new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102"), new Guid("e2b8a345-064a-4381-ab50-70724003fcbd"), "Red velvet cake", null, "https://pabalefoodandbeverage.in/wp-content/uploads/2024/03/Red-Velvet-Cake.jpg", "Ordinary" },
                    { new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01"), new Guid("cec94c18-629d-4491-8b26-dee405de2cfd"), "Cantuccini with almonds / 100g", 5.19m, "https://po-krasivi.net/wp-content/uploads/2019/03/kantuchini-recepta-300x201.jpg", "Gluten-free" },
                    { new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f"), new Guid("0c10b01e-1b74-48fb-ab1f-7577c7c837de"), "Muffin with avocado", 3.19m, "https://www.milkandhoneynutrition.com/wp-content/uploads/2020/07/Chocolate-Avocado-Muffins-3.jpg", "Diabetic" },
                    { new Guid("dea18594-de69-4d30-9acd-0f2af621d27f"), new Guid("0c10b01e-1b74-48fb-ab1f-7577c7c837de"), "Eclair cake", null, "https://local.deweys.com/uploads/1/3/0/7/130725445/s190270156824480679_p237_i3_w1200.png", "Ordinary" },
                    { new Guid("defc5f08-42d7-495f-bd66-a762226d29c5"), new Guid("e2b8a345-064a-4381-ab50-70724003fcbd"), "Vanilla cake", null, "https://www.gratefulbites.org/wp-content/uploads/2018/02/VanillaVanillaCake.jpg", "Ordinary" },
                    { new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b"), new Guid("e2b8a345-064a-4381-ab50-70724003fcbd"), "Chocolate chip cookies / 100g", 4.99m, "https://images.aws.nestle.recipes/resized/5b069c3ed2feea79377014f6766fcd49_Original_NTH_Chocolate_Chip_Cookie_1080_850.jpg", "Gluten-free" },
                    { new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628"), new Guid("cec94c18-629d-4491-8b26-dee405de2cfd"), "French village cake", null, "https://parmy.bg/media/cache/48/a6/thumb7_IMG_9075.jpg", "Ordinary" }
                });

            migrationBuilder.InsertData(
                table: "products_categories",
                columns: new[] { "category_id", "product_id" },
                values: new object[,]
                {
                    { new Guid("46371267-0d7c-4e7a-a64f-8716972f0f54"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("46371267-0d7c-4e7a-a64f-8716972f0f54"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("46371267-0d7c-4e7a-a64f-8716972f0f54"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("85901598-c0eb-49ac-93d7-8e680de25a68"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") },
                    { new Guid("85901598-c0eb-49ac-93d7-8e680de25a68"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") },
                    { new Guid("85901598-c0eb-49ac-93d7-8e680de25a68"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") },
                    { new Guid("85901598-c0eb-49ac-93d7-8e680de25a68"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") },
                    { new Guid("a313707e-4307-4e0e-91b9-5ecd4399931f"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") },
                    { new Guid("a313707e-4307-4e0e-91b9-5ecd4399931f"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") },
                    { new Guid("bd6b7990-7394-4c6e-af12-981ac6e2d28b"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") },
                    { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") }
                });

            migrationBuilder.InsertData(
                table: "products_ingredients",
                columns: new[] { "ingredient_id", "product_id" },
                values: new object[,]
                {
                    { new Guid("05810086-be70-48b4-a40c-0330ebea7f7e"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") },
                    { new Guid("0955c74b-8e3c-4ad6-97fc-bdc72c4a70f2"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") },
                    { new Guid("16fe2f69-513c-4277-af3d-52b641fe9487"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("16fe2f69-513c-4277-af3d-52b641fe9487"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") },
                    { new Guid("16fe2f69-513c-4277-af3d-52b641fe9487"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("16fe2f69-513c-4277-af3d-52b641fe9487"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("1776e340-9db2-453a-b29f-947b732796cc"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("1776e340-9db2-453a-b29f-947b732796cc"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("19c410e1-f574-4e2e-b235-51906d01c727"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("19c410e1-f574-4e2e-b235-51906d01c727"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("1c73c664-4242-467f-a13f-5816ed222b97"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") },
                    { new Guid("25464223-7321-45e1-a377-e3d3bc9a1a70"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") },
                    { new Guid("26e2241b-5ef0-4998-bf81-3be8b5c5dd64"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") },
                    { new Guid("287e7803-b225-4131-b7f4-e3b57de672af"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("287e7803-b225-4131-b7f4-e3b57de672af"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("2d8b869c-ef64-44d9-807a-1221ff08e3b9"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") },
                    { new Guid("59a4a752-8e59-4cc9-a5f2-5b52f5e998ca"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") },
                    { new Guid("5a35c906-4373-43ef-a4c5-316058e22536"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") },
                    { new Guid("5a35c906-4373-43ef-a4c5-316058e22536"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") },
                    { new Guid("5df10646-eaea-4040-b50c-393cf49ca75e"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("5f89b69f-ee79-488e-bd01-9527b101493a"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") },
                    { new Guid("5f89b69f-ee79-488e-bd01-9527b101493a"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") },
                    { new Guid("65009db2-6a67-470e-951b-b9dfd68109f8"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") },
                    { new Guid("65009db2-6a67-470e-951b-b9dfd68109f8"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") }
                });

            migrationBuilder.InsertData(
                table: "products_ingredients",
                columns: new[] { "ingredient_id", "product_id" },
                values: new object[,]
                {
                    { new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") },
                    { new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") },
                    { new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") },
                    { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("6ad109c5-e8e7-4f40-8c0e-434f272db285"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") },
                    { new Guid("6ad109c5-e8e7-4f40-8c0e-434f272db285"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") },
                    { new Guid("6ad109c5-e8e7-4f40-8c0e-434f272db285"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") },
                    { new Guid("701c2a97-48ac-4781-8a08-c60c6aa3f040"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("775e23ed-1fb6-4125-b23c-c43cb98fe1b6"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") },
                    { new Guid("775e23ed-1fb6-4125-b23c-c43cb98fe1b6"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") },
                    { new Guid("775e23ed-1fb6-4125-b23c-c43cb98fe1b6"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("7d52d73e-b4e5-45f6-999e-9e7bd42e8a93"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") },
                    { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") }
                });

            migrationBuilder.InsertData(
                table: "products_ingredients",
                columns: new[] { "ingredient_id", "product_id" },
                values: new object[,]
                {
                    { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("8e394b57-2c7a-42a1-b700-263d57f8cc5e"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") },
                    { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") },
                    { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("ac3d8343-895b-4805-aaeb-3b0d2f9de96a"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") },
                    { new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") },
                    { new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") },
                    { new Guid("ad8bddfd-a20d-4f5b-b53b-86e008dc3fc1"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") },
                    { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") },
                    { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") },
                    { new Guid("be3ebdea-a67c-4a28-b83e-c238cb85c09d"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") },
                    { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") }
                });

            migrationBuilder.InsertData(
                table: "products_ingredients",
                columns: new[] { "ingredient_id", "product_id" },
                values: new object[,]
                {
                    { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") },
                    { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("c067592d-7db2-476b-8216-da94a089b269"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("d8acfa7d-2e90-4fc3-a2a0-89441d7866c2"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") },
                    { new Guid("d90013c0-3372-4dce-8376-9d50e1952a0d"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") },
                    { new Guid("e880c006-3af2-4d28-b8a4-7684cb986185"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") },
                    { new Guid("e880c006-3af2-4d28-b8a4-7684cb986185"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_client_id",
                table: "orders",
                column: "client_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_client_id",
                table: "orders");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1dcab376-7fa5-4514-8528-c0bc09e12627", "06f7430b-dfbf-42ed-9618-20f2cfd24875" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bde985f1-7ae2-4da7-a2b3-afc16ad1c528", "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6", "7376f12c-855e-40ba-a5d5-d6a993022bf3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6", "a501c64b-74f7-46b7-a938-bda911a77b81" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bde985f1-7ae2-4da7-a2b3-afc16ad1c528", "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bde985f1-7ae2-4da7-a2b3-afc16ad1c528", "ca99e01c-6a19-45a2-9ac2-89f17f79dd08" });

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "id",
                keyValue: new Guid("c96d52c3-571e-4381-a724-b88c58492caa"));

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "id",
                keyValue: new Guid("fa6c6780-40d5-4c7e-9e48-fd82d03190b5"));

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("46371267-0d7c-4e7a-a64f-8716972f0f54"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("46371267-0d7c-4e7a-a64f-8716972f0f54"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("46371267-0d7c-4e7a-a64f-8716972f0f54"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("85901598-c0eb-49ac-93d7-8e680de25a68"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("85901598-c0eb-49ac-93d7-8e680de25a68"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("85901598-c0eb-49ac-93d7-8e680de25a68"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("85901598-c0eb-49ac-93d7-8e680de25a68"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("a313707e-4307-4e0e-91b9-5ecd4399931f"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("a313707e-4307-4e0e-91b9-5ecd4399931f"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("bd6b7990-7394-4c6e-af12-981ac6e2d28b"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") });

            migrationBuilder.DeleteData(
                table: "products_categories",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("05810086-be70-48b4-a40c-0330ebea7f7e"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("0955c74b-8e3c-4ad6-97fc-bdc72c4a70f2"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("16fe2f69-513c-4277-af3d-52b641fe9487"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("16fe2f69-513c-4277-af3d-52b641fe9487"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("16fe2f69-513c-4277-af3d-52b641fe9487"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("16fe2f69-513c-4277-af3d-52b641fe9487"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("1776e340-9db2-453a-b29f-947b732796cc"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("1776e340-9db2-453a-b29f-947b732796cc"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("19c410e1-f574-4e2e-b235-51906d01c727"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("19c410e1-f574-4e2e-b235-51906d01c727"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("1c73c664-4242-467f-a13f-5816ed222b97"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("25464223-7321-45e1-a377-e3d3bc9a1a70"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("26e2241b-5ef0-4998-bf81-3be8b5c5dd64"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("287e7803-b225-4131-b7f4-e3b57de672af"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("287e7803-b225-4131-b7f4-e3b57de672af"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("2d8b869c-ef64-44d9-807a-1221ff08e3b9"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("59a4a752-8e59-4cc9-a5f2-5b52f5e998ca"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("5a35c906-4373-43ef-a4c5-316058e22536"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("5a35c906-4373-43ef-a4c5-316058e22536"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("5df10646-eaea-4040-b50c-393cf49ca75e"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("5f89b69f-ee79-488e-bd01-9527b101493a"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("5f89b69f-ee79-488e-bd01-9527b101493a"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("65009db2-6a67-470e-951b-b9dfd68109f8"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("65009db2-6a67-470e-951b-b9dfd68109f8"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6ad109c5-e8e7-4f40-8c0e-434f272db285"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6ad109c5-e8e7-4f40-8c0e-434f272db285"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("6ad109c5-e8e7-4f40-8c0e-434f272db285"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("701c2a97-48ac-4781-8a08-c60c6aa3f040"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("775e23ed-1fb6-4125-b23c-c43cb98fe1b6"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("775e23ed-1fb6-4125-b23c-c43cb98fe1b6"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("775e23ed-1fb6-4125-b23c-c43cb98fe1b6"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("7d52d73e-b4e5-45f6-999e-9e7bd42e8a93"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("8e394b57-2c7a-42a1-b700-263d57f8cc5e"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ac3d8343-895b-4805-aaeb-3b0d2f9de96a"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ad8bddfd-a20d-4f5b-b53b-86e008dc3fc1"), new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("be3ebdea-a67c-4a28-b83e-c238cb85c09d"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("c067592d-7db2-476b-8216-da94a089b269"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("d8acfa7d-2e90-4fc3-a2a0-89441d7866c2"), new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("d90013c0-3372-4dce-8376-9d50e1952a0d"), new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("e880c006-3af2-4d28-b8a4-7684cb986185"), new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421") });

            migrationBuilder.DeleteData(
                table: "products_ingredients",
                keyColumns: new[] { "ingredient_id", "product_id" },
                keyValues: new object[] { new Guid("e880c006-3af2-4d28-b8a4-7684cb986185"), new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dcab376-7fa5-4514-8528-c0bc09e12627");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bde985f1-7ae2-4da7-a2b3-afc16ad1c528");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06f7430b-dfbf-42ed-9618-20f2cfd24875");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7376f12c-855e-40ba-a5d5-d6a993022bf3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a501c64b-74f7-46b7-a938-bda911a77b81");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("46371267-0d7c-4e7a-a64f-8716972f0f54"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("85901598-c0eb-49ac-93d7-8e680de25a68"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("a313707e-4307-4e0e-91b9-5ecd4399931f"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("bd6b7990-7394-4c6e-af12-981ac6e2d28b"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("bd90eb3d-e1b9-4308-8cd5-a6c887895ddc"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("05810086-be70-48b4-a40c-0330ebea7f7e"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("0955c74b-8e3c-4ad6-97fc-bdc72c4a70f2"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("16fe2f69-513c-4277-af3d-52b641fe9487"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("1776e340-9db2-453a-b29f-947b732796cc"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("19c410e1-f574-4e2e-b235-51906d01c727"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("1c73c664-4242-467f-a13f-5816ed222b97"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("25464223-7321-45e1-a377-e3d3bc9a1a70"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("26e2241b-5ef0-4998-bf81-3be8b5c5dd64"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("287e7803-b225-4131-b7f4-e3b57de672af"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("2d8b869c-ef64-44d9-807a-1221ff08e3b9"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("59a4a752-8e59-4cc9-a5f2-5b52f5e998ca"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("5a35c906-4373-43ef-a4c5-316058e22536"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("5df10646-eaea-4040-b50c-393cf49ca75e"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("5f89b69f-ee79-488e-bd01-9527b101493a"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("65009db2-6a67-470e-951b-b9dfd68109f8"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("662c546d-3e05-4cb4-a392-682cb3fed443"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("6a76316d-e003-40d4-8d5e-553d6c59747f"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("6ad109c5-e8e7-4f40-8c0e-434f272db285"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("701c2a97-48ac-4781-8a08-c60c6aa3f040"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("75879d97-4f7e-4f11-860d-205d63dfb1e9"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("775e23ed-1fb6-4125-b23c-c43cb98fe1b6"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("7d52d73e-b4e5-45f6-999e-9e7bd42e8a93"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("85311af6-ce87-461c-b7ff-699a86eb0b47"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("8e394b57-2c7a-42a1-b700-263d57f8cc5e"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("9216d028-f18e-44d4-b932-2f78719c0cba"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("a95acbbb-6cef-4a7b-a245-7f8d028e0de7"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("ac3d8343-895b-4805-aaeb-3b0d2f9de96a"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("ac441ba7-a0ff-4f44-84e8-3c11b8430c73"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("ad8bddfd-a20d-4f5b-b53b-86e008dc3fc1"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("ae5e95cb-f722-4460-8f07-29d58df97a55"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("be3ebdea-a67c-4a28-b83e-c238cb85c09d"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("beee5e53-e8ef-4d6e-a113-b449540d398e"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("c067592d-7db2-476b-8216-da94a089b269"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("cb3fc820-bf1d-4eee-a6c4-a9183618283a"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("d62340b8-b340-4765-a289-cc4ec987e23a"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("d8acfa7d-2e90-4fc3-a2a0-89441d7866c2"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("d90013c0-3372-4dce-8376-9d50e1952a0d"));

            migrationBuilder.DeleteData(
                table: "ingredients",
                keyColumn: "id",
                keyValue: new Guid("e880c006-3af2-4d28-b8a4-7684cb986185"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("1824a2d5-1519-4173-b628-6ccee98019b2"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("3b4feead-b9a6-41e4-b96a-42a50609603d"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("4b856ddb-c40f-404e-9b06-164ebb3755cf"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("8d23fc0e-42c7-4a64-8100-63d6cf061421"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("8f9967a1-2dd4-4d7e-9160-93da660a3d01"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("b21d0d2d-fe21-4080-8f99-d7b61574957f"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("dea18594-de69-4d30-9acd-0f2af621d27f"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("defc5f08-42d7-495f-bd66-a762226d29c5"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("e4dfb73d-8426-4c5e-bade-452c6d43bc3b"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628"));

            migrationBuilder.DeleteData(
                table: "confectioners",
                keyColumn: "id",
                keyValue: new Guid("0c10b01e-1b74-48fb-ab1f-7577c7c837de"));

            migrationBuilder.DeleteData(
                table: "confectioners",
                keyColumn: "id",
                keyValue: new Guid("cec94c18-629d-4491-8b26-dee405de2cfd"));

            migrationBuilder.DeleteData(
                table: "confectioners",
                keyColumn: "id",
                keyValue: new Guid("e2b8a345-064a-4381-ab50-70724003fcbd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca99e01c-6a19-45a2-9ac2-89f17f79dd08");

            migrationBuilder.DropColumn(
                name: "id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "delivery_address",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "product_amount",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "thumbnail",
                table: "products",
                newName: "Thumbnail");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)",
                oldPrecision: 10,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "total_price",
                table: "orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)",
                oldPrecision: 10,
                oldScale: 3);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                columns: new[] { "client_id", "product_id" });
        }
    }
}
