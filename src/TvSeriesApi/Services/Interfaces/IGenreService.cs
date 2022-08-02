namespace TvSeriesApi.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreReadDTO>> GetAllGenresAsync();
        Task<GenreReadDTO> GetGenreByIdAsync(int id);
        Task<GenreReadDTO> AddGenreAsync(GenreCreateDTO name);
        Task EditGenreAsync(int id, GenreUpdateDTO genreDTO);
        Task DeleteGenreAsync(int id);
    }
}
