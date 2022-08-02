namespace TvSeriesApi.Data.Entities
{
    public class Season
    {
        public int SeasonId { get; set; }
        public string Name { get; set; }
        public TVSeries TVSeries { get; set; }
        public IEnumerable<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
