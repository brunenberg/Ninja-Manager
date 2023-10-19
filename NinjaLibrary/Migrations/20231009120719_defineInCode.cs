using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NinjaLibrary.Migrations
{
    /// <inheritdoc />
    public partial class defineInCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Gears_GearId",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Ninjas_NinjaId",
                table: "InventoryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ninjas",
                table: "Ninjas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItem",
                table: "InventoryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gears",
                table: "Gears");

            migrationBuilder.RenameTable(
                name: "Ninjas",
                newName: "ninja");

            migrationBuilder.RenameTable(
                name: "InventoryItem",
                newName: "inventory_item");

            migrationBuilder.RenameTable(
                name: "Gears",
                newName: "gear");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ninja",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Gold",
                table: "ninja",
                newName: "gold");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ninja",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "GearId",
                table: "inventory_item",
                newName: "Gear_id");

            migrationBuilder.RenameColumn(
                name: "NinjaId",
                table: "inventory_item",
                newName: "Ninja_id");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItem_GearId",
                table: "inventory_item",
                newName: "IX_inventory_item_Gear_id");

            migrationBuilder.RenameColumn(
                name: "Strength",
                table: "gear",
                newName: "strength");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "gear",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Intelligence",
                table: "gear",
                newName: "intelligence");

            migrationBuilder.RenameColumn(
                name: "GoldValue",
                table: "gear",
                newName: "goldvalue");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "gear",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Agility",
                table: "gear",
                newName: "agility");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "gear",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ninja",
                table: "ninja",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_item",
                table: "inventory_item",
                columns: new[] { "Ninja_id", "Gear_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_gear",
                table: "gear",
                column: "id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_item_gear_Gear_id",
                table: "inventory_item");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_item_ninja_Ninja_id",
                table: "inventory_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ninja",
                table: "ninja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_item",
                table: "inventory_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gear",
                table: "gear");

            migrationBuilder.RenameTable(
                name: "ninja",
                newName: "Ninjas");

            migrationBuilder.RenameTable(
                name: "inventory_item",
                newName: "InventoryItem");

            migrationBuilder.RenameTable(
                name: "gear",
                newName: "Gears");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Ninjas",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "gold",
                table: "Ninjas",
                newName: "Gold");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Ninjas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Gear_id",
                table: "InventoryItem",
                newName: "GearId");

            migrationBuilder.RenameColumn(
                name: "Ninja_id",
                table: "InventoryItem",
                newName: "NinjaId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_item_Gear_id",
                table: "InventoryItem",
                newName: "IX_InventoryItem_GearId");

            migrationBuilder.RenameColumn(
                name: "strength",
                table: "Gears",
                newName: "Strength");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Gears",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "intelligence",
                table: "Gears",
                newName: "Intelligence");

            migrationBuilder.RenameColumn(
                name: "goldvalue",
                table: "Gears",
                newName: "GoldValue");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Gears",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "agility",
                table: "Gears",
                newName: "Agility");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Gears",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ninjas",
                table: "Ninjas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItem",
                table: "InventoryItem",
                columns: new[] { "NinjaId", "GearId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gears",
                table: "Gears",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_Gears_GearId",
                table: "InventoryItem",
                column: "GearId",
                principalTable: "Gears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_Ninjas_NinjaId",
                table: "InventoryItem",
                column: "NinjaId",
                principalTable: "Ninjas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
