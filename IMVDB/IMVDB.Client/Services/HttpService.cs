using PolyhydraGames.Core.Interfaces;

public class HttpService : IHttpService
{
    public HttpService()
    {
        GetClient = new HttpClient();
    }

    public Task<string> GetAuthToken()
    {
        return Task.FromResult("");
    }

    public HttpClient GetClient { get; } 
}