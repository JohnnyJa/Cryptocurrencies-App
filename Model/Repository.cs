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
        Uri url = new Uri(_client.BaseAddress!,"assets/" + "?limit=10");
        Assets? asset = await _client.GetFromJsonAsync<Assets>(url);
        return asset;
    }
    
    public async Task<Asset> GetAssetByIdAsync(string id)
    {
        Uri url = new Uri(_client.BaseAddress!,"assets/" + id);
        Asset? asset = await _client.GetFromJsonAsync<Asset>(url);
        return asset;
    }
}