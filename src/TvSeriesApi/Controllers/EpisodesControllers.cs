namespace TvSeriesApi.Controllers
{
    [Route("api/Episodes")]
    [ApiController]
    public class EpisodesControllers : ControllerBase
    {
        private IEpisodeService _episodeService;

        public EpisodesControllers(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEpisodesAsync()
        {
            var operationResult = await _episodeService.GetAllEpisodesAsync();
            if (operationResult.Status == OperationStatus.Fail)
            {
                return NotFound(operationResult.ErrorMessage);
            }

            return Ok(operationResult.Value);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEpisodeAsync(int id)
        {
            var operationResult = await _episodeService.GetEpisodeByIdAsync(id);
            if (operationResult.Status == OperationStatus.Fail)
            {
                return NotFound(operationResult.ErrorMessage);               
            }

            return Ok(operationResult.Value);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEpisodeAsync(int id)
        {
            await _episodeService.DeleteEpisodeAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEpisodeAsync(EpisodeCreateDTO episode)
        {
            await _episodeService.CreateEpisode(episode);
            return Created("", episode);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEpisodeAsync(int episodeId, EpisodeUpdateDTO episode)
        {
            var operationResult = await _episodeService.UpdateEpisodeAsync(episodeId, episode);

            if (operationResult.Status == OperationStatus.Fail)
            {
                return BadRequest(operationResult.ErrorMessage);
            }

            return NoContent();
        }
    }
}
