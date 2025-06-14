using System.Net;
using Microsoft.Extensions.Options;

public class EpisodeService : IEpisodeService
{
    private readonly HttpClient _httpClient;

    public EpisodeService(HttpClient httpClient, IOptions<ConfigurationSettings> options)
    {
        var baseUrl = options.Value.RickAndMortyApi;
        httpClient.BaseAddress = new Uri(baseUrl);
        _httpClient = httpClient;
    }

    public async Task<ResponseEpisodeDTO?> GetAll()
    {
        ResponseEpisodeDTO? data = new();
        HttpResponseMessage response = await _httpClient.GetAsync("episode");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new AppHttpException(404, "No se encontraron datos.");
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var detalle = await response.Content.ReadAsStringAsync();
            throw new AppHttpException(400, $"Solicitud inválida: {detalle}");
        }

        response.EnsureSuccessStatusCode();

        data = await response.Content.ReadFromJsonAsync<ResponseEpisodeDTO>();
        data.StatusCode = (int)response.StatusCode;
        return data;
    }

    public async Task<ResponseEpisodeDTO?> GetEpisodes(int page)
    {
        ResponseEpisodeDTO? data = new();
        HttpResponseMessage response = await _httpClient.GetAsync($"episode?page={page}");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new AppHttpException(404, "El página de episodios no existe.");
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var detalle = await response.Content.ReadAsStringAsync();
            throw new AppHttpException(400, $"Solicitud inválida: {detalle}");
        }

        response.EnsureSuccessStatusCode();

        data = await response.Content.ReadFromJsonAsync<ResponseEpisodeDTO>();
        data.StatusCode = (int)response.StatusCode;
        return data;
    }

    public async Task<ResponseEpisodeDTO?> GetFilteredEpisodes(string? name, string? episode)
    {
        ResponseEpisodeDTO? data = new();
        HttpResponseMessage response = await _httpClient.GetAsync($"episode?name={name}&episode={episode}");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new AppHttpException(404, "El episodio no existe.");
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var detalle = await response.Content.ReadAsStringAsync();
            throw new AppHttpException(400, $"Solicitud inválida: {detalle}");
        }

        response.EnsureSuccessStatusCode();

        data = await response.Content.ReadFromJsonAsync<ResponseEpisodeDTO>();
        data.StatusCode = (int)response.StatusCode;
        return data;
    }
}