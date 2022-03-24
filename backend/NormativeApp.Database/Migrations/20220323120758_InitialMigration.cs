using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NormativeApp.Database.Migrations
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 23, 13, 7, 57, 860, DateTimeKind.Local).AddTicks(3843), "Breakfast" },
                    { 2, new DateTime(2022, 3, 23, 13, 7, 57, 862, DateTimeKind.Local).AddTicks(8971), "Lunch" },
                    { 3, new DateTime(2022, 3, 23, 13, 7, 57, 862, DateTimeKind.Local).AddTicks(9004), "Dinner" },
                    { 4, new DateTime(2022, 3, 23, 13, 7, 57, 862, DateTimeKind.Local).AddTicks(9009), "Brunch" },
                    { 5, new DateTime(2022, 3, 23, 13, 7, 57, 862, DateTimeKind.Local).AddTicks(9012), "Snack" },
                    { 6, new DateTime(2022, 3, 23, 13, 7, 57, 862, DateTimeKind.Local).AddTicks(9014), "Midnight snack" },
                    { 7, new DateTime(2022, 3, 23, 13, 7, 57, 862, DateTimeKind.Local).AddTicks(9017), "Healty snack" },
                    { 8, new DateTime(2022, 3, 23, 13, 7, 57, 862, DateTimeKind.Local).AddTicks(9020), "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedDate", "Name", "PurchasePrice", "PurchaseQuantity", "PurchaseUnitMeasure" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 23, 13, 7, 57, 863, DateTimeKind.Local).AddTicks(6425), "Flour", 10m, 1m, 0 },
                    { 2, new DateTime(2022, 3, 23, 13, 7, 57, 863, DateTimeKind.Local).AddTicks(6446), "Pepper", 4m, 10m, 1 },
                    { 3, new DateTime(2022, 3, 23, 13, 7, 57, 863, DateTimeKind.Local).AddTicks(6450), "Oil", 7m, 1m, 2 },
                    { 4, new DateTime(2022, 3, 23, 13, 7, 57, 863, DateTimeKind.Local).AddTicks(6453), "Cheese", 15m, 100m, 1 },
                    { 5, new DateTime(2022, 3, 23, 13, 7, 57, 863, DateTimeKind.Local).AddTicks(6457), "Sugar", 3m, 80m, 1 },
                    { 6, new DateTime(2022, 3, 23, 13, 7, 57, 863, DateTimeKind.Local).AddTicks(6460), "Salt", 2m, 70m, 1 },
                    { 7, new DateTime(2022, 3, 23, 13, 7, 57, 863, DateTimeKind.Local).AddTicks(6463), "Meat", 20m, 1m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 152, 80, 138, 97, 110, 142, 94, 110, 216, 79, 218, 222, 41, 135, 6, 243, 0, 14, 104, 103, 12, 102, 128, 66, 101, 216, 44, 49, 148, 157, 190, 89, 233, 117, 153, 138, 103, 186, 16, 105, 56, 79, 249, 157, 26, 2, 249, 109, 241, 31, 205, 109, 230, 136, 129, 76, 1, 7, 117, 73, 213, 249, 34, 177 }, new byte[] { 19, 149, 97, 173, 40, 175, 212, 4, 250, 186, 73, 41, 26, 42, 183, 116, 122, 167, 183, 103, 92, 162, 17, 44, 245, 70, 212, 112, 179, 207, 158, 60, 52, 110, 73, 110, 13, 184, 44, 192, 12, 60, 195, 246, 144, 242, 12, 2, 228, 5, 110, 37, 197, 153, 57, 73, 167, 243, 125, 193, 181, 111, 255, 141, 60, 39, 225, 212, 121, 244, 50, 207, 6, 54, 77, 55, 100, 31, 192, 176, 121, 9, 135, 108, 14, 244, 123, 30, 16, 238, 153, 17, 173, 174, 195, 152, 92, 42, 16, 91, 87, 3, 55, 98, 48, 131, 42, 246, 43, 80, 119, 235, 185, 156, 254, 46, 203, 80, 234, 51, 193, 133, 98, 65, 68, 30, 143, 243 }, "admin" });

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
