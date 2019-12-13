using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_ECommerce.Migrations.StoreDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    CreditCard = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

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
                    Image = table.Column<string>(nullable: true),
                    IsFeatured = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.CartID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartID",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderItems_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Description", "Image", "IsFeatured", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, "A combination of multiple small cactuses", "https://tinyplants.blob.core.windows.net/products/CAC001", true, "Atlantic", 12m, "CAC001" },
                    { 2, "A hot pink little cactus to bright up your room", "https://tinyplants.blob.core.windows.net/products/CAC002", true, "Rosette", 9m, "CAC002" },
                    { 3, "This cactus with elegant-looking glass is perfect for your desk", "https://tinyplants.blob.core.windows.net/products/CAC003", false, "Pastel", 7m, "CAC003" },
                    { 4, "This cute little coral will definitely lighten up your mood", "https://tinyplants.blob.core.windows.net/products/CAC004", true, "Coral", 10m, "CAC004" },
                    { 5, "The unique looking little parakeet is one of the tiny plants that you must have", "https://tinyplants.blob.core.windows.net/products/CAC005", false, "Parakeet", 18m, "CAC005" },
                    { 6, "This spiky and layered looking cactus is defenitely a rare found", "https://tinyplants.blob.core.windows.net/products/CAC006", false, "Crimson", 17m, "CAC006" },
                    { 7, "A blue orchid is one of the best indoor plants that you can have", "https://tinyplants.blob.core.windows.net/products/FLW001", false, "Arctic", 24m, "FLW001" },
                    { 8, "This ornamental plant comes with violet flowers and kokedama that adds more style to your plant", "https://tinyplants.blob.core.windows.net/products/FLW002", false, "Violet Kokedama", 29m, "FLW002" },
                    { 9, "Bamboo is easy to take care of and it grows fast", "https://tinyplants.blob.core.windows.net/products/PLN001", false, "Bamboo", 26m, "PLN001" },
                    { 10, "This plant can live in water and it makes a great indoor plant", "https://tinyplants.blob.core.windows.net/products/PLN002", false, "Hyacinth", 22m, "PLN002" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductID",
                table: "OrderItems",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
