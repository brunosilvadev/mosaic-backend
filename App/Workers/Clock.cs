namespace Mosaic.Workers;

public static class Clock
{
    private static long _start = new DateTime(2000, 1, 1).Ticks;
    public static string tickId()
    {
        var currentDate = DateTime.Now;
        long ticks = currentDate.Ticks - _start;
        return ticks.ToString("x");
    }
}
