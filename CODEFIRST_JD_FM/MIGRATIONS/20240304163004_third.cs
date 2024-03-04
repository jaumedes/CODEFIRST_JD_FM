using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CODEFIRST_JD_FM.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    customerNumber = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customerName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    contactLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ContactFirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    addressLine1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    addressLine2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    postalCode = table.Column<string>(type: "varchar(50)", maxLength: 15, nullable: false),
                    country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    salesRepEmployeeNumber = table.Column<int>(type: "INT(11)", nullable: true),
                    creditLimit = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.customerNumber);
                    table.ForeignKey(
                        name: "FK_CUSTOMERS_EMPLOYEES_salesRepEmployeeNumber",
                        column: x => x.salesRepEmployeeNumber,
                        principalTable: "EMPLOYEES",
                        principalColumn: "employeeNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTS",
                columns: table => new
                {
                    customerNumber = table.Column<int>(type: "INT(11)", nullable: false),
                    checkNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    paymentDate = table.Column<DateTime>(type: "Date", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTS", x => new { x.customerNumber, x.checkNumber });
                    table.ForeignKey(
                        name: "FK_PAYMENTS_CUSTOMERS_customerNumber",
                        column: x => x.customerNumber,
                        principalTable: "CUSTOMERS",
                        principalColumn: "customerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_salesRepEmployeeNumber",
                table: "CUSTOMERS",
                column: "salesRepEmployeeNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAYMENTS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");
        }
    }
}
