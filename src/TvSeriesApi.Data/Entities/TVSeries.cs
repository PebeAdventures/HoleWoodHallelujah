namespace TvSeriesApi.Data.Entities
{
    public class TVSeries
    {
        public int TVSeriesId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public IEnumerable<Actor> Cast { get; set; } = new List<Actor>();
        public IEnumerable<Season> Seasons { get; set; } = new List<Season>();
    }
}
