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
    //TODO: Move logic to abstractions (eye, brush etc.)
    public void RegisterRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/see", SeeCanvas);
        app.MapGet("/stretch", CreateCanvas);
        app.MapPost("/paint-canvas", PaintPixelInCanvas);
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
    public async Task<List<Pixel>> SelectPixel(string partitionKey)
    {
        var p = new Mosaic.Persistence.CosmosProvider(_config);
        return await p.SelectPixel(partitionKey);
    }
    public async Task<List<Pixel>> GetPixels()
    {
        var p = new Mosaic.Persistence.CosmosProvider(_config);
        return await p.SelectPixel(String.Empty);
    }
    public async Task CreateCanvas(int size)
    {
        var p = new Mosaic.Persistence.CosmosProvider(_config);
        await p.CreateCanvas(size);
    }
    public async Task PaintPixelInCanvas(Pixel pixel)
    {
        var p = new Mosaic.Persistence.CosmosProvider(_config);
        await p.PaintPixelInCanvas(pixel);
    }
    public async Task<Canvas?> SeeCanvas()
    {
        var p = new Mosaic.Persistence.CosmosProvider(_config);
        return await p.SeeCanvas();
    }

}