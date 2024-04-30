using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetWorld.Infrastructure.Data.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
