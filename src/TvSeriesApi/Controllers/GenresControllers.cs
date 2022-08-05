namespace TvSeriesApi.Controllers
{
    [Authorize]
    [EnableCors("corsapp")]
    [Route("api/Genre")]
    [ApiController]
    public class GenresControllers : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly ILogger<GenresControllers> _logger;
        public GenresControllers(IGenreService genreService, ILogger<GenresControllers> logger)
        {
            _genreService = genreService;
            _logger = logger;
        }

        //GET api/genres
        [EnableCors]
        [SwaggerOperation(Summary = "Get all genres")]
        [HttpGet]
        public async Task<IActionResult> GetAllGenresAsync([FromQuery] PageParameters pageParameters)
        {
            var operationResult = await _genreService.GetAllGenresAsync(pageParameters);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + NotFound().StatusCode);
                return NotFound(operationResult.ErrorMessage);
            }

            _logger.LogInformation(operationResult.Status.ToString() + Ok().ToString());
            return Ok(operationResult.Value);
        }

        //GET api/genres/{id}
        [SwaggerOperation(Summary = "Get genre by id")]
        [HttpGet("{id}", Name = "GetGenreByIdAsync")]
        public async Task<IActionResult> GetGenreByIdAsync(int id)
        {
            var operationResult = await _genreService.GetGenreByIdAsync(id);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + NotFound().StatusCode);
                return NotFound(operationResult.ErrorMessage);
            }
            _logger.LogInformation(operationResult.Status.ToString() + Ok().ToString());
            return Ok(operationResult.Value);
        }

        //POST api/genres
        [SwaggerOperation(Summary = "Create genre by DTO data")]
        [HttpPost]
        public async Task<IActionResult> CreateGenreAsync(GenreCreateDTO genreCreateDTO)
        {
            var operationResult = await _genreService.AddGenreAsync(genreCreateDTO);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + BadRequest().StatusCode);
                return BadRequest(operationResult.ErrorMessage);
            }
            var newGenre = operationResult.Value;

            _logger.LogInformation(operationResult.Status.ToString() + " Status " + Created($"api/songs/{newGenre.GenreId}", newGenre));
            return Created($"api/songs/{newGenre.GenreId}", newGenre);
        }

        //PUT api/genres/{id}
        [SwaggerOperation(Summary = "Update genre by id")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenreById(int id, GenreUpdateDTO genreUpdateDTO)
        {
            var operationResult = await _genreService.EditGenreAsync(id, genreUpdateDTO);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + BadRequest().StatusCode);
                return BadRequest(operationResult.ErrorMessage);
            }

            _logger.LogInformation(operationResult.Status.ToString() + NoContent().ToString());
            return NoContent();
        }

        //DELETE api/genres/{id}
        [SwaggerOperation(Summary = "Delete genre by id")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreById(int id)
        {
            var operationResult = await _genreService.DeleteGenreAsync(id);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + BadRequest().StatusCode);
                return BadRequest(operationResult.ErrorMessage);
            }
            _logger.LogInformation(operationResult.Status.ToString() + NoContent().ToString());
            return NoContent();
        }
    }
}