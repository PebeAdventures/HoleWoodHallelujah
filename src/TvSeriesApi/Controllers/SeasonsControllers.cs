﻿namespace TvSeriesApi.Controllers
{
    [Authorize]
    [Route("api/seasons")]
    [ApiController]
    public class SeasonsControllers : ControllerBase
    {
        private readonly ISeasonService _seasonService;
        private readonly ILogger<SeasonsControllers> _logger;
        public SeasonsControllers(ISeasonService seasonService, ILogger<SeasonsControllers> logger)
        {
            _seasonService = seasonService;
            _logger = logger;
        }

        //GET api/seasons/
        [SwaggerOperation(Summary = "Get all seasons")]
        [HttpGet]
        public async Task<IActionResult> GetAllSeasonsAsync()
        {
            var operationResult = await _seasonService.GetAllSeasonsAsync();
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + NotFound().StatusCode);
                return NotFound(operationResult.ErrorMessage);
            }

            _logger.LogInformation(operationResult.Status.ToString() + Ok().ToString());
            return Ok(operationResult.Value);
        }

        //GET api/seasons/
        [SwaggerOperation(Summary = "Get season by id")]
        [HttpGet("{seasonId}")]
        public async Task<IActionResult> GetSeasonsByIdAsync(int seasonId)
        {
            var operationResult = await _seasonService.GetSeasonById(seasonId);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + NotFound().StatusCode);
                return NotFound(operationResult.ErrorMessage);
            }

            _logger.LogInformation(operationResult.Status.ToString() + Ok().ToString());
            return Ok(operationResult.Value);
        }

        //GET api/seasons/{id}/episodes
        [SwaggerOperation(Summary = "Get all episodes by season id")]
        [HttpGet("{seasonId}/episodes")]
        public async Task<IActionResult> GetAllEpisodesBySeasonId(int seasonId)
        {
            var operationResult = await _seasonService.GetAllEpisodesBySeasonIdAsync(seasonId);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + NotFound().StatusCode);
                return NotFound(operationResult.ErrorMessage);
            }

            _logger.LogInformation(operationResult.Status.ToString() + Ok().ToString());
            return Ok(operationResult.Value);
        }

        //GET api/seasons/{id}/episodes/{id}
        [SwaggerOperation(Summary = "Get episode by id by season id")]
        [HttpGet("{seasonId}/episodes/{episodeId}")]
        public async Task<IActionResult> GetEpisodesBySeasonIdAsync(int seasonId, int episodeId)
        {
            var operationResult = await _seasonService.GetEpisodeByIdBySeasonIdAsync(seasonId, episodeId);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + NotFound().StatusCode);
                return NotFound(operationResult.ErrorMessage);
            }

            _logger.LogInformation(operationResult.Status.ToString() + Ok().ToString());
            return Ok(operationResult.Value);
        }

        //POST api/seasons
        [SwaggerOperation(Summary = "Add new season")]
        [HttpPost]
        public async Task<IActionResult> AddNewSeason(SeasonCreateDTO seasonCreateDTO)
        {
            await _seasonService.CreateSeason(seasonCreateDTO);

            _logger.LogInformation(" Status " + NoContent().StatusCode);
            return NoContent();
        }

        //PUT api/seasons
        [SwaggerOperation(Summary = "Edit existing season")]
        [HttpPut]
        public async Task<IActionResult> UpdateSeasonAsync(int id, SeasonUpdateDTO seasonUpdateDTO)
        {
            var operationResult = await _seasonService.EditSeasonAync(id, seasonUpdateDTO);
            if (operationResult.Status == OperationStatus.Fail)
            {
                _logger.LogInformation(operationResult.ErrorMessage + " Status " + NotFound().StatusCode);
                return BadRequest(operationResult.ErrorMessage);
            }

            _logger.LogInformation(operationResult.Status.ToString() + "Status" + NoContent().ToString());
            return NoContent();
        }
        [SwaggerOperation(Summary = "Delete existing season")]
        [HttpDelete]
        public async Task<IActionResult> DeleteExistingSeasonAsync(int id)
        {
            await _seasonService.DeleteSeasonAsync(id);
            _logger.LogInformation("Status" + NoContent().ToString());
            return NoContent();
        }
    }
}

