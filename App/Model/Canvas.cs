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
    public List<Pixel> Pixels {get;set;}
    [JsonProperty(PropertyName = "partitionKey")]
    public string PartitionKey { get; set; }
    [JsonProperty(PropertyName = "id")]
    public string Id {
        get
        {
            return PartitionKey;
        }
    }
}