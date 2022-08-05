namespace TvSeriesApi.Controllers
{
    [Authorize]
    [Route("api/TvSeries")]
    [ApiController]
    public class TVSeriesControllers : ControllerBase
    {
        private ITVSeriesService _tvSeriesService;
        private readonly ILogger _logger;
        public TVSeriesControllers(ITVSeriesService tvSeriesService, ILogger logger)
        {
            _tvSeriesService = tvSeriesService;
            _logger = logger;
        }




        //GET api/tvseries
        // [SwaggerOperation(Summary = "Get all TV series")]
        [HttpGet]
        public async Task<IActionResult> GetAllSeriesAsync()
        {
            var operationResult = await _tvSeriesService.GetAllSeriesAsync();
            if (operationResult.Status == OperationStatus.Fail)
            {
                return NotFound(operationResult.ErrorMessage);
            }
            return Ok(operationResult.Value);
        }




        [SwaggerOperation(Summary = "Get TV series by id")]
        [HttpGet("{id}", Name = "GetSeriesByIdAsync")]

        public async Task<IActionResult> GetSeriesByIdAsync(int id)
        {
            var operationResult = await _tvSeriesService.GetSeriesByIdAsync(id);
            if (operationResult.Status == OperationStatus.Fail)
            {
                return NotFound(operationResult.ErrorMessage);
            }

            return Ok(operationResult.Value);

        }
        //POST api/tvseries
        [SwaggerOperation(Summary = "Create TV series by DTO data")]
        [HttpPost]
        /*  public async Task<IActionResult> CreateSeriesAsync(TVSeriesCreateDTO seriesCreateDTO)
          {
              var seriesToCreate = await _tvSeriesService.AddSeriesAsync(seriesCreateDTO);
              return Ok(seriesToCreate);
          }

          //PUT api/tvseries/{id}
          [SwaggerOperation(Summary = "Update TV series by id")]
          [HttpPut("{id}")]
          public async Task<IActionResult> UpdateSeriesById(int id, TVSeriesUpdateDTO seriesUpdateDTO)
          {
              await _tvSeriesService.EditSeriesAsync(id, seriesUpdateDTO);
              return NoContent();
          }
          //DELETE api/tvseries/{id}
          [SwaggerOperation(Summary = "Delete series by id")]
          [HttpDelete("{id}")]*/
        public async Task<IActionResult> DeleteSerieById(int id)
        {
            await _tvSeriesService.DeleteSeriesAsync(id);
            return NoContent();

        }
    }
}
