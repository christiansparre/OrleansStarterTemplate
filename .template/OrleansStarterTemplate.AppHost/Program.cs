var builder = DistributedApplication.CreateBuilder(args);

var storage = builder
    .AddAzureStorage("storage")
    .RunAsEmulator(resourceBuilder => resourceBuilder.WithContainerName("azurite").WithLifetime(ContainerLifetime.Persistent));

var clusteringTable = storage.AddTables("clustering");

var orleans = builder
    .AddOrleans("starter-template")
    .WithClusterId(Guid.NewGuid().ToString())
    .WithClustering(clusteringTable);

var silhost = builder.AddProject<Projects.OrleansStarterTemplate_SiloHost>("silohost")
    .WithReference(orleans)
    .WithHttpHealthCheck("/alive");

builder.AddProject<Projects.OrleansStarterTemplate_WebClient>("webclient")
    .WithReference(orleans.AsClient())
    .WaitFor(silhost);

builder.Build().Run();
