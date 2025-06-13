public class ResponseEpisodeDTO
{
    public InfoModel Info { get; set; } = new();
    public List<EpisodeModel> Results { get; set; } = [];
}