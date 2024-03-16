using System.Text.Json.Serialization;

namespace Mosaic.Model;

public record Canvas ()
{
    [JsonIgnore]
    public int CanvasId { get; set; }
    public ICollection<Pixel> Pixels { get; set; } = [];
}