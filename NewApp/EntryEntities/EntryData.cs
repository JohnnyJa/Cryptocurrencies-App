using System.Collections.Generic;
// ReSharper disable ClassNeverInstantiated.Global

namespace NewApp.EntryEntities;

public class EntryAsset
{
    public AssetData? Data { get; set; }
    public long Timestamp { get; set; }
}

public class EntryAssetsList
{

    public List<AssetData?>? Data { get; set; }
    public long Timestamp { get; set; }
}

public class AssetData
{
    public string? Id { get; set; } 
    public string? Rank { get; set; }
    public string? Symbol { get; set; }
    public string? Name { get; set; }
    public string? Supply { get; set; }
    public string? MaxSupply { get; set; }
    public string? MarketCapUsd { get; set; }
    public string? VolumeUsd24Hr { get; set; }
    public string? PriceUsd { get; set; }
    public string? ChangePercent24Hr { get; set; }
    public string? Vwap24Hr { get; set; }
}

public class EntryMarket
{
    public MarketData? Data { get; set; }
    public long Timestamp{ get; set; }
}

public class EntryMarketsList
{
    public List<MarketData?>? Data { get; set; }
    public long Timestamp { get; set; }
}

public class MarketData
{
    public string? ExchangeId { get; set; } 
    public string? BaseId { get; set; }
    public string? Symbol { get; set; }
    public string? QuoteId { get; set; }
    public string? BaseSymbol { get; set; }
    public string? QuoteSymbol { get; set; }
    public string? VolumeUsd24Hr { get; set; }
    public string? PriceUsd { get; set; }
    public string? VolumePercent { get; set; }
}



