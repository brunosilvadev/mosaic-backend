using Mosaic.Model;
using Mosaic.Persistence;

namespace Mosaic.Workers;

public class Eye : IEye
{
    private ITemporaryDbProvider _provider;
    public Eye(ITemporaryDbProvider provider)
    {
        _provider  = provider;
    }
    public Canvas SeeCanvas()
    {
        return _provider.GetCanvas();
    }
}
public interface IEye
{
    public Canvas SeeCanvas();
}