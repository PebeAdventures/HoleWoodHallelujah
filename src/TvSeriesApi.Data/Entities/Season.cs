namespace TvSeriesApi.Data.Entities
{
    public class Season
    {
        public int SeasonId { get; set; }
        public string Name { get; set; }
        public TVSeries TVSeries { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
