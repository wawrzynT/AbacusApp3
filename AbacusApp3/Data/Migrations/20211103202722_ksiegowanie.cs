using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbacusApp3.Data.Migrations
{
    public partial class ksiegowanie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ksiegowanie",
                columns: table => new
                {
                    KsiegowanieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LokalizacjaId = table.Column<int>(type: "int", nullable: false),
                    KontoId = table.Column<int>(type: "int", nullable: false),
                    TerminPlatnosci = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KwotaWn = table.Column<double>(type: "float", nullable: false),
                    KwotaWplaty = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KwotaMa = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiegowanie", x => x.KsiegowanieId);
                    table.ForeignKey(
                        name: "FK_Ksiegowanie_Konto_KontoId",
                        column: x => x.KontoId,
                        principalTable: "Konto",
                        principalColumn: "KontoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ksiegowanie_Lokalizacja_LokalizacjaId",
                        column: x => x.LokalizacjaId,
                        principalTable: "Lokalizacja",
                        principalColumn: "LokalizacjaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ksiegowanie_KontoId",
                table: "Ksiegowanie",
                column: "KontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiegowanie_LokalizacjaId",
                table: "Ksiegowanie",
                column: "LokalizacjaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ksiegowanie");
        }
    }
}
