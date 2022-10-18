using Xunit;
using Mosaic.Model;

public class MosaicTests
{
    [Fact]
    public void CanvasHasPixels()
    {
        var c = new Canvas();
        Assert.IsType<List<Pixel>>(c.Pixels);
    }

}