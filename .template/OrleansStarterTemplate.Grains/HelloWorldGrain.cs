using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Runtime;
using OrleansStarterTemplate.Grains.Interfaces;

namespace OrleansStarterTemplate.Grains;

public class HelloWorldGrain : IHelloWorldGrain, IGrainBase
{
    private readonly ILogger<HelloWorldGrain> _logger;

    public HelloWorldGrain(IGrainContext grainContext, ILogger<HelloWorldGrain> logger)
    {
        _logger = logger;
        GrainContext = grainContext;
    }

    public Task<HelloMessage> Hello(string name)
    {
        _logger.LogInformation("Received hello call from {Name}", name);

        return Task.FromResult(new HelloMessage($"Hello {name}, {this.GetPrimaryKeyString()} says hi! 👋", DateTimeOffset.UtcNow));
    }

    public Task OnActivateAsync(CancellationToken token)
    {
        _logger.LogInformation("Hello grain {GrainId} was activated", GrainContext.GrainId);
        return Task.CompletedTask;
    }

    public IGrainContext GrainContext { get; }
}