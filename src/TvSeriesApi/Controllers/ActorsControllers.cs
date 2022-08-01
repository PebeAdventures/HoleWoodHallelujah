
using Microsoft.AspNetCore.Mvc;

namespace TvSeriesApi.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsControllers : ControllerBase
    {
        public ActorsControllers()
        {

        }
        //GET api/actors
        [HttpGet]
        public IActionResult<IEnumerable<>>
        [HttpPut]
        [HttpPost]
        [HttpDelete]
    }
}
