using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_ApiServer.Migrations
{
    /// <inheritdoc />
    public partial class Suppliernulleableinproductentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Persons_supplierid",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "supplierid",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Persons_supplierid",
                table: "Products",
                column: "supplierid",
                principalTable: "Persons",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Persons_supplierid",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "supplierid",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Persons_supplierid",
                table: "Products",
                column: "supplierid",
                principalTable: "Persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
