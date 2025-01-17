# Orleans Starter Template

A simple starter template with the projects needed to get started exploring Orleans, Aspire and Azure Container Apps

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

## Deploy using Aspire and Azure Container Apps

The `AppHost` is somewhat prepared to be published and deployed to container apps, adjust as needed

See docs: [Deploy a .NET Aspire project to Azure Container Apps using the Azure Developer CLI (in-depth guide)](https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment-azd-in-depth?tabs=windows)