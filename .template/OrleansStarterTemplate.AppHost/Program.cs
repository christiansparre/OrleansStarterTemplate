var builder = DistributedApplication.CreateBuilder(args);

var storage = builder
    .AddAzureStorage("storage");

var tableStorage = storage.AddTables("default");

var orleans = builder
    .AddOrleans("starter-template")
    .WithGrainStorage("Default", tableStorage)
    .WithReminders(tableStorage);

if (builder.ExecutionContext.IsPublishMode)
{
    orleans = orleans
         .WithClustering(tableStorage);
}
else
{
    orleans = orleans
         .WithDevelopmentClustering();

    storage
         .RunAsEmulator(resourceBuilder => resourceBuilder.WithContainerName("azurite").WithLifetime(ContainerLifetime.Persistent));
}

var silhost = builder.AddProject<Projects.OrleansStarterTemplate_SiloHost>("silohost")
    .WithReference(orleans)
    .WithHttpHealthCheck("/alive");

builder.AddProject<Projects.OrleansStarterTemplate_WebClient>("webclient")
    .WithReference(orleans.AsClient())
    .WaitFor(silhost);

builder.Build().Run();
