using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using OrleansStarterTemplate.Grains.Interfaces;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureServices(services =>
{
    services.AddOrleansClient(client =>
    {
        client.UseLocalhostClustering();
        client.Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "Local";
            options.ServiceId = "OrleansStarterTemplate";
        });
    });
});

var host = builder.Build();

var _ = host.RunAsync();

var clusterClient = host.Services.GetRequiredService<IClusterClient>();

string? name;

await Task.Delay(1000);

do
{

    Console.WriteLine("Enter your name and get a message");

    name = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(name))
    {
        var message = await clusterClient.GetGrain<IHelloWorldGrain>(IHelloWorldGrain.Key).Hello(name);

        Console.WriteLine(message);
    }

} while (name != "quit");

Console.WriteLine("Bye!");

await host.StopAsync(TimeSpan.FromSeconds(2000));
