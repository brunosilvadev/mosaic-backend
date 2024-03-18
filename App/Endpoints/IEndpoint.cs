namespace Mosaic.API;
public interface IEndpoint
{
    void RegisterRoutes(IEndpointRouteBuilder app);
}