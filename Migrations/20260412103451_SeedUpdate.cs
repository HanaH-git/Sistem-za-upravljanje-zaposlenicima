using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aplikacija.Migrations
{
    /// <inheritdoc />
    public partial class SeedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Odjeli",
                columns: new[] { "OdjelId", "Lokacija", "Naziv" },
                values: new object[,]
                {
                    { 1, "Sarajevo", "HR" },
                    { 2, "Mostar", "Finansije" },
                    { 3, "Zenica", "IT" }
                });

            migrationBuilder.InsertData(
                table: "Zaposlenici",
                columns: new[] { "ZaposlenikId", "DatumZaposlenja", "Email", "Ime", "OdjelId", "PlataMonthly", "Prezime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "lana@log.com", "Lana", 1, 1500m, "Hodžić" },
                    { 2, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "amar@log.com", "Amar", 2, 2000m, "Mešić" },
                    { 3, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "lejla@log.com", "Lejla", 2, 1800m, "Kovač" },
                    { 4, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "emina@log.com", "Emina", 2, 1700m, "Softić" },
                    { 5, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kenan@log.com", "Kenan", 1, 1600m, "Alić" },
                    { 6, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@log.com", "Sara", 3, 1900m, "Begović" },
                    { 7, new DateTime(2020, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "nermin@log.com", "Nermin", 1, 2100m, "Hasić" },
                    { 8, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "amina@log.com", "Amina", 2, 1750m, "Zornić" },
                    { 9, new DateTime(2019, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "haris@log.com", "Haris", 3, 2200m, "Delić" },
                    { 10, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "zara@log.com", "Zara", 2, 1850m, "Osmanović" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zaposlenici",
                keyColumn: "ZaposlenikId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zaposlenici",
                keyColumn: "ZaposlenikId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zaposlenici",
                keyColumn: "ZaposlenikId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zaposlenici",
                keyColumn: "ZaposlenikId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zaposlenici",
                keyColumn: "ZaposlenikId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Zaposlenici",
                keyColumn: "ZaposlenikId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Zaposlenici",
                keyColumn: "ZaposlenikId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Zaposlenici",
                keyColumn: "ZaposlenikId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Zaposlenici",
                keyColumn: "ZaposlenikId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Zaposlenici",
                keyColumn: "ZaposlenikId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Odjeli",
                keyColumn: "OdjelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Odjeli",
                keyColumn: "OdjelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Odjeli",
                keyColumn: "OdjelId",
                keyValue: 3);
        }
    }
}
