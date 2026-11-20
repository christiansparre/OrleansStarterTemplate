# Orleans Starter Template

A simple starter template with the projects needed to get started exploring Orleans, Aspire and Azure Container Apps

## Requirements

- [.NET 11 SDK](https://dotnet.microsoft.com/download/dotnet/11.0)
- [Aspire CLI](https://aspire.dev) `17.0.0` or newer. Update an existing install with

  ```
  aspire update --self
  ```
- A container runtime for the Azurite storage emulator: Docker, Podman or WSL containers (`wslc`). Docker and Podman are preferred if installed. For WSL containers you need WSL `3.0.4` or newer:

  ```
  wsl --update
  ```

## Install

Install using

```
dotnet new install sparreio.Templates.OrleansStarterTemplate
```
It is available on [nuget.org](https://www.nuget.org/packages/sparreio.Templates.OrleansStarterTemplate)

## Use

```
dotnet new orleansstartertemplate -n MyOrleansProject
```

This creates a `MyOrleansProject.slnx` solution (the XML solution format, supported by Visual Studio, Rider and the .NET CLI). Run it with

```
aspire run
```

Shared build settings (target framework, nullable, warnings as errors) live in `Directory.Build.props`.

## Deploy using Aspire and Azure Container Apps

The `AppHost` is somewhat prepared to be published and deployed to container apps, adjust as needed

See docs: [Deploy a .NET Aspire project to Azure Container Apps using the Azure Developer CLI (in-depth guide)](https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment-azd-in-depth?tabs=windows)

# Releasing

_Note to self_

```
dotnet pack /p:PackageVersion=10.4.2 .\template-package.csproj
```

```
dotnet new install C:\******\github\christiansparre\OrleansStarterTemplate\bin\Release\sparreio.Templates.OrleansStarterTemplate.8.0.0.nupkg
```