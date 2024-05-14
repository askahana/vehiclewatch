using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleWatch.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ReportedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emergency = table.Column<bool>(type: "bit", nullable: false),
                    ReportStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Name" },
                values: new object[,]
                {
                    { 1, "Adam" },
                    { 2, "Bengt" },
                    { 3, "Cathy" },
                    { 4, "David" },
                    { 5, "Erika" },
                    { 6, "Felicia" },
                    { 7, "Gabriella" },
                    { 8, "Henrik" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "RegistrationNumber" },
                values: new object[,]
                {
                    { 1, "ABC123" },
                    { 2, "WEL217" },
                    { 3, "UEN357" },
                    { 4, "KAZ813" },
                    { 5, "WES123" },
                    { 6, "NEM345" },
                    { 7, "MLB803" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "Emergency", "EmployeeId", "ReportDescription", "ReportStatus", "ReportedDate", "VehicleId" },
                values: new object[,]
                {
                    { 1, true, 1, "Fel med motor", 0, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, false, 2, "vindrutetorkaren fungerar inte", 0, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, false, 3, "sprickan i vindrutan", 2, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, false, 4, "sprickan i vindrutan", 0, new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EmployeeId",
                table: "Reports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_VehicleId",
                table: "Reports",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
