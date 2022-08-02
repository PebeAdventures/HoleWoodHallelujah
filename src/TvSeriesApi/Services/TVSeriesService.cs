namespace TvSeriesApi.Services
{
    public class TVSeriesService : ITVSeriesService
    {
        public Task<TVSeriesReadDTO> AddSeriesAsync(SeriesCreateDTO name)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSeriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditSeriesAsync(int id, TVSeriesUpdateDTO seriesDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TVSeriesReadDTO>> GetAllSeriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TVSeriesReadDTO> GetSeriesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
