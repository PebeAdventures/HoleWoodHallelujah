namespace TvSeriesApi.Controllers
{
    [Route("api/seasons")]
    [ApiController]
    public class SeasonsControllers : ControllerBase
    {
        private readonly ISeasonService _seasonService;
        public SeasonsControllers(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        //GET api/seasons/{id}
        [SwaggerOperation(Summary = "Get seasons by id")]
        [HttpGet]
        public async Task<IActionResult> GetAllSeasonsByIdAsync(int seasonId)
        {
            var operationResult = await _seasonService.GetSeasonById(seasonId);
            if (operationResult.Status == OperationStatus.Fail)
            {
                return NotFound(operationResult.ErrorMessage);
            }
            return Ok(operationResult.Value);
        }
    }
}

