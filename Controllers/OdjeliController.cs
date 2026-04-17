using Aplikacija.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MojaAplikacija.Controllers
{
    public class OdjeliController : Controller
    {
        private readonly AplikacijaDbContext _context;

        public OdjeliController(AplikacijaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var odjeli = _context.Odjeli
                .Include(o => o.Zaposlenici)
                .ToList();

            return View(odjeli);
        }
    }
}
