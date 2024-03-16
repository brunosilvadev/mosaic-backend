namespace Mosaic.Model;
public record Pixel ()
{
    public int PixelId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public string? HexColor { get; set; }
    public virtual int CanvasId { get; set; }
    public string Id
    {
        get
        {
            return $"{X};{Y}";
        }
    }
}