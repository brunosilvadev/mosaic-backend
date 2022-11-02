using Mosaic.Model;
using Mosaic.Workers;

public class MosaicEndpoint : IEndpoint
{
    private IBrush _brush;
    private IEye _eye;
    private IConfiguration _config;
    public MosaicEndpoint(IBrush brush, IEye eye, IConfiguration config)
    {
        _brush = brush;
        _eye = eye;
        _config = config;
    }
    public void RegisterRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/see", SeeCanvas);
        app.MapPost("/paint", PaintPixel);
        app.MapPost("/cosmopaint", CosmoPaint);
        app.MapGet("/select", SeePixel);
    }
    public void PaintPixel(Pixel pixel)
    {
       _brush.PaintPixel(pixel);
    }
    public async Task CosmoPaint(Pixel pixel)
    {
        var p = new Mosaic.Persistence.CosmosProvider(_config);
        await p.PaintPixel(pixel);
    }
    public async Task<List<Pixel>> SeePixel(string k)
    {
        var p = new Mosaic.Persistence.CosmosProvider(_config);
        return await p.SelectPixel(k);
    }
    public Canvas SeeCanvas()
    {
        return _eye.SeeCanvas();
    }

}