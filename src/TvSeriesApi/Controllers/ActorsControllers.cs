namespace TvSeriesApi.Controllers
{
    [Route("api/Actors")]
    [ApiController]
    public class ActorsControllers : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsControllers(IActorService actorService)
        {
            _actorService = actorService;
        }

        [SwaggerOperation(Summary = "Get all actors")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var actors = await _actorService.GetAllActorsAsync();
            if (actors == null)
            {
                return NotFound();
            }
            return Ok(actors);
        }


        [SwaggerOperation(Summary = "Retrieves specific Artist")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var actor = await _actorService.GetActorByIdAsync(id);
            if (actor is not null)
            {
                return Ok(actor);
            }
            return NotFound();
        }


        [SwaggerOperation(Summary = "Create new Actor")]
        [HttpPost]
        public async Task<IActionResult> AddAsync(ActorCreateDTO actorDTO)
        {
            var newActor = await _actorService.AddActorAsync(actorDTO);
            return CreatedAtRoute(nameof(GetAllAsync), new { id = newActor.ActorId }, newActor);
        }

        [SwaggerOperation(Summary = "Edit specific Actor")]
        [HttpPost("{id}")]
        public async Task<IActionResult> EditAsync(int id, ActorUpdateDTO actorDTO)
        {
            await _actorService.EditActorAsync(id, actorDTO);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete specific Actor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _actorService.DeleteActorAsync(id);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Get specific Actor with TvSeries")]
        [HttpGet("{id}/TvSeries")]
        public async Task<IActionResult> GetActorWithTvSeriesByIdAsync(int id)
        {
            var actor = await _actorService.GetActorWithTvSeries(id);
            if (actor is not null) return Ok(actor);
            return NotFound();
        }
    }
}
