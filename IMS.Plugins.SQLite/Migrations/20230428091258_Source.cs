using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Plugins.SQLite.Migrations
{
    public partial class Source : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Source_SourceId",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Source",
                table: "Source");

            migrationBuilder.RenameTable(
                name: "Source",
                newName: "Sources");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sources",
                table: "Sources",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "ContactName", "Discriminator", "Name", "PhoneNumber" },
                values: new object[] { 5, "John Doe", "ContactSource", "Contact 1", "555-1234" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "ContactName", "Discriminator", "Name", "PhoneNumber" },
                values: new object[] { 6, "Jane Smith", "ContactSource", "Contact 2", "555-5678" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Address", "Discriminator", "Name" },
                values: new object[] { 1, "123 Main St", "LocationSource", "Location 1" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Address", "Discriminator", "Name" },
                values: new object[] { 2, "456 Oak St", "LocationSource", "Location 2" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Discriminator", "Name", "Process" },
                values: new object[] { 7, "SelfObtainedSource", "Self Obtained 1", "Manual" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Discriminator", "Name", "Process" },
                values: new object[] { 8, "SelfObtainedSource", "Self Obtained 2", "Automated" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Discriminator", "Name", "StoreName" },
                values: new object[] { 3, "StoreSource", "Store 1", "Best Mart" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Discriminator", "Name", "StoreName" },
                values: new object[] { 4, "StoreSource", "Store 2", "Super Store" });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "InventoryId", "InventoryName", "Price", "Quantity", "SourceId" },
                values: new object[] { 1, 100, "Item A", 5.0, 10, 1 });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "InventoryId", "InventoryName", "Price", "Quantity", "SourceId" },
                values: new object[] { 2, 200, "Item B", 10.0, 20, 3 });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "InventoryId", "InventoryName", "Price", "Quantity", "SourceId" },
                values: new object[] { 3, 300, "Item C", 7.5, 15, 5 });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "InventoryId", "InventoryName", "Price", "Quantity", "SourceId" },
                values: new object[] { 4, 400, "Item D", 12.5, 8, 7 });

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Sources_SourceId",
                table: "Inventories",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Sources_SourceId",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sources",
                table: "Sources");

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Sources",
                newName: "Source");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Source",
                table: "Source",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Source_SourceId",
                table: "Inventories",
                column: "SourceId",
                principalTable: "Source",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
