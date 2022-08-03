
using TvSeriesApi.Data;
using TvSeriesApi.Data.DAL.Interfaces;

namespace TvSeriesApi.Services
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActorService(IUnitOfWork actorRepository, IMapper mapper)
        {
            _unitOfWork = actorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActorReadDTO>> GetAllActorsAsync()
        {
            var actors = await _unitOfWork.Actors.GetAllAsync();
            return _mapper.Map<IEnumerable<ActorReadDTO>>(actors);
        }

        public async Task<ActorReadDTO> GetActorByIdAsync(int id)
        {
            var actor = await _unitOfWork.Actors.GetActorByIdAsync(id);
            return _mapper.Map<ActorReadDTO>(actor);
        }

        public async Task<ActorReadDTO> AddActorAsync(ActorCreateDTO actorDTO)
        {
            var newActor = _mapper.Map<Actor>(actorDTO);
            var actor = await _unitOfWork.Actors.AddAsync(newActor);
            return _mapper.Map<ActorReadDTO>(actor);
        }

        public async Task EditActorAsync(int id, ActorUpdateDTO actorDTO)
        {
            var actor = await _unitOfWork.Actors.GetActorByIdAsync(id);
            _mapper.Map(actorDTO, actor);
            await _unitOfWork.Actors.UpdateAsync(actor);
        }

        public async Task DeleteActorAsync(int id)
        {
            var actor = await _unitOfWork.Actors.GetActorByIdAsync(id);
            await _unitOfWork.Actors.DeleteAsync(actor);
        }
    }
}
