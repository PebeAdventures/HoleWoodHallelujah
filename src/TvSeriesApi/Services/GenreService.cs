using TvSeriesApi.Data.Helpers;

namespace TvSeriesApi.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<PagedGenreDto>> GetAllGenresAsync(PageParameters pageParameters)
        {
            var genres = _unitOfWork.Genres.GetGenresPaginated(pageParameters);
            var pagedGenres = await PagedList<Genre>.ToPagedListAsync(genres, pageParameters.PageNumber, pageParameters.PageSize);
            if (pagedGenres == null || pagedGenres.Count == 0)
            {
                return OperationResult<PagedGenreDto>.Fail("There are no Genres");
            }
            var gen = _mapper.Map<PagedGenreDto>(pagedGenres);
            return OperationResult<PagedGenreDto>.Success(gen);
        }

        public async Task<OperationResult<GenreReadDTO>> GetGenreByIdAsync(int id)
        {
            var genre = await _unitOfWork.Genres.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return OperationResult<GenreReadDTO>.Fail("There is no Genre with provided Id");
            }
            return OperationResult<GenreReadDTO>.Success(_mapper.Map<GenreReadDTO>(genre));
        }

        public async Task<OperationResult<GenreReadDTO>> AddGenreAsync(GenreCreateDTO newGenreDto)
        {
            if (string.IsNullOrEmpty(newGenreDto.Name))
            {
                return OperationResult<GenreReadDTO>.Fail("Name can not be empty");
            }
            var newGenre = _mapper.Map<Genre>(newGenreDto);
            var insertedGenre = await _unitOfWork.Genres.AddAsync(newGenre);
            return OperationResult<GenreReadDTO>.Success(_mapper.Map<GenreReadDTO>(insertedGenre));
        }

        public async Task<OperationResult> EditGenreAsync(int id, GenreUpdateDTO genreDTO)
        {
            var genre = await _unitOfWork.Genres.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return OperationResult.Fail("There is no Genre with provided Id");
            }
            if (string.IsNullOrEmpty(genreDTO.Name))
            {
                return OperationResult<GenreReadDTO>.Fail("Name of updated genre can not be empty");
            }
            var editedGenre = _mapper.Map(genreDTO, genre);
            await _unitOfWork.Genres.UpdateAsync(editedGenre);
            return OperationResult.Success();
        }

        public async Task<OperationResult> DeleteGenreAsync(int id)
        {
            var genre = await _unitOfWork.Genres.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return OperationResult.Fail("There is no Genre with provided Id");
            }
            await _unitOfWork.Genres.DeleteAsync(genre);
            return OperationResult.Success();
        }
    }
}