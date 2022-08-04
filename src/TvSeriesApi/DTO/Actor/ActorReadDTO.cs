

namespace TvSeriesApi.DTO.Actor
{
    public class ActorReadDTO
    {
        public int ActorId { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public List<string> TVSeries { get; set; }
    }
}
