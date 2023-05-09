using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Plugins.SQLite.Migrations
{
    public partial class Initial : Migration
    {
        // The Up method is used to apply the migration, creating tables and indexes.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Creating the 'Source' table with the specified columns and their data types.
            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    ContactName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Process = table.Column<string>(type: "TEXT", nullable: true),
                    StoreName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    // Defining the primary key constraint for the 'Source' table.
                    table.PrimaryKey("PK_Source", x => x.Id);
                });

            // Creating the 'Inventories' table with the specified columns and their data types.
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
                    SourceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    // Defining the primary key constraint for the 'Inventories' table.
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    // Defining the foreign key constraint between the 'Inventories' table and the 'Source' table.
                    table.ForeignKey(
                        name: "FK_Inventories_Source_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Source",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Creating an index for the 'SourceId' column in the 'Inventories' table to optimize queries.
            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SourceId",
                table: "Inventories",
                column: "SourceId");
        }

        // The Down method is used to revert the migration, undoing the schema changes.
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Dropping the 'Inventories' table.
            migrationBuilder.DropTable(
                name: "Inventories");

            // Dropping the 'Source' table.
            migrationBuilder.DropTable(
                name: "Source");
        }
    }
}
