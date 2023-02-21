using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NewApp.EntryEntities;
using NewApp.Model;

namespace NewApp.Converters;

public static class EntryConverter
{
    private static Asset ConvertDataToAsset(AssetData? assetData)
    {
        Asset asset = new Asset()
        {
            Id = assetData!.Id,
            Name = assetData.Name,
            ChangePercent = assetData.ChangePercent24Hr,
            Price = assetData.PriceUsd,
            Rank = assetData.Rank,
            Symbol = assetData.Symbol,
            Volume = assetData.VolumeUsd24Hr
        };

        return asset;
    }
    
    public static Asset ToAsset(EntryAsset entryAsset)
    {
        var assetData = entryAsset.Data;
        return ConvertDataToAsset(assetData);
    }

    public static ObservableCollection<Asset> ToObservableAssets(EntryAssetsList entryAssetsList)
    {
        var res = new ObservableCollection<Asset>();
        var assetList = entryAssetsList.Data;
        foreach (var assetData in assetList!)
        {
            res.Add(ConvertDataToAsset(assetData));
        }

        return res;
    }
    
    public static async Task<Asset> ToAssetAsync(Task<EntryAsset> entryTask)
    {
        var asset = await entryTask;
        return ConvertDataToAsset(asset.Data);
    }

    public static async Task<ObservableCollection<Asset>> ToObservableAssetsAsync(Task<EntryAssetsList?> entryTask)
    {
        var res = new ObservableCollection<Asset>();
        var assetList = await entryTask;
        
        foreach (var assetData in assetList!.Data!)
        {
            res.Add(ConvertDataToAsset(assetData));
        }

        return res;
    }
    
    private static Market ConvertDataToMarket(MarketData? marketData)
    {
        Market market = new Market()
        {
            ExchangeId = marketData!.ExchangeId,
            Price = marketData.PriceUsd
        };

        return market;
    }
    
    public static Market ToMarket(EntryMarket entryMarket)
    {
        var marketData = entryMarket.Data;
        return ConvertDataToMarket(marketData);
    }

    public static ObservableCollection<Market> ToObservableMarkets(EntryMarketsList entryMarketsList)
    {
        var res = new ObservableCollection<Market>();
        var marketList = entryMarketsList.Data;
        foreach (var marketData in marketList!)
        {
            res.Add(ConvertDataToMarket(marketData));
        }

        return res;
    }
    
    public static async Task<Market> ToMarketAsync(Task<EntryMarket> entryTask)
    {
        var market = await entryTask;
        return ConvertDataToMarket(market.Data);
    }

    public static async Task<ObservableCollection<Market>> ToObservableMarketsAsync(Task<EntryMarketsList?> entryTask)
    {
        var res = new ObservableCollection<Market>();
        var marketList = await entryTask;
        
        foreach (var marketData in marketList!.Data!)
        {
            res.Add(ConvertDataToMarket(marketData));
        }

        return res;
    }
}