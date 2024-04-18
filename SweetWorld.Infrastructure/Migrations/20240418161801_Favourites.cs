using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetWorld.Infrastructure.Data.Migrations
{
    public partial class Favourites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_amount = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(10,3)", precision: 10, scale: 3, nullable: true),
                    additional_information = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.id);
                    table.ForeignKey(
                        name: "FK_carts_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "favourite_products",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favourite_products", x => new { x.product_id, x.client_id });
                    table.ForeignKey(
                        name: "FK_favourite_products_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favourite_products_products_product_id",
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
                value: "3fea201a-b99e-47d3-9cf1-1a93b5e78d3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bde985f1-7ae2-4da7-a2b3-afc16ad1c528",
                column: "ConcurrencyStamp",
                value: "d00de7e8-8e8f-4e73-9270-3f01bacbf5ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6",
                column: "ConcurrencyStamp",
                value: "816a3347-884e-43da-bc18-ffe9ff0639fb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06f7430b-dfbf-42ed-9618-20f2cfd24875",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3832904c-593a-4dba-b4d1-9e2a4c57d0bb", "AQAAAAEAACcQAAAAEDZyVJuvp3en0Dm6WzQKfjx9Pu6dq4se1UPZjgVdbP7P3+MfddHK4RTMcQOtXKF5Nw==", "43fbc3cb-bd16-4014-9981-fac41b6f46ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "225b4c34-756a-44d3-99e9-42d59da0de19", "AQAAAAEAACcQAAAAEADrjbHC1Yz81xcsu7xzEijKG+DGJGrMzHTcFU90JvnxkLz2/SjVmrXN4Ftfaar3Yg==", "fcf8350b-60ae-495b-a932-ac6fb480d663" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7376f12c-855e-40ba-a5d5-d6a993022bf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3663ca34-b973-45ed-b3b2-eaff0b908111", "AQAAAAEAACcQAAAAEDFml9UKW/UG3FZbcLnOeZYPvnz61czjlT47eHdwMR8JC338vg1fibYlKAcRtp/XJA==", "a0840c20-3c2d-4176-b38f-e4859d0c95f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a501c64b-74f7-46b7-a938-bda911a77b81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3052520-edd0-457c-8f66-c8ffd5a751e3", "AQAAAAEAACcQAAAAEGPxMs2+pgYkrOFth8pDfnOyJdLcdu8j5BOgPaUey3df4O7xoAU2VpcT317wNBBeIg==", "a930a08b-0811-49d8-bc84-0885d95d54ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c26ed7f7-9c40-4db1-a798-54927306468d", "AQAAAAEAACcQAAAAEAIvC8wD5Gq9iJDpc2shGTFBrpHyHsXjt9hLE05DtxgB0o8FibkZyy5IP0WlsprGQg==", "6efc5b16-462c-4ad3-866b-e0af1156b932" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca99e01c-6a19-45a2-9ac2-89f17f79dd08",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bef5f155-afb1-4241-89bc-409525f3ab75", "AQAAAAEAACcQAAAAEDX71WpHlKeND5XAm9rHyMvdJR4dj9xXn3eZ8lT/S16fEAMlHJ0CKgch82sFpLPTyg==", "3666774e-0b2a-49cd-ad6b-19941324b398" });

            migrationBuilder.CreateIndex(
                name: "IX_carts_client_id",
                table: "carts",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_favourite_products_client_id",
                table: "favourite_products",
                column: "client_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "favourite_products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dcab376-7fa5-4514-8528-c0bc09e12627",
                column: "ConcurrencyStamp",
                value: "7544cea2-9750-4770-8cc4-66e26942199a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bde985f1-7ae2-4da7-a2b3-afc16ad1c528",
                column: "ConcurrencyStamp",
                value: "e7c98515-ec85-4ea8-af49-b55870338d69");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe6c24e5-83c3-43bb-9c8a-21b7338c6af6",
                column: "ConcurrencyStamp",
                value: "d0a0f126-2c35-4c7e-b3f6-a07803e2dfb8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06f7430b-dfbf-42ed-9618-20f2cfd24875",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db2f0e02-ebd2-4e5b-a47d-beb3fc4bc50a", "AQAAAAEAACcQAAAAEOgGJSxo5zGha8ncZtoEWMuDy73OGKwLELbAjIDTj0Gk7x8ksO4hjlC6pUC5aB6R5w==", "44bf2474-b8a4-475c-991f-6f89ccd43019" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0dcee1c1-7ac3-4e14-9e43-77f8c85dae75",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69293a71-2ffd-4396-850a-4b68cc43239c", "AQAAAAEAACcQAAAAENUb324lx03wxKu4bUcxtLzDLJyrNl98UeQa+WN4iviBJGB5w4RQHodXy8vRMSoVLg==", "6b1629fe-319b-4e8a-b0e0-2275157fb4a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7376f12c-855e-40ba-a5d5-d6a993022bf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eef3d6b9-3c76-4bdb-8cb6-9bd98a24796c", "AQAAAAEAACcQAAAAEERWeuG6PoYK+xYtFV0HL+8zUwOvOtprVa9UIplLd2KhDlprLbT19m60RLsmb/cKxQ==", "924a7544-cbac-4138-a6e9-c17a1fb03b51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a501c64b-74f7-46b7-a938-bda911a77b81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e23ab02-8f65-4192-a4ff-7f5ef6201532", "AQAAAAEAACcQAAAAEHa3v5PkNcuK5fgeyQtj5YIsg/i4hM6AFftTXjXVdOxSvDmvBEEA866Mbb6BXqVUAQ==", "dfff5f02-68b7-4fc4-a020-9291498a786d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb7750b4-cc79-4361-a63b-dd4ad4a9e53f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b0cb05d-3bb4-465f-beb9-51c1915b4c8b", "AQAAAAEAACcQAAAAEMuiPBN3//0u+azPCZq+Kmcs+ncbZEbZFAwQD5OKBS/LpZYp/eRUtrDJ3bsLqXHg7w==", "72b7a7da-7b20-484b-ac35-00707a637d47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca99e01c-6a19-45a2-9ac2-89f17f79dd08",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53f0a675-c514-4537-810a-f6304ecaa4e6", "AQAAAAEAACcQAAAAEKCYyxwnQxd6X5RPrN9WYnXpIB/7SFHZFO9q+oQeZmcS1n9YvT++vBIlia4FCWW2RQ==", "195b1c40-30d3-41e9-956a-42aec07cc6ce" });
        }
    }
}
