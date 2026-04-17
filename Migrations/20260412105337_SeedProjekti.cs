using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aplikacija.Migrations
{
    /// <inheritdoc />
    public partial class SeedProjekti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projekti",
                columns: new[] { "ProjekatId", "BudzetUSD", "DatumKraj", "DatumPocetak", "Naziv" },
                values: new object[,]
                {
                    { 1, 50000m, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web App" },
                    { 2, 30000m, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile App" },
                    { 3, 70000m, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ERP Sistem" },
                    { 4, 25000m, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR Portal" }
                });

            migrationBuilder.InsertData(
                table: "ZaposlenikProjekti",
                columns: new[] { "ProjekatId", "ZaposlenikId", "SatiNaTjednu", "Uloga" },
                values: new object[,]
                {
                    { 1, 1, 40, "Backend Developer" },
                    { 1, 2, 10, "HR Support" },
                    { 2, 3, 35, "Frontend Developer" },
                    { 2, 4, 20, "QA Engineer" },
                    { 3, 5, 30, "DevOps Engineer" },
                    { 3, 6, 15, "Business Analyst" },
                    { 4, 7, 25, "Project Manager" },
                    { 4, 8, 20, "UI/UX Designer" },
                    { 1, 9, 12, "Finance Consultant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ZaposlenikProjekti",
                keyColumns: new[] { "ProjekatId", "ZaposlenikId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ZaposlenikProjekti",
                keyColumns: new[] { "ProjekatId", "ZaposlenikId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ZaposlenikProjekti",
                keyColumns: new[] { "ProjekatId", "ZaposlenikId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ZaposlenikProjekti",
                keyColumns: new[] { "ProjekatId", "ZaposlenikId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ZaposlenikProjekti",
                keyColumns: new[] { "ProjekatId", "ZaposlenikId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ZaposlenikProjekti",
                keyColumns: new[] { "ProjekatId", "ZaposlenikId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ZaposlenikProjekti",
                keyColumns: new[] { "ProjekatId", "ZaposlenikId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "ZaposlenikProjekti",
                keyColumns: new[] { "ProjekatId", "ZaposlenikId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "ZaposlenikProjekti",
                keyColumns: new[] { "ProjekatId", "ZaposlenikId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "Projekti",
                keyColumn: "ProjekatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projekti",
                keyColumn: "ProjekatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projekti",
                keyColumn: "ProjekatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projekti",
                keyColumn: "ProjekatId",
                keyValue: 4);
        }
    }
}
