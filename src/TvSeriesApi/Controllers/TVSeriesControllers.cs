namespace TvSeriesApi.Controllers
{
    public class TVSeriesControllers : ControllerBase
    {
        private readonly ITVSeriesService _tvSeriesService;
        public TVSeriesControllers()
        {

        }
        //GET api/tvseries
        [SwaggerOperation(Summary = "Get all TV series")]
        [HttpGet]
        public async Task<IActionResult> GetAllSeriesAsync()
        {
            var series = await _genreService.GetAllSeriesAsync();
            return Ok(series);
        }
        //GET api/tvseries/{id}
        [SwaggerOperation(Summary = "Get TV series by id")]
        [HttpGet("{id}", Name = "GetSeriesByIdAsync")]
        public async Task<IActionResult> GetSeriesByIdAsync(int id)
        {
            var series = await _seriesService.GetSeriesByIdAsync(id);
            return Ok(series);
        }
        //POST api/tvseries
        [SwaggerOperation(Summary = "Create TV series by DTO data")]
        [HttpPost]
        public async Task<IActionResult> CreateSeriesAsync(TVSeriesCreateDTO seriesCreateDTO)
        {
            var seriesToCreate = await _seriesService.AddSeriesAsync(seriesCreateDTO);
            return Ok(seriesToCreate);
        }
        //POST api/tvseries
        [SwaggerOperation(Summary = "Create TV series by name")]
        [HttpPost]
        public async Task<IActionResult> CreateSeriesByNameAsync(string seriesNameToAdd)
        {
            var seriesToUpdate = await _seriesService.AddSeriesByNameAsync(seriesToAdd);
            return Ok(seriesToUpdate);
        }
        //PUT api/tvseries/{id}
        [SwaggerOperation(Summary = "Update TV series by id")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenreById(int id, SeriesUpdateDTO seriesUpdateDTO)
        {
            await _seriesService.EditSeriesAsync(id, seriesUpdateDTO);
            return NoContent();
        }
        //DELETE api/tvseries/{id}
        [SwaggerOperation(Summary = "Delete series by id")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerieById(int id)
        {
            await _seriesService.DeleteSeriesAsync(id);
            return NoContent();

        }
    }
}
