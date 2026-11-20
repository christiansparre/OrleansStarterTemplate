# Orleans Starter Template

A `dotnet new` template with the projects you need to start exploring [Microsoft Orleans](https://learn.microsoft.com/dotnet/orleans/), [Aspire](https://aspire.dev) and Azure Container Apps.

## Requirements

- [.NET 11 SDK](https://dotnet.microsoft.com/download/dotnet/11.0)
- [Aspire CLI](https://aspire.dev) `17.0.0` or newer. Update an existing install with

  ```
  aspire update --self
  ```
- A container runtime for the Azurite storage emulator: Docker, Podman or WSL containers (`wslc`). Docker and Podman are used if installed. WSL containers need WSL `3.0.4` or newer:

  ```
  wsl --update
  ```

## Install

```
dotnet new install sparreio.Templates.OrleansStarterTemplate
```

The template is available on [nuget.org](https://www.nuget.org/packages/sparreio.Templates.OrleansStarterTemplate). Run the same command again to update to the latest version.

## Create a project

```
dotnet new orleansstartertemplate -n MyOrleansProject
cd MyOrleansProject
aspire run
```

`aspire run` starts the AppHost and opens the Aspire dashboard, where you can find the web client, the silo and their logs, traces and metrics.

## What's included

| Project | Description |
| --- | --- |
| `MyOrleansProject.AppHost` | Aspire AppHost. Wires up Azure Table Storage (Azurite locally), the Orleans cluster, the silo and the web client |
| `MyOrleansProject.SiloHost` | Orleans silo with grain storage and reminders in Azure Table Storage, and a grain health check |
| `MyOrleansProject.WebClient` | Blazor Server app with an Orleans client. The Weather page calls a grain |
| `MyOrleansProject.Grains` | Sample grains: `HelloWorldGrain` and `WeatherForecastsGrain` (which also registers a reminder) |
| `MyOrleansProject.Grains.Interfaces` | Grain interfaces and serializable types shared by the silo and the client |
| `MyOrleansProject.ServiceDefaults` | Shared Aspire service defaults: OpenTelemetry, health checks, service discovery and HTTP resilience |

Also included:

- A `MyOrleansProject.slnx` solution (the XML solution format, supported by Visual Studio, Rider and the .NET CLI)
- `Directory.Build.props` with shared build settings: target framework, implicit usings, nullable and warnings as errors
- Orleans metrics and distributed traces (including grain calls) exported to the Aspire dashboard through OpenTelemetry

### Local development

When running locally, the silo and client use localhost clustering, and the Azurite emulator runs as a persistent container named `azurite`, so stored grain state and reminders survive restarts. Remove the container to start from a clean state.

## Deploy to Azure Container Apps

The AppHost is prepared to be published and deployed to Azure Container Apps. In publish mode the cluster uses Azure Table Storage for clustering, and the silo's container app can be tuned (CPU, memory and scaling) in `AppHost/Program.cs`. Adjust as needed.

See [Deploy an Aspire project to Azure Container Apps using the Azure Developer CLI](https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment-azd-in-depth?tabs=windows).

## Uninstall

```
dotnet new uninstall sparreio.Templates.OrleansStarterTemplate
```

## License

[MIT](https://github.com/christiansparre/OrleansStarterTemplate/blob/main/LICENSE)
