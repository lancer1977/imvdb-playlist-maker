
using Microsoft.JSInterop;
using PolyhydraGames.IMVDB.API;
using PolyhydraGames.IMVDB.DTO;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace IMVDB.Gui.Pages;
public class SearchViewModel : ReactiveObject
{
    private readonly IIMVDBAuthorization _authorization;
    private readonly IMVDBService _imvdbService;
    private readonly IJSRuntime _js;

    public SearchViewModel(IIMVDBAuthorization Authorization, IMVDBService IMVDBService, IJSRuntime js)
    {
        _authorization = Authorization;
        _imvdbService = IMVDBService;
        _js = js;
        this.WhenAnyValue(x => x.ApiKey).Subscribe(x => _authorization.APIKey = x);
    }
    public async Task CopyToClipboard()
    {
        await _js.InvokeVoidAsync("navigator.clipboard.writeText", PlainTextUrls);
    }
     
    private IJSRuntime JS { get; set; }
    [Reactive] public string ApiKey { get; set; }
   [Reactive] public string ArtistName { get; set; }
   [Reactive] public IReadOnlyList<Video> VideoUrls { get; set; }
   [Reactive] public string PlainTextUrls { get; set; }
   [Reactive] public bool IsLoading { get; set; }
   [Reactive] public string ErrorMessage { get; set; }


   public async Task SearchVideos()
   {
       if (string.IsNullOrWhiteSpace(ApiKey) || string.IsNullOrWhiteSpace(ArtistName))
       {
           ErrorMessage = "API Key and Artist Name are required.";
           return;
       }

       IsLoading = true;
       ErrorMessage = string.Empty;
       VideoUrls = new List<Video>();
       PlainTextUrls = string.Empty;

       try
       {
           var response = await _imvdbService.SearchVideos(ArtistName);
           if (response.Success)
           {
               var result =   response.Value;
               VideoUrls = result?.Results ?? new List<Video>();
               PlainTextUrls = string.Join('\n', VideoUrls);
           }
           else
           {
               ErrorMessage = $"API error: {response.Message}";
           }
       }
       catch (Exception ex)
       {
           ErrorMessage = $"Exception: {ex.Message}";
       }
       finally
       {
           IsLoading = false;
       }
   }

}