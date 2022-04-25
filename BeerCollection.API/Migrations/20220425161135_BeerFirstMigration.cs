using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerCollection.API.Migrations
{
    public partial class BeerFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeerRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BeerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeerRatings_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "Name", "Rating", "Type" },
                values: new object[] { 1, "Tuborg", 1.0, "Strong" });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "Name", "Rating", "Type" },
                values: new object[] { 2, "Kingfisher", 1.0, "Premium" });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "Name", "Rating", "Type" },
                values: new object[] { 3, "Carlsberg", 1.0, "Elephant" });

            migrationBuilder.InsertData(
                table: "BeerRatings",
                columns: new[] { "Id", "BeerId", "Description", "Rate" },
                values: new object[,]
                {
                    { 1, 1, "Delicious", 3 },
                    { 2, 1, "Special", 5 },
                    { 3, 2, "Delicious", 3 },
                    { 4, 2, "Delicious", 5 },
                    { 5, 3, "Delicious", 3 },
                    { 6, 3, "Delicious", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeerRatings_BeerId",
                table: "BeerRatings",
                column: "BeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerRatings");

            migrationBuilder.DropTable(
                name: "Beers");
        }
    }
}
