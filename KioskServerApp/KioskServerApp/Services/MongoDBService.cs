using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

public class MongoDBService
{
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _database;

    public MongoDBService(IConfiguration config)
    {
        string? connectionString = config.GetConnectionString("MongoDbConnection");
        _client = new MongoClient(connectionString);
        _database = _client.GetDatabase("kiosk");
    }

    public IMongoCollection<Category> GetCategoryCollection()
    {
        return _database.GetCollection<Category>("category");
    }
}
