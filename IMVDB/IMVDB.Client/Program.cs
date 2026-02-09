using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PolyhydraGames.Core.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddIMVDB();
builder.Services.AddViewModels();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();
