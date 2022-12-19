using FixWithCustomSerialization.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FixWithCustomSerialization.Services;

public class IDbService
{
    private readonly IMongoCollection<MediaFile> _mediaCollection;

    public IDbService(
        IOptions<MediaStoreDatabaseSettings> mediaStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            mediaStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mediaStoreDatabaseSettings.Value.DatabaseName);

        _mediaCollection = mongoDatabase.GetCollection<MediaFile>(
            mediaStoreDatabaseSettings.Value.MediaCollectionName);
    }

    public async Task<List<MediaFile>> GetAsync() =>
        await _mediaCollection.Find(_ => true).ToListAsync();

    public async Task<MediaFile?> GetAsync(string id) =>
        await _mediaCollection.Find(x => x.Name == id).FirstOrDefaultAsync();

    public async Task CreateAsync(MediaFile newMedia) =>
        await _mediaCollection.InsertOneAsync(newMedia);

    public async Task UpdateAsync(string id, MediaFile updatedMedia) =>
        await _mediaCollection.ReplaceOneAsync(x => x.Name == id, updatedMedia);

    public async Task RemoveAsync(string id) =>
        await _mediaCollection.DeleteOneAsync(x => x.Name == id);
}