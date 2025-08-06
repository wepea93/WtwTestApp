using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Requests.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeId = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TypeOfRequest = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "Id", "EmployeeId", "EmployeeName", "EndDate", "Reason", "RequestDate", "StartDate", "Status", "TypeOfRequest" },
                values: new object[,]
                {
                    { -3, "EMP003", "Sofia Martinez", new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal errands and family matters", new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2 },
                    { -2, "EMP002", "Michael Smith", new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flu symptoms and medical rest", new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { -1, "EMP001", "Alice Johnson", new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family vacation to the coast", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request");
        }
    }
}
