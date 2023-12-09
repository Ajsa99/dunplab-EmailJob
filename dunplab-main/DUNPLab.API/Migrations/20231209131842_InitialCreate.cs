using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DUNPLab.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojDokumenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumIstekaDokumenta = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testiranja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UkupnaCena = table.Column<double>(type: "float", nullable: false),
                    NacinPlacanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestOdradio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JesuLiPotvrdjeniSviUzorci = table.Column<bool>(type: "bit", nullable: true),
                    DatumVremeTestiranja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumVremeRezultata = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojSobe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Izmenio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IzmenioDatumVreme = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testiranja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzorci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodEpruvete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetodTestiranja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KonacanRezultat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: true),
                    Kutija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTestiranja = table.Column<int>(type: "int", nullable: false),
                    Izmenio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IzmenioDatumVreme = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzorci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uzorci_Testiranja_IdTestiranja",
                        column: x => x.IdTestiranja,
                        principalTable: "Testiranja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zahtev",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumTestiranja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Metode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestiranjeId = table.Column<int>(type: "int", nullable: true),
                    PacijentId = table.Column<int>(type: "int", nullable: true),
                    JeLiObradjen = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zahtev_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zahtev_Testiranja_TestiranjeId",
                        column: x => x.TestiranjeId,
                        principalTable: "Testiranja",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Supstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oznaka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonjaGranica = table.Column<double>(type: "float", nullable: true),
                    GornjaGranica = table.Column<double>(type: "float", nullable: true),
                    MetodTestiranja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    ZahtevId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supstance_Zahtev_ZahtevId",
                        column: x => x.ZahtevId,
                        principalTable: "Zahtev",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rezultati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JeLiUGranicama = table.Column<bool>(type: "bit", nullable: true),
                    Vrednost = table.Column<double>(type: "float", nullable: true),
                    IdUzorka = table.Column<int>(type: "int", nullable: false),
                    IdSupstance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezultati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezultati_Supstance_IdSupstance",
                        column: x => x.IdSupstance,
                        principalTable: "Supstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezultati_Uzorci_IdUzorka",
                        column: x => x.IdUzorka,
                        principalTable: "Uzorci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pacijenti",
                columns: new[] { "Id", "Adresa", "BrojDokumenta", "DatumIstekaDokumenta", "DatumRodjenja", "Email", "Grad", "Ime", "JMBG", "Pol", "Prezime", "Telefon" },
                values: new object[,]
                {
                    { 1, "Adresa 1", "ABC123", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ajsa.alibasic11@gmail.com", "Grad 1", "Ajsa", "1234567890123", "Zenski", "Alibasic", "123456789" },
                    { 2, "Adresa 2", "XYZ789", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "softversko.i23m@gmail.com", "Grad 2", "Kristina", "9876543210123", "Zenski", "Milentijevic", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Supstance",
                columns: new[] { "Id", "Cena", "DonjaGranica", "GornjaGranica", "MetodTestiranja", "Naziv", "Opis", "Oznaka", "Tip", "ZahtevId" },
                values: new object[,]
                {
                    { 1, 150.0, 12.0, 17.5, "Laboratorijski", "Hemoglobin", "Krv", "Hb", "Biološka", null },
                    { 2, 120.0, 70.0, 100.0, "Laboratorijski", "Glukoza", "šećer", "Glu", "Biološka", null },
                    { 3, 180.0, 70.0, 200.0, "Laboratorijski", "Holesterol", "holesterol", "Hch", "Biološka", null }
                });

            migrationBuilder.InsertData(
                table: "Testiranja",
                columns: new[] { "Id", "BrojSobe", "DatumVremeRezultata", "DatumVremeTestiranja", "Izmenio", "IzmenioDatumVreme", "JesuLiPotvrdjeniSviUzorci", "NacinPlacanja", "Naziv", "Status", "TestOdradio", "UkupnaCena" },
                values: new object[,]
                {
                    { 1, "101", new DateTime(2023, 12, 9, 14, 18, 41, 299, DateTimeKind.Local).AddTicks(7027), new DateTime(2023, 12, 9, 14, 18, 41, 299, DateTimeKind.Local).AddTicks(7017), "Admin", new DateTime(2023, 12, 9, 14, 18, 41, 299, DateTimeKind.Local).AddTicks(7033), true, "Kartica", "Opšti test", "Zavrseno", "Ajsa", 450.0 },
                    { 2, "210", new DateTime(2023, 12, 9, 14, 18, 41, 299, DateTimeKind.Local).AddTicks(7047), new DateTime(2023, 12, 9, 14, 18, 41, 299, DateTimeKind.Local).AddTicks(7042), "Admin", new DateTime(2023, 12, 9, 14, 18, 41, 299, DateTimeKind.Local).AddTicks(7052), false, "Gotovinsko", "Krvni pritisak", "U toku", "Kristina", 250.0 }
                });

            migrationBuilder.InsertData(
                table: "Uzorci",
                columns: new[] { "Id", "Cena", "IdTestiranja", "Izmenio", "IzmenioDatumVreme", "KodEpruvete", "Komentar", "KonacanRezultat", "Kutija", "MetodTestiranja", "Naziv" },
                values: new object[,]
                {
                    { 1, 100.0, 1, "Ajsa", new DateTime(2023, 12, 9, 14, 18, 41, 299, DateTimeKind.Local).AddTicks(7117), "KRV-001", "Nema komentara", "Negativan", "BX20", "Krvni pritisak", "Krv" },
                    { 2, 150.0, 2, "Kristina", new DateTime(2023, 12, 9, 14, 18, 41, 299, DateTimeKind.Local).AddTicks(7127), "UZ-001", "Negativan rezultat", "Negativan", "BX21", "Opšti test", "Opšti uzorak" },
                    { 3, 100.0, 2, "Kristina", new DateTime(2023, 12, 9, 14, 18, 41, 299, DateTimeKind.Local).AddTicks(7136), "KRV-002", "Pozitivan rezultat", "Pozitivan", "BX22", "Krvni pritisak", "Krv" }
                });

            migrationBuilder.InsertData(
                table: "Zahtev",
                columns: new[] { "Id", "DatumTestiranja", "JeLiObradjen", "Metode", "PacijentId", "TestiranjeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 9, 14, 18, 41, 299, DateTimeKind.Local).AddTicks(6713), true, "[\"Krv\"]", 1, 1 },
                    { 2, new DateTime(2023, 12, 9, 14, 18, 41, 299, DateTimeKind.Local).AddTicks(6816), false, "[\"Urin\",\"Krv\"]", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Rezultati",
                columns: new[] { "Id", "IdSupstance", "IdUzorka", "JeLiUGranicama", "Vrednost" },
                values: new object[,]
                {
                    { 1, 1, 1, true, 85.0 },
                    { 2, 2, 2, true, 90.0 },
                    { 3, 3, 3, false, 140.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezultati_IdSupstance",
                table: "Rezultati",
                column: "IdSupstance");

            migrationBuilder.CreateIndex(
                name: "IX_Rezultati_IdUzorka",
                table: "Rezultati",
                column: "IdUzorka");

            migrationBuilder.CreateIndex(
                name: "IX_Supstance_ZahtevId",
                table: "Supstance",
                column: "ZahtevId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzorci_IdTestiranja",
                table: "Uzorci",
                column: "IdTestiranja");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtev_PacijentId",
                table: "Zahtev",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtev_TestiranjeId",
                table: "Zahtev",
                column: "TestiranjeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezultati");

            migrationBuilder.DropTable(
                name: "Supstance");

            migrationBuilder.DropTable(
                name: "Uzorci");

            migrationBuilder.DropTable(
                name: "Zahtev");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Testiranja");
        }
    }
}
