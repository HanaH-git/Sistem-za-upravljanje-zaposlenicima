using System.Text.Json;

namespace Aplikacija.Services
{
    public class ValutaService : IValutaService
    {
        private readonly HttpClient _httpClient;

        public ValutaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal?> KonvertujIzBamAsync(decimal iznosUBam, string valuta)
        {
            var response = await _httpClient.GetAsync("https://open.er-api.com/v6/latest/BAM");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(json);

            if (!document.RootElement.TryGetProperty("rates", out var rates))
            {
                return null;
            }

            if (!rates.TryGetProperty(valuta, out var kursElement))
            {
                return null;
            }

            var kurs = kursElement.GetDecimal();

            return iznosUBam * kurs;
        }
    }
}