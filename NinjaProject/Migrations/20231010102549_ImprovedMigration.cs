using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NinjaProject.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_item_gear_Gear_id",
                table: "inventory_item");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_item_ninja_Ninja_id",
                table: "inventory_item");

            migrationBuilder.DropColumn(
                name: "category",
                table: "gear");

            migrationBuilder.RenameColumn(
                name: "Gear_id",
                table: "inventory_item",
                newName: "gear_id");

            migrationBuilder.RenameColumn(
                name: "Ninja_id",
                table: "inventory_item",
                newName: "ninja_id");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_item_Gear_id",
                table: "inventory_item",
                newName: "IX_inventory_item_gear_id");

            migrationBuilder.AddColumn<int>(
                name: "PricePaid",
                table: "inventory_item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "gear",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "gear_category",
                columns: table => new
                {
                    category = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gear_category", x => x.category);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gear_CategoryId",
                table: "gear",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gear_GearCategory",
                table: "gear",
                column: "CategoryId",
                principalTable: "gear_category",
                principalColumn: "category");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_item_gear_gear_id",
                table: "inventory_item",
                column: "gear_id",
                principalTable: "gear",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_item_ninja_ninja_id",
                table: "inventory_item",
                column: "ninja_id",
                principalTable: "ninja",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gear_GearCategory",
                table: "gear");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_item_gear_gear_id",
                table: "inventory_item");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_item_ninja_ninja_id",
                table: "inventory_item");

            migrationBuilder.DropTable(
                name: "gear_category");

            migrationBuilder.DropIndex(
                name: "IX_gear_CategoryId",
                table: "gear");

            migrationBuilder.DropColumn(
                name: "PricePaid",
                table: "inventory_item");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "gear");

            migrationBuilder.RenameColumn(
                name: "gear_id",
                table: "inventory_item",
                newName: "Gear_id");

            migrationBuilder.RenameColumn(
                name: "ninja_id",
                table: "inventory_item",
                newName: "Ninja_id");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_item_gear_id",
                table: "inventory_item",
                newName: "IX_inventory_item_Gear_id");

            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "gear",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_item_gear_Gear_id",
                table: "inventory_item",
                column: "Gear_id",
                principalTable: "gear",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_item_ninja_Ninja_id",
                table: "inventory_item",
                column: "Ninja_id",
                principalTable: "ninja",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
