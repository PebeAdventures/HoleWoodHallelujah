
using TvSeriesApi.Data.DAL.Interfaces;

namespace TvSeriesApi.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;

        public ActorService(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public Task<ActorReadDTO> AddActorAsync(ActorCreateDTO actorDTO)
        {
            throw new NotImplementedException();
            //var newActor = _mapper.Map<Actor>(actorDTO);

            //// TODO:  srodek
            //return _mapper.Map<ActorReadDTO>(newActor);
        }
        public Task DeleteActorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditActorAsync(int id, ActorUpdateDTO actorDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ActorReadDTO> GetActorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ActorReadDTO>> GetAllActorsAsync()
        {
            var actors = await _actorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ActorReadDTO>>(actors);  
        }
    }
}
