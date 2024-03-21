using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetWorld.Infrastructure.Data.Migrations
{
    public partial class newProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "products");
        }
    }
}
