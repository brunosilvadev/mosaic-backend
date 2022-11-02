using Mosaic.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

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
        var pixelList = await this.SelectPixel(pixel.partitionKey);
        
        if(pixelList.Count == 0)
            return await _container
                    .CreateItemAsync<Pixel>(pixel, new PartitionKey(pixel.partitionKey));
        else
            return await _container
                    .UpsertItemAsync<Pixel>(pixel,new PartitionKey(pixel.partitionKey));
    }

    public async Task<List<Pixel>> SelectPixel(string partitionKey)
    {
        var returnList = new List<Pixel>();
        var iterator = _container.GetItemLinqQueryable<Pixel>()
                        .Where(p => p.partitionKey == partitionKey)
                        .ToFeedIterator();
        while (iterator.HasMoreResults)
        {
            FeedResponse<Pixel> response = await iterator.ReadNextAsync();
            foreach (var item in response)
            {
                returnList.Add(item);
            }
        }
        return returnList;
    }
    public bool ConfigsWereRead()
    {
        return (_uri != null && _key != null);
    }
}
