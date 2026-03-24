# IMVDB Playlist Maker

A .NET 9/10 codebase for building IMVDB playlist workflows with three main pieces:

- `IMVDB/IMVDB` - ASP.NET Core server project
- `IMVDB/IMVDB.Client` - Blazor WebAssembly client
- `IMVDB/IMVDB.Client.Shared` - shared contracts/models
- `IMVDB.Gui` - Blazor WebAssembly GUI

## Project Description

IMVDB Playlist Maker is a small IMVDB-focused app suite for playlist browsing and management.
It includes server-side web functionality, browser-based clients, and shared models for reuse across the stack.

## Prerequisites

- .NET SDK 9.0 or newer
- .NET 10 SDK/runtime if you want to build `IMVDB/IMVDB.Client` exactly as currently configured (`net10.0`)
- Access to the external API project referenced by the clients:
  - `/home/lancer1977/code/APIs/API.IMVDB/PolyhydraGames.IMVDB.Api/PolyhydraGames.IMVDB.csproj`

Verify your SDK installation:

```bash
dotnet --version
```

## Build Instructions

Build each project directly from the repository root:

```bash
dotnet restore IMVDB/IMVDB/IMVDB.csproj
dotnet build IMVDB/IMVDB/IMVDB.csproj -c Release

dotnet restore IMVDB/IMVDB.Client/IMVDB.Client.csproj
dotnet build IMVDB/IMVDB.Client/IMVDB.Client.csproj -c Release

dotnet restore IMVDB.Gui/IMVDB.Gui.csproj
dotnet build IMVDB.Gui/IMVDB.Gui.csproj -c Release
```

## Running Instructions

### Run the server project

```bash
dotnet run --project IMVDB/IMVDB/IMVDB.csproj
```

### Run the Blazor client project

```bash
dotnet run --project IMVDB/IMVDB.Client/IMVDB.Client.csproj
```

### Run the GUI project

```bash
dotnet run --project IMVDB.Gui/IMVDB.Gui.csproj
```

If a referenced external project is missing, restore/build/run will fail until that dependency is available locally.

## Dependencies

Primary framework dependencies found in the project files:

- `IMVDB/IMVDB`
  - `Microsoft.AspNetCore.Components.WebAssembly.Server` `9.0.4`
  - `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore` `9.0.4`
  - `Microsoft.AspNetCore.Identity.EntityFrameworkCore` `9.0.4`
  - `Microsoft.EntityFrameworkCore.SqlServer` `9.0.4`
  - `Microsoft.EntityFrameworkCore.Tools` `9.0.4`
- `IMVDB/IMVDB.Client`
  - `Microsoft.AspNetCore.Components.WebAssembly` `9.0.4`
  - `Microsoft.AspNetCore.Components.WebAssembly.Authentication` `9.0.4`
  - `ReactiveUI.Blazor` `20.2.45`
  - `ReactiveUI.Fody` `19.5.41`
- `IMVDB.Gui`
  - `Microsoft.AspNetCore.Components.WebAssembly` `9.0.4`
  - `Microsoft.AspNetCore.Components.WebAssembly.DevServer` `9.0.4`
  - `Microsoft.AspNetCore.Components.WebAssembly.Authentication` `9.0.4`
  - `ReactiveUI.Blazor` `20.2.45`
  - `ReactiveUI.Fody` `19.5.41`

## Notes

- There is no solution file checked into this repository right now, so use the project-file commands above.
- `IMVDB.Client` currently targets `net10.0`, while the server and shared project target `net9.0`.
- The web clients reference an API project outside this repository; keep that path available when building locally.


## 📖 Documentation
Detailed documentation can be found in the following sections:
- [Feature Index](./docs/features/README.md)
- [Core Capabilities](./docs/features/core-capabilities.md)
