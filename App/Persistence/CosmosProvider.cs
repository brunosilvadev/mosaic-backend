using Mosaic.Model;
using Microsoft.Azure.Cosmos;

namespace Mosaic.Persistence;

public class CosmosProvider
{
    private IConfiguration _config;
    private readonly string _uri;
    private readonly string _key;
    private const string _dbId = "PixelCanvas";
    private const string _containerId = "Items";
    private readonly CosmosClient _client;    
    private readonly Database _db;
    private Container _container;

    public CosmosProvider(IConfiguration config)
    {
        _config = config;
        _uri = _config.GetValue<string>("EndpointUri");
        _key = _config.GetValue<string>("PrimaryKey");

        _client = new CosmosClient(_uri, _key, new CosmosClientOptions() { ApplicationName = "CollabCanvas" });
        _db = _client.CreateDatabaseIfNotExistsAsync(_dbId).Result;
        _container = _db.CreateContainerIfNotExistsAsync(_containerId, "/partitionKey").Result;
    }

    public async Task<ItemResponse<Pixel>> PaintPixel(Pixel pixel)
    {
        return await _container.CreateItemAsync<Pixel>(pixel, new PartitionKey(pixel.partitionKey));
    }
    public bool ConfigsWereRead()
    {
        return (_uri != null && _key != null);
    }
}
