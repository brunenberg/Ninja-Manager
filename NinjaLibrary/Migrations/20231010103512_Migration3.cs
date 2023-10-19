using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NinjaLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "gear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "gear",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
