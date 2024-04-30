using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetWorld.Infrastructure.Data.Migrations
{
    public partial class Pieces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pieces_count",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,3)", precision: 10, scale: 3, nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pieces_count", x => x.id);
                    table.ForeignKey(
                        name: "FK_pieces_count_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dcab376-7fa5-4514-8528-c0bc09e12627",
                column: "ConcurrencyStamp",
                value: "5b01aa46-86cf-4078-8e57-86d534986bdf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bde985f1-7ae2-4da7-a2b3-afc16ad1c528",
                column: "ConcurrencyStamp",
                value: "a2aea1a7-65ff-4696-94f6-6eb7ba74aa4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6",
                column: "ConcurrencyStamp",
                value: "e72ac8e9-eeea-4b3b-a9ac-f40ddbf97a7d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06f7430b-dfbf-42ed-9618-20f2cfd24875",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81008bd9-8a9d-4bc5-93b5-e1335d970ad4", "AQAAAAEAACcQAAAAECZVUpP4NR5IZII3eGbHrdsQZChDR1kJIqDem6jWHM9j22DTUq14tU1GCk93A5go5Q==", "c7cf4614-76fa-4ea9-aa91-8c01f0fdc231" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe4c622a-bfe6-4002-adea-775904c669cb", "AQAAAAEAACcQAAAAEPNa1q4LuVPogUlrbA7M5b/CJ0bto8VehwLFYm4/waK/cmzTZ8bF7jpm5/uOMJLSZg==", "c9fdab3d-b44e-4580-aee9-8e279fcb32ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7376f12c-855e-40ba-a5d5-d6a993022bf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ddb923a-3bf0-4084-858d-886b4cd97ad9", "AQAAAAEAACcQAAAAEPSobuSiGI/SHWZdTRJIDdxfjQq86s2tT5j0acn5VyUPsFMzEDNksH5fESVujZQtRA==", "fe60e08c-0f65-4397-a37d-4c8bef2959bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a501c64b-74f7-46b7-a938-bda911a77b81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaddc352-dd98-4a35-9adf-5d21817a878e", "AQAAAAEAACcQAAAAEETu1a+jWAIEZuZJTvGX4htOu1P90NFs/wc/dHmUMG5GWGTP8MhfAq6puyfHovVFlQ==", "fa04b4d9-f233-4a99-93d3-d901ff7668e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "359c4127-8bb7-4079-a2fe-238666cb4b92", "AQAAAAEAACcQAAAAEGiQjgQbVy/fzF9oxq66xsU+rFUrfbR0o9wAs3O9w/Vl9D580jXgyiHKJp/3Ekh9ZA==", "1481e702-55d7-4f1d-9508-295363f6a2ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca99e01c-6a19-45a2-9ac2-89f17f79dd08",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7d66382-ef01-4d2c-aa22-0217608e8571", "AQAAAAEAACcQAAAAEIYL7rkNt7UE9S3SykPJSs0qPKb3U0teidZljcaibXqjVdlmoJKW469x09gAfNZSxQ==", "c83d1765-46bf-46ac-862e-59e5d813b1a4" });

            migrationBuilder.InsertData(
                table: "pieces_count",
                columns: new[] { "id", "count", "price", "product_id" },
                values: new object[,]
                {
                    { new Guid("01ebaca3-f90b-45fe-b752-1b7f352c0fc6"), 21, 112.49m, new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("0ec26597-851c-4dd5-af77-2df6f812a93b"), 28, 82.49m, new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("1dd605fa-db7c-41bc-aa76-f0e0d77d884a"), 28, 94.49m, new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("1ffce214-541e-47c7-9c19-c4f689a56c07"), 14, 67.49m, new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("26721920-7a64-47b1-8db3-3f1722815c0e"), 28, 127.49m, new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("2ab33556-22ae-4728-88a9-1536ee195794"), 1, 6.29m, new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("32374966-e7ff-4e87-b8e9-6e55f6b21f50"), 16, 52.49m, new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("34bda0be-b8fe-44c8-b38b-9e63ff44623e"), 21, 85.49m, new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("34dd8b64-ff9f-407b-a747-38f2a972e236"), 1, 3.29m, new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("36f51a20-3acc-4ded-a0d8-01a2fcb23514"), 8, 37.49m, new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("383abed3-00c9-4efa-b83c-a98e15e38197"), 14, 74.99m, new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("4108d057-4102-496c-a2db-18632f95835a"), 1, 4.49m, new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("417881ab-91c3-4205-8153-dee41d1b0de8"), 25, 77.99m, new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") },
                    { new Guid("5381d766-528a-4cfc-b427-030f3a880a8a"), 1, 5.69m, new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("554a3fa2-0057-4adf-9759-86534d453450"), 28, 97.49m, new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("5fb46ba7-9aa0-4453-948b-6be10804e1c3"), 28, 119.99m, new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("6d077fe2-db60-4a43-bd2d-283e246c3d0c"), 16, 67.49m, new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("6fa27b41-8905-416b-b73c-5f6a2692fe47"), 8, 37.49m, new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") },
                    { new Guid("714c1dce-b33c-4519-b0c5-1ae7258e30e7"), 28, 94.49m, new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("7b23ddd3-3a86-4b54-b4e2-a994a00990c0"), 1, 4.79m, new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("7f23ea0a-aaef-4423-b6bc-8cb07636cf12"), 8, 49.49m, new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("83e7c20b-dd48-454b-a840-8a3a5b260dda"), 16, 70.49m, new Guid("f5f626f4-9a54-48bc-8cda-e68926a4e628") },
                    { new Guid("97d0a9a9-c5c7-4155-8ad6-98e89daf5fcb"), 16, 67.49m, new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("99afd1ca-e05f-4b10-aae2-362b5165b808"), 28, 107.99m, new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("a2aa1e41-48f2-4ee3-bfdf-af86d45e99ef"), 1, 5.99m, new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("a8ffcaf4-ae90-4d6a-af52-3bfe2e38e1ed"), 1, 5.29m, new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") },
                    { new Guid("b4ea66a0-cd1f-4895-b943-8d4c774a4aa2"), 21, 94.49m, new Guid("5229ab70-1818-42be-b0c2-3b4da48a3caa") },
                    { new Guid("bb06bde1-d2ab-460e-836f-5ffe8ffc6e76"), 1, 4.79m, new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") },
                    { new Guid("bde41a83-221c-48b1-916f-b1a017349ac4"), 21, 115.49m, new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("be873400-b90a-43ca-9314-f6cac0903198"), 14, 82.49m, new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("c9630313-f214-45bb-a8a2-6b03095f503c"), 14, 77.99m, new Guid("1824a2d5-1519-4173-b628-6ccee98019b2") },
                    { new Guid("d59f6694-5fef-4f8d-a469-5e5fdf3921e1"), 8, 52.49m, new Guid("dea18594-de69-4d30-9acd-0f2af621d27f") },
                    { new Guid("dd9f719d-5256-4337-89ce-a9fcc863c3fe"), 36, 137.99m, new Guid("64575b60-9c13-4f54-aee4-20dbf9d1f3cb") }
                });

            migrationBuilder.InsertData(
                table: "pieces_count",
                columns: new[] { "id", "count", "price", "product_id" },
                values: new object[] { new Guid("e83812be-6458-4fa3-b110-fccd355c179a"), 25, 103.49m, new Guid("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b") });

            migrationBuilder.InsertData(
                table: "pieces_count",
                columns: new[] { "id", "count", "price", "product_id" },
                values: new object[] { new Guid("f00ae7f4-ff96-47eb-9530-0e2998399cfe"), 8, 29.99m, new Guid("defc5f08-42d7-495f-bd66-a762226d29c5") });

            migrationBuilder.InsertData(
                table: "pieces_count",
                columns: new[] { "id", "count", "price", "product_id" },
                values: new object[] { new Guid("f36f5e08-cc89-4a73-a841-3e34c22b6120"), 14, 59.99m, new Guid("8f2a35c9-e3f5-4361-b393-d9ac177c4102") });

            migrationBuilder.CreateIndex(
                name: "IX_pieces_count_product_id",
                table: "pieces_count",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pieces_count");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dcab376-7fa5-4514-8528-c0bc09e12627",
                column: "ConcurrencyStamp",
                value: "581cd48b-1170-4270-abcd-3621c9957fbc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bde985f1-7ae2-4da7-a2b3-afc16ad1c528",
                column: "ConcurrencyStamp",
                value: "f84df18c-ddce-4445-b6ee-f9b0f82014c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6",
                column: "ConcurrencyStamp",
                value: "5cf95cc2-e01e-4863-aa10-a75cb473cc80");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06f7430b-dfbf-42ed-9618-20f2cfd24875",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9d567b6-8957-4fdb-bcef-a4b499400548", "AQAAAAEAACcQAAAAEG0Cy/OPYIrQ3U6wxG7XddiqfnSg7+RRNlfHYIUO4lMT8TwCvcqhD8lbgRizxcq/Uw==", "14a5bb9c-60b1-40d0-a70c-6798f4796d06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82f796ef-a43b-4ebc-90cc-68ba3efb75ab", "AQAAAAEAACcQAAAAECrWb8Q0tj28Qq7PePIApseix9QMiedOvUCc0vMNjswmdyNa2rfy/HlS/Iflwxb02A==", "b31610de-aa8b-4182-82be-ad86c61b93ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7376f12c-855e-40ba-a5d5-d6a993022bf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cfa859a-30b0-4085-8af9-292eb19488e9", "AQAAAAEAACcQAAAAEH6BGedKywb+aDKfYRwi1JOoOQPa0UuzNkNwPxjGtiWs29TA597YjgLrzS86iIHB1w==", "bfbf5575-5d57-4a07-a249-916861164fac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a501c64b-74f7-46b7-a938-bda911a77b81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "520752a4-a83f-45e7-8e98-e2eb2ca62c60", "AQAAAAEAACcQAAAAECQQf/1PpVeTHc9DpxdwAS5Qc8EEwvv8l4GLdG2lHyIiO6fJ4/EFkcOjWX8bacEhdg==", "0e0bba3a-7f97-42ec-9f9c-46aa34a1e81d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71b16834-1066-4727-8678-926c000a0ff8", "AQAAAAEAACcQAAAAEE6gwOEbTy08LGbW6LlWIKWVJsyBJThWth1FNMpD/Wi598iFGboNajgqSaLkCe27AQ==", "0682cd05-fd61-4af3-9a4b-17787a956877" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca99e01c-6a19-45a2-9ac2-89f17f79dd08",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4bb6b7e-b718-4e90-a730-117f3103ad43", "AQAAAAEAACcQAAAAEAgHj+HpkIOZmcIX3/s2OhkfqSMUmPr6e0vziGwuguoDhWalXZbQ8s/pE9aCd6eV4A==", "d9ecfd34-59eb-44b4-924c-2e20bc64ecfc" });
        }
    }
}
