namespace TvSeriesApi.Services.Interfaces
{
    public interface IEpisodeService
    {
        Task<OperationResult<EpisodeReadDTO>> GetEpisodeByIdAsync(int id);
        Task DeleteEpisodeAsync(int id);
        Task CreateEpisode(EpisodeCreateDTO episode);
        Task<OperationResult> UpdateEpisodeAsync (int episodeId, EpisodeUpdateDTO episode);
        Task<OperationResult<List<EpisodeReadDTO>>> GetAllEpisodesAsync();
    }
}
