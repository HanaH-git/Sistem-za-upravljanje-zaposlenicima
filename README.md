
# Sistem za upravljanje zaposlenicima

ASP.NET Core MVC aplikacija za upravljanje zaposlenicima, odjelima, projektima i izvještajima.

---

## Tehnologije
- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Razor Views

---

## Funkcionalnosti
- CRUD za zaposlenike
- Filter zaposlenika po odjelu
- Pregled odjela sa brojem zaposlenika i prosječnom platom
- Pregled projekata i angažovanih zaposlenika
- Konverzija plate u valute (EUR, USD, GBP, CHF) putem vanjskog API-ja
- Download CSV izvještaja o zaposlenicima po odjelima

---

## Podešavanje connection stringa

U fajlu `appsettings.json` postaviti:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=AplikacijaBaza;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## Pokretanje migracija
Pokrenuti komandom:
```bash 
dotnet ef database update
```

## Pokretanje aplikacije
Pokretanje komandom:
```bash
dotnet run
```

## Seed podaci
Aplikacija sadrži testne podatke za:
- odjele
- zaposlenike
- projekte
- angažmane zaposlenika na projektima


## Šta je urađeno
- Baza i relacije
- CRUD zaposlenika
- Filter po odjelu
- Odjeli pregled
- Projekti pregled i detalji
- API konverzija plate
- CSV izvještaj

## Šta nije urađeno
- Excel export preko ClosedXML
- Dodatno stilizovanje UI-a
- Unit testovi
- Deployment