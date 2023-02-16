using Model;

namespace TestProject1;

public class Tests
{
    Repository repository = new Repository();
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        
        GotAsset gotAsset = await repository.GetAssetByIdAsync("bitcoin");
        if (gotAsset.Data.Id == "bitcoin")
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public async Task Test2()
    {
        GotAssets gotAsset = await repository.GetTopAssetsAsync();
        if (gotAsset.Data.First().Id == "bitcoin")
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public async Task Test3()
    {
        GotAssets gotAsset = await repository.GetSearchedAssetsAsync("BTC");
        if (gotAsset.Data.First().Id == "bitcoin")
        {
            Assert.Pass();
        }
    }
}