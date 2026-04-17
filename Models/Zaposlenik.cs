using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplikacija.Models
{
    public class Zaposlenik
    {
        public int ZaposlenikId { get; set; }
        [Required]
        public string Ime { get; set; } = string.Empty;
        [Required]
        public string Prezime { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal PlataMonthly { get; set; }
        public DateTime DatumZaposlenja { get; set; }

        public int OdjelId { get; set; }
        public Odjel? Odjel { get; set; }

        public ICollection<ZaposlenikProjekat> ZaposlenikProjekti { get; set; } = new List<ZaposlenikProjekat>();
    }
}
