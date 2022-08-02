namespace TvSeriesApi.Services.Interfaces
{
    public interface IEpisodeService
    {
        // TODO zastanowić się czy szukanie odcinków po serialu oraz szukanie po serialu i sezonie powinno być w IEpisode czy odpowiednio w ISeasons oraz ISeries
        Task<EpisodeReadDTO> GetEpisodeByIdAsync(int id);
        Task DeleteEpisodeAsync(int id);
        Task CreateEpisode(EpisodeCreateDTO episode);
        Task UpdateEpisode(EpisodeUpdateDTO episode);
    }
}
