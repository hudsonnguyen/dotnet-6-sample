using Flurl;
using Flurl.Http;

public class CatService
{
    private const string CatApiUrl = "https://api.thecatapi.com/v1/images/search";

    public async Task<string> RandomImage()
    {
        var resp = await CatApiUrl.GetJsonAsync<TheCapApiSearchResponse[]>();
        return resp.First().Url;
    }

    public async Task<Stream> RandomImageStream()
    {
        var resp = await CatApiUrl.GetJsonAsync<TheCapApiSearchResponse[]>();
        return await resp.First().Url.GetStreamAsync();
    }

    public record TheCapApiSearchResponse
    {
        public string Url { get; set; } = string.Empty;
    }
}