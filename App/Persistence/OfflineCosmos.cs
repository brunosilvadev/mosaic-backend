using Microsoft.Azure.Cosmos;
using Mosaic.Model;
namespace Mosaic.Persistence;

public class OfflineCosmos : ICosmosProvider
{
    private readonly List<Pixel> pixels;
    public OfflineCosmos()
    {
        pixels = GeneratePixelData();
    }
    public Task PaintPixelInCanvas(Pixel pixel)
    {
        throw new NotImplementedException();
    }
    public Task<List<Pixel>> SelectPixel(string partitionKey)
    {
        return Task.FromResult(pixels);
    }
    public Task<bool> CheckAuthor(byte[] ipAddress)
    {
        throw new NotImplementedException();
    }
    public Task<ItemResponse<Pixel>> PaintPixel(Pixel pixel)
    {
        throw new NotImplementedException();
    }
    public async Task<ItemResponse<Canvas>> CreateCanvas(int size)
    {
        throw new NotImplementedException();
    }
    public Task<Canvas?> SeeCanvas()
    {
        var c = new Canvas()
        {
            Pixels = GeneratePixelData()
        };
        return Task.FromResult(c);
    }
    private List<Pixel> GeneratePixelData()
    {
        var pixelData = new List<Pixel>();

        var random = new Random();

        for (int x = 1; x <= 16; x++)
        {
            for (int y = 1; y <= 16; y++)
            {
                var pixel = new Pixel
                {
                    X = x,
                    Y = y,
                    HexColor = $"{random.Next(0, 256).ToString("X2")}{random.Next(0, 256).ToString("X2")}{random.Next(0, 256).ToString("X2")}"
                };
                pixelData.Add(pixel);
            }
        }
        return pixelData;
}


}