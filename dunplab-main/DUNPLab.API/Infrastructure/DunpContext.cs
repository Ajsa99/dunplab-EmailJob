using DUNPLab.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DUNPLab.API.Infrastructure
{
    public class DunpContext : DbContext
    {
        public DunpContext(DbContextOptions<DunpContext> options) : base(options)
        {
        }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<Uzorak> Uzorci { get; set; }
        public DbSet<Testiranje> Testiranja { get; set; }
        public DbSet<Supstanca> Supstance { get; set; }
        public DbSet<Rezultat> Rezultati { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }
        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacijent>().HasData(
               new Pacijent
               {
                   Id = 1,
                   Ime = "Ajsa",
                   Prezime = "Alibasic",
                   Email = "ajsa.alibasic11@gmail.com",
                   DatumRodjenja = new DateTime(1999, 1, 22),
                   Adresa = "Adresa 1",
                   Grad = "Grad 1",
                   Telefon = "123456789",
                   Pol = "Zenski",
                   JMBG = "1234567890123",
                   BrojDokumenta = "ABC123",
                   DatumIstekaDokumenta = new DateTime(2025, 1, 1)
               },
                new Pacijent
                {
                    Id = 2,
                    Ime = "Kristina",
                    Prezime = "Milentijevic",
                    Email = "softversko.i23m@gmail.com",
                    DatumRodjenja = new DateTime(1999, 10, 7),
                    Adresa = "Adresa 2",
                    Grad = "Grad 2",
                    Telefon = "987654321",
                    Pol = "Zenski",
                    JMBG = "9876543210123",
                    BrojDokumenta = "XYZ789",
                    DatumIstekaDokumenta = new DateTime(2024, 12, 31)
                }
            );

            modelBuilder.Entity<Supstanca>().HasData(
                new Supstanca
                {
                    Id = 1,
                    Naziv = "Hemoglobin",
                    Oznaka = "Hb",
                    Opis = "Krv",
                    Tip = "Biološka",
                    DonjaGranica = 12,
                    GornjaGranica = 17.5,
                    MetodTestiranja = "Laboratorijski",
                    Cena = 150
                },
                new Supstanca
                {
                    Id = 2,
                    Naziv = "Glukoza",
                    Oznaka = "Glu",
                    Opis = "šećer",
                    Tip = "Biološka",
                    DonjaGranica = 70,
                    GornjaGranica = 100,
                    MetodTestiranja = "Laboratorijski",
                    Cena = 120
                },
                 new Supstanca
                 {
                     Id = 3,
                     Naziv = "Holesterol",
                     Oznaka = "Hch",
                     Opis = "holesterol",
                     Tip = "Biološka",
                     DonjaGranica = 70,
                     GornjaGranica = 200,
                     MetodTestiranja = "Laboratorijski",
                     Cena = 180
                 }
            );

            modelBuilder.Entity<Zahtev>().HasData(
            new Zahtev
            {
                Id = 1,
                DatumTestiranja = DateTime.Now,
                Metode = new HashSet<string> { "Krv" },
                TestiranjeId = 1,
                PacijentId = 1,
                JeLiObradjen = true,
            },
             new Zahtev
             {
                 Id = 2,
                 DatumTestiranja = DateTime.Now,
                 Metode = new HashSet<string> { "Urin", "Krv" },
                 TestiranjeId = 2,
                 PacijentId = 2,
                 JeLiObradjen = false,
             }
        );

            modelBuilder.Entity<Testiranje>().HasData(
                new Testiranje
                {
                    Id = 1,
                    Naziv = "Opšti test",
                    UkupnaCena = 450,
                    NacinPlacanja = "Kartica",
                    TestOdradio = "Ajsa",
                    JesuLiPotvrdjeniSviUzorci = true,
                    DatumVremeTestiranja = DateTime.Now,
                    DatumVremeRezultata = DateTime.Now,
                    Status = "Zavrseno",
                    BrojSobe = "101",
                    Izmenio = "Admin",
                    IzmenioDatumVreme = DateTime.Now
                },
                new Testiranje
                {
                    Id = 2,
                    Naziv = "Krvni pritisak",
                    UkupnaCena = 250,
                    NacinPlacanja = "Gotovinsko",
                    TestOdradio = "Kristina",
                    JesuLiPotvrdjeniSviUzorci = false,
                    DatumVremeTestiranja = DateTime.Now,
                    DatumVremeRezultata = DateTime.Now,
                    Status = "U toku",
                    BrojSobe = "210",
                    Izmenio = "Admin",
                    IzmenioDatumVreme = DateTime.Now
                }
            );

            modelBuilder.Entity<Uzorak>().HasData(
                new Uzorak
                {
                    Id = 1,
                    Naziv = "Krv",
                    KodEpruvete = "KRV-001",
                    MetodTestiranja = "Krvni pritisak",
                    KonacanRezultat = "Negativan",
                    Komentar = "Nema komentara",
                    Cena = 100.00,
                    Kutija = "BX20",
                    IdTestiranja = 1,
                    Izmenio = "Ajsa",
                    IzmenioDatumVreme = DateTime.Now
                },
                new Uzorak
                {
                    Id = 2,
                    Naziv = "Opšti uzorak",
                    KodEpruvete = "UZ-001",
                    MetodTestiranja = "Opšti test",
                    KonacanRezultat = "Negativan",
                    Komentar = "Negativan rezultat",
                    Cena = 150.00,
                    Kutija = "BX21",
                    IdTestiranja = 2,
                    Izmenio = "Kristina",
                    IzmenioDatumVreme = DateTime.Now
                },
                new Uzorak
                {
                    Id = 3,
                    Naziv = "Krv",
                    KodEpruvete = "KRV-002",
                    MetodTestiranja = "Krvni pritisak",
                    KonacanRezultat = "Pozitivan",
                    Komentar = "Pozitivan rezultat",
                    Cena = 100.00,
                    Kutija = "BX22",
                    IdTestiranja = 2,
                    Izmenio = "Kristina",
                    IzmenioDatumVreme = DateTime.Now
                }
            );


            modelBuilder.Entity<Rezultat>().HasData(
                new Rezultat
                {
                    Id = 1,
                    JeLiUGranicama = true,
                    Vrednost = 85,
                    IdUzorka = 1,
                    IdSupstance = 1
                },
                new Rezultat
                {
                    Id = 2,
                    JeLiUGranicama = true,
                    Vrednost = 90,
                    IdUzorka = 2,
                    IdSupstance = 2
                },
                new Rezultat
                {
                    Id = 3,
                    JeLiUGranicama = false,
                    Vrednost = 140,
                    IdUzorka = 3,
                    IdSupstance = 3
                }
           );
        }

    }
}
