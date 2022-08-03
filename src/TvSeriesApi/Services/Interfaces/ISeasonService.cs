namespace TvSeriesApi.Services.Interfaces
{
    public interface ISeasonService
    {
        Task CreateSeason(SeasonCreateDTO seasonCreateDTO);
        Task<OperationResult<IEnumerable<EpisodeReadDTO>>> GetAllEpisodesBySeasonIdAsync(int seasonId);
        Task<OperationResult<EpisodeReadDTO>> GetEpisodeByIdBySeasonIdAsync(int seasonId, int episodeId);
        Task<OperationResult<SeasonUpdateDTO>> EditSeasonAync(int seasonId, SeasonUpdateDTO seasonUpdateDTO);
        Task DeleteSeasonAsync(int id);
    }
}
