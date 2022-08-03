namespace TvSeriesApi.Controllers
{
    [Route("api/seasons")]
    [ApiController]
    public class SeasonsControllers
    {
        private readonly ISeasonService _seasonService;
        public SeasonsControllers(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }
        //GET api/seasons/{id} 
        [SwaggerOperation(Summary = "Get seasons by id")]
        [HttpGet]
        public async Task<IActionResult> GetAllSeriesByIdAsync()
        {
            var series = await _seasonService.
            return Ok(series);
        }

    }
}
