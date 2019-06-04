using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Host.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/demo")]
    [Produces("application/json")]
    public class DemoController : ControllerBase
    {
        [HttpGet("resource")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult GetResource()
        {
            return Ok("resource");
        }
    }
}
