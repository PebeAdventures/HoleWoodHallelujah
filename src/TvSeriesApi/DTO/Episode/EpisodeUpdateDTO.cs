using System.ComponentModel.DataAnnotations;
using TvSeriesApi.Data.Entities;
namespace TvSeriesApi.DTO.Episode
{
    public class EpisodeUpdateDTO
    {
        [Required]
        [DataType("string")] 
        public string Name { get; set; }
        [Required]
        [DataType("int")]
        public int SeasonId { get; set; }
    }
}
