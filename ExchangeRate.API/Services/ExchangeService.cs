using ExchangeRate.API.Models;
using System.Xml.Serialization;

namespace ExchangeRate.API.Services
{
    public class ExchangeService
    {

        private readonly HttpClient _httpClient;

        public ExchangeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ExchangeResponse> GetExchangeRate()
        {
            var response = await _httpClient.GetAsync("https://www.tcmb.gov.tr/kurlar/today.xml");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Kurları çekmede hata oluştu");
            }

            var xmlString = await response.Content.ReadAsStringAsync();

            var exchangeResponse = DeserializeXmlToKurResponse(xmlString);
            return exchangeResponse;

        }


        private ExchangeResponse DeserializeXmlToKurResponse(string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExchangeResponse));

            using (StringReader reader = new StringReader(xmlString))
            {
                return (ExchangeResponse)serializer.Deserialize(reader);
            }
        }
    }
}
