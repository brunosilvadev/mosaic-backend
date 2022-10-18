namespace Mosaic.Model;
public record Pixel
{
    public int X { get; set; }
    public int Y { get; set; }
    public string HexColor { get; set; } = default!;
}