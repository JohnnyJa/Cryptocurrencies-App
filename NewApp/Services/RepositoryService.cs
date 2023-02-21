using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NewApp.EntryEntities;

namespace NewApp.Services;

public class RepositoryService
{
    private readonly HttpClient _client = new HttpClient();
    
    public RepositoryService()
    {
        
        _client.BaseAddress = new Uri("https://api.coincap.io/v2/");
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<EntryAssetsList?> GetTopAssetsAsync(int num)
    {
        string relativeUrl = "assets/?limit=" + num;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        EntryAssetsList? assets = await _client.GetFromJsonAsync<EntryAssetsList>(url);
        return assets;
    }

    public async Task<EntryAsset?> GetAssetByIdAsync(string id)
    {
        string relativeUrl = "assets/" + id;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        EntryAsset? asset = await _client.GetFromJsonAsync<EntryAsset>(url);
        return asset;
    }

    public async Task<EntryAssetsList?> GetSearchedAssetsAsync(string? keyword, int? num = 10)
    {
        string relativeUrl = "assets?search=" + keyword + "&limit=" + num;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        EntryAssetsList? assets = await _client.GetFromJsonAsync<EntryAssetsList>(url);
        return assets;
    }

    public async Task<EntryMarketsList?> GetMarketsByIdAsync(string? id, int? num = 10)
    {
        string relativeUrl = "assets/" + id + "/markets?limit=" + num;
        Uri url = new Uri(_client.BaseAddress!, relativeUrl);
        EntryMarketsList? markets = await _client.GetFromJsonAsync<EntryMarketsList>(url);
        return markets;
    }
}