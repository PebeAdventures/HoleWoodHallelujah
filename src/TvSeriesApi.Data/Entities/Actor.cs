namespace TvSeriesApi.Data.Entities
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public List<TVSeries> TVSeries { get; set; }
    }
}
