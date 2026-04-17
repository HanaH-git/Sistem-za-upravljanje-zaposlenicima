using Aplikacija.Models;
using Aplikacija.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aplikacija.Services;

namespace MojaAplikacija.Controllers
{
    public class ZaposleniciController : Controller
    {
        private readonly AplikacijaDbContext _context;
        private readonly IValutaService _valutaService;
        public ZaposleniciController(AplikacijaDbContext context, IValutaService valutaService)
        {
            _context = context;
            _valutaService = valutaService;
        }

        public IActionResult Index(int? odjelId)
        {
            ViewBag.Odjeli = _context.Odjeli.ToList();
            ViewBag.OdabraniOdjel = odjelId;

            var zaposlenici = _context.Zaposlenici
                .Include(z => z.Odjel)
                .AsQueryable();

            if (odjelId.HasValue)
            {
                zaposlenici = zaposlenici.Where(z => z.OdjelId == odjelId.Value);
            }

            return View(zaposlenici.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Odjeli = _context.Odjeli.ToList();
            return View(new Zaposlenik());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Zaposlenik zaposlenik)
        {
            if (ModelState.IsValid)
            {
                _context.Zaposlenici.Add(zaposlenik);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Odjeli = _context.Odjeli.ToList();
            return View(zaposlenik);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaposlenik = _context.Zaposlenici.Find(id);

            if (zaposlenik == null)
            {
                return NotFound();
            }

            ViewBag.Odjeli = _context.Odjeli.ToList();
            return View(zaposlenik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Zaposlenik zaposlenik)
        {
            if (id != zaposlenik.ZaposlenikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Zaposlenici.Update(zaposlenik);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Odjeli = _context.Odjeli.ToList();
            return View(zaposlenik);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaposlenik = _context.Zaposlenici
                .Include(z => z.Odjel)
                .FirstOrDefault(z => z.ZaposlenikId == id);

            if (zaposlenik == null)
            {
                return NotFound();
            }

            return View(zaposlenik);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var zaposlenik = _context.Zaposlenici.Find(id);

            if (zaposlenik != null)
            {
                _context.Zaposlenici.Remove(zaposlenik);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id, string? valuta)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaposlenik = _context.Zaposlenici
                .Include(z => z.Odjel)
                .FirstOrDefault(z => z.ZaposlenikId == id);

            if (zaposlenik == null)
            {
                return NotFound();
            }

            ViewBag.KonvertovanaPlata = null;
            ViewBag.OdabranaValuta = valuta;

            if (!string.IsNullOrEmpty(valuta))
            {
                ViewBag.KonvertovanaPlata = await _valutaService.KonvertujIzBamAsync(zaposlenik.PlataMonthly, valuta);
            }

            return View(zaposlenik);
        }
    }
}