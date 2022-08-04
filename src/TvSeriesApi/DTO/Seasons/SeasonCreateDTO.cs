namespace TvSeriesApi.DTO.Seasons
{
    public class SeasonCreateDTO
    {
        [Required]
        public string Name { get; set; }
        public int TVSeriesId { get; set; }
    }
}
