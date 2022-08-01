namespace TvSeriesApi.Data.Entities
{
    public class Episode
    {
        public int EpisodeId { get; set; }
        public string Name { get; set; }
        public Season Season { get; set; }
    }
}
