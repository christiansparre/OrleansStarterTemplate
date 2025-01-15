using OrleansStarterTemplate.Grains.Interfaces;

namespace OrleansStarterTemplate.Grains;

public class WeatherForecastsGrain : IWeatherForecastsGrain
{
    public async Task<WeatherForecast[]> Get()
    {
        // Simulate asynchronous loading to demonstrate a loading indicator
        await Task.Delay(500);

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast(startDate.AddDays(index), Random.Shared.Next(-20, 55), summaries[Random.Shared.Next(summaries.Length)])).ToArray();
    }
}