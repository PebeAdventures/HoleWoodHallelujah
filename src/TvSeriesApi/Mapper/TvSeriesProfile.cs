namespace TvSeriesApi
{
    public class TvSeriesProfile : Profile
    {
        public TvSeriesProfile()
        {
            CreateMap<TVSeries, TVSeriesReadDTO>()
                .ForMember(e => e.Genre, opt => opt.MapFrom(e => e.Genre.Name))
            .ForMember(c => c.Cast, opt => opt.MapFrom(c => c.Cast));

            CreateMap<TVSeries, TVSeriesCreateDTO>();
            CreateMap<TVSeries, TVSeriesUpdateDTO>();
        }

        //public class ActorProfile : Profile
        //{
        //    public ActorProfile()
        //    {
        //        CreateMap<Actor, ActorDTO>()
        //            .ForMember(dest => dest.Episodes,
        //            opt => opt.MapFrom<ActorIncludesResolver>());

        //        CreateMap<ActorPostDTO, Actor>();
        //    }
        //}
        //public class ActorIncludesResolver : IValueResolver<Actor, ActorDTO, IEnumerable<string>>
        //{
        //    public IEnumerable<string> Resolve(Actor source, ActorDTO destination, IEnumerable<string> destMember, ResolutionContext context)
        //    {
        //        var episodes = new List<string>();
        //        if (source.Episodes != null && source.Episodes.Count() > 0)
        //            foreach (var episode in source.Episodes)
        //            {
        //                episodes.Add(episode.Name);
        //            }
        //        return episodes.AsEnumerable();
        //    }
        //}
    }

}



