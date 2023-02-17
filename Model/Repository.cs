using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Model;


public class Repository
{
    static HttpClient _client = new HttpClient();

    private static Repository uniqueRepository;
    public static Repository GetInstance()
    {
        if (uniqueRepository == null)
        {
            uniqueRepository = new Repository();
        }

        return uniqueRepository;
    }
    
    private Repository()
    {
        
        _client.BaseAddress = new Uri("https://api.coincap.io/v2/");
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public async Task<List<Asset>> GetTopAssetsAsync(int num)
    {
        string relativeUrl = "assets/?limit=" + num;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        AssetsData? assets = await _client.GetFromJsonAsync<AssetsData>(url);
        return assets.Data;
    }
    
    public async Task<Asset> GetAssetByIdAsync(string id)
    {
        string relativeUrl = "assets/" + id;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        AssetData? asset = await _client.GetFromJsonAsync<AssetData>(url);
        return asset.Data;
    }

    public async Task<List<Asset>> GetSearchedAssetsAsync(string keyword)
    {
        string relativeUrl = "assets?search=" + keyword;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        AssetsData? assets = await _client.GetFromJsonAsync<AssetsData>(url);
        return assets.Data;
    }
    
    public async Task<List<Market>> GetMarketsByIdAsync(string id, int? num = 10)
    {
        string relativeUrl = "assets/" + id + "/markets?limit=" + num;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        MarketsData? markets = await _client.GetFromJsonAsync<MarketsData>(url);
        return markets.Data;
    }
}