using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Demo.Api.Host.Controllers
{
    [Route("v1/demo")]
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
