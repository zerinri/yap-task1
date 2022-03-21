using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Database.Migrations
{
    public partial class BaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifedDate",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "RecipeIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RecipeIngredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifedDate",
                table: "RecipeIngredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 144, 83, 142, 21, 3, 200, 147, 141, 106, 50, 149, 151, 6, 159, 125, 176, 34, 251, 18, 225, 207, 6, 95, 45, 189, 102, 8, 80, 7, 82, 217, 212, 163, 133, 111, 89, 88, 10, 32, 193, 65, 178, 131, 43, 72, 192, 0, 93, 90, 96, 91, 185, 29, 250, 110, 244, 190, 161, 176, 234, 175, 249, 77, 172 }, new byte[] { 6, 23, 54, 213, 30, 50, 51, 120, 184, 24, 111, 151, 156, 217, 42, 44, 34, 120, 10, 167, 218, 58, 255, 119, 34, 237, 248, 39, 188, 186, 194, 189, 149, 49, 224, 219, 55, 208, 64, 71, 60, 131, 39, 198, 16, 87, 150, 147, 236, 23, 206, 54, 138, 32, 59, 168, 150, 26, 118, 46, 150, 71, 110, 166, 220, 230, 182, 128, 85, 5, 135, 12, 233, 111, 12, 246, 61, 239, 140, 56, 13, 76, 171, 70, 158, 64, 170, 23, 248, 128, 204, 19, 24, 28, 219, 226, 49, 121, 30, 198, 23, 227, 125, 168, 223, 102, 164, 248, 213, 251, 36, 7, 65, 243, 161, 38, 128, 35, 24, 144, 161, 139, 227, 229, 221, 146, 248, 234 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ModifedDate",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "ModifedDate",
                table: "RecipeIngredients");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 48, 136, 255, 31, 76, 25, 47, 156, 32, 188, 132, 122, 80, 6, 23, 41, 10, 180, 110, 122, 10, 133, 49, 235, 219, 224, 108, 33, 242, 248, 96, 56, 122, 22, 21, 212, 165, 214, 80, 117, 164, 177, 21, 159, 93, 51, 100, 89, 217, 249, 175, 187, 212, 231, 19, 187, 154, 222, 214, 252, 169, 233, 184, 159 }, new byte[] { 202, 204, 124, 220, 110, 6, 66, 82, 235, 83, 29, 110, 45, 227, 216, 93, 53, 221, 75, 103, 42, 69, 223, 217, 16, 10, 171, 95, 45, 229, 126, 43, 180, 227, 103, 102, 115, 81, 94, 32, 52, 15, 42, 32, 65, 15, 162, 5, 158, 146, 1, 14, 198, 172, 0, 221, 84, 159, 28, 14, 114, 177, 11, 103, 184, 4, 102, 139, 180, 188, 239, 9, 87, 101, 94, 63, 67, 249, 157, 154, 118, 32, 64, 59, 116, 113, 21, 232, 10, 40, 190, 76, 81, 136, 91, 141, 121, 194, 241, 110, 184, 75, 254, 178, 52, 131, 238, 8, 123, 177, 10, 126, 198, 213, 194, 192, 95, 163, 7, 178, 106, 135, 61, 223, 218, 58, 45, 37 } });
        }
    }
}
