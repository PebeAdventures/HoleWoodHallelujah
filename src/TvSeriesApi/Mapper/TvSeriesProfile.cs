namespace TvSeriesApi
{
    public class TvSeriesProfile : Profile
    {
        public TvSeriesProfile()
        {
            CreateMap<TVSeries, TVSeriesReadDTO>()
               .ForMember(e => e.Genre, opt => opt.MapFrom(e => e.Genre.Name))
            .ForMember(c => c.Cast, opt => opt.MapFrom<ActorIncludesResolver>());
            CreateMap<TVSeries, TVSeriesCreateDTO>();
            CreateMap<TVSeries, TVSeriesUpdateDTO>();
            CreateMap<TVSeriesCreateDTO, TVSeries>();
        }
        public class ActorIncludesResolver : IValueResolver<TVSeries, TVSeriesReadDTO, IEnumerable<string>>
        {
            public IEnumerable<string> Resolve(TVSeries source, TVSeriesReadDTO destination, IEnumerable<string> destMember, ResolutionContext context)
            {
                var actors = new List<string>();
                if (source.Cast != null && source.Cast.Count() > 0)
                    foreach (var actor in source.Cast)
                    {
                        actors.Add(actor.Fullname);
                    }
                return actors.AsEnumerable();
            }
        }
    }

}



