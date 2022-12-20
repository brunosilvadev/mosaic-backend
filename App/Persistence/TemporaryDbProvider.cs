using Mosaic.Model;

namespace Mosaic.Persistence;

public class TemporaryDbProvider : ITemporaryDbProvider
{
    private Canvas _canvas;

    public TemporaryDbProvider()
    {
        _canvas = new Canvas();
    }
    public Canvas GetCanvas()
    {
        return _canvas;
    }
    public void AddPixel(Pixel pixel)
    {
        var existe = _canvas.Pixels.FirstOrDefault(x => (x.X == pixel.X && x.Y ==pixel.Y) );
        if (existe != null)
        {
            existe.HexColor = pixel.HexColor;
        }
        else
        {
           _canvas.Pixels.Add(pixel);
        }
       
    }

}

public interface ITemporaryDbProvider
{
    public Canvas GetCanvas();
    public void AddPixel(Pixel pixel);
}