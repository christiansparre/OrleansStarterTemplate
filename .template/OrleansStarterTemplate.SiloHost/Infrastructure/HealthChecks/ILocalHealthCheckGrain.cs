namespace OrleansStarterTemplate.SiloHost.Infrastructure.HealthChecks;

public interface ILocalHealthCheckGrain : IGrainWithGuidKey
{
    Task Ping();
}