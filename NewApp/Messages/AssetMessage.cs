using Model;

namespace WpfPaging.Messages;

public class AssetMessage : IMessage
{
    public AssetMessage(Asset asset)
    {
        Asset = asset;
    }
    
    public Asset Asset { get; set; }
}