using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Model;


public class Repository
{
    static HttpClient _client = new HttpClient();

    public Repository()
    {
        
        _client.BaseAddress = new Uri("https://api.coincap.io/v2/");
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public async Task<GotAssets> GetTopAssetsAsync()
    {
        string relativeUrl = "assets/?limit=10";
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        GotAssets? assets = await _client.GetFromJsonAsync<GotAssets>(url);
        return assets;
    }
    
    public async Task<GotAsset> GetAssetByIdAsync(string id)
    {
        string relativeUrl = "assets/" + id;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        GotAsset? asset = await _client.GetFromJsonAsync<GotAsset>(url);
        return asset;
    }

    public async Task<GotAssets> GetSearchedAssetsAsync(string keyword)
    {
        string relativeUrl = "assets?search=" + keyword;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        GotAssets? assets = await _client.GetFromJsonAsync<GotAssets>(url);
        return assets;
    }
}