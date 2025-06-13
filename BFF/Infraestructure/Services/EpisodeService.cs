public class EpisodeService : IEpisodeService
{
    private readonly HttpClient _httpClient;

    public EpisodeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseEpisodeDTO?> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<ResponseEpisodeDTO>("episode");
    }

    public async Task<ResponseEpisodeDTO?> GetEpisodes(int page)
    {
        return await _httpClient.GetFromJsonAsync<ResponseEpisodeDTO>($"episode?page={page}");
    }

    public async Task<ResponseEpisodeDTO?> GetFilteredEpisodes(string? name, string? episode)
    {
        return await _httpClient.GetFromJsonAsync<ResponseEpisodeDTO>($"episode?name={name}&episode={episode}");
    }
}