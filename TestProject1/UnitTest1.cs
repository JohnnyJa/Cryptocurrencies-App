using Model;

namespace TestProject1;

public class Tests
{
    Repository repository;
    [SetUp]
    public void Setup()
    {
        repository = Repository.GetInstance();
    }

    [Test]
    public async Task Test1()
    {
        
        Asset gotAsset = await repository.GetAssetByIdAsync("bitcoin");
        if (gotAsset.Id == "bitcoin")
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public async Task Test2()
    {
        var gotAsset = await repository.GetTopAssetsAsync(10);
        if (gotAsset.First().Id == "bitcoin")
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public async Task Test3()
    {
        var gotAsset = await repository.GetSearchedAssetsAsync("BTC");
        if (gotAsset.First().Id == "bitcoin")
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public async Task Test4()
    {
        var gotAsset = await repository.GetMarketsByIdAsync("bitcoin");
        if (gotAsset.First().ExchangeId == "Binance")
        {
            Assert.Pass();
        }
    }
}