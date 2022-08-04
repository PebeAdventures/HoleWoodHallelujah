using System.ComponentModel.DataAnnotations;

namespace TvSeriesApi.DTO.Episode
{
    public class EpisodeCreateDTO
    {
        [Required]
        [DataType("string")]
        public string Name { get; set; }
        [Required]
        [DataType("int")]
        public int SeasonId { get; set; }
    }
}
