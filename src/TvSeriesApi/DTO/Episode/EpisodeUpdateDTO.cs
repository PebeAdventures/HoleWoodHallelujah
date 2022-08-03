using TvSeriesApi.Data.Entities;
namespace TvSeriesApi.DTO.Episode
{
    public class EpisodeUpdateDTO
    {
        public string Name { get; set; }
        public int SeasonId { get; set; }
    }
}
