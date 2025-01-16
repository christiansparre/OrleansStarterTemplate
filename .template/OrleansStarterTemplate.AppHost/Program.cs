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
    .WithHttpHealthCheck("/alive")
    .PublishAsAzureContainerApp((infrastructure, app) =>
    {
        var container = app.Template.Containers[0];
        
        ArgumentNullException.ThrowIfNull(container.Value);

        // Change CPU memory allocations
        //container.Value.Resources.Cpu = 2;
        //container.Value.Resources.Memory = "4Gi";

        // Change scale settings
        //app.Template.Scale.MinReplicas = 2;
        //app.Template.Scale.MaxReplicas = 2;
    });

builder.AddProject<Projects.OrleansStarterTemplate_WebClient>("webclient")
    .WithReference(orleans.AsClient())
    .WithExternalHttpEndpoints()
    .WaitFor(silhost);

builder.Build().Run();
