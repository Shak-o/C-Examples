using CheckingRestEase.Client.Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RestEase;

namespace CheckingRestEase.Client.Controllers
{
    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("/Weather")]
        public async Task<List<WeatherForecast>> Get()
        {
            var api = RestClient.For<IWeatherApi>("https://localhost:7173");
            var data = await api.GetForecasts();
            return data;
        }
    }
}