namespace TvSeriesApi.Data.Entities
{
    public class Season
    {
        public int SeasonId { get; set; }
        public string Name { get; set; }
        public List<TVSeries> TVSeries { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
