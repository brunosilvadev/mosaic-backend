using Mosaic.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace Mosaic.Persistence;

public class CosmosProvider
{
    private readonly IConfiguration _config;
    private readonly string _uri;
    private readonly string _key;
    private const string _dbId = "PixelCanvas";
    private const string _containerId = "Items";
    private readonly CosmosClient _client;    
    private readonly Database _db;
    private readonly Container _container;

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
        var pixelList = await SelectPixel(pixel.PartitionKey);
        
        if(pixelList.Count == 0)
            return await _container
                    .CreateItemAsync(pixel, new PartitionKey(pixel.PartitionKey));
        else
            return await _container
                    .UpsertItemAsync(pixel,new PartitionKey(pixel.PartitionKey));
    }

    public async Task PaintPixelInCanvas(Pixel pixel)
    {
        var canvas = _container.GetItemLinqQueryable<Canvas>().FirstOrDefault();
        if (canvas != null)
        {
            var canvasPixel = canvas.Pixels.Where(p => p.X == pixel.X && p.Y == pixel.Y).First();
            if (canvasPixel != null)
            {
                canvasPixel = pixel;
                await _container.UpsertItemAsync(canvas, new PartitionKey(canvas.PartitionKey));
            }
        }        
    }

    public async Task<ItemResponse<Canvas>> CreateCanvas(int size)
    {
        var canvas = Workers.Stretcher.BuildBlankCanvas(size);
        return await _container.CreateItemAsync(canvas, new PartitionKey(canvas.PartitionKey));       
    }

    public async Task<List<Pixel>> SelectPixel(string partitionKey)
    {
        var returnList = new List<Pixel>();
        var iterator = _container.GetItemLinqQueryable<Pixel>()
                        .Where(p =>
                            p.PartitionKey == (string.IsNullOrEmpty(partitionKey) ?
                                         p.PartitionKey
                                         : partitionKey)
                                        )
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
}
