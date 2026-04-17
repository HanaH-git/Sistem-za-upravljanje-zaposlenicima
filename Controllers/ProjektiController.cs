using Aplikacija.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MojaAplikacija.Controllers
{
    public class ProjektiController : Controller
    {
        private readonly AplikacijaDbContext _context;

        public ProjektiController(AplikacijaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projekti = _context.Projekti
                .Include(p => p.ZaposlenikProjekti)
                .ToList();

            return View(projekti);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projekat = _context.Projekti
                .Include(p => p.ZaposlenikProjekti)
                    .ThenInclude(zp => zp.Zaposlenik)
                .FirstOrDefault(p => p.ProjekatId == id);

            if (projekat == null)
            {
                return NotFound();
            }

            return View(projekat);
        }
    }
}
