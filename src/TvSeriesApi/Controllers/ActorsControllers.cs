namespace TvSeriesApi.Controllers
{
    [Authorize]
    [EnableCors("corsapp")]
    [Route("api/Actors")]
    [ApiController]
    public class ActorsControllers : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly ILogger<ActorsControllers> _logger;
        public ActorsControllers(IActorService actorService, ILogger<ActorsControllers> logger)
        {
            _actorService = actorService;
            _logger = logger;
        }

        [SwaggerOperation(Summary = "Get all actors")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var actors = await _actorService.GetAllActorsAsync();
            if (actors == null)
            {
                _logger.LogInformation(NotFound().StatusCode.ToString());
                return NotFound();
            }

            _logger.LogInformation(Ok().StatusCode.ToString());
            return Ok(actors);
        }


        [SwaggerOperation(Summary = "Retrieves specific Artist by id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var actor = await _actorService.GetActorByIdAsync(id);
            if (actor is not null)
            {
                _logger.LogInformation(Ok().StatusCode.ToString());
                return Ok(actor);
            }

            _logger.LogInformation(NotFound().StatusCode.ToString());
            return NotFound();
        }


        [SwaggerOperation(Summary = "Create new Actor")]
        [HttpPost]
        public async Task<IActionResult> AddAsync(ActorCreateDTO actorDTO)
        {
            var newActor = await _actorService.AddActorAsync(actorDTO);
            _logger.LogInformation(CreatedAtRoute(nameof(GetAllAsync), new { id = newActor.ActorId }, newActor).ToString());
            return CreatedAtRoute(nameof(GetAllAsync), new { id = newActor.ActorId }, newActor);
        }

        [SwaggerOperation(Summary = "Edit specific Actor")]
        [HttpPost("{id}")]
        public async Task<IActionResult> EditAsync(int id, ActorUpdateDTO actorDTO)
        {
            await _actorService.EditActorAsync(id, actorDTO);
            _logger.LogInformation(NoContent().StatusCode.ToString());
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete specific Actor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _actorService.DeleteActorAsync(id);
            _logger.LogInformation(NoContent().StatusCode.ToString());
            return NoContent();
        }

        [SwaggerOperation(Summary = "Get specific Actor with TvSeries")]
        [HttpGet("{id}/TvSeries")]
        public async Task<IActionResult> GetActorWithTvSeriesByIdAsync(int id)
        {
            var actor = await _actorService.GetActorWithTvSeries(id);
            if (actor is not null)
            {
                _logger.LogInformation(Ok().StatusCode.ToString());
                return Ok(actor);
            }

            _logger.LogInformation(NotFound().StatusCode.ToString());
            return NotFound();
        }
    }
}
