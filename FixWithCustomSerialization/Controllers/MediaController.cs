using Microsoft.AspNetCore.Mvc;

namespace FixWithCustomSerialization.Controllers;

[ApiController]
[Route("[controller]")]
public class MediaController : ControllerBase
{
    private readonly ILogger<MediaController> _logger;

    public MediaController(ILogger<MediaController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public MediaFile UpdateMedia([FromBody] MediaFile media)
    {
        throw new NotImplementedException();

        /* todo: Implement the method
         * 
         * 1. media will be contained in the ImageDataB64 prop. It should have been already saved to the webroots folder by the "read" method of MediaFileJsonConverter
         * 2. Save the media object in Mongo db
         * 3. return the MediaFile object
         * 4. We expect the "write" method of MediaFileJsonConverter to create the public URL
         * 
         * */
    }

    [HttpGet("{Name}")]
    public MediaFile GetMedia(string Name)
    {
        throw new NotImplementedException();

        /*
         * return _mongoDb.getcollection<MediaFile>.Find(m=>m.Name==Name).SingleAsync();
         * 
         * 1. We expect the "write" method of MediaFileJsonConverter to create the public URL
         * 
         */
    }
}

/// <summary>
/// todo: implement MediaFileJsonConverter  
/// [JsonConverter(typeof(MediaFileJsonConverter))]
/// </summary>
public class MediaFile
{
    /// <summary>
    /// todo: We want media name to be Unique, Please enforce using MongoDb Unique Index
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// todo: donot Save in database
    /// </summary>
    public string ImageDataB64 { get; set; } = "";

    /// <summary>
    /// todo: donot Save in database, Generate dynamically using 
    /// </summary>
    public string PublicUrl { get; set; } = "";


}



