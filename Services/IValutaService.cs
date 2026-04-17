namespace Aplikacija.Services
{
    public interface IValutaService
    {
        Task<decimal?> KonvertujIzBamAsync(decimal iznosUBam, string valuta);
    }
}
