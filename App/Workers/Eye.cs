using Microsoft.EntityFrameworkCore;
using Mosaic.Model;
using Mosaic.Persistence;

namespace Mosaic.Workers;

public class Eye(CanvasDbContext context) : IEye
{
    public async Task<List<Pixel>> SeeCanvas(int canvasId) =>
        await context.Pixels
            .Where(c => c.CanvasId == canvasId)
            .ToListAsync();

}
public interface IEye
{
    public Task<List<Pixel>> SeeCanvas(int canvasId);
}