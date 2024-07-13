using System.Xml.Serialization;

namespace ExchangeRate.API.Models
{
    public class Currency
    {
        [XmlAttribute("Kod")]
        public string Code { get; set; }

        [XmlElement("Unit")]
        public string Currencyy { get; set; }

        [XmlElement("Isim")]
        public string CurrencyName { get; set; }

        [XmlElement("ForexBuying")]
        public string ForexBuyingString { get; set; }

        [XmlElement("ForexSelling")]
        public string ForexSellingString { get; set; }


        [XmlIgnore]
        public decimal ForexBuying => ParseDecimal(ForexBuyingString);

        [XmlIgnore]
        public decimal ForexSelling => ParseDecimal(ForexSellingString);


        private decimal ParseDecimal(string value)
        {
            if (decimal.TryParse(value, out var result))
            {
                return result;
            }
            return 0; // veya uygun bir varsayılan değer
        }
    }
}
