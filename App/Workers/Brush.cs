using Mosaic.Model;
using Mosaic.Persistence;

namespace Mosaic.Workers;

public class Brush : IBrush
{
    private ITemporaryDbProvider _dbProvider;
    private ICosmosProvider _cosmos;
    public Brush(ITemporaryDbProvider provider, ICosmosProvider cosmos)
    {
        _dbProvider = provider;
        _cosmos = cosmos;
    }    
    public async Task PaintPixel(Pixel pixel)
    {
        if(_cosmos == null)
        {
            throw new Exception("cosmos failed to instantiate");
        }
        _dbProvider.AddPixel(pixel);
    }
}
public interface IBrush
{
    public Task PaintPixel(Pixel pixel);
}