using Mosaic.Model;
using Mosaic.Persistence;
using Mosaic.Workers;

public class MosaicEndpoint : IEndpoint
{
    private IBrush _brush;
    private IEye _eye;
    private ICosmosProvider _provider;
    public MosaicEndpoint(IBrush brush, IEye eye, ICosmosProvider provider)
    {
        _brush = brush;
        _eye = eye;
        _provider = provider;
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
        await _provider.PaintPixel(pixel);
    }
    public async Task<List<Pixel>> SelectPixel(string partitionKey)
    {
        return await _provider.SelectPixel(partitionKey);
    }
    public async Task<List<Pixel>> GetPixels()
    {
        return await _provider.SelectPixel(String.Empty);
    }
    public async Task CreateCanvas(int size)
    {
        await _provider.CreateCanvas(size);
    }
    public async Task PaintPixelInCanvas(Pixel pixel)
    {
        await _provider.PaintPixelInCanvas(pixel);
    }
    public async Task<Canvas?> SeeCanvas()
    {
        return await _provider.SeeCanvas();
    }

}