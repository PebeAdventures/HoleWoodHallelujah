namespace TvSeriesApi.Controllers
{
    public class GenresControllers : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresControllers()
        {

        }
        //GET api/genres
        [SwaggerOperation(Summary = "Get all genres")]
        [HttpGet]
        public async Task<IActionResult> GetAllGenresAsync()
        {
            var genres = await _genreService.GetAllActorsAsync();
            return Ok(genres);
        }
        //GET api/genres/{id}
        [SwaggerOperation(Summary = "Get genre by id")]
        [HttpGet("{id}", Name = "GetGenreByIdAsync")]
        public async Task<IActionResult> GetGenreByIdAsync(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            return Ok(genre);
        }
        //POST api/genres
        [SwaggerOperation(Summary = "Create genre by DTO data")]
        [HttpPost]
        public async Task<IActionResult> CreateGenreAsync(GenreCreateDTO genreCreateDTO)
        {
            var genreToCreate = await _genreService.AddGenreAsync(genreCreateDTO);
            return Ok(genreToCreate);
        }
        //POST api/genre
        [SwaggerOperation(Summary = "Create genre by name")]
        [HttpPost]
        public async Task<IActionResult> CreateActorByNameAsync(string genreToAdd)
        {
            var genreToUpdate = await _genreService.AddActorByNameAsync(genreToAdd);
            return Ok(genreToUpdate);
        }
        //PUT api/genres/{id}
        [SwaggerOperation(Summary = "Update genre by id")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenreById(int id, GenreUpdateDTO genreUpdateDTO)
        {
            await _genreservice.EditGenreAsync(id, genreUpdateDTO);
            return NoContent();
        }
        //DELETE api/genres/{id}
        [SwaggerOperation(Summary = "Delete genre by id")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreById(int id)
        {
            await _genreService.DeleteGenreAsync(id);
            return NoContent();

        }
    }
}
