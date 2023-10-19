using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.IdentityModel.Tokens;

#nullable disable

namespace NinjaLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "gear",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "ninja",
                columns: new[] { "name", "gold" },
                values: new object[,]
                {
                    { "Wouter", "1000" },
                    { "Joris", "1200" },
                    { "Pieter-Jan Flatgebouw", "5000000" },
                    { "Zwerver", "10" },
                    { "Ninjaman123", "2000" }
                });

            migrationBuilder.InsertData(
                table: "gear_category",
                column: "category",
                values: new object[]
                {
                    "Head",
                    "Necklace",
                    "Chest",
                    "Hands",
                    "Ring",
                    "Feet"
                });

            migrationBuilder.InsertData(
                table: "gear",
                columns: new[] { "name", "goldvalue", "strength", "intelligence", "agility", "CategoryId" },
                values: new object[,]
                {
                    { "Diamanten Helm", 2000, 1000, 100, 300, "Head" },
                    { "Gucci Pet", 300, -100, -400, 500, "Head" },
                    { "Hoge Hoed", 1000, 0, 1000, 300, "Head" },

                    { "Diamanten Ketting", 3000, 500, 700, 50, "Necklace" },
                    { "Gouden Ketting", 500, 300, 400, 100, "Necklace" },
                    { "Zilveren Ketting", 200, 100, 100, 150, "Necklace" },

                    { "Plaatpantser", 1500, 800, 200, 200, "Chest" },
                    { "Kevlar Vest", 800, 200, 400, 100, "Chest" },
                    { "Robijnen Borstplaat", 2500, 1000, 200, 300, "Chest" },

                    { "Lederen Handschoenen", 200, 100, 50, 150, "Hands" },
                    { "Stalen Handschoenen", 500, 200, 100, 50, "Hands" },
                    { "Magische Handschoenen", 1000, 300, 500, 200, "Hands" },

                    { "Zegelring", 800, 200, 400, 100, "Ring" },
                    { "Amethist Ring", 500, 100, 300, 50, "Ring" },
                    { "Gouden Ring", 1200, 300, 200, 200, "Ring" },

                    { "Diamanten Schoenen", 2000, 300, 200, 500, "Feet" },
                    { "Nike Air Mag \"Back to the Future\"", 40000, 500, 500, 1000, "Feet" },
                    { "Ninja schoenen", 500, -100, 200, 500, "Feet" },
                    { "Hoge hakken", 300, 100, 400, -1000, "Feet" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "gear",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
