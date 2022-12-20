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
    public void AddPixel(Pixel newPixel)
    {
        var existe = _canvas.Pixels.FirstOrDefault(pixel => (pixel.X == newPixel.X && pixel.Y == newPixel.Y) );
        if (existe != null)
        {
            existe.HexColor = newPixel.HexColor;
        }
        else
        {
           _canvas.Pixels.Add(newPixel);
        }
       
    }

}

public interface ITemporaryDbProvider
{
    public Canvas GetCanvas();
    public void AddPixel(Pixel pixel);
}