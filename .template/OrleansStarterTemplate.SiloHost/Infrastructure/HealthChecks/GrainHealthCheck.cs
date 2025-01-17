using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace OrleansStarterTemplate.SiloHost.Infrastructure.HealthChecks;

public class GrainHealthCheck : IHealthCheck
{
    private readonly IClusterClient _client;

    public GrainHealthCheck(IClusterClient client)
    {
        _client = client;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            var localGrain = _client.GetGrain<ILocalHealthCheckGrain>(Guid.Empty);
            await localGrain.Ping();
        }
        catch (Exception exception)
        {
            return HealthCheckResult.Unhealthy("Unable to ping local health check grain", exception);
        }

        return HealthCheckResult.Healthy();
    }
}