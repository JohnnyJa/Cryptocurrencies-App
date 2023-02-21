using NewApp.Model;

namespace NewApp.Messages;

public class AssetMessage : IMessage
{
    public AssetMessage(Asset? asset)
    {
        Asset = asset;
    }
    
    public Asset? Asset { get; set; }
}