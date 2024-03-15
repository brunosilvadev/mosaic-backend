using Mosaic.Model;

namespace Mosaic.Workers;

public static class Stretcher
{
    public static Canvas BuildBlankCanvas(int size)
    {
        var c = new Canvas();

        var pixelId = 1;

        for(int i = 1; i <= size; i++)
        {
            for(int j = 1; j <= size; j++)
            {
                c.Pixels.Add(new Pixel()
                {
                    PixelId = pixelId,
                    X = i,
                    Y = j,
                    HexColor = "FFFFFF"
                });
            }            
        }

        return c;
    }
}
