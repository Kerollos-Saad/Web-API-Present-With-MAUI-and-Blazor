# Web API Present with MAUI and Blazor

> **Creating Demo .NET Core API and Presentation layer with .NET MAUI and Blazor**

A comprehensive full-stack cross-platform solution demonstrating modern .NET architecture with an ASP.NET Core Web API backend that serves multiple client applications through a shared API client library. This project showcases how to build applications that run seamlessly across web browsers (via Blazor) and native platforms (via MAUI) while maintaining clean separation of concerns.

[![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=flat&logo=blazor&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![MAUI](https://img.shields.io/badge/MAUI-512BD4?style=flat&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/apps/maui)

## 📋 Table of Contents

- [Overview](#-overview)
- [Architecture](#-architecture)
- [Project Structure](#-project-structure)
- [Features](#-features)
- [Technology Stack](#-technology-stack)
- [Prerequisites](#-prerequisites)
- [Getting Started](#-getting-started)
- [Running the Applications](#-running-the-applications)
- [Configuration](#-configuration)
- [Key Concepts](#-key-concepts)
- [Contributing](#-contributing)
- [License](#-license)

## 🎯 Overview

This solution demonstrates a production-ready approach to building cross-platform applications using .NET's latest technologies. It consists of four main projects:

### **1. Demo.Api** 
ASP.NET Core Web API that serves as the centralized backend, exposing RESTful endpoints for data operations and business logic.

### **2. Demo.ApiClient**
Shared library containing HTTP client services, DTOs, and API communication logic. This promotes code reusability and ensures consistent API consumption across different client platforms.

### **3. Demo.BlazorApp**
Blazor Web Application providing a rich, interactive web experience that runs in any modern browser.

### **4. Demo.MauiApiConsumer**
.NET MAUI application that delivers native experiences on iOS, Android, Windows, and macOS by consuming the same API through the shared client library.




https://github.com/user-attachments/assets/f169f0a9-29bf-47be-8f8c-f366e31c009e





## 🏗️ Architecture

The solution follows a clean architecture pattern with clear separation of concerns:

```
┌──────────────────────────────────────────────────────────┐
│                   Presentation Layer                      │
├─────────────────────────┬────────────────────────────────┤
│   Demo.BlazorApp        │   Demo.MauiApiConsumer         │
│   (Web Browser)         │   (iOS/Android/Windows/macOS)  │
│   - Blazor Components   │   - MAUI Pages                 │
│   - Razor Pages         │   - Native UI                  │
└───────────┬─────────────┴─────────────┬──────────────────┘
            │                           │
            │    ┌────────────────────┐ │
            └────│ Demo.ApiClient     │─┘
                 │ (Shared Library)   │
                 │ - HTTP Services    │
                 │ - DTOs/Models      │
                 │ - API Contracts    │
                 └──────────┬─────────┘
                            │
                 ┌──────────▼─────────┐
                 │    Demo.Api        │
                 │ (ASP.NET Core)     │
                 │ - Controllers      │
                 │ - Business Logic   │
                 │ - Data Access      │
                 └────────────────────┘
```

### Architecture Benefits

✅ **API-First Design**: Business logic centralized in the API
✅ **Code Reusability**: Shared API client eliminates duplication
✅ **Platform Independence**: Same backend serves all clients
✅ **Maintainability**: Changes in one place affect all consumers
✅ **Testability**: Each layer can be tested independently
✅ **Scalability**: Easy to add new client platforms

## 📁 Project Structure

```
Web-API-Present-With-MAUI-and-Blazor/
│
├── Api/
│   ├── Demo.Api/                          # ASP.NET Core Web API
│   │   ├── Controllers/                   # API endpoints
│   │   │   └── [YourControllers.cs]
│   │   ├── Models/                        # Domain models
│   │   ├── Services/                      # Business logic services
│   │   ├── Data/                          # Data access layer (if applicable)
│   │   ├── Program.cs                     # API startup and configuration
│   │   ├── appsettings.json              # API configuration
│   │   └── Demo.Api.csproj
│   │
│   └── Demo.ApiClient/                    # Shared API Client Library
│       ├── Services/                      # HTTP client services
│       │   └── [ApiServices.cs]
│       ├── Models/                        # Data Transfer Objects (DTOs)
│       │   └── [Dtos.cs]
│       ├── Interfaces/                    # Service contracts
│       ├── Extensions/                    # Helper methods
│       └── Demo.ApiClient.csproj
│
├── Presentation/
│   ├── Demo.BlazorApp/                    # Blazor Web Application
│   │   ├── Components/                    # Reusable Blazor components
│   │   │   ├── Pages/                     # Routable pages
│   │   │   └── Layout/                    # Layout components
│   │   ├── wwwroot/                       # Static assets (CSS, JS, images)
│   │   │   ├── css/
│   │   │   └── js/
│   │   ├── Program.cs                     # Blazor app configuration
│   │   ├── App.razor                      # Root component
│   │   ├── _Imports.razor                 # Global using statements
│   │   ├── appsettings.json              # Client configuration
│   │   └── Demo.BlazorApp.csproj
│   │
│   └── Demo.MauiApiConsumer/              # MAUI Application
│       ├── Pages/                         # MAUI ContentPages
│       │   └── [YourPages.xaml]
│       ├── ViewModels/                    # MVVM ViewModels
│       ├── Services/                      # Platform-specific services
│       ├── Platforms/                     # Platform-specific code
│       │   ├── Android/
│       │   │   ├── MainActivity.cs
│       │   │   └── AndroidManifest.xml
│       │   ├── iOS/
│       │   │   └── AppDelegate.cs
│       │   ├── Windows/
│       │   │   └── App.xaml.cs
│       │   └── MacCatalyst/
│       │       └── AppDelegate.cs
│       ├── Resources/                     # App resources
│       │   ├── Images/
│       │   ├── Fonts/
│       │   ├── Raw/
│       │   └── AppIcon/
│       ├── MauiProgram.cs                 # MAUI app configuration
│       ├── App.xaml                       # Application definition
│       └── Demo.MauiApiConsumer.csproj
│
└── Web API + .NET MAUI.sln               # Solution file
```

## ✨ Features

### 🌐 Cross-Platform Support
- **Web**: Blazor runs in any modern browser (Chrome, Firefox, Safari, Edge)
- **Mobile**: Native iOS and Android applications
- **Desktop**: Windows, macOS applications
- **Consistent Experience**: Shared API client ensures uniform behavior

### 🔄 API-First Architecture
- RESTful API endpoints for all operations
- JSON-based communication protocol
- Centralized business logic and data validation
- Versioned API for backward compatibility
- Swagger/OpenAPI documentation

### 📦 Shared API Client Library
- **Single Source of Truth**: One implementation for all API calls
- **Type Safety**: Strongly-typed DTOs and contracts
- **Error Handling**: Centralized exception handling
- **Authentication**: Unified auth token management
- **Extensibility**: Easy to add new endpoints

### 🎨 Modern UI Frameworks
- **Blazor**: Component-based architecture with C# and Razor syntax
- **MAUI**: Native controls with XAML and C# code-behind
- **Responsive Design**: Adaptive layouts for all screen sizes

## 🛠️ Technology Stack

| Layer | Technology | Version | Purpose |
|-------|-----------|---------|----------|
| **Backend** | ASP.NET Core Web API | .NET 8+ | RESTful API service |
| **Database** | SQL Server | 2019+ | Data persistence with EF Core |
| **Web Client** | Blazor | .NET 8+ | Interactive web application |
| **Native Client** | .NET MAUI | .NET 8+ | Cross-platform native apps |
| **Shared Library** | C# Class Library | .NET 8+ | API client services |
| **Language** | C# | 12+ | Primary programming language |
| **API Documentation** | Swagger/OpenAPI | 3.0 | API specification and testing |
| **HTTP Client** | HttpClient | - | HTTP communication |
| **Serialization** | System.Text.Json | - | JSON serialization |
| **ORM** | Entity Framework Core | 8+ | Database access layer |

### Optional Technologies
- **Database**: SQL Server (used in this project with Entity Framework Core)
- **Authentication**: JWT Bearer tokens, Identity Server (can be added)
- **Logging**: Serilog, NLog (can be added)
- **Caching**: Memory Cache, Redis (can be added)

## 📋 Prerequisites

### Required Software

1. **[.NET 8 SDK](https://dotnet.microsoft.com/download)** or later
   ```bash
   dotnet --version
   # Should output 8.0.0 or higher
   ```

2. **IDE** (Choose one):
   - **[Visual Studio 2022](https://visualstudio.microsoft.com/)** v17.8+ (Recommended for Windows)
     - Workloads required:
       - ASP.NET and web development
       - .NET Multi-platform App UI development
   - **[Visual Studio Code](https://code.visualstudio.com/)**
     - Extensions: C#, .NET MAUI
   - **[JetBrains Rider](https://www.jetbrains.com/rider/)** (Alternative)

### Platform-Specific Requirements

#### For MAUI Development

**Windows (10/11):**
- Visual Studio 2022 with MAUI workload
- Windows 10 SDK (10.0.19041.0 or higher)

**macOS (12+):**
- Xcode (latest stable version)
- Xcode Command Line Tools
- CocoaPods (for iOS dependencies)

#### For Mobile Development

**Android:**
- Android SDK (API 21 or higher)
- Android Emulator or physical device
- Java Development Kit (JDK 11 or higher)

**iOS (macOS only):**
- Xcode with iOS Simulator
- Apple Developer account (for device deployment)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Kerollos-Saad/Web-API-Present-With-MAUI-and-Blazor.git
cd Web-API-Present-With-MAUI-and-Blazor
```

### 2. Setup Database

The project uses **SQL Server** with Entity Framework Core.

1. **Install SQL Server** if you don't have it:
   - [SQL Server Express](https://www.microsoft.com/sql-server/sql-server-downloads) (Free)
   - Or [SQL Server LocalDB](https://learn.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb)

2. **Update Connection String** in `Api/Demo.Api/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DbConnection": "Server=YOUR_SERVER_NAME;Database=MAUIDemo;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
     }
   }
   ```
   
   Replace `YOUR_SERVER_NAME` with your SQL Server instance name (e.g., `localhost`, `.\SQLEXPRESS`, or your computer name).

3. **Apply Database Migrations**:
   ```bash
   cd Api/Demo.Api
   dotnet ef database update
   ```
   
   If you don't have EF tools installed:
   ```bash
   dotnet tool install --global dotnet-ef
   ```

### 3. Restore Dependencies

```bash
# Restore all projects in the solution
dotnet restore "Web API + .NET MAUI.sln"
```

### 4. Build the Solution

```bash
# Build all projects
dotnet build "Web API + .NET MAUI.sln"
```

### 5. Configure API Endpoints

The API runs on **HTTPS port 44300** (or HTTP port 4353 via IIS Express).

**For Blazor** - Already configured in `Presentation/Demo.BlazorApp/appsettings.json`:
```json
{
  "ApiBaseAddress": "https://localhost:44300"
}
```

**For MAUI** - Already configured in `Presentation/Demo.MauiApiConsumer/MauiProgram.cs`:
```csharp
builder.Services.AddDemoApiClientService(x => 
    x.ApiBaseAddress = "https://localhost:44300/");
```

**Important for Android Emulator**: Change the API address to `http://10.0.2.2:44300/` in MauiProgram.cs when testing on Android emulator.

## 🎮 Running the Applications

### Option 1: Using Visual Studio

#### Run the API
1. Set **Demo.Api** as the startup project (right-click → Set as Startup Project)
2. Press **F5** or click **Start Debugging**
3. API will launch at `https://localhost:44300` (HTTPS) or `http://localhost:4353` (HTTP via IIS Express)
4. Swagger UI will be available at `https://localhost:44300` (root path)

**Launch Settings**: The API is configured with two profiles:
- **HTTP**: Runs on `http://localhost:5192` with Swagger
- **IIS Express**: Runs on `http://localhost:4353` with HTTPS on port 44300

#### Run Blazor App
1. Set **Demo.BlazorApp** as the startup project
2. Press **F5**
3. App will open in your default browser at `https://localhost:5067` (or configured port)

#### Run MAUI App
1. Set **Demo.MauiApiConsumer** as the startup project
2. Select target platform from dropdown:
   - **Windows Machine** (for Windows)
   - **Android Emulator** (requires Android SDK)
   - **iOS Simulator** (macOS only)
3. Press **F5**

### Option 2: Using Command Line

#### 1. Start the API

```bash
cd Api/Demo.Api
dotnet run

# API will start at:
# - HTTP: http://localhost:5192
# - HTTPS (IIS Express): https://localhost:44300
# Swagger UI: https://localhost:44300 (root path)
```

**Keep this terminal window open**

#### 2. Run Blazor App (New Terminal)

```bash
cd Presentation/Demo.BlazorApp
dotnet run

# App will start at https://localhost:5067
```

Open your browser to `https://localhost:5067`

#### 3. Run MAUI App (New Terminal)

**For Windows:**
```bash
cd Presentation/Demo.MauiApiConsumer
dotnet build -t:Run -f net8.0-windows10.0.19041.0
```

**For Android:**
```bash
cd Presentation/Demo.MauiApiConsumer

# IMPORTANT: Before running, update MauiProgram.cs to use Android emulator address:
# builder.Services.AddDemoApiClientService(x => x.ApiBaseAddress = "http://10.0.2.2:44300/");

dotnet build -t:Run -f net8.0-android
```

**For iOS (macOS only):**
```bash
cd Presentation/Demo.MauiApiConsumer
dotnet build -t:Run -f net8.0-ios
```

**For macOS (macOS only):**
```bash
cd Presentation/Demo.MauiApiConsumer
dotnet build -t:Run -f net8.0-maccatalyst
```

### Troubleshooting

**Issue**: Connection refused when client tries to reach API
- **Solution**: Ensure the API is running and the base URL in client config matches the API's address

**Issue**: Android emulator can't reach localhost
- **Solution**: Use `http://10.0.2.2:44300/` instead of `localhost` for Android emulator in `MauiProgram.cs`

**Issue**: HTTPS certificate errors
- **Solution**: Trust the development certificate:
  ```bash
  dotnet dev-certs https --trust
  ```

## ⚙️ Configuration

### API Configuration (`Api/Demo.Api/appsettings.json`)

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DbConnection": "Server=YOUR_SERVER;Database=MAUIDemo;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

**Note**: Update the `Server` value in the connection string to match your SQL Server instance name.

### CORS Configuration

CORS is configured in `Program.cs` to allow requests from the Blazor app:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy => policy
            .WithOrigins("http://localhost:5067", "https://localhost:5067")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Apply CORS policy
app.UseCors("AllowBlazor");
```

The API accepts requests from:
- `http://localhost:5067` (Blazor HTTP)
- `https://localhost:5067` (Blazor HTTPS)

### Blazor Configuration (`Presentation/Demo.BlazorApp/appsettings.json`)

```json
{
  "ApiBaseAddress": "https://localhost:44300",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### MAUI Configuration (In code)

Update `MauiProgram.cs`:

```csharp
using Demo.ApiClient;
using Demo.ApiClient.IoC;
using Microsoft.Extensions.Logging;

namespace Demo.MauiApiConsumer
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Configure API client service
            // For Android emulator, use: http://10.0.2.2:44300/
            // For other platforms, use: https://localhost:44300/
            builder.Services.AddDemoApiClientService(x => 
                x.ApiBaseAddress = "https://localhost:44300/");
            
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
```

**Important Note for Android Emulator**: 
- Android emulators cannot access `localhost` directly
- Use `http://10.0.2.2:44300/` instead when testing on Android emulator
- Uncomment the Android emulator line and comment the localhost line when testing on Android

## 💡 Key Concepts

### 1. Database Context with Entity Framework Core

The API uses Entity Framework Core with SQL Server:

```csharp
// In Program.cs
builder.Services.AddDbContext<DemoDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbConnection");
    options.UseSqlServer(connectionString);
});
```

The `DemoDbContext` class (in `Demo.Api.Data` namespace) manages database operations:
- DbSet properties for your entities
- Configurations for table relationships
- Migrations for database schema changes

### 2. Shared API Client Pattern

The `Demo.ApiClient` project contains all API communication logic and provides an extension method for easy service registration:

```csharp
// Demo.ApiClient.IoC namespace provides extension method
using Demo.ApiClient.IoC;

// In MauiProgram.cs or Blazor Program.cs
builder.Services.AddDemoApiClientService(options => 
{
    options.ApiBaseAddress = "https://localhost:44300/";
});
```

This extension method registers all necessary services including:
- HttpClient with configured base address
- API service interfaces and implementations
- JSON serialization options

**Example API Service Interface:**
```csharp
// Example API Service Interface
public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(int id, Product product);
    Task<bool> DeleteProductAsync(int id);
}

// Implementation used by both Blazor and MAUI
public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    
    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<Product>> GetAllProductsAsync()
    {
        var response = await _httpClient.GetAsync("api/products");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<Product>>();
    }
    
    // ... other methods
}
```

### 3. Dependency Injection

Both Blazor and MAUI use the same API client registration through the extension method:

**Blazor** (`Program.cs`):
```csharp
using Demo.ApiClient.IoC;

var builder = WebApplication.CreateBuilder(args);

// Register API client services
var apiBaseAddress = builder.Configuration["ApiBaseAddress"];
builder.Services.AddDemoApiClientService(options => 
{
    options.ApiBaseAddress = apiBaseAddress; // https://localhost:44300
});

// ... other services
```

**MAUI** (`MauiProgram.cs`):
```csharp
using Demo.ApiClient.IoC;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        
        // Register API client services
        builder.Services.AddDemoApiClientService(options => 
        {
            options.ApiBaseAddress = "https://localhost:44300/";
            // For Android: "http://10.0.2.2:44300/"
        });
        
        builder.Services.AddTransient<MainPage>();
        
        return builder.Build();
    }
}
```

Both platforms can now inject and use the same service interfaces!

### 4. Swagger/OpenAPI Configuration

The API uses the new OpenAPI specification with Swagger UI:

```csharp
// In Program.cs
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// Configure Swagger UI
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API v1");
        options.RoutePrefix = string.Empty; // Swagger at root URL
    });
}
```

Access Swagger UI at: `https://localhost:44300/` to test API endpoints interactively.

### 5. Platform-Specific Code in MAUI

Use conditional compilation for platform-specific features:

```csharp
#if ANDROID
    // Android-specific code
#elif IOS
    // iOS-specific code
#elif WINDOWS
    // Windows-specific code
#elif MACCATALYST
    // macOS-specific code
#endif
```

## 🤝 Contributing

Contributions are welcome! Please follow these guidelines:

### How to Contribute

1. **Fork the repository**
   ```bash
   # Click the Fork button on GitHub
   ```

2. **Clone your fork**
   ```bash
   git clone https://github.com/YOUR_USERNAME/Web-API-Present-With-MAUI-and-Blazor.git
   ```

3. **Create a feature branch**
   ```bash
   git checkout -b feature/amazing-feature
   ```

4. **Make your changes**
   - Write clean, readable code
   - Follow existing code style
   - Add comments where necessary
   - Update documentation

5. **Commit your changes**
   ```bash
   git commit -m "Add: Amazing new feature"
   ```

6. **Push to your fork**
   ```bash
   git push origin feature/amazing-feature
   ```

7. **Open a Pull Request**
   - Go to the original repository
   - Click "New Pull Request"
   - Describe your changes

### Code Style

- Follow [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use meaningful variable and method names
- Write XML documentation comments for public APIs
- Keep methods focused and concise

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

### MIT License Summary

```
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software...
```

## 👤 Author

**Kerollos Saad**

- GitHub: [@Kerollos-Saad](https://github.com/Kerollos-Saad)
- Repository: [Web-API-Present-With-MAUI-and-Blazor](https://github.com/Kerollos-Saad/Web-API-Present-With-MAUI-and-Blazor)

## 📚 Resources & Documentation

### Official Documentation
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Blazor Documentation](https://docs.microsoft.com/aspnet/core/blazor)
- [.NET MAUI Documentation](https://docs.microsoft.com/dotnet/maui)
- [C# Documentation](https://docs.microsoft.com/dotnet/csharp)

### Tutorials & Guides
- [Build Web Apps with Blazor](https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro)
- [Build Mobile Apps with .NET MAUI](https://dotnet.microsoft.com/learn/maui)
- [API Design Best Practices](https://docs.microsoft.com/azure/architecture/best-practices/api-design)

### Community Resources
- [.NET Blog](https://devblogs.microsoft.com/dotnet/)
- [Blazor University](https://blazor-university.com/)
- [MAUI Community Toolkit](https://github.com/CommunityToolkit/Maui)


---

<div align="center">

### ⭐ Star this repository if you find it helpful!

**Built with ❤️ using .NET**

[Report Bug](https://github.com/Kerollos-Saad/Web-API-Present-With-MAUI-and-Blazor/issues) · 
[Request Feature](https://github.com/Kerollos-Saad/Web-API-Present-With-MAUI-and-Blazor/issues) · 
[Contribute](https://github.com/Kerollos-Saad/Web-API-Present-With-MAUI-and-Blazor/pulls)

</div>
