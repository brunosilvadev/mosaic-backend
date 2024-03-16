using Microsoft.EntityFrameworkCore;
using Mosaic.Model;
using Mosaic.Persistence;

namespace Mosaic.Workers;

public class Eye(CanvasDbContext context) : IEye
{
    public async Task<Canvas> SeeCanvas(int canvasId) =>
        new Canvas()
        {
            CanvasId = 1,
            Pixels = await context.Pixels
            .Where(c => c.CanvasId == canvasId)
            .ToListAsync()
        };

}
public interface IEye
{
    public Task<Canvas> SeeCanvas(int canvasId);
}