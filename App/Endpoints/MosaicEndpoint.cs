using Microsoft.EntityFrameworkCore;
using Mosaic.Model;
using Mosaic.Persistence;
using Mosaic.Workers;

namespace Mosaic.API;
public class MosaicEndpoint() : IEndpoint
{   
    //TODO: Move logic to abstractions (eye, brush etc.)
    public void RegisterRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/paint-canvas", PaintPixel);
        app.MapGet("/see", SeeCanvas);
        app.MapGet("/stretch", Stretch);
        app.MapGet("/destroy", Destroy);
    }
    public async Task PaintPixel(Pixel pixel, IBrush brush) =>
        ///TODO: add more canvases
       await brush.PaintPixel(pixel, 1);

    public async Task<Canvas> SeeCanvas(IEye eye) =>
        ///TODO: add more canvases
        await eye.SeeCanvas(1);

    public async Task Stretch(CanvasDbContext context)
    {        
        var canvas = new Canvas() { CanvasId = 1 };
        context.Canvas.Add(canvas);
        context.Pixels.AddRange(Stretcher.BuildBlankCanvas(16));
        await context.SaveChangesAsync();
    }

    public async Task Destroy(CanvasDbContext context)
    {
        var canvas = await context.Canvas.ToListAsync();
        context.Canvas.RemoveRange(canvas);
        await context.SaveChangesAsync();
    }

}