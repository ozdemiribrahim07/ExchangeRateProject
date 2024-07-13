using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ExchangeService
{
    private readonly HttpClient _httpClient;

    public ExchangeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<KurResponse> GetKurAsync()
    {
        var response = await _httpClient.GetAsync("https://localhost:7076/ExchangeRates");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Kurları çekmede hata oluştu");
        }

        var jsonString = await response.Content.ReadAsStringAsync();
        var kurResponse = JsonConvert.DeserializeObject<KurResponse>(jsonString);

        return kurResponse;
    }
}

public class KurResponse
{
    public List<Currency> Currencies { get; set; }
}

public class Currency
{
    public string Code { get; set; }
    public string CurrencyName { get; set; }
    public decimal ForexBuying { get; set; }
    public decimal ForexSelling { get; set; }
}
