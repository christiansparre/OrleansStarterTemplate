using OrleansStarterTemplate.SiloHost.Infrastructure.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddKeyedAzureTableServiceClient("default");

builder.UseOrleans(siloBuilder =>
{
    // Propagate trace context through grain calls so they show up as spans in the Aspire dashboard
    siloBuilder.AddActivityPropagation();

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