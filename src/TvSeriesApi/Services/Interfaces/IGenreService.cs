using TvSeriesApi.Data.Helpers;

using TvSeriesApi.DTO.Genre;

namespace TvSeriesApi.Services.Interfaces
{
    public interface IGenreService
    {
        Task<OperationResult<PagedGenreDto>> GetAllGenresAsync(PageParameters pageParameters);

        Task<OperationResult<GenreReadDTO>> GetGenreByIdAsync(int id);

        Task<OperationResult<GenreReadDTO>> AddGenreAsync(GenreCreateDTO newGenreDto);

        Task<OperationResult> EditGenreAsync(int id, GenreUpdateDTO genreDTO);

        Task<OperationResult> DeleteGenreAsync(int id);
    }
}