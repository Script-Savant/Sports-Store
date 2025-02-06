using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sports_Store.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Watersports", "A boat for one person", "Kayak", 275m },
                    { 2L, "Watersports", "Protective and fashionable", "Lifejacket", 48.95m },
                    { 3L, "Soccer", "FIFA-approved size and weigh less", "Soccer Ball", 19.50m },
                    { 4L, "Soccer", "Give your playing field a professional touch", "Corner Flags", 34.95m },
                    { 5L, "Soccer", "Flat-packed 35,000-seat stadium", "Stadium", 79500m },
                    { 6L, "Chess", "Improve brain efficiency by 75%", "Thinking Cap", 16m },
                    { 7L, "Chess", "Secretly give your opponent a disadvantage", "Unsteady Chair", 29.95m },
                    { 8L, "Chess", "A fun game for the family", "Human Chess Board", 75m },
                    { 9L, "Chess", "Gold-plated, diamond-studded King", "Bling-Bling King", 1200m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
