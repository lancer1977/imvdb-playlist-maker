using PolyhydraGames.Core.Interfaces;

public class HttpService : IHttpService
{
    public HttpService(HttpClient getClient)
    {
        GetClient = getClient;
    }

    public Task<string> GetAuthToken()
    {
        return Task.FromResult("");
    }

    public HttpClient GetClient { get; } 
}