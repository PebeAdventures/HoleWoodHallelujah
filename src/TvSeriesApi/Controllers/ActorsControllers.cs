namespace TvSeriesApi.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsControllers : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsControllers()
        {

        }

        //GET api/actors
        [SwaggerOperation(Summary = "Get all actors")]
        [HttpGet]
        public async Task<IActionResult> GetAllActorsAsync()
        {
            var actors = await _actorService.GetAllActorsAsync();
            return Ok(actors);
        }

        //GET api/actors/{id}
        [SwaggerOperation(Summary = "Get actor by id")]
        [HttpGet("{id}", Name = "GetActorByIdAsync")]
        public async Task<IActionResult> GetActorByIdAsync(int id)
        {
            var actor = await _actorService.GetActorByIdAsync(id);
            return Ok(actor);
        }

        //GET api/actors/{name}
        [SwaggerOperation(Summary = "Get actor by name")]
        [HttpGet("{name}", Name = "GetActorByName")]
        public async Task<IActionResult> GetActorByName(string name)
        {
            var actor = await _actorService.GetActorByName(name);
            return Ok(actor);
        }

        //POST api/actors
        [SwaggerOperation(Summary = "Create actor by DTO data")]
        [HttpPost]
        public async Task<IActionResult> CreateActorAsync(ActorCreateDTO actorCreateDTO)
        {
            var actorToCreate = await _actorService.AddActorAsync(actorCreateDTO);
            return Ok(actorToCreate);
        }

        //POST api/actors
        [SwaggerOperation(Summary = "Create actor by name")]
        [HttpPost]
        public async Task<IActionResult> CreateActorByNameAsync(string actorToAdd)
        {
            var actorToUpdate = await _actorService.AddActorByNameAsync(actorToAdd);
            return Ok(actorToUpdate);
        }

        //PUT api/actors/{id}
        [SwaggerOperation(Summary = "Update actor by id")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActorById(int id, ActorUpdateDTO actorUpdateDTO)
        {
            await _actorService.EditActorAsync(id, actorUpdateDTO);
            return NoContent();
        }

        //DELETE api/actors/{id}
        [SwaggerOperation(Summary = "Delete actor by id")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActorById(int id)
        {
            await _actorService.DeleteActorAsync(id);
            return NoContent();

        }
    }
}
