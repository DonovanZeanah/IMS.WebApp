using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Plugins.SQLite.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventorySources",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    SourceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventorySources", x => new { x.InventoryId, x.SourceId });
                });

            migrationBuilder.CreateTable(
                name: "SourceDiscriminator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceDiscriminator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DiscriminatorID = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscriminatorIdId = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    InventorySourceInventoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    InventorySourceSourceId = table.Column<int>(type: "INTEGER", nullable: true),
                    ContactName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Process = table.Column<string>(type: "TEXT", nullable: true),
                    StoreName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sources_InventorySources_InventorySourceInventoryId_InventorySourceSourceId",
                        columns: x => new { x.InventorySourceInventoryId, x.InventorySourceSourceId },
                        principalTable: "InventorySources",
                        principalColumns: new[] { "InventoryId", "SourceId" });
                    table.ForeignKey(
                        name: "FK_Sources_SourceDiscriminator_DiscriminatorIdId",
                        column: x => x.DiscriminatorIdId,
                        principalTable: "SourceDiscriminator",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryName = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: true),
                    SourceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventoryInventorySource",
                columns: table => new
                {
                    InventoriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    InventorySourcesInventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    InventorySourcesSourceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryInventorySource", x => new { x.InventoriesId, x.InventorySourcesInventoryId, x.InventorySourcesSourceId });
                    table.ForeignKey(
                        name: "FK_InventoryInventorySource_Inventories_InventoriesId",
                        column: x => x.InventoriesId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryInventorySource_InventorySources_InventorySourcesInventoryId_InventorySourcesSourceId",
                        columns: x => new { x.InventorySourcesInventoryId, x.InventorySourcesSourceId },
                        principalTable: "InventorySources",
                        principalColumns: new[] { "InventoryId", "SourceId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "InventoryId", "InventoryName", "Price", "Quantity", "SourceId" },
                values: new object[] { 25, 0, "Steering Wheel", 30.0, 10, null });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "InventoryId", "InventoryName", "Price", "Quantity", "SourceId" },
                values: new object[] { 26, 0, "Driver Seat", 20.0, 100, null });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "InventoryId", "InventoryName", "Price", "Quantity", "SourceId" },
                values: new object[] { 27, 0, "Battery Bank", 12.0, 100, null });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "InventoryId", "InventoryName", "Price", "Quantity", "SourceId" },
                values: new object[] { 28, 0, "Drive Motor", 1.0, 100, null });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "ContactName", "Discriminator", "DiscriminatorID", "DiscriminatorIdId", "InventorySourceInventoryId", "InventorySourceSourceId", "Name", "PhoneNumber" },
                values: new object[] { 5, "John Doe", "ContactSource", 0, null, null, null, "Contact 1", "555-1234" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "ContactName", "Discriminator", "DiscriminatorID", "DiscriminatorIdId", "InventorySourceInventoryId", "InventorySourceSourceId", "Name", "PhoneNumber" },
                values: new object[] { 6, "Jane Smith", "ContactSource", 0, null, null, null, "Contact 2", "555-5678" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Address", "Discriminator", "DiscriminatorID", "DiscriminatorIdId", "InventorySourceInventoryId", "InventorySourceSourceId", "Name" },
                values: new object[] { 1, "123 Main St", "LocationSource", 0, null, null, null, "Location 1" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Address", "Discriminator", "DiscriminatorID", "DiscriminatorIdId", "InventorySourceInventoryId", "InventorySourceSourceId", "Name" },
                values: new object[] { 2, "456 Oak St", "LocationSource", 0, null, null, null, "Location 2" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Discriminator", "DiscriminatorID", "DiscriminatorIdId", "InventorySourceInventoryId", "InventorySourceSourceId", "Name", "Process" },
                values: new object[] { 7, "SelfObtainedSource", 0, null, null, null, "Self Obtained 1", "Manual" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Discriminator", "DiscriminatorID", "DiscriminatorIdId", "InventorySourceInventoryId", "InventorySourceSourceId", "Name", "Process" },
                values: new object[] { 8, "SelfObtainedSource", 0, null, null, null, "Self Obtained 2", "Automated" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Discriminator", "DiscriminatorID", "DiscriminatorIdId", "InventorySourceInventoryId", "InventorySourceSourceId", "Name", "StoreName" },
                values: new object[] { 3, "StoreSource", 0, null, null, null, "Store 1", "Best Mart" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Discriminator", "DiscriminatorID", "DiscriminatorIdId", "InventorySourceInventoryId", "InventorySourceSourceId", "Name", "StoreName" },
                values: new object[] { 4, "StoreSource", 0, null, null, null, "Store 2", "Super Store" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SourceId",
                table: "Inventories",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryInventorySource_InventorySourcesInventoryId_InventorySourcesSourceId",
                table: "InventoryInventorySource",
                columns: new[] { "InventorySourcesInventoryId", "InventorySourcesSourceId" });

            migrationBuilder.CreateIndex(
                name: "IX_Sources_DiscriminatorIdId",
                table: "Sources",
                column: "DiscriminatorIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Sources_InventorySourceInventoryId_InventorySourceSourceId",
                table: "Sources",
                columns: new[] { "InventorySourceInventoryId", "InventorySourceSourceId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "InventoryInventorySource");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "InventorySources");

            migrationBuilder.DropTable(
                name: "SourceDiscriminator");
        }
    }
}
