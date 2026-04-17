using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplikacija.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odjeli",
                columns: table => new
                {
                    OdjelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odjeli", x => x.OdjelId);
                });

            migrationBuilder.CreateTable(
                name: "Projekti",
                columns: table => new
                {
                    ProjekatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BudzetUSD = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    DatumPocetak = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumKraj = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekti", x => x.ProjekatId);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenici",
                columns: table => new
                {
                    ZaposlenikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlataMonthly = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OdjelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenici", x => x.ZaposlenikId);
                    table.ForeignKey(
                        name: "FK_Zaposlenici_Odjeli_OdjelId",
                        column: x => x.OdjelId,
                        principalTable: "Odjeli",
                        principalColumn: "OdjelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZaposlenikProjekti",
                columns: table => new
                {
                    ZaposlenikId = table.Column<int>(type: "int", nullable: false),
                    ProjekatId = table.Column<int>(type: "int", nullable: false),
                    Uloga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SatiNaTjednu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaposlenikProjekti", x => new { x.ZaposlenikId, x.ProjekatId });
                    table.ForeignKey(
                        name: "FK_ZaposlenikProjekti_Projekti_ProjekatId",
                        column: x => x.ProjekatId,
                        principalTable: "Projekti",
                        principalColumn: "ProjekatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZaposlenikProjekti_Zaposlenici_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenici",
                        principalColumn: "ZaposlenikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenici_Email",
                table: "Zaposlenici",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenici_OdjelId",
                table: "Zaposlenici",
                column: "OdjelId");

            migrationBuilder.CreateIndex(
                name: "IX_ZaposlenikProjekti_ProjekatId",
                table: "ZaposlenikProjekti",
                column: "ProjekatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZaposlenikProjekti");

            migrationBuilder.DropTable(
                name: "Projekti");

            migrationBuilder.DropTable(
                name: "Zaposlenici");

            migrationBuilder.DropTable(
                name: "Odjeli");
        }
    }
}
