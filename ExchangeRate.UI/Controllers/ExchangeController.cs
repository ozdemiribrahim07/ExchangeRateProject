using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.UI.Controllers
{
    public class ExchangeController : Controller
    {
        private readonly ExchangeService _exchangeService;

        public ExchangeController(ExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        public async Task<IActionResult> Index()
        {
            var kurlar = await _exchangeService.GetKurAsync();
            return View(kurlar);
        }
    }
}
