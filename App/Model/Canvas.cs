namespace Mosaic.Model;

public record Canvas
{
    public Canvas() {Pixels = new List<Pixel>();}
    public List<Pixel> Pixels {get;set;}
}