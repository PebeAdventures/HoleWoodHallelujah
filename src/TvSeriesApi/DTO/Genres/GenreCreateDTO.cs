using System.ComponentModel.DataAnnotations;

namespace TvSeriesApi.DTO.Genre
{
    public class GenreCreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}