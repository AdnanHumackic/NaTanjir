using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace http.Migrations
{
    /// <inheritdoc />
    public partial class dbScript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KategorijaProizvoda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKategorije = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaProizvoda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlikaKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is2FActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Admin_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kupac_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UkupnaCijena = table.Column<float>(type: "real", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDostavljeno = table.Column<bool>(type: "bit", nullable: false),
                    AdresaIsporuke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvidentiraoKorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Narudzba_KorisnickiNalog_EvidentiraoKorisnikID",
                        column: x => x.EvidentiraoKorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Radnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Radnik_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vlasnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vlasnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vlasnik_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restoran",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RadnoVrijemeOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RadnoVrijemeDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlikaRestorana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isObrisan = table.Column<bool>(type: "bit", nullable: false),
                    VlasnikRestoranaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restoran", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Restoran_Vlasnik_VlasnikRestoranaID",
                        column: x => x.VlasnikRestoranaID,
                        principalTable: "Vlasnik",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Dostava",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CijenaDostave = table.Column<float>(type: "real", nullable: false),
                    TelefonskiBrojDostavljaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestoranID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostava", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dostava_Restoran_RestoranID",
                        column: x => x.RestoranID,
                        principalTable: "Restoran",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivProizvoda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CijenaProizvoda = table.Column<float>(type: "real", nullable: false),
                    Sastojci = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUPonudi = table.Column<bool>(type: "bit", nullable: false),
                    VrijemePripreme = table.Column<float>(type: "real", nullable: false),
                    SlikaProizvoda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategorijaID = table.Column<int>(type: "int", nullable: false),
                    RestoranID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proizvod_KategorijaProizvoda_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "KategorijaProizvoda",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Proizvod_Restoran_RestoranID",
                        column: x => x.RestoranID,
                        principalTable: "Restoran",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Korpa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    UkupnaCijena = table.Column<float>(type: "real", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: false),
                    EvidentiraoKorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korpa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korpa_KorisnickiNalog_EvidentiraoKorisnikID",
                        column: x => x.EvidentiraoKorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Korpa_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dostava_RestoranID",
                table: "Dostava",
                column: "RestoranID");

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_EvidentiraoKorisnikID",
                table: "Korpa",
                column: "EvidentiraoKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_ProizvodID",
                table: "Korpa",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_EvidentiraoKorisnikID",
                table: "Narudzba",
                column: "EvidentiraoKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_KategorijaID",
                table: "Proizvod",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_RestoranID",
                table: "Proizvod",
                column: "RestoranID");

            migrationBuilder.CreateIndex(
                name: "IX_Restoran_VlasnikRestoranaID",
                table: "Restoran",
                column: "VlasnikRestoranaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Dostava");

            migrationBuilder.DropTable(
                name: "Korpa");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Radnik");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "KategorijaProizvoda");

            migrationBuilder.DropTable(
                name: "Restoran");

            migrationBuilder.DropTable(
                name: "Vlasnik");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");
        }
    }
}
