using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EpisodeController : ControllerBase
{
    private readonly IEpisodeService _episodeService;

    public EpisodeController(IEpisodeService episodeService)
    {
        _episodeService = episodeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _episodeService.GetAll();
        return Ok(result);
    }

    [HttpGet("page")]
    public async Task<IActionResult> Get([FromQuery] int page = 1)
    {
        var result = await _episodeService.GetEpisodes(page);
        return Ok(result);
    }
    
    [HttpGet("filter")]
    public async Task<IActionResult> Get([FromQuery] string name, string? episode)
    {
        var result = await _episodeService.GetFilteredEpisodes(name, episode);
        return Ok(result);
    }
}