namespace Mosaic.Model;

public record Canvas
{
    public Canvas() {Pixels = new List<Pixel>();}
    public IEnumerable<Pixel> Pixels {get;set;}
}