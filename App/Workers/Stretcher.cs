using Mosaic.Model;

namespace Mosaic.Workers;

public static class Stretcher
{
    public static List<Pixel> BuildBlankCanvas(int size)
    {
        var c = new List<Pixel>();

        var pixelId = 1;

        for(int i = 1; i <= size; i++)
        {
            for(int j = 1; j <= size; j++)
            {
                c.Add(new Pixel()
                {
                    PixelId = pixelId,
                    X = i,
                    Y = j,
                    HexColor = "FFFFFF",
                    CanvasId = 1 ///TODO: make it flexible, multiple Canvas
                });
                pixelId++;
            }            
        }

        return c;
    }
}
