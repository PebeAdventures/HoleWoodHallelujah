namespace TvSeriesApi.Data.Entities
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public IEnumerable<TVSeries> TVSeries { get; set; } = new List<TVSeries>();

        public Actor()
        {
            TVSeries = new List<TVSeries>();
        }
    }
}
