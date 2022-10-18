using Mosaic.Model;

public class MosaicEndpoint : IEndpoint
{
    public void RegisterRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/see", SeeCanvas);        
    }
    public async Task<Canvas> SeeCanvas()
    {
        return new Canvas();
    }
}