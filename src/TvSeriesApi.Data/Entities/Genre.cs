namespace TvSeriesApi.Data.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public IEnumerable<TVSeries> TVSeries { get; set; } = new List<TVSeries>();
    }
}
