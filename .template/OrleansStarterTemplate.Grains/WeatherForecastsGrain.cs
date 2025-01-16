using Microsoft.Extensions.Logging;
using Orleans.Timers;
using OrleansStarterTemplate.Grains.Interfaces;

namespace OrleansStarterTemplate.Grains;

public class WeatherForecastsGrain : IGrainBase, IWeatherForecastsGrain, IRemindable
{
    private readonly IReminderRegistry _reminderRegistry;
    private readonly ILogger<WeatherForecastsGrain> _logger;

    public WeatherForecastsGrain(IGrainContext grainContext, IReminderRegistry reminderRegistry, ILogger<WeatherForecastsGrain> logger)
    {
        GrainContext = grainContext;
        _reminderRegistry = reminderRegistry;
        _logger = logger;
    }

    public async Task<WeatherForecast[]> Get()
    {
        var grainReminder = await _reminderRegistry.GetReminder(GrainContext.GrainId, "test");

        if (grainReminder is null)
        {
            await _reminderRegistry.RegisterOrUpdateReminder(GrainContext.GrainId, "test", TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
        }

        // Simulate asynchronous loading to demonstrate a loading indicator
        await Task.Delay(500);

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast(startDate.AddDays(index), Random.Shared.Next(-20, 55), summaries[Random.Shared.Next(summaries.Length)])).ToArray();
    }

    public Task ReceiveReminder(string reminderName, TickStatus status)
    {
        _logger.LogInformation("Received reminder {ReminderName}", reminderName);
        return Task.CompletedTask;
    }

    public IGrainContext GrainContext { get; }
}