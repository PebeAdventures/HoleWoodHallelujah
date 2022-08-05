namespace TvSeriesApi.Controllers
{
    //[Authorize]
    [Route("api/Episodes")]
    [ApiController]
    public class EpisodesControllers : ControllerBase
    {
        private IEpisodeService _episodeService;
        private readonly ILogger<EpisodesControllers> _logger;

        public EpisodesControllers(IEpisodeService episodeService, ILogger<EpisodesControllers> logger)
        {
            _episodeService = episodeService;
            _logger = logger;
        }

        [SwaggerOperation(Summary = "Get all episodes")]
        [HttpGet]
        public async Task<IActionResult> GetEpisodesAsync()
        {
            var operationResult = await _episodeService.GetAllEpisodesAsync();
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + NotFound().StatusCode);
                return NotFound(operationResult.ErrorMessage);
            }

            _logger.LogInformation(operationResult.Status.ToString() + Ok().ToString());
            return Ok(operationResult.Value);
        }

        [SwaggerOperation(Summary = "Get episode by id")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEpisodeAsync(int id)
        {
            var operationResult = await _episodeService.GetEpisodeByIdAsync(id);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + NotFound().StatusCode);
                return NotFound(operationResult.ErrorMessage);
            }

            _logger.LogInformation(operationResult.Status.ToString());
            return Ok(operationResult.Value);
        }

        [SwaggerOperation(Summary = "Delete episode")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEpisodeAsync(int id)
        {
            var operationResult = await _episodeService.DeleteEpisodeAsync(id);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + BadRequest().StatusCode);
                return BadRequest(operationResult.ErrorMessage);
            }

            _logger.LogInformation(operationResult.Status.ToString());
            return NoContent();
        }

        [SwaggerOperation(Summary = "Create episode")]
        [HttpPost]
        public async Task<IActionResult> CreateEpisodeAsync(EpisodeCreateDTO episodeDTO)
        {
            var operationResult = await _episodeService.CreateEpisode(episodeDTO);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + BadRequest().StatusCode);
                return BadRequest(operationResult.ErrorMessage);
            }
            var newEpisode = operationResult.Value;

            _logger.LogInformation(operationResult.Status.ToString() + " Status " + Created($"api/songs/{newEpisode.EpisodeId}", newEpisode));
            return Created($"api/songs/{newEpisode.EpisodeId}", newEpisode);
        }

        [SwaggerOperation(Summary = "Update episode")]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEpisodeAsync(int id, EpisodeUpdateDTO episode)
        {
            var operationResult = await _episodeService.UpdateEpisodeAsync(id, episode);

            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + BadRequest().StatusCode);
                return BadRequest(operationResult.ErrorMessage);
            }

            _logger.LogInformation(operationResult.Status.ToString());
            return NoContent();
        }
    }
}
