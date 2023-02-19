using System.Collections.ObjectModel;

namespace Model;

public class AssetData
{
    public Asset Data { get; set; }
    public long Timestamp { get; set; }
}

public class AssetsData
{
    public ObservableCollection<Asset> Data { get; set; }
    public long Timestamp { get; set; }
}

public class Asset
{
    public string Id { get; set; } 
    public string Rank { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Supply { get; set; }
    public string maxSupply { get; set; }
    public string marketCapUsd { get; set; }
    public string volumeUsd24Hr { get; set; }
    public string priceUsd { get; set; }
    public string changePercent24Hr { get; set; }
    public string vwap24Hr { get; set; }
}

public class MarketData
{
    public Market Data { get; set; }
    public long Timestamp{ get; set; }
}

public class MarketsData
{
    public ObservableCollection<Market> Data { get; set; }
    public long Timestamp { get; set; }
}

public class Market
{
    public string ExchangeId { get; set; } 
    public string BaseId { get; set; }
    public string Symbol { get; set; }
    public string quoteId { get; set; }
    public string baseSymbol { get; set; }
    public string quoteSymbol { get; set; }
    public string volumeUsd24Hr { get; set; }
    public string priceUsd { get; set; }
    public string volumePercent { get; set; }
}



