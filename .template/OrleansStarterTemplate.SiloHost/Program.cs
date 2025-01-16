using OrleansStarterTemplate.SiloHost.Infrastructure.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddKeyedAzureTableClient("default");

builder.UseOrleans(siloBuilder =>
{
    if (builder.Environment.IsDevelopment())
    {
        siloBuilder.UseLocalhostClustering();
    }
});

builder.Services.AddHealthChecks()
    .AddCheck<GrainHealthCheck>("GrainHealth", tags: ["live"]);

var host = builder.Build();

host.MapDefaultEndpoints();

await host.RunAsync();