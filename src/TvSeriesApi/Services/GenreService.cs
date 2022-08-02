namespace TvSeriesApi.Services
{
    public class GenreService : IGenreService
    {
        public Task<GenreReadDTO> AddGenreAsync(GenreCreateDTO name)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGenreAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditGenreAsync(int id, GenreUpdateDTO genreDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenreReadDTO>> GetAllGenresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenreReadDTO> GetGenreByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
