using Mosaic.Model;
using Mosaic.Persistence;

public class MosaicEndpoint : IEndpoint
{
    private ITemporaryDbProvider _dbProvider;
    public MosaicEndpoint(ITemporaryDbProvider provider)
    {
        _dbProvider = provider;
    }
    public void RegisterRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/see", SeeCanvas);
        app.MapPost("/paint", PaintPixel);
    }
    public void PaintPixel(Pixel pixel)
    {
       _dbProvider.AddPixel(pixel);
    }
    public Canvas SeeCanvas()
    {
        return _dbProvider.GetCanvas();
    }

}