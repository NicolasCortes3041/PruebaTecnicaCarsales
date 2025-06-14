public class ResponseEpisodeDTO : HttpExternalServicesResponse
{
    public InfoModel Info { get; set; } = new();
    public List<EpisodeModel> Results { get; set; } = [];
}