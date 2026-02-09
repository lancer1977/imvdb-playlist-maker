using IMVDB.Gui;
using IMVDB.Gui.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PolyhydraGames.Core.Interfaces;
using PolyhydraGames.IMVDB.API;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.ConfigureHttpClient(builder.HostEnvironment.BaseAddress); 
builder.AddAuthentication();
builder.AddIMVDB();
builder.Services.AddViewModels();

await builder.Build().RunAsync();

public static class SetupHelpers
{
    public static void AddViewModels(this IServiceCollection sp)
    {
        sp.AddScoped<IMVDBSearchViewModel>();
    }
    public static void AddIMVDB(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped<IMVDBService>();
        builder.Services.AddScoped<IIMVDBAuthorization>(x =>
        {
            var config = x.GetRequiredService<IConfiguration>();
            var apiKey = config["IMVDB:APIKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
               // throw new InvalidOperationException("IMVDB API Key is not configured.");
            }
            return new IMVDBAuthorization { APIKey = apiKey };
        });
    }
    public static void ConfigureHttpClient(this IServiceCollection services, string baseAddress)
    {
        services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
        services.AddScoped<IHttpService, HttpService>();
    }

    public static void AddAuthentication(this WebAssemblyHostBuilder builder)
    {

        builder.Services.AddOidcAuthentication(options => {
            // Configure your authentication provider options here.
            // For more information, see https://aka.ms/blazor-standalone-auth
            builder.Configuration.Bind("Local", options.ProviderOptions);
        });
    }
}