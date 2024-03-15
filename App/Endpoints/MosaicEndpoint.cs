using Mosaic.Model;
using Mosaic.Workers;

namespace Mosaic.API;
public class MosaicEndpoint() : IEndpoint
{   
    //TODO: Move logic to abstractions (eye, brush etc.)
    public void RegisterRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/paint", PaintPixel);
        app.MapGet("/see", SeeCanvas);
    }
    public async Task PaintPixel(Pixel pixel, IBrush brush) =>
        ///TODO: add more canvases
       await brush.PaintPixel(pixel, 1);

    public async Task<Canvas?> SeeCanvas(IEye eye) =>
        ///TODO: add more canvases
        await eye.SeeCanvas(1);

}