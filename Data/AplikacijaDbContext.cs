using Aplikacija.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace Aplikacija.Data
{
    public class AplikacijaDbContext : DbContext
    {
        public AplikacijaDbContext(DbContextOptions<AplikacijaDbContext> options) : base(options)
        {
        }

        public DbSet<Odjel> Odjeli { get; set; }
        public DbSet<Zaposlenik> Zaposlenici { get; set; }
        public DbSet<Projekat> Projekti { get; set; }
        public DbSet<ZaposlenikProjekat> ZaposlenikProjekti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Zaposlenik>()
                .HasIndex(z => z.Email)
                .IsUnique();

            modelBuilder.Entity<ZaposlenikProjekat>()
                .HasKey(zp => new { zp.ZaposlenikId, zp.ProjekatId });

            modelBuilder.Entity<Odjel>().HasData(
                new Odjel { OdjelId = 1, Naziv = "HR", Lokacija = "Sarajevo" },
                new Odjel { OdjelId = 2, Naziv = "Finansije", Lokacija = "Mostar" },
                new Odjel { OdjelId = 3, Naziv = "IT", Lokacija = "Zenica" }
                );

            modelBuilder.Entity<Zaposlenik>().HasData(
                new Zaposlenik { ZaposlenikId = 1, Ime = "Lana", Prezime = "Hodžić", Email="lana@log.com", PlataMonthly = 1500, DatumZaposlenja = new DateTime(2022, 1, 10), OdjelId = 1 },
                new Zaposlenik { ZaposlenikId = 2, Ime = "Amar", Prezime = "Mešić", Email = "amar@log.com", PlataMonthly = 2000, DatumZaposlenja = new DateTime(2020, 3, 20), OdjelId = 2 },
                new Zaposlenik { ZaposlenikId = 3, Ime = "Lejla", Prezime = "Kovač", Email = "lejla@log.com", PlataMonthly = 1800, DatumZaposlenja = new DateTime(2021, 5, 15), OdjelId = 2 },
                new Zaposlenik { ZaposlenikId = 4, Ime = "Emina", Prezime = "Softić", Email = "emina@log.com", PlataMonthly = 1700, DatumZaposlenja = new DateTime(2023, 2, 12), OdjelId = 2 },
                new Zaposlenik { ZaposlenikId = 5, Ime = "Kenan", Prezime = "Alić", Email = "kenan@log.com", PlataMonthly = 1600, DatumZaposlenja = new DateTime(2022, 7, 1), OdjelId = 1 },
                new Zaposlenik { ZaposlenikId = 6, Ime = "Sara", Prezime = "Begović", Email = "sara@log.com", PlataMonthly = 1900, DatumZaposlenja = new DateTime(2021, 11, 5), OdjelId = 3 },
                new Zaposlenik { ZaposlenikId = 7, Ime = "Nermin", Prezime = "Hasić", Email = "nermin@log.com", PlataMonthly = 2100, DatumZaposlenja = new DateTime(2020, 6, 18), OdjelId = 1 },
                new Zaposlenik { ZaposlenikId = 8, Ime = "Amina", Prezime = "Zornić", Email = "amina@log.com", PlataMonthly = 1750, DatumZaposlenja = new DateTime(2022, 9, 9), OdjelId = 2 },
                new Zaposlenik { ZaposlenikId = 9, Ime = "Haris", Prezime = "Delić", Email = "haris@log.com", PlataMonthly = 2200, DatumZaposlenja = new DateTime(2019, 4, 25), OdjelId = 3 },
                new Zaposlenik { ZaposlenikId = 10, Ime = "Zara", Prezime = "Osmanović", Email = "zara@log.com", PlataMonthly = 1850, DatumZaposlenja = new DateTime(2023, 1, 30), OdjelId = 2 }
                );

            modelBuilder.Entity<Projekat>().HasData(
                new Projekat { ProjekatId = 1, Naziv = "Web App", BudzetUSD = 50000, DatumPocetak = new DateTime(2025, 1, 10), DatumKraj = new DateTime(2025, 6, 10) },
                new Projekat { ProjekatId = 2, Naziv = "Mobile App", BudzetUSD = 30000, DatumPocetak = new DateTime(2025, 2, 1), DatumKraj = new DateTime(2025, 8, 1) },
                new Projekat { ProjekatId = 3, Naziv = "ERP Sistem", BudzetUSD = 70000, DatumPocetak = new DateTime(2025, 3, 15), DatumKraj = new DateTime(2025, 12, 15) },
                new Projekat { ProjekatId = 4, Naziv = "HR Portal", BudzetUSD = 25000, DatumPocetak = new DateTime(2025, 4, 1), DatumKraj = new DateTime(2025, 9, 1) }
                );

            modelBuilder.Entity<ZaposlenikProjekat>().HasData(
                new ZaposlenikProjekat { ZaposlenikId = 1, ProjekatId = 1, Uloga = "Backend Developer", SatiNaTjednu = 40 },
                new ZaposlenikProjekat { ZaposlenikId = 2, ProjekatId = 1, Uloga = "HR Support", SatiNaTjednu = 10 },
                new ZaposlenikProjekat { ZaposlenikId = 3, ProjekatId = 2, Uloga = "Frontend Developer", SatiNaTjednu = 35 },
                new ZaposlenikProjekat { ZaposlenikId = 4, ProjekatId = 2, Uloga = "QA Engineer", SatiNaTjednu = 20 },
                new ZaposlenikProjekat { ZaposlenikId = 5, ProjekatId = 3, Uloga = "DevOps Engineer", SatiNaTjednu = 30 },
                new ZaposlenikProjekat { ZaposlenikId = 6, ProjekatId = 3, Uloga = "Business Analyst", SatiNaTjednu = 15 },
                new ZaposlenikProjekat { ZaposlenikId = 7, ProjekatId = 4, Uloga = "Project Manager", SatiNaTjednu = 25 },
                new ZaposlenikProjekat { ZaposlenikId = 8, ProjekatId = 4, Uloga = "UI/UX Designer", SatiNaTjednu = 20 },
                new ZaposlenikProjekat { ZaposlenikId = 9, ProjekatId = 1, Uloga = "Finance Consultant", SatiNaTjednu = 12 }
                );
        }
    }
}
