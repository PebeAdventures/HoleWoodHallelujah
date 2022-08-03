namespace TvSeriesApi.Services.Interfaces
{
    public interface ISeasonService
    {
        Task<IEnumerable<EpisodeReadDTO>> GetAllEpisodesBySeasonIdAsync(int seasonId);
        Task<EpisodeReadDTO> GetEpisodeByIdBySeasonIdAsync(int seasonId);
        Task<SeasonCreateDTO> AddSeasonAsync(SeasonCreateDTO seasonCreateDTO);
        Task<SeasonUpdateDTO> EditSeasonAync(SeasonUpdateDTO seasonUpdateDTO);
        Task<SeasonReadDTO> DeleteSeasonAsync(int id);
    }
}
