namespace TvSeriesApi.Services.Interfaces
{
    public interface ISeasonService
    {
        public Task<SeasonReadDTO> GetAllSeasonBySeriesAsync(int id);
        public Task<SeasonReadDTO> GetSeasonByIdFromSeriesAsync(int idSeries, int idSeason);
        public Task<SeasonCreateDTO> AddSeasonAsync(SeasonCreateDTO seasonCreateDTO, int idSeries);
        public Task<SeasonUpdateDTO> EditSeasonAync(SeasonUpdateDTO seasonUpdateDTO, int idSeries);
        public Task<SeasonReadDTO> DeleteSeasonAsync(int id);

    }
}
