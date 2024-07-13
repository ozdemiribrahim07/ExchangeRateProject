namespace ExchangeRate.UI.Services
{
    public class ExchangeService
    {
        private readonly HttpClient _httpClient;

        public ExchangeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExchangeResponse> GetKurAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5000/kur");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Kurları çekmede hata oluştu");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var kurResponse = JsonConvert.DeserializeObject<KurResponse>(jsonString);

            return kurResponse;
        }





    }
}
