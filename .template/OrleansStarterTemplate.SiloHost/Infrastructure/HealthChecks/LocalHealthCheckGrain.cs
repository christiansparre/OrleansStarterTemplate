using Orleans.Concurrency;

namespace OrleansStarterTemplate.SiloHost.Infrastructure.HealthChecks;

[StatelessWorker]
[CollectionAgeLimit(Minutes = 2)]
public class LocalHealthCheckGrain : Grain, ILocalHealthCheckGrain
{
    public Task Ping() => Task.CompletedTask;
}