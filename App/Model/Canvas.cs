namespace Mosaic.Model;

public record Canvas (int CanvasId, ICollection<Pixel> Pixels) {}