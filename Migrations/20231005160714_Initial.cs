using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BotanicalDB.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpeciesComplexes",
                columns: table => new
                {
                    ComplexId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplexName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesComplexes", x => x.ComplexId);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Synonym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distribution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplexId = table.Column<int>(type: "int", nullable: false),
                    AquiredDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plants_SpeciesComplexes_ComplexId",
                        column: x => x.ComplexId,
                        principalTable: "SpeciesComplexes",
                        principalColumn: "ComplexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SpeciesComplexes",
                columns: new[] { "ComplexId", "ComplexName" },
                values: new object[,]
                {
                    { 1, "Undetermined" },
                    { 2, "Hybrid" },
                    { 3, "Cuprea group" },
                    { 4, "Heterophylla group" },
                    { 5, "Longiloba group" }
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "AquiredDate", "ComplexId", "Distribution", "PlantName", "PlantStatus", "PlantType", "Synonym" },
                values: new object[,]
                {
                    { 1, "September 2022", 1, "Indonesia", "Alocasia azlanii", "Healthy", "Species", "Red Mambo" },
                    { 2, "May 2023", 2, "Philippines", "Alocasia heterophylla", "Healthy", "Species", "Dragon's Breath" },
                    { 3, "May 2023", 3, "Philippines", "Alocasia sanderiana", "Healthy", "Species", "Nobilis" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ComplexId",
                table: "Plants",
                column: "ComplexId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "SpeciesComplexes");
        }
    }
}
