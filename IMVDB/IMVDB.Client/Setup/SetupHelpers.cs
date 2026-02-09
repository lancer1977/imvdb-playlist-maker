using IMVDB.Gui.Pages;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PolyhydraGames.Core.Interfaces;
using PolyhydraGames.IMVDB.API;

public static class SetupHelpers
{
    public static void AddViewModels(this IServiceCollection sp)
    {
        sp.AddScoped<SearchViewModel>();
    }
    public static void AddIMVDB(this IServiceCollection services)
    {
        services.AddScoped<IHttpService, HttpService>();
        services.AddScoped<IMVDBService>();
        services.AddScoped<IIMVDBAuthorization>(x =>
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
 

    public static void AddAuthentication(this IServiceCollection builder, IConfiguration config)
    {

        builder.AddOidcAuthentication(options => {
            // Configure your authentication provider options here.
            // For more information, see https://aka.ms/blazor-standalone-auth
            config.Bind("Local", options.ProviderOptions);
        });
    }
}