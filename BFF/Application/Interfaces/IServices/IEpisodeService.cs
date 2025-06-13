public interface IEpisodeService
{
    Task<ResponseEpisodeDTO?> GetAll();
    Task<ResponseEpisodeDTO?> GetEpisodes(int page);
    Task<ResponseEpisodeDTO?> GetFilteredEpisodes(string? name, string? episode);
}