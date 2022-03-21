using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Database.Migrations
{
    public partial class InitialMigration : Migration
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
                values: new object[] { 1, new byte[] { 48, 136, 255, 31, 76, 25, 47, 156, 32, 188, 132, 122, 80, 6, 23, 41, 10, 180, 110, 122, 10, 133, 49, 235, 219, 224, 108, 33, 242, 248, 96, 56, 122, 22, 21, 212, 165, 214, 80, 117, 164, 177, 21, 159, 93, 51, 100, 89, 217, 249, 175, 187, 212, 231, 19, 187, 154, 222, 214, 252, 169, 233, 184, 159 }, new byte[] { 202, 204, 124, 220, 110, 6, 66, 82, 235, 83, 29, 110, 45, 227, 216, 93, 53, 221, 75, 103, 42, 69, 223, 217, 16, 10, 171, 95, 45, 229, 126, 43, 180, 227, 103, 102, 115, 81, 94, 32, 52, 15, 42, 32, 65, 15, 162, 5, 158, 146, 1, 14, 198, 172, 0, 221, 84, 159, 28, 14, 114, 177, 11, 103, 184, 4, 102, 139, 180, 188, 239, 9, 87, 101, 94, 63, 67, 249, 157, 154, 118, 32, 64, 59, 116, 113, 21, 232, 10, 40, 190, 76, 81, 136, 91, 141, 121, 194, 241, 110, 184, 75, 254, 178, 52, 131, 238, 8, 123, 177, 10, 126, 198, 213, 194, 192, 95, 163, 7, 178, 106, 135, 61, 223, 218, 58, 45, 37 }, "admin" });

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
