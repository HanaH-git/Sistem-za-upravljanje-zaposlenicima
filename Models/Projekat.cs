using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplikacija.Models
{
    public class Projekat
    {
        public int ProjekatId { get; set; }
        [Required]
        public string Naziv { get; set; } = string.Empty;
        [Column(TypeName = "decimal(14,2)")]
        public decimal? BudzetUSD { get; set; }
        public DateTime? DatumPocetak { get; set; }
        public DateTime? DatumKraj { get; set; }
        public ICollection<ZaposlenikProjekat> ZaposlenikProjekti { get; set; } = new List<ZaposlenikProjekat>();
    }
}
