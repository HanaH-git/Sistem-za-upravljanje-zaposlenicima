using System.ComponentModel.DataAnnotations;

namespace Aplikacija.Models
{
    public class Odjel
    {
        public int OdjelId { get; set; }

        [Required]
        public string Naziv { get; set; }
        public string? Lokacija { get; set; }
        public ICollection<Zaposlenik> Zaposlenici { get; set; } = new List<Zaposlenik>();
    }
}
