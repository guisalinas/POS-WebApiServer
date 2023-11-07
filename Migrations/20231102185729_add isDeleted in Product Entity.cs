using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_ApiServer.Migrations
{
    /// <inheritdoc />
    public partial class addisDeletedinProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Persons_PersonId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Persons_supplierId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "supplierId",
                table: "Products",
                newName: "supplierid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_supplierId",
                table: "Products",
                newName: "IX_Products_supplierid");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Address",
                newName: "personid");

            migrationBuilder.RenameIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                newName: "IX_Address_personid");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Sales",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "supplierid",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Persons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Persons_personid",
                table: "Address",
                column: "personid",
                principalTable: "Persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Persons_supplierid",
                table: "Products",
                column: "supplierid",
                principalTable: "Persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Persons_personid",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Persons_supplierid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "supplierid",
                table: "Products",
                newName: "supplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_supplierid",
                table: "Products",
                newName: "IX_Products_supplierId");

            migrationBuilder.RenameColumn(
                name: "personid",
                table: "Address",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_personid",
                table: "Address",
                newName: "IX_Address_PersonId");

            migrationBuilder.AlterColumn<int>(
                name: "supplierId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Persons_PersonId",
                table: "Address",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Persons_supplierId",
                table: "Products",
                column: "supplierId",
                principalTable: "Persons",
                principalColumn: "id");
        }
    }
}
