# Releasing

Notes for maintainers. This file is not included in the template package.

## Versioning

The package version follows the Orleans version the template targets (for example `10.4.2`). Update `PackageVersion` in `template-package.csproj`, or pass it on the command line.

## Pack

```
dotnet pack template-package.csproj -c Release -o artifacts /p:PackageVersion=10.4.2
```

Local state (`bin`, `obj`, `.vs`, `.aspire` and `*.user` files) is excluded from the package by `template-package.csproj`.

## Test locally

Install the package, create a project from it and build it:

```
dotnet new install artifacts/sparreio.Templates.OrleansStarterTemplate.10.4.2.nupkg
dotnet new orleansstartertemplate -n TemplateTest -o <some temp folder>/TemplateTest
dotnet build <some temp folder>/TemplateTest/TemplateTest.slnx
```

Optionally run it with `aspire run` from the generated folder. Then remove the local install:

```
dotnet new uninstall sparreio.Templates.OrleansStarterTemplate
```

## Publish

```
dotnet nuget push artifacts/sparreio.Templates.OrleansStarterTemplate.10.4.2.nupkg --source https://api.nuget.org/v3/index.json --api-key <key>
```
