namespace OrleansStarterTemplate.Grains.Interfaces
{
    public interface IWeatherForecastsGrain : IGrainWithStringKey
    {
        Task<WeatherForecast[]> Get();
    }
}
