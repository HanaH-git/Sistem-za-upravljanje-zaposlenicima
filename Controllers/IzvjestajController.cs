using Aplikacija.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace MojaAplikacija.Controllers
{
    public class IzvjestajController : Controller
    {
        private readonly AplikacijaDbContext _context;

        public IzvjestajController(AplikacijaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Download()
        {
            var odjeli = _context.Odjeli
                .Include(o => o.Zaposlenici)
                .ToList();

            var sb = new StringBuilder();

            foreach (var odjel in odjeli)
            {
                sb.AppendLine($"Odjel: {odjel.Naziv}");
                sb.AppendLine("Ime,Prezime,Email,Plata,DatumZaposlenja");

                foreach (var z in odjel.Zaposlenici)
                {
                    sb.AppendLine($"{z.Ime},{z.Prezime},{z.Email},{z.PlataMonthly},{z.DatumZaposlenja:yyyy-MM-dd}");
                }

                sb.AppendLine($"Ukupan broj zaposlenika:,{odjel.Zaposlenici.Count()}");

                var prosjek = odjel.Zaposlenici.Any()
                    ? odjel.Zaposlenici.Average(z => z.PlataMonthly)
                    : 0;

                sb.AppendLine($"Prosječna plata:,{prosjek:0.00}");
                sb.AppendLine();
            }

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());

            return File(bytes, "text/csv", "izvjestaj.csv");
        }
    }
}