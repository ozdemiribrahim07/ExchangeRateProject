using System.Xml.Serialization;

namespace ExchangeRate.API.Models
{
    [XmlRoot("Tarih_Date")]
    public class ExchangeResponse
    {
        [XmlElement("Currency")]
        public List<Currency> Currencies { get; set; }
    }
}
