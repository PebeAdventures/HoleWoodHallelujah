namespace TvSeriesApi.Services.Interfaces
{
    public interface IEpisodeService
    {
        Task<OperationResult<EpisodeReadDTO>> GetEpisodeByIdAsync(int id);

        Task<OperationResult> DeleteEpisodeAsync(int id);
        Task<OperationResult<EpisodeReadDTO>> CreateEpisode(EpisodeCreateDTO episode);
        Task<OperationResult> UpdateEpisodeAsync (int episodeId, EpisodeUpdateDTO episode);
        Task<OperationResult<List<EpisodeReadDTO>>> GetAllEpisodesAsync();
    }
}