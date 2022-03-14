using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitMeasure = table.Column<int>(type: "int", nullable: false),
                    MinimalUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipe_Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitMeasure = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipe_Ingredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipe_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Lunch" },
                    { 3, "Dinner" },
                    { 5, "Brunch" },
                    { 6, "Snack" },
                    { 7, "Midnight snack" },
                    { 9, "Healty snack" },
                    { 10, "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "MinimalUnitPrice", "Name", "PurchaseQuantity", "UnitMeasure" },
                values: new object[,]
                {
                    { 1, 10m, "Flour", 1m, 0 },
                    { 2, 4m, "Pepper", 10m, 1 },
                    { 3, 7m, "Oil", 1m, 2 },
                    { 4, 15m, "Cheese", 100m, 1 },
                    { 5, 3m, "Sugar", 80m, 1 },
                    { 6, 2m, "Salt", 70m, 1 },
                    { 7, 20m, "Meat", 1m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 67, 232, 159, 144, 174, 141, 125, 51, 214, 138, 107, 5, 40, 96, 173, 80, 180, 129, 91, 187, 42, 2, 194, 160, 109, 88, 214, 137, 145, 107, 203, 25, 65, 150, 51, 151, 196, 24, 164, 91, 127, 121, 243, 54, 2, 223, 136, 39, 59, 12, 84, 251, 149, 49, 0, 138, 9, 117, 210, 25, 87, 192, 172, 138 }, new byte[] { 111, 89, 66, 68, 184, 155, 23, 4, 70, 53, 141, 124, 186, 136, 215, 209, 103, 86, 198, 165, 205, 232, 27, 71, 236, 15, 26, 232, 29, 109, 123, 213, 65, 138, 41, 196, 168, 190, 33, 28, 2, 157, 217, 212, 80, 101, 238, 148, 79, 32, 99, 45, 224, 91, 202, 81, 213, 184, 128, 68, 145, 213, 111, 87, 243, 155, 136, 204, 210, 140, 113, 140, 84, 54, 64, 156, 48, 142, 126, 32, 38, 111, 122, 9, 68, 136, 57, 20, 179, 119, 174, 3, 234, 167, 224, 219, 16, 228, 186, 215, 118, 172, 20, 41, 3, 243, 173, 154, 55, 15, 180, 227, 76, 125, 91, 238, 253, 118, 27, 82, 149, 155, 82, 220, 117, 164, 96, 7 }, "user" });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_Ingredients_IngredientId",
                table: "Recipe_Ingredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_Ingredients_RecipeId",
                table: "Recipe_Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipe_Ingredients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
