using Microsoft.EntityFrameworkCore;
using Mosaic.Model;
using Mosaic.Persistence;

namespace Mosaic.Workers;

public class Eye(CanvasDbContext context) : IEye
{
    public async Task<Canvas?> SeeCanvas(int canvasId) =>
        await context.Canvas
            .Where(c => c.CanvasId == canvasId)
            .FirstOrDefaultAsync();

}
public interface IEye
{
    public Task<Canvas?> SeeCanvas(int canvasId);
}