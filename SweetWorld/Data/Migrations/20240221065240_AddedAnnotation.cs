using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetWorld.Data.Migrations
{
    public partial class AddedAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Confectioners_AspNetUsers_UserId",
                table: "Confectioners");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Confectioners_ConfectionerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsCategories_Categories_CategoryId",
                table: "ProductsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsCategories_Products_ProductId",
                table: "ProductsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsIngredients_Ingredients_IngredientId",
                table: "ProductsIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsIngredients_Products_ProductId",
                table: "ProductsIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Confectioners",
                table: "Confectioners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsIngredients",
                table: "ProductsIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsCategories",
                table: "ProductsCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductsCategories_CategoryId",
                table: "ProductsCategories");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "ingredients");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "images");

            migrationBuilder.RenameTable(
                name: "Confectioners",
                newName: "confectioners");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "clients");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "ProductsIngredients",
                newName: "products_ingredients");

            migrationBuilder.RenameTable(
                name: "ProductsCategories",
                newName: "products_categories");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "products",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ConfectionerId",
                table: "products",
                newName: "confectioner_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ConfectionerId",
                table: "products",
                newName: "IX_products_confectioner_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "orders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "orders",
                newName: "total_price");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "orders",
                newName: "date_of_creating");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "orders",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "orders",
                newName: "client_id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProductId",
                table: "orders",
                newName: "IX_orders_product_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ingredients",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ingredients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "images",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "images",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "images",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ProductId",
                table: "images",
                newName: "IX_images_product_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "confectioners",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "confectioners",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Confectioners_UserId",
                table: "confectioners",
                newName: "IX_confectioners_user_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "clients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "clients",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_UserId",
                table: "clients",
                newName: "IX_clients_user_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "products_ingredients",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "products_ingredients",
                newName: "ingredient_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsIngredients_ProductId",
                table: "products_ingredients",
                newName: "IX_products_ingredients_product_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "products_categories",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "products_categories",
                newName: "product_id");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "products",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "products",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "additional_information",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                columns: new[] { "client_id", "product_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ingredients",
                table: "ingredients",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_images",
                table: "images",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_confectioners",
                table: "confectioners",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clients",
                table: "clients",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products_ingredients",
                table: "products_ingredients",
                columns: new[] { "ingredient_id", "product_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_products_categories",
                table: "products_categories",
                columns: new[] { "category_id", "product_id" });

            migrationBuilder.CreateIndex(
                name: "IX_products_categories_product_id",
                table: "products_categories",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_AspNetUsers_user_id",
                table: "clients",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_confectioners_AspNetUsers_user_id",
                table: "confectioners",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_images_products_product_id",
                table: "images",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_clients_client_id",
                table: "orders",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_product_id",
                table: "orders",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_products_confectioners_confectioner_id",
                table: "products",
                column: "confectioner_id",
                principalTable: "confectioners",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_categories_category_id",
                table: "products_categories",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_products_product_id",
                table: "products_categories",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_ingredients_ingredients_ingredient_id",
                table: "products_ingredients",
                column: "ingredient_id",
                principalTable: "ingredients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_ingredients_products_product_id",
                table: "products_ingredients",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_AspNetUsers_user_id",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "FK_confectioners_AspNetUsers_user_id",
                table: "confectioners");

            migrationBuilder.DropForeignKey(
                name: "FK_images_products_product_id",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_clients_client_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_product_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_products_confectioners_confectioner_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_categories_category_id",
                table: "products_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_products_product_id",
                table: "products_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_ingredients_ingredients_ingredient_id",
                table: "products_ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_products_ingredients_products_product_id",
                table: "products_ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ingredients",
                table: "ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_images",
                table: "images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_confectioners",
                table: "confectioners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clients",
                table: "clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products_ingredients",
                table: "products_ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products_categories",
                table: "products_categories");

            migrationBuilder.DropIndex(
                name: "IX_products_categories_product_id",
                table: "products_categories");

            migrationBuilder.DropColumn(
                name: "additional_information",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "ingredients",
                newName: "Ingredients");

            migrationBuilder.RenameTable(
                name: "images",
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "confectioners",
                newName: "Confectioners");

            migrationBuilder.RenameTable(
                name: "clients",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "products_ingredients",
                newName: "ProductsIngredients");

            migrationBuilder.RenameTable(
                name: "products_categories",
                newName: "ProductsCategories");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Products",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "confectioner_id",
                table: "Products",
                newName: "ConfectionerId");

            migrationBuilder.RenameIndex(
                name: "IX_products_confectioner_id",
                table: "Products",
                newName: "IX_Products_ConfectionerId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "total_price",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "date_of_creating",
                table: "Orders",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Orders",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "client_id",
                table: "Orders",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_product_id",
                table: "Orders",
                newName: "IX_Orders_ProductId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Ingredients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Ingredients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "Images",
                newName: "URL");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Images",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Images",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_images_product_id",
                table: "Images",
                newName: "IX_Images_ProductId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Confectioners",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Confectioners",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_confectioners_user_id",
                table: "Confectioners",
                newName: "IX_Confectioners_UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Clients",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_clients_user_id",
                table: "Clients",
                newName: "IX_Clients_UserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "ProductsIngredients",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ingredient_id",
                table: "ProductsIngredients",
                newName: "IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ingredients_product_id",
                table: "ProductsIngredients",
                newName: "IX_ProductsIngredients_ProductId");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "ProductsCategories",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "ProductsCategories",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                columns: new[] { "ClientId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Confectioners",
                table: "Confectioners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsIngredients",
                table: "ProductsIngredients",
                columns: new[] { "IngredientId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsCategories",
                table: "ProductsCategories",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCategories_CategoryId",
                table: "ProductsCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Confectioners_AspNetUsers_UserId",
                table: "Confectioners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Confectioners_ConfectionerId",
                table: "Products",
                column: "ConfectionerId",
                principalTable: "Confectioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsCategories_Categories_CategoryId",
                table: "ProductsCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsCategories_Products_ProductId",
                table: "ProductsCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsIngredients_Ingredients_IngredientId",
                table: "ProductsIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsIngredients_Products_ProductId",
                table: "ProductsIngredients",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
