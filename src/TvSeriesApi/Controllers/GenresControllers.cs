namespace TvSeriesApi.Controllers
{
    [Route("api/Genre")]
    [ApiController]
    public class GenresControllers : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresControllers(IGenreService genreService)
        {
            _genreService = genreService;
        }

        //GET api/genres
        [SwaggerOperation(Summary = "Get all genres")]
        [HttpGet]
        public async Task<IActionResult> GetAllGenresAsync()
        {
            var operationResult = await _genreService.GetAllGenresAsync();
            if (operationResult.Status == OperationStatus.Fail)
            {
                return NotFound(operationResult.ErrorMessage);
            }
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
                return NotFound(operationResult.ErrorMessage);
            }
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
                return BadRequest(operationResult.ErrorMessage);
            }
            var newGenre = operationResult.Value;
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
                return BadRequest(operationResult.ErrorMessage);
            }
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
                return BadRequest(operationResult.ErrorMessage);
            }
            return NoContent();
        }
    }
}