using Mosaic.Model;
using Mosaic.Workers;

public class MosaicEndpoint : IEndpoint
{
    private IBrush _brush;
    private IEye _eye;
    public MosaicEndpoint(IBrush brush, IEye eye)
    {
        _brush = brush;
        _eye = eye;
    }
    public void RegisterRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/see", SeeCanvas);
        app.MapPost("/paint", PaintPixel);
    }
    public void PaintPixel(Pixel pixel)
    {
       _brush.PaintPixel(pixel);
    }
    public Canvas SeeCanvas()
    {
        return _eye.SeeCanvas();
    }

}