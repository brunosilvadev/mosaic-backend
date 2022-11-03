using Newtonsoft.Json;

namespace Mosaic.Model;
public record Pixel
{
    [JsonProperty(PropertyName = "id")]
    public string Id {
        get
        {
            return X.ToString() + ";" + Y.ToString();
        }
    }
    [JsonProperty(PropertyName = "partitionKey")]
    public string PartitionKey{
        get
        {
            string fmt = "00000000.##";
            return X.ToString(fmt) + Y.ToString(fmt);
        }
    }
    public int X { get; set; }
    public int Y { get; set; }
    public string HexColor { get; set; } = default!;
}