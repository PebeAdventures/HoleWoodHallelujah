namespace TvSeriesApi.DTO.Genres
{
    public class PagedGenreDto
    {
        public IEnumerable<GenreReadDTO> Genres { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}