using FixWithCustomSerialization.Models;
using FixWithCustomSerialization.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FixWithCustomSerialization.Controllers;

[ApiController]
[Route("[controller]")]
public class MediaController : ControllerBase
{
    private readonly IDbService _db;
    private readonly ILogger<MediaController> _logger;

    public MediaController(ILogger<MediaController> logger, IDbService db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet]
    public async Task<List<MediaFile>> GetMedia() =>
        await _db.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<MediaFile>> GetMedia(string id)
    {
        var media = await _db.GetAsync(id);

        if (media is null)
        {
            return NotFound();
        }

        return media;
    }

    [HttpPost]
    public async Task<IActionResult> Post(MediaFile newMedia)
    {
        await _db.CreateAsync(newMedia);

        return CreatedAtAction(nameof(GetMedia), new { id = newMedia.Name }, newMedia);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> UpdateMedia(string name, MediaFile updatedMedia)
    {
        var media = await _db.GetAsync(name);

        if (media is null)
        {
            return NotFound();
        }

        updatedMedia.Name = media.Name;

        await _db.UpdateAsync(name, updatedMedia);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string name)
    {
        var media = await _db.GetAsync(name);

        if (media is null)
        {
            return NotFound();
        }

        await _db.RemoveAsync(name);

        return NoContent();
    }

}



