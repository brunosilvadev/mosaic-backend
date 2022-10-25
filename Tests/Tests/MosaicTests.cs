using Xunit;
using Mosaic.Model;
using Mosaic.Persistence;
using Microsoft.Extensions.Configuration;

namespace Mosaic.Tests;
public class MosaicTests
{
    [Fact]
    public void CanvasHasPixels()
    {
        var c = new Canvas();
        Assert.IsType<List<Pixel>>(c.Pixels);
    }
    [Fact]
    public void CosmosConnects()
    {
        var inMemorySettings = new Dictionary<string, string>
        {
            {"EndpointUri",@"AAA" },
            {"PrimaryKey",@"BBB"}
        };
        IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();                    
        var c = new CosmosProvider(config);
        Assert.True(c.ConfigsWereRead());
    }

}