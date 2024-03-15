namespace Mosaic.Model;
public record Pixel (int PixelId, int X, int Y)
{
    public string? HexColor { get; set; }
    public virtual Canvas? Canvas { get; set; }
    public virtual int CanvasId { get; set; }
}