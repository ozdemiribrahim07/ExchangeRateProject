using ExchangeRate.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {

        private readonly ExchangeService _exchangeService;
        public ExchangeRatesController(ExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var kurlar = await _exchangeService.GetExchangeRate();
            return Ok(kurlar);
        }


    }
}
