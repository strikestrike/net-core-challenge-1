using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FixWithCustomSerialization.Models;

public class MediaFile
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = "";
    
    public string ImageDataB64 { get; set; } = "";

    public string PublicUrl { get; set; } = "";
}


public class MediaFileJsonConverter : JsonConverter<byte[]>
{
    public override byte[] Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        string path = Path.Combine(@"wwwroot", "Uploads");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        byte[] data = reader.GetBytesFromBase64();

        var randomFileName = Guid.NewGuid().ToString().Substring(0, 4) + ".png";
        path = Path.Combine(path, randomFileName);
        File.WriteAllBytes(path, data);

        return data;
    }

    public override void Write(Utf8JsonWriter writer, byte[] wf, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}