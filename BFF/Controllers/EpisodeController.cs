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
        try
        {
            var result = await _episodeService.GetAll();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return ErrorHandler.Handle(ex);
        }
    }

    [HttpGet("page")]
    public async Task<IActionResult> Get([FromQuery] int page = 1)
    {
        try
        {
            var result = await _episodeService.GetEpisodes(page);

            if (result == null) return NotFound(new { message = "pagina no encontrada" });

            return Ok(result);
        }
        catch (Exception ex)
        {
            return ErrorHandler.Handle(ex);
        }
    }

    [HttpGet("filter")]
    public async Task<IActionResult> Get([FromQuery] string name, string? episode)
    {
        try
        {
            var result = await _episodeService.GetFilteredEpisodes(name, episode);

            if (result == null) return NotFound(new { message = "No se ha encontrado el episodio" });

            return Ok(result);
        }
        catch (Exception ex)
        {
            return ErrorHandler.Handle(ex);
        }
    }
}