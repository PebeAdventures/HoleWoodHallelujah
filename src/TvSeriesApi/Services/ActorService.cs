

namespace TvSeriesApi.Services
{
    public class ActorService : IActorService
    {
        public Task<ActorReadDTO> AddActorAsync(ActorCreateDTO name)
        {
            throw new NotImplementedException();
        }

        public Task<ActorReadDTO> AddActorByNameAsync(string name)
        {
            throw new NotImplementedException();
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

        public Task<IEnumerable<ActorReadDTO>> GetAllActorsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
