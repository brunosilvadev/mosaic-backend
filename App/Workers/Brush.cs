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
    public Task PaintPixel(Pixel pixel)
    {        
        throw new NotImplementedException();
    }
}
public interface IBrush
{
    public Task PaintPixel(Pixel pixel);    
}