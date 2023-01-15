using RestEase;

namespace CheckingRestEase.Client.Clients.Interfaces
{
    public interface IWeatherApi
    {
        [Get("WeatherForecast")]
        public Task<List<WeatherForecast>> GetForecasts();
    }
}
