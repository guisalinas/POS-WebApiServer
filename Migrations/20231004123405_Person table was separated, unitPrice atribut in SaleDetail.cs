using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_ApiServer.Migrations
{
    /// <inheritdoc />
    public partial class PersontablewasseparatedunitPriceatributinSaleDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Persons_supplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Persons_customerId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "tieredType",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "tradeName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "web",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "SalesDetail",
                newName: "unitPrice");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    tieredType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Customers_Persons_id",
                        column: x => x.id,
                        principalTable: "Persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    web = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tradeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Persons_id",
                        column: x => x.id,
                        principalTable: "Persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_supplierId",
                table: "Products",
                column: "supplierId",
                principalTable: "Suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_customerId",
                table: "Sales",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_supplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_customerId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "unitPrice",
                table: "SalesDetail",
                newName: "price");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "tieredType",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tradeName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "web",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Persons_supplierId",
                table: "Products",
                column: "supplierId",
                principalTable: "Persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Persons_customerId",
                table: "Sales",
                column: "customerId",
                principalTable: "Persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
