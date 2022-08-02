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
        public async Task<IActionResult> GetEpisodeAsync(int id)
        {
            var episode = await _episodeService.GetEpisodeByIdAsync(id);
            if (episode == null)
            {
                return NotFound();
            }

            return Ok(episode);
        }

        [HttpDelete]
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
        public async Task<IActionResult> UpdateEpisodeAsync(EpisodeUpdateDTO episode)
        {
            await _episodeService.UpdateEpisodeAsync(episode);
            return Created("", episode);
        }
    }
}
