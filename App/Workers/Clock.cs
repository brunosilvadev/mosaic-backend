namespace Mosaic.Workers;

public static class Clock
{
    private static long _start = new DateTime(2000, 1, 1).Ticks;
    public static long currentTick()
    {
        return DateTime.Now.Ticks - _start;
    }
}
