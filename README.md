
# Sitemapfy.Net

## Overview

Sitemapfy.Net is a powerful .NET 8 library that facilitates the creation, serialization, and serving of XML sitemaps in ASP.NET Core minimal API applications. This package leverages the capabilities of Functional.DotNet to provide a functional programming approach for handling sitemap generation and serialization.

## Features

- **Easily convert sitemap objects to XML:** Convert your sitemap objects to XML strings or streams with simple extension methods.
- **Integrate sitemap generation services:** Add sitemap generation services to your ASP.NET Core application's dependency injection container.
- **Serve sitemaps through customizable endpoints:** Use endpoint routing to serve your sitemaps with ease.
- **Functional programming paradigms:** Utilize functional programming paradigms for error handling and result mapping.

## Installation

Install the package via NuGet Package Manager:

```sh
dotnet add package Sitemapfy.Net
```

Or use the NuGet Package Manager Console:

```sh
Install-Package Sitemapfy.Net
```

## Usage

### Setup

1. **Define your sitemap service:**

```csharp
public class MySitemapService : ISiteMapService
{
    public Task<Sitemap> GenerateLocationsAsync()
    {
        // Implement your sitemap generation logic here
        return Task.FromResult(new Sitemap { /* sitemap data */ });
    }
}
```

2. **Configure services in your `Program.cs`:**

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSitemap<MySitemapService>();

var app = builder.Build();

app.MapSitemap();

app.Run();
```


You can access your file at https://youradress/sitemap.xml
