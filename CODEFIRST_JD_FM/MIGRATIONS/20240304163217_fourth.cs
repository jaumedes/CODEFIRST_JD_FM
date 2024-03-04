using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CODEFIRST_JD_FM.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    orderNumber = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    orderDate = table.Column<DateTime>(type: "Date", nullable: false),
                    requiredDate = table.Column<DateTime>(type: "Date", nullable: false),
                    shippedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    status = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    comments = table.Column<string>(type: "text", nullable: true),
                    customerNumber = table.Column<int>(type: "INT(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.orderNumber);
                    table.ForeignKey(
                        name: "FK_ORDERS_CUSTOMERS_customerNumber",
                        column: x => x.customerNumber,
                        principalTable: "CUSTOMERS",
                        principalColumn: "customerNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDERDETAILS",
                columns: table => new
                {
                    orderNumber = table.Column<int>(type: "INT(11)", nullable: false),
                    productCode = table.Column<string>(type: "varchar(50)", maxLength: 15, nullable: false),
                    quantityOrdered = table.Column<int>(type: "INT(11)", nullable: false),
                    priceEach = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    orderLineNumber = table.Column<short>(type: "smallint(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERDETAILS", x => new { x.orderNumber, x.productCode });
                    table.ForeignKey(
                        name: "FK_ORDERDETAILS_ORDERS_orderNumber",
                        column: x => x.orderNumber,
                        principalTable: "ORDERS",
                        principalColumn: "orderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERDETAILS_PRODUCTS_productCode",
                        column: x => x.productCode,
                        principalTable: "PRODUCTS",
                        principalColumn: "productCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAILS_productCode",
                table: "ORDERDETAILS",
                column: "productCode");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_customerNumber",
                table: "ORDERS",
                column: "customerNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDERDETAILS");

            migrationBuilder.DropTable(
                name: "ORDERS");
        }
    }
}
