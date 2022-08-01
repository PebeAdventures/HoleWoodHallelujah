namespace TvSeriesApi.Data.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<TVSeries> TVSeries { get; set; }
    }
}
