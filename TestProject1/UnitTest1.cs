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
        
        Asset asset = await repository.GetAssetByIdAsync("bitcoin");
        if (asset.data.Id == "bitcoin")
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public async Task Test2()
    {
        Assets asset = await repository.GetTopAssetsAsync();
        if (asset.data.First().Id == "bitcoin")
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public async Task Test3()
    {
        Assets asset = await repository.GetSearchedAssetsAsync("BTC");
        if (asset.data.First().Id == "bitcoin")
        {
            Assert.Pass();
        }
    }
}