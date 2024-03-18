using System.Text.Json.Serialization;

namespace Mosaic.Model;
public record Pixel ()
{
    [JsonIgnore]
    public int PixelId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public string? HexColor { get; set; }
    
    [JsonIgnore]
    public virtual int CanvasId { get; set; }
    public string Id
    {
        get
        {
            return $"{X};{Y}";
        }
    }
}