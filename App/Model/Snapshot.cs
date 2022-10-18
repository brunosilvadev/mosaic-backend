namespace Mosaic.Model;

public record Snapshot
{
    public Snapshot() {Canvas = new Canvas();}
    public int SnapshotId {get;set;}
    public DateTime TimeStamp {get;set;}
    public Canvas Canvas {get;set;}
}