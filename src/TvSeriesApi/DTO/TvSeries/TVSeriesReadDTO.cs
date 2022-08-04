namespace TvSeriesApi.DTO.TvSeries
{
    public class TVSeriesReadDTO
    {

        public string Name { get; set; }
        public int Year { get; set; }

        public string Genre { get; set; }

        public List<string> Cast { get; set; }


    }
}
