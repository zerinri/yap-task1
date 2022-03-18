using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Api.Migrations
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
                    PurchaseUnitMeasure = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                name: "RecipeIngredients",
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
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
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
                    { 4, "Brunch" },
                    { 5, "Snack" },
                    { 6, "Midnight snack" },
                    { 7, "Healty snack" },
                    { 8, "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "PurchasePrice", "PurchaseQuantity", "PurchaseUnitMeasure" },
                values: new object[,]
                {
                    { 1, "Flour", 10m, 1m, 0 },
                    { 2, "Pepper", 4m, 10m, 1 },
                    { 3, "Oil", 7m, 1m, 2 },
                    { 4, "Cheese", 15m, 100m, 1 },
                    { 5, "Sugar", 3m, 80m, 1 },
                    { 6, "Salt", 2m, 70m, 1 },
                    { 7, "Meat", 20m, 1m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 126, 18, 131, 218, 222, 89, 224, 20, 191, 82, 66, 167, 114, 90, 23, 56, 250, 56, 2, 160, 167, 204, 116, 75, 136, 123, 176, 226, 173, 113, 171, 50, 243, 101, 204, 115, 1, 87, 251, 132, 229, 202, 34, 188, 251, 127, 169, 51, 32, 144, 88, 208, 170, 14, 162, 182, 241, 188, 0, 104, 152, 179, 90, 99 }, new byte[] { 208, 111, 23, 193, 231, 240, 166, 150, 55, 23, 79, 141, 99, 76, 99, 194, 107, 141, 186, 136, 241, 87, 22, 44, 211, 68, 105, 118, 217, 80, 209, 126, 218, 0, 179, 232, 189, 31, 245, 66, 81, 122, 78, 150, 114, 224, 198, 146, 171, 242, 159, 101, 86, 8, 84, 135, 135, 163, 51, 32, 26, 138, 136, 200, 154, 109, 154, 208, 88, 137, 186, 241, 227, 85, 139, 4, 59, 33, 236, 124, 238, 103, 246, 48, 188, 85, 255, 175, 141, 195, 53, 84, 10, 52, 214, 28, 143, 208, 43, 38, 98, 66, 130, 103, 141, 185, 58, 117, 165, 152, 45, 84, 192, 181, 171, 161, 149, 38, 4, 96, 144, 140, 198, 24, 64, 37, 118, 166 }, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");

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
