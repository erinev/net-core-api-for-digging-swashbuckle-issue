using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Host.Controllers
{
    [Route("v1/anotherDemo")]
    [Produces("application/json")]
    public class AnotherDemoController : ControllerBase
    {
        [HttpGet("resource")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult GetResource()
        {
            return Ok("anotherResource");
        }
    }
}
