namespace TvSeriesApi.Profiles
{
    public class TvSeriesProfile : Profile
    {
        public TvSeriesProfile()
        {
            CreateMap<TVSeries, TVSeriesReadDTO>();
            /*            CreateMap<TVSeriesCreateDTO, TVSeries>();
                        CreateMap<TVSeriesUpdateDTO, TVSeries>();*/
        }
    }
}
