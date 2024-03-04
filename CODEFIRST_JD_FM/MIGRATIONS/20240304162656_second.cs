using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CODEFIRST_JD_FM.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OFFICES",
                columns: table => new
                {
                    officeCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    city = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    addressLine1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    addressLine2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    postalCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    territory = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFFICES", x => x.officeCode);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    employeeNumber = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    lastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    extension = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: false),
                    officeCode = table.Column<string>(type: "varchar(10)", maxLength: 50, nullable: false),
                    reportsTo = table.Column<int>(type: "INT(11)", nullable: true),
                    jobTitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.employeeNumber);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_OFFICES_officeCode",
                        column: x => x.officeCode,
                        principalTable: "OFFICES",
                        principalColumn: "officeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_EMPLOYEES_reportsTo",
                        column: x => x.reportsTo,
                        principalTable: "EMPLOYEES",
                        principalColumn: "employeeNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_officeCode",
                table: "EMPLOYEES",
                column: "officeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_reportsTo",
                table: "EMPLOYEES",
                column: "reportsTo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "OFFICES");
        }
    }
}
