

namespace Aplikacija.Models
{
    public class ZaposlenikProjekat
    {
        public int ZaposlenikId {  get; set; }
        public Zaposlenik? Zaposlenik { get; set; }
        public int ProjekatId { get; set; }
        public Projekat? Projekat { get; set; }

        public string? Uloga { get; set; }
        public int SatiNaTjednu { get; set; }
    }
}
