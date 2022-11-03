using Xunit;
using Mosaic.Model;
using Mosaic.Workers;
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
    public void StretcherStretches()
    {
        var c = Stretcher.BuildBlankCanvas(10);
        Assert.IsType<Canvas>(c);
    }
    [Fact]
    public void StretcherBuildsCorrectSizeCanvas()
    {
        var c = Stretcher.BuildBlankCanvas(10);
        Assert.Equal(10 * 10, c.Pixels.Count);
    }
    [Fact]
    public void tickIdHasCorrectLength()
    {
        var id = Clock.tickId();
        Assert.True(id.Length > 10 && id.Length < 20);
    }

}