using Newtonsoft.Json;

namespace Mosaic.Model;

public record Canvas
{
    public Canvas() {
        Pixels = new List<Pixel>();
        PartitionKey = string.Empty; 
    }
    public Canvas(string id)
    {
        Pixels = new List<Pixel>();
        PartitionKey = id;
    }
    [JsonProperty(PropertyName = "partitionKey")]
    public string PartitionKey { get; set; }    
    public List<Pixel> Pixels {get;set;}

}