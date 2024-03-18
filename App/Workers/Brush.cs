using Mosaic.Model;
using Mosaic.Persistence;

namespace Mosaic.Workers;

public class Brush(CanvasDbContext context) : IBrush
{
    public async Task<bool> PaintPixel(Pixel pixel, int canvasId)
    {
        var pixelToUpdate = context.Pixels
            .Where(p  => p.CanvasId  == canvasId && p.X == pixel.X && p.Y == pixel.Y )
            .FirstOrDefault();

        if(pixelToUpdate is null)
            return false;

        pixelToUpdate.HexColor = pixel.HexColor;
        await context.SaveChangesAsync();

        return true;        
    }
}
public interface IBrush
{
    public Task<bool> PaintPixel(Pixel pixel, int canvasId);    
}