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
    
    public async Task<Assets> GetTopAssetsAsync()
    {
        string relativeUrl = "assets/?limit=10";
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        Assets? assets = await _client.GetFromJsonAsync<Assets>(url);
        return assets;
    }
    
    public async Task<Asset> GetAssetByIdAsync(string id)
    {
        string relativeUrl = "assets/" + id;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        Asset? asset = await _client.GetFromJsonAsync<Asset>(url);
        return asset;
    }

    public async Task<Assets> GetSearchedAssetsAsync(string keyword)
    {
        string relativeUrl = "assets?search=" + keyword;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        Assets? assets = await _client.GetFromJsonAsync<Assets>(url);
        return assets;
    }
}