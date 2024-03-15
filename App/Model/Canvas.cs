namespace Mosaic.Model;

public record Canvas ()
{
    public int CanvasId { get; set; }
    public ICollection<Pixel> Pixels { get; set; } = [];
}