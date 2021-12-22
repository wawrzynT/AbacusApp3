using Microsoft.EntityFrameworkCore.Migrations;

namespace AbacusApp3.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Konto",
                columns: table => new
                {
                    KontoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaKonta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konto", x => x.KontoId);
                    table.ForeignKey(
                        name: "FK_Konto_Konto_KontoId1",
                        column: x => x.KontoId1,
                        principalTable: "Konto",
                        principalColumn: "KontoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lokalizacja",
                columns: table => new
                {
                    LokalizacjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaLok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrDomu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrLokalu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miejscowosc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokalizacja", x => x.LokalizacjaId);
                });

            migrationBuilder.CreateTable(
                name: "Osoba",
                columns: table => new
                {
                    OsobaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<int>(type: "int", nullable: false),
                    DokumentTozsamosci = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LokalizacjaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoba", x => x.OsobaId);
                    table.ForeignKey(
                        name: "FK_Osoba_Lokalizacja_LokalizacjaId",
                        column: x => x.LokalizacjaId,
                        principalTable: "Lokalizacja",
                        principalColumn: "LokalizacjaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Konto_KontoId1",
                table: "Konto",
                column: "KontoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Osoba_LokalizacjaId",
                table: "Osoba",
                column: "LokalizacjaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Konto");

            migrationBuilder.DropTable(
                name: "Osoba");

            migrationBuilder.DropTable(
                name: "Lokalizacja");
        }
    }
}
