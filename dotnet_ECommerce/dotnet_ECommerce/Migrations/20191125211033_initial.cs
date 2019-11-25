using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_ECommerce.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Description", "Image", "IsFeatured", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, "A combination of multiple small cactuses", "/images/cactus_atlantic.jpg", true, "Atlantic", 12m, "CAC001" },
                    { 2, "A hot pink little cactus to bright up your room", "/images/cactus_rosette.jpg", true, "Rosette", 9m, "CAC002" },
                    { 3, "This cactus with elegant-looking glass is perfect for your desk", "/images/cactus_pastel.jpg", false, "Pastel", 7m, "CAC003" },
                    { 4, "This cute little coral will definitely lighten up your mood", "/images/cactus_coral.jpg", true, "Coral", 10m, "CAC004" },
                    { 5, "The unique looking little parakeet is one of the tiny plants that you must have", "/images/cactus_parakeet.jpg", false, "Parakeet", 18m, "CAC005" },
                    { 6, "This spiky and layered looking cactus is defenitely a rare found", "/images/cactus_crimson.jpg", false, "Crimson", 17m, "CAC006" },
                    { 7, "A blue orchid is one of the best indoor plants that you can have", "/images/flower_arctic.jpg", false, "Arctic", 24m, "FLW001" },
                    { 8, "This ornamental plant comes with violet flowers and kokedama that adds more style to your plant", "/images/flower_kokedama.jpg", false, "Violet Kokedama", 29m, "FLW002" },
                    { 9, "Bamboo is easy to take care of and it grows fast", "/images/plant_bamboo.jpg", false, "Bamboo", 26m, "PLN001" },
                    { 10, "This plant can live in water and it makes a great indoor plant", "/images/plant_hyacinth.jpg", false, "Hyacinth", 22m, "PLN002" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
