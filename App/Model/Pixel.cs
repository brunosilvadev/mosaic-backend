namespace Mosaic.Model;
public record Pixel
{
    public int x { get; set; }
    public int y { get; set; }
    public string hexColor { get;set; } = default!;
}