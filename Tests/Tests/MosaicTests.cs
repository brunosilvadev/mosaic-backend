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
    public async Task CosmosConnects()
    {
        var inMemorySettings = new Dictionary<string, string>
        {
            {"EndpointUri",@"AAA" },
            {"PrimaryKey",@"BBB"}
        };
        IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();                    
        var c = new CosmosProvider(config);

        var response = await c.PaintPixel(new Pixel()
        {
            X = 5,
            Y = 10,
            HexColor = "000000"
        });
        Assert.True(c.ConfigsWereRead());
    }

}