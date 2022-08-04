namespace TvSeriesApi.Services.Interfaces
{
    public interface ISeasonService
    {
        Task<OperationResult>CreateSeason(SeasonCreateDTO seasonCreateDTO);
        Task<OperationResult<List<EpisodeReadDTO>>> GetAllEpisodesBySeasonIdAsync(int seasonId);
        Task<OperationResult<EpisodeReadDTO>> GetEpisodeByIdBySeasonIdAsync(int seasonId, int episodeId);
        Task<OperationResult> EditSeasonAync(int seasonId, SeasonUpdateDTO seasonUpdateDTO);
        Task<OperationResult>DeleteSeasonAsync(int id);
        Task<OperationResult<SeasonReadDTO>> GetSeasonById(int id);
        Task<OperationResult<List<SeasonReadDTO>>> GetAllSeasonsAsync();
    }
}
