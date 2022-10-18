using Xunit;
using Mosaic.Model;

namespace Mosaic.Tests;
public class MosaicTests
{
    [Fact]
    public void CanvasHasPixels()
    {
        var c = new Canvas();
        Assert.IsType<List<Pixel>>(c.Pixels);
    }

}