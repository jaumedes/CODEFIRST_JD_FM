using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CODEFIRST_JD_FM.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCTLINES",
                columns: table => new
                {
                    productLineName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    textDescription = table.Column<string>(type: "varchar(4000)", maxLength: 50, nullable: false),
                    htmlDescription = table.Column<string>(type: "mediumtext", nullable: true),
                    image = table.Column<byte[]>(type: "mediumblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTLINES", x => x.productLineName);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    productCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    productName = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    productLine = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    productScale = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    productVendor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    productDescription = table.Column<string>(type: "text", nullable: false),
                    quantityStock = table.Column<short>(type: "smallint(6)", nullable: false),
                    buyPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MSRP = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.productCode);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_PRODUCTLINES_productLine",
                        column: x => x.productLine,
                        principalTable: "PRODUCTLINES",
                        principalColumn: "productLineName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_productLine",
                table: "PRODUCTS",
                column: "productLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "PRODUCTLINES");
        }
    }
}
