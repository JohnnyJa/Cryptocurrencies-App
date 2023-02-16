using Newtonsoft.Json;

namespace Model;

public class GotAsset
{
    public Asset Data { get; set; }
    public long timestamp;
}

public class GotAssets
{
    public List<Asset> Data { get; set; }
    public long timestamp;
}

public class Asset
{
    public string Id { get; set; } 
    public string Rank { get; set; }
    public string Symbol { get; set; }
    public string name { get; set; }
    public string supply { get; set; }
    public string maxSupply { get; set; }
    public string marketCapUsd { get; set; }
    public string volumeUsd24Hr { get; set; }
    public string priceUsd { get; set; }
    public string changePercent24Hr { get; set; }
    public string vwap24Hr { get; set; }
}

