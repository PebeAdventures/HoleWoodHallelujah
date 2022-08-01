namespace TvSeriesApi.Data.Entities
{
    public class TVSeries
    {
        public int TVSeriesId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public List<Actor> Cast { get; set; }
        public List<Season> Seasons { get; set; }

    }
}
