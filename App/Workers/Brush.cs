using Mosaic.Model;
using Mosaic.Persistence;

namespace Mosaic.Workers;

public class Brush : IBrush
{
    private ITemporaryDbProvider _dbProvider;
    public Brush(ITemporaryDbProvider provider)
    {
        _dbProvider = provider;
    }    
    public async Task PaintPixel(Pixel pixel)
    {
        _dbProvider.AddPixel(pixel);
    }
}
public interface IBrush
{
    public Task PaintPixel(Pixel pixel);
}