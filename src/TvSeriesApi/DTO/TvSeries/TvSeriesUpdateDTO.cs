namespace TvSeriesApi.DTO.TvSeries
{
    public class TVSeriesUpdateDTO
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public string Genre { get; set; }

        public IEnumerable<string> Cast { get; set; }
    }
}
