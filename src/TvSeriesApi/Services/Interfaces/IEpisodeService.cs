namespace TvSeriesApi.Services.Interfaces
{
    public interface IEpisodeService
    {
        public Task<EpisodeReadDTO> GetAllEpisode_BySeriesAsync(int id);
        public Task<EpisodeReadDTO> GetAllEpisode_BySeries_BySeasonAsync(int id);
        public Task<EpisodeReadDTO> GetEpisodeById_BySeries_BySeasonAsync(int id);

        // TODO zastanowić się czy szukanie odcinków po serialu oraz szukanie po serialu i sezonie powinno być w IEpisode czy odpowiednio w ISeasons oraz ISeries
    }
}
